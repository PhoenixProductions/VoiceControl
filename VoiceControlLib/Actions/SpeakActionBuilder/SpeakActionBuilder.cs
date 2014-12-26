using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoiceControlLib.Actions;

namespace VoiceControlLib.Builders
{
    public partial class SpeakActionBuilder : Form , IBuilderForm
    {
        private IAction _action = null;
        public SpeakActionBuilder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            _action = new VoiceControlLib.Actions.SpeakAction(TextResponse.Text);
            this.Close();
        }

        public IAction Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        private void SpeakActionBuilder_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
