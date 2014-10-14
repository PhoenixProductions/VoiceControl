using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoiceControlLib;

namespace VCTestHarness
{
    public partial class Form1 : Form
    {
        VoiceControlLib.VoiceControl _vc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _vc = new VoiceControl();
            _vc.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _vc.StopSpeaking();
        }
    }
}
