using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class TcpClientApp
{
    private static readonly string certPath = "Certificates/client.pfx";
    private static readonly string certPassword = "password";  

    public static void Main()
    {
        try
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 5000))
            using (var sslStream = new SslStream(client.GetStream(), false, 
                new RemoteCertificateValidationCallback((a, b, c, d) => true)))
            {
                var clientCertificate = new X509Certificate2(certPath, certPassword);
                sslStream.AuthenticateAsClient("localhost", new X509CertificateCollection { clientCertificate }, SslProtocols.Tls12, false);

                StreamReader reader = new StreamReader(sslStream, Encoding.UTF8);
                StreamWriter writer = new StreamWriter(sslStream, Encoding.UTF8) { AutoFlush = true };

                Console.WriteLine("Enter commands: GET_TEMP, GET_HUMIDITY, GET_STATUS");

                while (true)
                {
                    string command = Console.ReadLine();
                    writer.WriteLine(command);
                    string response = reader.ReadLine();
                    Console.WriteLine("Response: " + response);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Client Error: " + ex.Message);
        }
    }
}
