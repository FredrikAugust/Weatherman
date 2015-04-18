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

        private Parts[] PartsArray = new Parts[20];

        private void Form1_Load(object sender, EventArgs e)
        {
            // Include splash screen perhaps?

            // Add all the parts to the partsarray
            PartsArray[0] = new WelcomeClass() 
            {
                message = "Welcome to Weatherman!\nYou can always type your \ncommands, even when \nWeatherman is speaking. \nDon't hesitate to interupt.\n\nType anything to start"
            };

            PartsArray[1] = new WelcomeResponseClass()
            {
                message = "This is so disorienting."
            };
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

        private int level;

        /// <summary>
        /// This first initiates the timer which controls the tyepwriter effect of the main game dialogue.
        /// After that it starts the timer which creates a cursor in the input area.
        /// </summary>

        private void button1_Click(object sender, EventArgs e)  // Power button
        {
            level = 0;
            errorLevel = 0;

            // Just to start off the program
            WriteMessage(PartsArray[0].message);

            UserInput.Focus();
            HideCaret(UserInput.Handle);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private int errorLevel = 0;
        ErrorHandling ErrHandler = new ErrorHandling();

        /// <summary>
        /// This actually handles close to all the logic when it comes to level management.
        /// First of all, it will only do something if the enter key is pressed;
        /// this saves me from a lot of resource handling etc.
        /// Secondly it stores the result from checking if the user input is a valid answer to the initial question.
        /// This is stored in a tuple, as this is the easiest for validation and printing a message.
        /// After that it checks if the answer was valid, and if it was it will set the ContinueMethod to 
        /// CorrectAnswer, this will allow me to tailor the next dialogue to his/her answer.
        /// After that it increases the level variable so I can move on, and then it prints the 'valid result'.
        /// 
        /// The error handling here is a bit klunky, but it works. It kind of works as a second parser, and I might merge them later, but this will do for now.
        /// First it gets the parser result and checks if this passed;
        /// if it did it will do the same as above. (once again some horrible code, but it works)
        /// If not it will print the message saying you failed once again, and it will increase the error counter, which is again used to tailor the output.
        /// </summary>

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextTimer.Enabled = false;

                Tuple<bool, string> ParseResult = PartsArray[level].parser(UserInput.Text);

                if (ParseResult.Item1)  // Did it pass the initial test?
                {
                    PartsArray[level].cm = ContinueMethod.CorrectAnswer;
                    level += 1;
                    WriteMessage(ParseResult.Item2);
                }
                else
                {
                    Tuple<bool, string> ErrResult = ErrHandler.ErrorHandler(level, errorLevel, UserInput.Text);
                    if (ErrResult.Item1)
                    {
                        PartsArray[level].cm = ContinueMethod.ErrorOverload;
                        level += 1;
                        WriteMessage(ErrResult.Item2);
                    }
                    else
                    {
                        WriteMessage(ErrResult.Item2);
                        errorLevel += 1;
                    }
                }

                UserInput.Text = "";  // This clears the input field for next 'task'
            }
        }
    }
}