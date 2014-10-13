using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Web;
using System.ComponentModel;


namespace VoiceControlLib.Commands
{
    class WikipediaCommand : BaseCommand, IVoiceCommand
    {
        static Dictionary<string, string> _resultCache = new Dictionary<string, string>();

        List<string> _responses = new List<string>();

        public WikipediaCommand()
        {
            Choices c = new Choices(
                 new string[] {
                        "tell me about",
                        "wikipedia"
                    }
                );
            SemanticResultKey tellmecommands = new SemanticResultKey("tellmecommand", c.ToGrammarBuilder());
            //SemanticResultKey subject = new SemanticResultKey("subject", )
            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(tellmecommands);
            builder.AppendDictation();
            this._grammar = new Grammar(builder);
            _grammar.SpeechRecognized += Execute;
        }

        public override void Execute(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Result.Semantics["tellmecommand"].Value);

            string newresult = e.Result.Text.Replace(e.Result.Semantics["tellmecommand"].Value.ToString(), "").ToLower();

            if (_resultCache.ContainsKey(newresult)) {
                Console.WriteLine("Cache hit on " + newresult);
                VoiceControl._synth.SpeakAsync("Telling you about" + newresult +". " + (string)_resultCache[newresult]);
            }
            else
            {
                Console.WriteLine("Cache miss on " + newresult);
                VoiceControl._synth.SpeakAsync("Finding out about " + newresult +".");
                FetchInformationAsync(newresult);
            }
        }

        async void FetchInformationAsync(string subject)
        {
            string url = "https://en.wikipedia.org/wiki/Special:Search/"+ subject;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                
                string content = await wc.DownloadStringTaskAsync(url);

                HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(content);
                StringBuilder sb = new StringBuilder();
                foreach (HtmlAgilityPack.HtmlNode n in html.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]//text()"))
                {
                    string s = n.InnerText.Replace("&#160;", " ");
                    sb.Append(s);
                }
                string result = sb.ToString();
                _resultCache.Add(subject, result); 
                //In theory we should cache the results for any synonyms.
                VoiceControl._synth.SpeakAsync("Found information about " + subject + ". " + result);


            }
        }

    }

}
