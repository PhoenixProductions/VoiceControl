using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteLibrary
{
    class LogEntry
    {
        public LogEntry(string Summary)
        {
            _created = DateTime.Now;
            _modified = _created;
            _summary = Summary;
            _entry = "";
        }
        DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        string _summary;

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        } 
        string _entry;

        public string Entry
        {
            get { return _entry; }
            set { _entry = value; }
        }

        public override string ToString()
        {
            return _created + ":" + _summary + ":" + _entry;
        }

    }
}
