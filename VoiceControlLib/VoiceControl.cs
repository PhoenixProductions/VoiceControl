#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech.Recognition.SrgsGrammar;
using System.Diagnostics;
using Microsoft.Build.Utilities;

namespace VoiceControlLib
{
    public class VoiceControl : VoiceControlLib.IVoiceControl
    {
        static SpeechRecognitionEngine _recognitionEngine;
        public static SpeechSynthesizer _synth;

        static VoiceControlLib.ILogger _logger;

        //public static Dictionary<string, Variable> Options = new Dictionary<string, Variable>();
        public static Dictionary<string, string> Options = new Dictionary<string, string>();
        /// <summary>
        /// Holds the defined commands
        /// </summary>
        Dictionary<string, VoiceControlLib.IVoiceCommand> _commands;

        /// <summary>
        /// List of Plugin Assemblies loaded
        /// </summary>
        static Dictionary<string, IVoiceControlPlugin> _plugins = new Dictionary<string,IVoiceControlPlugin>();

        /// <summary>
        /// A location in which grammar documents are found
        /// </summary>
        string _grammarPath;

        public event EventHandler<RecognisedEventArgs> Recognised;
        public event EventHandler CommandsLoaded;
        public VoiceControl(): this("")
        {
            
        }
        public VoiceControl(string grammarPath)
        {
            _grammarPath = grammarPath;
            _logger = new Logger.FileLogger();

            Options.Add("selfname", "Dave");
            Options.Add("cmdrname", "Michael");       

            // Optional variables 
            Options.Add("opt_selfname", Options["selfname"]);
            Options.Add("opt_cmdrname", Options["cmdrname"]);
            
            Console.WriteLine("GrammarPath:" + _grammarPath);
            try
            {
                if (_recognitionEngine == null)
                {
                    _recognitionEngine = new SpeechRecognitionEngine();
                    //set up event handling
                    _recognitionEngine.SpeechDetected += _recognitionEngine_SpeechDetected;
                    _recognitionEngine.SpeechRecognized += _engine_SpeechRecognized;
                    _recognitionEngine.SetInputToDefaultAudioDevice();

                    

                    Console.WriteLine(@"Speech recognition engine created");
                    
                    // Load the dictation grammar so that we can filter out "noise".
                    DictationGrammar defaultDictationGrammar = new DictationGrammar();
                    defaultDictationGrammar.Name = "random";
                    _recognitionEngine.LoadGrammar(defaultDictationGrammar);
                }
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            catch (ArgumentException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            if (_synth == null)
            {
                _synth = new SpeechSynthesizer();
                ConfigureVoice();
            }
            _commands = new Dictionary<string, VoiceControlLib.IVoiceCommand>();
            this.AddCommand(new VoiceControlLib.Commands.StopSpeakingCommand());
            this.AddCommand(new VoiceControlLib.Commands.GreetingCommand());
            this.AddCommand(new VoiceControlLib.Commands.SignOffCommand());
            this.AddCommand(new VoiceControlLib.Commands.WikipediaCommand());
            this.AddCommand(new VoiceControlLib.Commands.TimeCommand());
            // A fake user speech command
            this.AddCommand(new VoiceControlLib.Commands.UserSpeechCommand("Raise shields", null));
            
            // Load any other dlls containing IVoiceCommands or IActions
        }

        /// <summary>
        /// Set up the voice output
        /// </summary>
        void ConfigureVoice()
        {
            foreach (InstalledVoice v in _synth.GetInstalledVoices())
            {
                Console.WriteLine(v.VoiceInfo.Name);
            }
            //_synth.SelectVoice("Microsoft David Desktop");
            //_synth.SelectVoice("Microsoft Zira Desktop");
            _synth.SelectVoice("Microsoft Hazel Desktop");
        }
        void _recognitionEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Console.WriteLine(@"Speech detected");
            
        }

        void _engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Speech recognised");
            System.Diagnostics.Debug.WriteLine(e.Result.Grammar.Name);
            System.Diagnostics.Debug.WriteLine(e.Result.Text);
            System.Diagnostics.Debug.WriteLine(e.Result.Confidence);
            System.Diagnostics.Debug.WriteLine(e.Result.Grammar.RuleName);
        }
            
        public void Start()
        {
            Console.WriteLine(@"Starting");
            _recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            Console.WriteLine(@"Started");
        }
        public void Stop()
        {
            _recognitionEngine.RecognizeAsyncCancel();
        }

        /// <summary>
        /// Stop synthesizer speaking.
        /// </summary>
        public void StopSpeaking()
        {
            _synth.SpeakAsyncCancelAll();
        }

        static Dictionary<string, string> _speechCache = new Dictionary<string, string>();
        public static void Speak(string TextToSpeak)
        {
            string Replaced;
            if (!_speechCache.ContainsKey(TextToSpeak.ToLower()))
            {
                Console.WriteLine("Speech Cache miss: "+TextToSpeak);
                Replaced = VoiceControl.ReplacePlaceholders(TextToSpeak);
                if (!TextToSpeak.Contains("%OPT_%"))    //don't cache text with %OPT_ variables in it
                {
                    _speechCache.Add(TextToSpeak.ToLower(), Replaced);
                }
            }
            else
            {
                Console.WriteLine("Speech Cache hit");
                Replaced = _speechCache[TextToSpeak.ToLower()];
            }
            VoiceControl._synth.SpeakAsync(Replaced);

            
        }

        public void TestInput(string input)
        {
            _recognitionEngine.RecognizeAsyncCancel();
            _recognitionEngine.EmulateRecognize(input);

            
        }
        /// <summary>
        /// </summary>
        /// <returns>Path to the constructed file</returns>
        public string constructInitialGrammarDocument(string path)
        {
            string filename = System.IO.Path.Combine(path, "default.xml");
            System.Speech.Recognition.SrgsGrammar.SrgsDocument doc = new System.Speech.Recognition.SrgsGrammar.SrgsDocument();


            System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(filename);
            Console.WriteLine("Saving default grammar to " + filename);
            doc.WriteSrgs(writer);
            writer.Close();
            return filename;
        }

        protected virtual void OnRecognised(SpeechRecognizedEventArgs e)
        {
            EventHandler<RecognisedEventArgs> handler = Recognised;
            if (handler != null)
            {
                RecognisedEventArgs args = new RecognisedEventArgs();
                args.Phrase = e.Result.Text;
                handler(this, args);
            }
        }

        protected virtual void OnCommandsLoaded()
        {
            EventHandler handler = CommandsLoaded;
            if (handler != null)
            {
                EventArgs e = new EventArgs();
                handler(this, e);
            }
        }
        
        //Command handling

        public Dictionary<string, VoiceControlLib.IVoiceCommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        public void LoadCommands(string filepath)
        {
            System.IO.Stream stream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Dictionary<string, IVoiceCommand> _commands = (Dictionary<string, IVoiceCommand>)formatter.Deserialize(stream);
            stream.Close();

            this._commands = _commands;
            //raise a commands loaded events
            this.OnCommandsLoaded();
#if DEBUG
            Console.WriteLine(_commands.Count() + " Commands loaded from file " + filepath);
            DumpCommands();
#endif

        }
        public void SaveCommands(string filePath)
        {
            System.IO.Stream stream = System.IO.File.Open(filePath, System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.IFormatter formatter;
            formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(stream, _commands);
            stream.Close();
        }
        /// <summary>
        /// Returns a list of commands that can be used.
        /// </summary>
        /// <returns></returns>
        public static Type[] GetAvailable(Type type)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));

            return types.ToArray<Type>();
        }
        
        protected void DumpCommands()
        {
            
            foreach (IVoiceCommand v in _commands.Values)
            {
                Console.WriteLine(v.Explain());
            }
            Console.WriteLine(this._commands);
        }
        

        public void AddCommand(IVoiceCommand command)
        {
            System.Diagnostics.Debug.WriteLine("Loading Command " + command);
            _recognitionEngine.LoadGrammar(command.Grammar);
        }

        void command_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            throw new NotImplementedException();
        }
        void RemoveCommand(IVoiceCommand command)
        {

        }
        void RemoveCommandAt(int index)
        {

        }
        // Plugin Management
        public void LoadPlugin(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine(path + " doesn't exist");
                return;
            }
            System.Reflection.Assembly pluginAsm = System.Reflection.Assembly.LoadFile(path);
            if (_plugins.ContainsKey(pluginAsm.FullName)) {
                Console.WriteLine("Plugin "+ pluginAsm.FullName + " is already loaded.");
                return;
            }
            //Configure the plugin
            Type[] plugins = GetAvailable(typeof(IVoiceControlPlugin));

            List<IVoiceControlPlugin> loadedPlugins = new List<IVoiceControlPlugin>();
            int i = 0;
            foreach (Type pluginType in plugins)
            {
                if (!pluginType.IsInterface)
                {

                    if (pluginType.GetMethod("Instance") == null)
                    {
                        Console.WriteLine(pluginType.FullName + " does not conform to standard Instance static propery missing");
                        continue;
                    }
                    i++;
                    Console.WriteLine(pluginType.FullName);
                    IVoiceControlPlugin plugin = (IVoiceControlPlugin)pluginType.GetMethod("Instance").Invoke(null, null);

                    //(VoiceControlLib.IAction)t.GetMethod("BuildAction").Invoke(null, null);
                    loadedPlugins.Add(plugin);
                }
            }
            Console.WriteLine(pluginAsm.FullName + " defines " + i + " plugins");
            foreach (IVoiceControlPlugin plugin in loadedPlugins)
            {
                plugin.Configure(this);
                plugin.Initialise(this);
            }


        }
        // Action management
        public static Type[] GetActions()
        {

            return GetAvailable(typeof(IAction));
        }
        // Options management
        public static string ReplacePlaceholders(string subject)
        {
            string outText = subject;
            foreach (string k in Options.Keys)
            {
                Console.WriteLine("Replacing %" + k + "% with " + Options[k]);
                if (k.StartsWith("opt_"))
                {
                    Console.WriteLine("optional subst");
                    //substitution is optional
                    Random r = new Random();
                    int chance = r.Next(2);
                    if (chance == 1)
                    {
                        Console.WriteLine(outText);
                        outText = outText.Replace("%" + k.ToUpper() + "%", "");
                        Console.WriteLine(outText);
                    }
                    else
                    {
                        outText = outText.Replace("%" + k.ToUpper() + "%", Options[k]);
                    }
                }
                else
                {
                    outText = outText.Replace("%" + k.ToUpper() + "%", Options[k]);
                }
            }
            return outText;
        }

        protected void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
    
}
