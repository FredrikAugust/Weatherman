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

        Tuple<bool, string> parser(string p);
    }

    class WelcomeClass : Parts
    {
        public string message { get; set; }

        public Tuple<bool, string> parser(string p)
        {
            if (p == "anything")
            {
                return Tuple.Create(true, "Wow, you're really \ngood at taking things \nliterally aren't ya?");
            }
            else
            {
                return Tuple.Create(false, "I told you to \ntype 'anything', \nnot '" + p + "'.");
            }
        }
    }

}
