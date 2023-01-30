// Mouse mover app that moves the moves randomly for X minutes, perfect for teleworking controlled workers

using System;
using System.Windows.Forms;
using System.Timers;

namespace MouseMover
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(MoveMouse);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int minutes = Convert.ToInt32(minutesTextBox.Text);
            timer.Interval = minutes * 60 * 1000;
            timer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void MoveMouse(object sender, ElapsedEventArgs e)
        {
            Cursor.Position = new System.Drawing.Point(random.Next(0, Screen.PrimaryScreen.Bounds.Width), random.Next(0, Screen.PrimaryScreen.Bounds.Height));
        }
    }
}
