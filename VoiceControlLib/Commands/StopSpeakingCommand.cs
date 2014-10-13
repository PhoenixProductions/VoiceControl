using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace VoiceControlLib.Commands
{
    class StopSpeakingCommand : BaseCommand, IVoiceCommand
    {
        List<string> _responses = new List<string>();

        public StopSpeakingCommand()
            : base()
        {
            _responses.AddRange(new string[] { "OK" });

            //GrammarBuilder builder = new GrammarBuilder("Hello");
            Choices c = new Choices(
                 new string[] {
                        "Stop speaking"
                    }
                );
            if (VoiceControl.Options.ContainsKey("cmdrname"))
            {
                string vcCmdr = (string)VoiceControl.Options["cmdrname"];
                _responses.Add("OK " + vcCmdr);
            }

            GrammarBuilder builder = new GrammarBuilder(c);

            this._grammar = new Grammar(builder);
            _grammar.SpeechRecognized += Execute;
        }

        public override void Execute(object sender, SpeechRecognizedEventArgs e)
        {
            VoiceControl._synth.SpeakAsyncCancelAll();
        }
    }
}
