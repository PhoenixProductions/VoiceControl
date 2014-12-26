using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteLibrary
{
    class PilotLogManager : VoiceControlLib.IVoiceControlPlugin
    {
        static PilotLogManager _manager;

        public void Configure(VoiceControlLib.IVoiceControl host)
        {
            return;// throw new NotImplementedException();
        }


        public void Initialise(VoiceControlLib.IVoiceControl host)
        {
            //throw new NotImplementedException();
            host.AddCommand(new EliteLibrary.PilotLogArrivalCommand());
        }


        public static PilotLogManager Instance()
        {

            if (_manager == null)
            {
                System.Diagnostics.Debug.WriteLine("Initialising Manager instance");
                //initialise a new manager at the current location
                _manager = new PilotLogManager();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Re-using Manager instance");
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



        public PilotLogManager()
        {

            _filePath = EliteLibrary.Properties.Settings.Default.logfilepath;
            Console.WriteLine("Log location: " + _filePath);
            _log = new List<LogEntry>();
        }
        
        public void Add(LogEntry e) {
            _log.Add(e);
            Console.WriteLine("Writing to " + _filePath);
            System.IO.StreamWriter s =  System.IO.File.AppendText(_filePath);
            s.WriteLine(e.ToString());
            s.Close();
        }

        public void Add(string Summary) {
            this.Add(new LogEntry(Summary));
        }


        public void Dump()
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
