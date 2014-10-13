using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace VoiceControlLib.Commands
{
    class GreetingCommand: BaseCommand, IVoiceCommand
    {

        List<string> _responses = new List<string>();

        public GreetingCommand() : base()
        {
            _responses.AddRange(new string[] {
                "Hello %OPT_CMDRNAME%", 
                "Greetings %OPT_CMDRNAME%"//, 
                //"Aye Commander"
            });

            //GrammarBuilder builder = new GrammarBuilder("Hello");
            Choices c = new Choices(
                 new string[] {
                        "Hello",
                        VoiceControl.ReplacePlaceholders("Hi %SELFNAME%")
                    }
                );
            GrammarBuilder builder = new GrammarBuilder(c);
            
            this._grammar = new Grammar(builder);
            _grammar.SpeechRecognized += Execute;
            
        }
        public override void Execute(object sender, SpeechRecognizedEventArgs e)
        {
            Random rnd = new Random();
            int selectedResponseIndex = rnd.Next(_responses.Count);
            System.Diagnostics.Debug.WriteLine("Selected response " + selectedResponseIndex);
            System.Diagnostics.Debug.WriteLine(_responses[selectedResponseIndex]);
            VoiceControl.Speak(_responses[selectedResponseIndex]);
            //VoiceControl._synth.SpeakAsync(_responses[selectedResponseIndex]);
        }
    }
}
