using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Weatherman
{
    interface Parts
    {
        string message { get; set; }

        Tuple<bool, string> parser(string input);
    }

    class WelcomeClass : Parts
    {
        public string message { get; set; }

        public Tuple<bool, string> parser(string input)
        {
            if (input == "anything")
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

                default:
                    return Tuple.Create(false, "You really suck, don't you?");
                    break;
            }

            return Tuple.Create(false, "");  // This doesn't really have a purpose, but it makes VS shut up.
        }
    }
    public class WelcomeResponseClass : Parts
    {
        public string message { get; set; }

        public Tuple<bool, string> parser(string input)
        {
            return Tuple.Create(true, "Wow, that is awesome!");
        }
    }

}
