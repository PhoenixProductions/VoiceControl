using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib.Actions
{
    class SpeakAction: BaseAction, IAction
    {
        public SpeakAction(string response)
        {
            this.Response = response;
        }
        private string _response = "";

        public string Response
        {
            get { return _response; }
            set { _response = value; }
        } 
        public static string Name()
        {
            return "Speak Action";
        }

        public override void Execute()
        {
            if (_response != "")
            {
                VoiceControl.Speak(_response);
            }
        }

        new public static IAction BuildAction()
        {
            VoiceControlLib.Builders.SpeakActionBuilder b = new VoiceControlLib.Builders.SpeakActionBuilder();
            System.Windows.Forms.DialogResult r = b.ShowDialog();
            if (r  == System.Windows.Forms.DialogResult.OK)
            {
                return b.Action;
            }
            return null ;
            //return System.Windows.Forms.DialogResult.OK;// throw new NotImplementedException();
        }

        public override string Explain()
        {
            return "Speak the phrase " + _response;
        }
    }
}
