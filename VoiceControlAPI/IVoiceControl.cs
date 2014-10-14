using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib
{
    public interface IVoiceControl
    {
        void AddCommand(IVoiceCommand Command);
    }
}
