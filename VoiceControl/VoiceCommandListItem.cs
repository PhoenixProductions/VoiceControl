using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControl
{
    class VoiceCommandListItem
    {
        Type _typeInfo;

        public Type TypeInfo
        {
            get { return _typeInfo; }
            set { _typeInfo = value; }
        }
        string _display;

        public string Display
        {
            get { return _display; }
            set { _display = value; }
        }

    }
}
