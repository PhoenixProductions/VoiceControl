using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace VoiceControlLib.Commands
{
    class TimeCommand : BaseCommand, IVoiceCommand
    {
        List<string> _responses = new List<string>();
        List<string> _timeresponses = new List<string>();
        public TimeCommand()
            : base()
        {
            Choices c = new Choices(
                new string[] {
                        "What time is it",
                        "What's the time",
                        "Tell me the time"
                    }
            );
            GrammarBuilder builder = new GrammarBuilder(c);

            this._grammar = new Grammar(builder);
            _grammar.SpeechRecognized += Execute;

            _responses.Add("it's %time%");
            _responses.Add("the time is %time%");
            _timeresponses.Add("{0:t}");
            _timeresponses.Add("{0:t} on {0:dddd d MMMM}");
        }

        public override void Execute(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            Random r = new Random();
            string response = _responses[r.Next(_responses.Count)];
            string timeresponse = _timeresponses[r.Next(_timeresponses.Count)];
            string timeResponse = String.Format(timeresponse, DateTime.Now);
            response = response.Replace("%time%", timeResponse);
            VoiceControl.Speak(response);
        }
    }
}
