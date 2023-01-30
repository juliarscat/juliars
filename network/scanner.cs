
using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace PortScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            string host = hostTextBox.Text;
            int startPort = Convert.ToInt32(startPortTextBox.Text);
            int endPort = Convert.ToInt32(endPortTextBox.Text);
            resultLabel.Text = "";
            string report = "Port,Status\n";

            for (int port = startPort; port <= endPort; port++)
            {
                using (TcpClient client = new TcpClient())
                {
                    try
                    {
                        client.Connect(host, port);
                        resultLabel.Text += "Port " + port + ": Open\n";
                        report += port + ",Open\n";
                    }
                    catch (Exception)
                    {
                        resultLabel.Text += "Port " + port + ": Closed\n";
                        report += port + ",Closed\n";
                    }
                }
            }

            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, report);
            }
        }
    }
}
