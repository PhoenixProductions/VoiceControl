using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace VoiceControlLib
{
    
    public interface IVoiceCommand 
    {
        void Execute(object sender, SpeechRecognizedEventArgs e);
        string Explain();
        System.Windows.Forms.Form GetBuilder();

        Grammar Grammar
        {
            get;
            set;
        }
    }
    
}
