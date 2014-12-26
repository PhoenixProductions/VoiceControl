using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace VoiceControlLib.Commands
{
    /// <summary>
    /// This is a command that is run in response to a user define speech and 
    /// has a user defined action.
    /// </summary>
    public class UserSpeechCommand : BaseCommand, IVoiceCommand
    {
        /// <summary>
        /// Used to hold the action(s) performed when recognised
        /// </summary>
        List<IAction> _actions;

        public List<IAction> Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }
        /// <summary>
        /// The phrase spoken by the user to initiate the command (only 1 permitted)
        /// </summary>
        string _userspeech;
        public UserSpeechCommand(string UserSpeech)
        {
            _userspeech = UserSpeech;
            _actions = new List<IAction>();
            GrammarBuilder builder = new GrammarBuilder(_userspeech);
            this._grammar = new Grammar(builder);
            _grammar.SpeechRecognized += Execute;
        }
        public UserSpeechCommand(string UserSpeech, VoiceControlLib.IAction action): this(UserSpeech)
        {
            //_userspeech = UserSpeech;
            //_actions = new List<IAction>();
            _actions.Add(action);

            //GrammarBuilder builder = new GrammarBuilder(_userspeech);
            //this._grammar = new Grammar(builder);
            //_grammar.SpeechRecognized += Execute;

        }
        public override void Execute(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            //VoiceControl._synth.SpeakAsync("Executing user speech command " + _userspeech);
            int _c = 1;
            foreach (IAction a in _actions)
            {
                System.Diagnostics.Debug.WriteLine(_c+ ":" +a.Explain());
                a.Execute();
                _c++;
            }
        }
        
    }
}
