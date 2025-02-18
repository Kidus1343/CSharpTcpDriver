using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class TcpServer
{
    private static ConcurrentDictionary<int, TcpClient> Clients = new ConcurrentDictionary<int, TcpClient>();
    private static int clientCounter = 0;
    private static readonly string certPath = "Certificates/server.pfx";
    private static readonly string certPassword = "password";  // Change this in production!

    public static void StartServer(int port)
    {
        try
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Logger.Log("Server started on port " + port);

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                clientCounter++;
                int clientId = clientCounter;

                Clients[clientId] = client;
                Logger.Log($"Client {clientId} connected.");

                Task.Run(() => HandleClient(client, clientId));
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Server Error: {ex.Message}");
        }
    }

    private static void HandleClient(TcpClient client, int clientId)
    {
        try
        {
            using (var sslStream = new SslStream(client.GetStream(), false))
            {
                var serverCertificate = new X509Certificate2(certPath, certPassword);
                sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls12, true);

                StreamReader reader = new StreamReader(sslStream, Encoding.UTF8);
                StreamWriter writer = new StreamWriter(sslStream, Encoding.UTF8) { AutoFlush = true };

                while (true)
                {
                    string request = reader.ReadLine();
                    if (string.IsNullOrEmpty(request)) break;

                    Logger.Log($"Received from Client {clientId}: {request}");
                    string response = HandleCommand(request);
                    writer.WriteLine(response);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Client {clientId} Error: {ex.Message}");
        }
        finally
        {
            Clients.TryRemove(clientId, out _);
            client.Close();
            Logger.Log($"Client {clientId} disconnected.");
        }
    }

    private static string HandleCommand(string command)
    {
        return command switch
        {
            "GET_TEMP" => $"Temperature: {SensorData.GetTemperature()}°C",
            "GET_HUMIDITY" => $"Humidity: {SensorData.GetHumidity()}%",
            "GET_STATUS" => $"Status: {SensorData.GetStatus()}",
            _ => "Unknown Command"
        };
    }
}
