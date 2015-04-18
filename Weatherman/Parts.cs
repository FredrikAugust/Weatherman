using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weatherman
{
    interface Parts
    {
        string message { get; set; }

        bool parser(string p);
    }

    class WelcomeClass : Parts
    {
        public string message { get; set; }

        public bool parser(string p)
        {
            Environment.Exit(0);

            return false;
        }
    }

}
