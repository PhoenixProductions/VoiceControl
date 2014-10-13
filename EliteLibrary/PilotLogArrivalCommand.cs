using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace EliteLibrary
{
    public class PilotLogArrivalCommand : VoiceControlLib.BaseCommand, VoiceControlLib.IVoiceCommand
    {
        public PilotLogArrivalCommand()
        {
            Choices c = new Choices(
                 new string[] {
                        "arrived at",
                        "reached"
                    }
                );
            SemanticResultKey arrivals = new SemanticResultKey("logarrival", c.ToGrammarBuilder());
            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(arrivals);
            builder.AppendDictation();

            this._grammar = new Grammar(builder);
            _grammar.SpeechRecognized += Execute;
        }
        public override void Execute(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            PilotLogManager manager = PilotLogManager.GetManager();
            if (e.Result.Semantics.ContainsKey("logarrival"))
            {
                string destination = e.Result.Text.Replace(e.Result.Semantics["logarrival"].Value.ToString(), "");
                manager.Add("Arrived in " + destination);
            }
        }
    }
}
