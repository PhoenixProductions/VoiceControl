using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib
{
    public class RecognisedEventArgs : EventArgs
    {
        string _phrase;

        public string Phrase
        {
            get { return _phrase; }
            set { _phrase = value; }
        }
    }
}
