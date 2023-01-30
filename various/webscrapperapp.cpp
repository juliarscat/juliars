//Sample code to create a web scraper and export data as a csv
using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using CsvHelper;

namespace WebScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnScrape_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            string data = GetWebsiteData(url);

            // Extract the required data from the website using a web scraper
            // (you can write your own logic to extract the required data)
            string extractedData = ExtractData(data);

            // Export the extracted data to a CSV file
            ExportToCSV(extractedData);

            MessageBox.Show("Data exported to CSV file successfully!");
        }

        private string GetWebsiteData(string url)
        {
            WebClient client = new WebClient();
            string data = client.DownloadString(url);

            return data;
        }

        private string ExtractData(string data)
        {
            // Write your own logic to extract the required data from the website
            // For example:
            // string extractedData = data.Substring(data.IndexOf("<body>"), data.IndexOf("</body>") - data.IndexOf("<body>"));

            return extractedData;
        }

        private void ExportToCSV(string data)
        {
            using (var writer = new StreamWriter("data.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
        }
    }
}
