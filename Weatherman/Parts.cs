using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Weatherman
{
    /// <summary>
    /// This is just used to determine what resulted in the user advancing.
    /// Doesn't do anything on it's own.
    /// </summary>
    enum ContinueMethod
    {
        CorrectAnswer,
        ErrorOverload
    }

    /// <summary>
    /// This interface is to make it easier for myself to add new parts to the program, althoguh it is still a pain..
    /// </summary>
    interface Parts
    {
        string message { get; set; }  // What the user should be prompted with initially

        /// <summary>
        /// Checks if the input is correct
        /// </summary>
        /// <param name="input">What the user entered</param>
        /// <returns>Boolean for determining whether the user should advance or not, and a string for showing to the user</returns>
        Tuple<bool, string> parser(string input);

        ContinueMethod cm { get; set; }
    }

    class WelcomeClass : Parts
    {
        public string message { get; set; }

        public ContinueMethod cm { get; set; }

        /// <summary>
        /// Checks if the input is correct
        /// </summary>
        /// <param name="input">What the user entered</param>
        /// <returns>Boolean for checking if the user should advance or not, and a string for showing to the user</returns>
        public Tuple<bool, string> parser(string input)
        {
            if (input.ToLower() == "anything")
            {
                return Tuple.Create(true, "Wow, you're really \ngood at taking things \nliterally aren't ya?");
            }
            else
            {
                return Tuple.Create(false, "");
            }
        }
    }
    public class ErrorHandling
    {
        /// <summary>
        /// Determines what to do based on how many errors the user has.
        /// Yes; I know this uses a switch, but that's becuase I'm lazy right now.
        /// If you don't like it, feel free to create a pull request and fix it yourself :)
        /// </summary>
        /// <param name="_level">What level you are on when entering this method</param>
        /// <param name="_errorLevel">How many times the user has failed</param>
        /// <param name="input">What the user inputted to the mission</param>
        /// <returns>Boolean for determining whether the user shall advance or not, and a string for showing the user.</returns>
        public Tuple<bool, string> ErrorHandler(int _level, int _errorLevel, string input)
        {
            switch (_level)
            {
                case 0:
                    if (_errorLevel >= 1)
                    {
                        return Tuple.Create(true, "You know what?\nYou suck so bad that\nI'm actually going to\nlet you pass.\n\nYou should be ashamed of yourself.");
                    }
                    else if (_errorLevel == 0)
                    {
                        return Tuple.Create(false, "I told you to \ntype 'anything', \nnot '" + input + "'.\n\nPlease type 'anything'.");
                    }
                    break;

                case 2:
                    if (input.Length == 0 || Regex.Match(input, @"\d").Length > 0)
                    {
                        return Tuple.Create(false, "Unless my programming skills are\nnot perfect;\n'" + input + "'\nis not a name.\n\nPlease enter your name.");
                    }
                    break;

                case 5:
                    if (input == "sudo lisp(((weatherman)))")
                    {
                        return Tuple.Create(true, "> Hello. I have been awaiting you.\n\n> Task:\n> * Hack NSA\n> * Steal weather info for Area 51\n> * Profit\n\n> Got it?");
                    }
                    else if (input != "sudo lisp(((weatherman)))" && input.Contains("sudo"))
                    {
                         // Do something funny, like running a weird regex or something
                        return Tuple.Create(true, "Using alias:\n'" + input + "='sudo lisp(((weatherman)))'\n\n");
                    }
                    else
                    {
                        return Tuple.Create(false, "ERROR: permission denied\n\nTry running with sudo");
                    }

                default:
                    return Tuple.Create(false, "Wh.. What happened?\nYou.. You broke my game.");
            }
        }
    }

    /// <summary>
    /// This will just respond to you after you finish the first mission.
    /// This will lead to the next part, which is getting name etc.
    /// </summary>
    class WelcomeResponseClass : Parts
    {
        public string message { get; set; }  // This is just the message to display when the mission starts

        public ContinueMethod cm { get; set; }  // Enum that is used to determine what made the program advance

        /// <summary>
        /// This gives you a witty remark or something along those lines depending on how you advanced to here.
        /// </summary>
        /// <param name="input">The text which the user inputted</param>
        /// <returns>Boolean for determining whether the code passed the test or not and a return string for displaying</returns>
        public Tuple<bool, string> parser(string input)
        {
            return Tuple.Create(true, message);
        }
    }

    class GetNameClass : Parts
    {
        public string message { get; set; }

        public Tuple<bool, string> parser(string input)
        {
            if (!(input.Length == 0 || Regex.Match(input, @"\d").Length > 0))
            {
                return Tuple.Create(true, "Very good, " + input + ".\nYou can write your name");
            }
            else
            {
                return Tuple.Create(false, "");
            }
        }

        public ContinueMethod cm { get; set; }
    }

    class IntroToWeatherman : Parts
    {
        public string message { get; set; }

        public Tuple<bool, string> parser(string input)
        {
            if (input == "lisp(((weatherman)))")
            {
                return Tuple.Create(false, "");
            }
            else
            {
                return Tuple.Create(false, "");
            }
        }

        public ContinueMethod cm { get; set; }
    }

}
