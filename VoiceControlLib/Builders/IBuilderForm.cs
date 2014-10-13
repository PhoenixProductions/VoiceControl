using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib.Builders
{
    public interface IBuilderForm
    {
        IAction Action
        {
            get;
            set;
        }
    }
}
