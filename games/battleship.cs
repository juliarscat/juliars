# Battleship sample code

using System;
using System.Windows.Forms;

namespace Battleship_Game
{
    public partial class Form1 : Form
    {
        int[,] board = new int[10, 10];
        int attempts = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set all values in board to 0
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = 0;
                }
            }

            // place ships on board
            PlaceShips();
        }

        private void PlaceShips()
        {
            // place 5 ships on board
            int ships = 5;
            Random rnd = new Random();

            while (ships > 0)
            {
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);

                if (board[x, y] == 0)
                {
                    board[x, y] = 1;
                    ships--;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            // increment attempts
            attempts++;

            // get button coordinates
            int x = int.Parse(((Button)sender).Name.Substring(6, 1));
            int y = int.Parse(((Button)sender).Name.Substring(7, 1));

            // check if there is a ship
            if (board[x, y] == 1)
            {
                ((Button)sender).BackColor = System.Drawing.Color.Red;
                ((Button)sender).Enabled = false;
                board[x, y] = 2;
            }
            else
            {
                ((Button)sender).BackColor = System.Drawing.Color.White;
                ((Button)sender).Enabled = false;
            }

            // check if all ships have been hit
            int shipsLeft = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == 1)
                    {
                        shipsLeft++;
                    }
                }
            }

            if (shipsLeft == 0)
            {
                MessageBox.Show("You win! Total attempts: " + attempts);
                Close();
            }
        }
    }
}
