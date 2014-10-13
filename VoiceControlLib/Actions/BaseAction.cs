using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib.Actions
{
    public abstract class BaseAction :IAction
    {
        public static IAction BuildAction()
        {
            throw new NotImplementedException();
        }

        public abstract string Explain();
        
        public abstract void Execute();
        
    }
}
