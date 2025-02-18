using System;
using System.Net.Sockets;
using System.Windows;

namespace TcpMonitor
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        private void RefreshData(object sender, RoutedEventArgs e)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 5000))
            using (StreamWriter writer = new StreamWriter(client.GetStream()))
            using (StreamReader reader = new StreamReader(client.GetStream()))
            {
                writer.WriteLine("GET_TEMP");
                string response = reader.ReadLine();
                TempText.Text = response;
            }
        }
    }
}
