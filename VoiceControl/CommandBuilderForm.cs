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
    public partial class CommandBuilderForm : Form
    {
        VoiceControlLib.Commands.UserSpeechCommand _command;

        public VoiceControlLib.Commands.UserSpeechCommand Command
        {
            get { return _command; }
            set { _command = value; }
        } 
        public CommandBuilderForm()
        {
            InitializeComponent();

        }


        private void CommandBuilderForm_Load(object sender, EventArgs e)
        {
            // Load Actions
            foreach (Type t in VoiceControlLib.VoiceControl.GetActions())
            {
                if (!t.IsInterface && !t.IsAbstract)
                {
                    PotentialActionListItem a = new PotentialActionListItem();
                    a.Name = (string)t.GetMethod("Name").Invoke(null, null);
                    a.Action = t;
                    ListPotentialActions.Items.Add(a);
                }
            }
            ListPotentialActions.DisplayMember = "Name";
            ListPotentialActions.ValueMember = "Action";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ListActions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PotentialActionListItem a = (PotentialActionListItem)ListPotentialActions.SelectedItem;
            Console.WriteLine(a);
            Type t = a.Action;
            //VoiceControlLib.Actions.BaseAction actionInstance = (VoiceControlLib.Actions.BaseAction)Activator.CreateInstance(t);
            VoiceControlLib.IAction result = (VoiceControlLib.IAction)t.GetMethod("BuildAction").Invoke(null,null);
            if (result != null)                 
            {
                System.Console.WriteLine("Action instance builder displayed OK");
                Console.WriteLine(result);
                ActionListItem ai = new ActionListItem() ;
                ai.Name = result.Explain();
                ai.Action = result;
                ListActions.Items.Add(ai);
                ListActions.DisplayMember = "Name";
                ListActions.ValueMember = "Action";
            }
            else
            {
                System.Console.WriteLine("Action instance builder failed to display");
            }
        }

        private void ButtonSaveCommand_Click(object sender, EventArgs e)
        {
            // persist the actions in the action list out in to the User Speech command object
        }
    }
     class PotentialActionListItem
    {
        private Type _Action;

        public Type Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    class ActionListItem
     {
         private VoiceControlLib.IAction _Action;

         public VoiceControlLib.IAction Action
         {
             get { return _Action; }
             set { _Action = value; }
         }
         private string _Name;

         public string Name
         {
             get { return _Name; }
             set { _Name = value; }
         }
     }
}
