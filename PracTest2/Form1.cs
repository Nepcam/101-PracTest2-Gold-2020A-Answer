using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracTest2
{
    public partial class Form1 : Form
    {
        //Name: Cameron Nepe
        //ID:

        //Width of a bar of gold or silver
        const int BAR_WIDTH = 50;
        //Height of a bar of gold or silver
        const int BAR_HEIGHT = 25;
        //The number of rows of bars to draw
        const int NUM_ROWS = 10;
        //The gap between rows and columns
        const int GAP = 10;
        //The colour for a gold bar
        Color GOLD_BAR_COLOR = Color.Gold;
        //The colour for a silver bar
        Color SILVER_BAR_COLOR = Color.Silver;
        //Row start
        const int ROW_STARTX = 0;

        //Minimum number of rows
        const int MIN_ROWS = 2;
        //Maximum number of rows
        const int MAX_ROWS = 12;

        //Silver bars
        const int SILVER_BARS = 5;


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears the picture box and textbox and sets focus to the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
            textBoxUserInput.Clear();
            textBoxUserInput.Focus();
        }

        private void buttonDrawBars_Click(object sender, EventArgs e)
        {
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            Pen Pen1 = new Pen(Color.Black, 1);
            SolidBrush brGold = new SolidBrush(Color.Gold);
            SolidBrush brSilver = new SolidBrush(Color.Silver);
            int x = 0;
            int y = 0;
            int numBars = 0;
            int gapSize = GAP;

            try
            {
                //GET how many columns of bars
                numBars = int.Parse(textBoxUserInput.Text);
                //CHECK if the number of rows is valid
                if (numBars >= MIN_ROWS && numBars <= MAX_ROWS)
                {
                    for (int line = 1; line <= numBars; line++)
                    {                     
                        for (int i = 0; i <= numBars; i++)
                        {
                            //Check the row count to set the color
                            if (i <= SILVER_BARS)
                            {
                                paper.FillRectangle(brSilver, x, y, BAR_WIDTH, BAR_HEIGHT);
                            }
                            else
                            {
                                paper.FillRectangle(brGold, x, y, BAR_WIDTH, BAR_HEIGHT);
                            }
                            //DRAW bar at current x and y position
                            paper.DrawRectangle(Pen1, x, y, BAR_WIDTH, BAR_HEIGHT);
                            //paper.FillRectangle(brGold, x, y, BAR_WIDTH, BAR_HEIGHT);
                            //SHIFT x to the right by the width of bar + gap
                            x += BAR_WIDTH + gapSize;
                        }
                        //SHIFT y down by the height of the bar + gap
                        y += BAR_HEIGHT + gapSize;
                        //SHIFT 
                        x = ROW_STARTX;
                    }
                   
                }
                else
                {
                    //Display an error message and clear and give the focus
                    MessageBox.Show("Please enter a value between 2 and 12 inclusive");
                    textBoxUserInput.Clear();
                    textBoxUserInput.Focus();
                }
            }
            catch (Exception ex)
            {
                //Display an error message and clear and give the focus
                MessageBox.Show(ex.Message);
                textBoxUserInput.Clear();
                textBoxUserInput.Focus();
            }
        }
    }
}
