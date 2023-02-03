// Generates X barcodes then stores them in an Access database

using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Get number of barcodes to generate
            int numBarcodes = Convert.ToInt32(txtNumBarcodes.Text);

            // Connect to Access database
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\barcodes.mdb");
            conn.Open();

            // Loop through and generate barcodes
            for (int i = 0; i < numBarcodes; i++)
            {
                // Generate unique barcode
                string barcode = Guid.NewGuid().ToString();

                // Insert barcode into Access database
                OleDbCommand cmd = new OleDbCommand("INSERT INTO barcodes (barcode) VALUES (@barcode)", conn);
                cmd.Parameters.AddWithValue("@barcode", barcode);
                cmd.ExecuteNonQuery();
            }

            // Close connection to Access database
            conn.Close();

            // Show message indicating barcodes have been generated and stored
            MessageBox.Show("Barcodes generated and stored in database!");
        }
    }
}
