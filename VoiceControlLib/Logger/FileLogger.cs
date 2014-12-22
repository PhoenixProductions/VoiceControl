using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlLib.Logger
{
    class FileLogger : VoiceControlLib.ILogger
    {
        public FileLogger()
        {
            //read configuration file ideally but for the moment hard coded
            
        }
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
