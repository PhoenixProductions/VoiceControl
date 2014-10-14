using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib
{
    public interface IVoiceControlPlugin
    {
        //IVoiceControlPlugin Instance { get; }
        /// <summary>
        /// Hook to allow the VoiceControl library to ask a plugin for configuration form.
        /// </summary>
        /// <param name="host">The VoiceControl application that loaded the plugin</param>
        void Configure(IVoiceControl host);

        /// <summary>
        /// Called by VoiceControlLib when plugin is loaded to so that it can initalise it's commands
        /// </summary>
        void Initialise(IVoiceControl host);
    }

}
