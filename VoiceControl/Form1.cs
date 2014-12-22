using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceControl
{
    public partial class Form1 : Form
    {
        VoiceControlLib.VoiceControl vc;
        Dictionary<string, VoiceControlLib.IVoiceCommand> commands;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            vc = new VoiceControlLib.VoiceControl(Application.UserAppDataPath);
            vc.Recognised += vc_Recognised;
            
            vc.Start();
            
            vc.LoadPlugin(@"C:\Users\michael\Documents\Visual Studio 2013\Projects\VoiceControl\VoiceControl\bin\Debug\EliteLibrary.dll");

        }

        void vc_Recognised(object sender, VoiceControlLib.RecognisedEventArgs e)
        {
            Console.WriteLine(e.Phrase);
        }

        private void addAction_click(object sender, EventArgs e)
        {
            CommandBuilderForm f = new CommandBuilderForm();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //then add resulting command definition into the VC lib
                vc.AddCommand(f.Command);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vc.Stop();
            vc.TestInput(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Stop();
        }


        void Start()
        {
            button2.Enabled = false;
            button3.Enabled = true;
            vc.Start();
        }
        void Stop()
        {
            vc.Stop();
            button2.Enabled = true;
            button3.Enabled = false;

        }
    }
}
