using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteLibrary
{
    class PilotLogManager
    {
        static PilotLogManager _manager;

        public static PilotLogManager GetManager()
        {
            if (_manager == null) { 
                //initialise a new manager at the current location
                _manager = new PilotLogManager();
            }
            return _manager;
        }

        string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private List<LogEntry> _log;

        protected PilotLogManager()
        {
            _filePath = "";
            _log = new List<LogEntry>();
        }
        
        public void Add(LogEntry e) {
            _log.Add(e);
        }

        public void Add(string Summary) {
            _log.Add(new LogEntry(Summary));
        }


        void Dump()
        {
            foreach (LogEntry e in _log)
            {
                Console.WriteLine(e.Created + ": " + e.Summary);
            }
        }

        void Save()
        {
            throw new NotImplementedException();
        }
        void Load()
        {
            throw new NotImplementedException();
        }
    }
}
