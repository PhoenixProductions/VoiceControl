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
            GrammarBuilder arrivalsbuilder = new GrammarBuilder();
            arrivalsbuilder.Append(arrivals);
            arrivalsbuilder.AppendDictation();

            /*
             * Phrases are:
             *  left|departed X 
             *  left|departed X for|heading to Y
             */ 
            Choices leftchoices = new Choices(new string[] { "left", "departed" });
            
            SemanticResultKey leftsemantics = new SemanticResultKey("left", leftchoices.ToGrammarBuilder());
            GrammarBuilder left1 = new GrammarBuilder(leftsemantics);
            left1.AppendDictation();

            GrammarBuilder left2 = new GrammarBuilder(leftsemantics);
            left2.Append(new Choices(new string[] { "for", "heading to" }));
            left2.AppendDictation();

            
            GrammarBuilder leftBuild = new GrammarBuilder(new Choices(left1, left2));

            GrammarBuilder builder = new GrammarBuilder(new Choices(arrivalsbuilder, leftBuild));

            this._grammar = new Grammar(builder);
            Console.WriteLine(builder.DebugShowPhrases);
            _grammar.SpeechRecognized += Execute;
        }
        public override void Execute(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("EliteLibrary handling");
            PilotLogManager manager = PilotLogManager.Instance();
            Console.WriteLine(e.Result.Semantics);
            if (e.Result.Semantics.ContainsKey("logarrival"))
            {
                string destination = e.Result.Text.Replace(e.Result.Semantics["logarrival"].Value.ToString(), "");
                manager.Add("Arrived in " + destination.TrimStart());
                manager.Dump();
            }
            if (e.Result.Semantics.ContainsKey("left"))
            {
                Console.WriteLine(e.Result.Text);
            }
        }
    }
}
