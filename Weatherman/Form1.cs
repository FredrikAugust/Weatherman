﻿using System;
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

        /// <summary>
        /// In a lack of better places to do this, I will load all the function into the array in the form_load function.
        /// This is becuase I couldn't think of a better way to do it, and I don't have time ATM to find that out either.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            email.Hide();
            nsahack.Hide();

            // Include splash screen perhaps?

            // Add all the parts to the partsarray
            PartsArray[0] = new WelcomeClass() 
            {
                message = @"Welcome to Weatherman!
You can always type your 
commands, even when 
Weatherman is speaking. 
Don't hesitate to interupt.

Type anything to start or
exit to exit.

If you are stuck,
press enter.
That usually works."
            };

            PartsArray[1] = new WelcomeResponseClass(); // This isntance of the class does not have a message prop becuase it doesn't need one.
            PartsArray[2] = new GetName(); // Same as the reason stated above.
            PartsArray[5] = new IntroToWeatherman(); // You know..
            PartsArray[6] = new NoYes();
            PartsArray[7] = new PresentScript();
            PartsArray[8] = new HackNSA();
            PartsArray[9] = new HackNSAReturn();
            PartsArray[10] = new AccessServer();
            PartsArray[11] = new CheckAccessServer();
            PartsArray[12] = new RememberCode();
            PartsArray[13] = new RemberCodeParser();
            PartsArray[14] = new GoodBye();
            PartsArray[15] = new Exit();

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

        /// <summary>
        /// This is a small hack that removes the marker from the input, so that it doens't ruin that 8-bit feel
        /// </summary>
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
        /// Small script that creates a typewriter effect and places cursor on the next line
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

        private int level; // This determines which mission the user is on

        /// <summary>
        /// Initiates the program by loading the first module
        /// </summary>
        private void button1_Click(object sender, EventArgs e)  // Power button
        {
            level = 0;
            errorLevel = 0;

            // Just to start off the program
            WriteMessage(PartsArray[0].message);

            UserInput.Focus();

            try 
            {
                HideCaret(UserInput.Handle);
            }
            catch (DllNotFoundException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            
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
                # region quit This quits the program if the input contains 'quit' or 'exit'
                if (UserInput.Text.ToLower() == "quit" || UserInput.Text.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                #endregion

                #region Level 1
                if (level == 1 && PartsArray[0].cm == ContinueMethod.CorrectAnswer)
                {
                    PartsArray[1].message = "Ok, so congratulations;\nyou managed to type a word!\nPrepare for the next challenge...\n\nEnter your name.";
                }
                else if (level == 1 && PartsArray[0].cm == ContinueMethod.ErrorOverload)
                {
                    PartsArray[1].message = "You didn't even manage\nto type a word. I'm actually \ntruly impressed. Not bad.\n\nNow, for the next task...\n\nWhat is your name?";
                }
                #endregion

                TextTimer.Enabled = false;

                switch (level)
                {
                    #region Level 3
                    case 3:
                        WriteMessage("Loading Whetherman..");
                        weathermanLoad.Visible = true;
                        loadingTimer.Enabled = true;
                        level++;
                        break;
                    #endregion

                    #region Level 8
                    case 8:
                        PartsArray[8].cm = ContinueMethod.CorrectAnswer;
                        email.Show();
                        WriteMessage(PartsArray[8].parser(UserInput.Text).Item2);
                        UserInput.Text = "";
                        level++;
                        break;
                    #endregion

                    default:
                        try
                        {
                            #region Hide email and accessories
                            try
                            {
                                email.Hide();
                                filecontent.Hide();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                            #endregion

                            Tuple<bool, string> ParseResult = PartsArray[level].parser(UserInput.Text);

                            if (ParseResult.Item1)  // Did it pass the initial test?
                            {
                                #region Parse user input
                                PartsArray[level].cm = ContinueMethod.CorrectAnswer;
                                level += 1;
                                WriteMessage(ParseResult.Item2);
                                #endregion
                            }
                            else
                            {
                                #region Error Handling
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
                                #endregion
                            }
                        }
                        catch (NullReferenceException ex)
                        {
                            WriteMessage("Level " + level + " doesn't exist yet.");
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                UserInput.Text = "";  // This clears the input field for next 'task'
            }
        }

        /// <summary>
        /// Increase the loading bar for weatherman
        /// </summary>

        bool jokeVirgin = true;

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            if ((weathermanLoad.Value < 100 && weathermanLoad.Value != 80) || (weathermanLoad.Value < 100 && !jokeVirgin))
            {
                weathermanLoad.Value += 1;
                loadingTimer.Interval -= 1;
            }
            else if (weathermanLoad.Value == 80 && jokeVirgin)
            {
                weathermanLoad.Value = 20;
                TextTimer.Enabled = false;
                WriteMessage("Heh.");
                jokeVirgin = false;
            }
            else if (weathermanLoad.Value == 100)
            {
                loadingTimer.Enabled = false;
                weathermanLoad.Visible = false;
                level += 1;
                WriteMessage("Weatherman loaded.\n\nEnter Weatherman by typing:\n'lisp(((weatherman)))'");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewContent_Click(object sender, EventArgs e)
        {
            if (filecontent.Visible == false)
            {
                filecontent.Visible = true;
            }
            else
            {
                filecontent.Visible = false;
            }
        }
    }
}