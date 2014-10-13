using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace VoiceControlLib
{
    /// <summary>
    /// Implements basic command interface
    /// </summary>
    
    public abstract class BaseCommand: IVoiceCommand
    {
        protected Grammar _grammar;

        Grammar IVoiceCommand.Grammar
        {
            get { return _grammar; }
            set { 

                _grammar = value;
                _grammar.SpeechRecognized += Execute;
            }
        }
        public BaseCommand()
            : base()
        {
        }
        /// <summary>
        /// Execute the grammar's action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Execute(object sender, SpeechRecognizedEventArgs e);


        /// <summary>
        /// Generates human orientated version of the command
        /// </summary>
        /// <returns></returns>
        string IVoiceCommand.Explain()
        {
            return "Base Command";
        }

        public System.Windows.Forms.Form GetBuilder()
        {
            return new Builders.DefaultBuilder();
        }

    }

    
}
