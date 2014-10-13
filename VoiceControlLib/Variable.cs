using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib
{
    class Variable
    {
        public Variable(string Placeholder, string defaultValue)
        {
            _defaultValue = defaultValue;
            _placeholder = Placeholder;
        }
        string _placeholder;

        public string Placeholder
        {
            get { return _placeholder; }
            set { _placeholder = value; }
        }
        string _defaultValue;

        public string Value
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }
    }
}
