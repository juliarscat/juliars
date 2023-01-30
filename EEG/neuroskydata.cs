
             //#sample code in C# to retrieve data from the NeuroSky Mobile 2
using System;
using System.IO.Ports;

namespace NeuroSkyMobile2 {
    class Program {
        static void Main(string[] args) {
            // Create a serial port object and set its properties
            SerialPort neuroSkyMobile2 = new SerialPort();
            neuroSkyMobile2.BaudRate = 115200;
            neuroSkyMobile2.DataBits = 8;
            neuroSkyMobile2.Parity = Parity.None;
            neuroSkyMobile2.StopBits = StopBits.One;
            neuroSkyMobile2.Handshake = Handshake.None;

            // Open the serial port and begin reading data
            neuroSkyMobile2.Open();
            neuroSkyMobile2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            // Cast the sender object as a SerialPort object
            SerialPort neuroSkyMobile2 = (SerialPort)sender;

            // Read the data from the serial port
            string data = neuroSkyMobile2.ReadExisting();

            // Process the data as needed
            // ...
        }
    }
}
