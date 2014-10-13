using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib
{
    interface IVoiceCommandResult
    {

        /// <summary>
        /// Return the text description of the result
        /// </summary>
        /// <returns></returns>
        string GetMessage();

        /// <summary>
        /// Return the result state 
        /// </summary>
        /// <returns></returns>
        int GetState();
    }
}
