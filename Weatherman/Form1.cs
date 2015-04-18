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

        public void WriteMessage(string message)
        {
            _text = message;

            // Main dialogue timer
            _timerIndex = 0; // This ensures that the method will restart writing the content

            if (TextTimer.Enabled || Dialogue.Text.Contains(_text))
            {
                TextTimer.Enabled = false;
            }
            else
            {
                TextTimer.Enabled = true;
            }

            Dialogue.Text = "";
        }

        /// <summary>
        /// These variables are used to determine what to write using the 'typewriter' method
        /// </summary>

        private int _timerIndex = 0;
        private string _text;

        /// <summary>
        /// Nothing out of the ordinary;
        /// after a 100 ticks this will write out a new letter form the string which contains the message to show.
        /// This generates a "typewriter" effect
        /// When the method has iterated through all the letters in the string it will remove the underscore (cursor)
        /// and place it on the line under.
        /// </summary>

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            Dialogue.Text = _text.Substring(0, _timerIndex) + "_";  //Substring is a part of Type_Text String that we declared at the start
            _timerIndex++;  //Doing a post fix
            if (_timerIndex == _text.Length + 1)
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
            // Welcoming message
            WriteMessage("Welcome to Weatherman API");

            UserInput.Focus();
            HideCaret(UserInput.Handle);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
