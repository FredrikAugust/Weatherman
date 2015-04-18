using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weatherman
{
    public partial class Weatherman : Form
    {
        public Weatherman()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Include splash screen perhaps?
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserInput_Enter(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Enabled = true;
        }

        /// <summary>
        /// These variables are used to determine what to write using the 'typewriter' method
        /// </summary>

        private static int _timerIndex = 0;
        private static string _WelcomeText = "Welcome to Weatherman API";

        /// <summary>
        /// Nothing out of the ordinary;
        /// after a 100 ticks this will write out a new letter form the string which contains the message to show.
        /// This generates a "typewriter" effect
        /// When the method has iterated through all the letters in the string it will remove the underscore (cursor)
        /// and place it on the line under.
        /// </summary>

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            Dialogue.Text = _WelcomeText.Substring(0, _timerIndex) + "_";  //Substring is a part of Type_Text String that we declared at the start
            _timerIndex++;  //Doing a post fix
            if (_timerIndex == _WelcomeText.Length + 1)
            {
                TextTimer.Enabled = false;
                Dialogue.Text = Dialogue.Text.Replace("_", "\n_");

            }
        }

        /// <summary>
        /// This first initiates the timer which controls the tyepwriter effect of the main game dialogue.
        /// After that it starts the timer which creates a cursor in the input area.
        /// </summary>

        private void button1_Click(object sender, EventArgs e)  // Power button
        {
            // Main dialogue timer
            _timerIndex = 0; // This ensures that the method will restart writing the content

            if (TextTimer.Enabled || Dialogue.Text.Contains(_WelcomeText))
            {
                TextTimer.Enabled = false;  
            }
            else
            {
                TextTimer.Enabled = true;
            }

            Dialogue.Text = "";

            // Input timer
            CursorTimer.Enabled = true;
            UserInput.Focus();
            HideCaret(UserInput.Handle);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (UserInput.Text.Length >= 1 && Convert.ToString(UserInput.Text[0]) != "_")
            {
                UserInput.Text = UserInput.Text.Replace("_", "");
                CursorTimer.Enabled = false;
            }
            else
            {
                CursorTimer.Enabled = true;
            }
        }

        private bool IsCursor = false;

        /// <summary>
        /// This contains the logic to make the cursor blink in the input field
        /// </summary>

        private void CursorTimer_Tick(object sender, EventArgs e)
        {
            if (!IsCursor)
            {
                UserInput.Text += "_";
                IsCursor = true;
            }
            else
            {
                try
                {
                    UserInput.Text = UserInput.Text.Remove(UserInput.Text.Length - 1);
                    IsCursor = false;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    IsCursor = false;
                    Console.WriteLine(ex.Message); // Debugging
                }
            }
        }
    }
}
