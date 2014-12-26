using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib.Actions
{
    class SendKeyAction: BaseAction, IAction
    {
        private string _keystroke;
        public SendKeyAction(string keystroke)
        {
            _keystroke = keystroke;
        }
        public static string Name()
        {
            return "Send Key Action";
        }
        public override string Explain()
        {
            return "Send '"+ this._keystroke+ "' key.";
        }

        public override void Execute()
        {
            System.Diagnostics.Debug.Write("Sending key '" + _keystroke + "'...");
            try
            {
                System.Windows.Forms.SendKeys.SendWait(_keystroke);
                System.Diagnostics.Debug.WriteLine("Sent");
            }
            catch (System.InvalidOperationException e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
            } 
            catch (System.Reflection.TargetInvocationException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            
        }

        new public static IAction BuildAction()
        {
            VoiceControlLib.Actions.SendKeyActionBuilder.SendKeyActionBuilder b = new SendKeyActionBuilder.SendKeyActionBuilder();
            System.Windows.Forms.DialogResult r = b.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                return b.Action;

            }
            return null;
        }
    }
}
