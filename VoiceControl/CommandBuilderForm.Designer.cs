namespace VoiceControl
{
    partial class CommandBuilderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserSpeechTrigger = new System.Windows.Forms.TextBox();
            this.ListPotentialActions = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ListActions = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonSaveCommand = new System.Windows.Forms.Button();
            this.ButtonCancelCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserSpeechTrigger
            // 
            this.UserSpeechTrigger.Location = new System.Drawing.Point(149, 12);
            this.UserSpeechTrigger.Name = "UserSpeechTrigger";
            this.UserSpeechTrigger.Size = new System.Drawing.Size(340, 20);
            this.UserSpeechTrigger.TabIndex = 0;
            // 
            // ListPotentialActions
            // 
            this.ListPotentialActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPotentialActions.DisplayMember = "Name";
            this.ListPotentialActions.FormattingEnabled = true;
            this.ListPotentialActions.Location = new System.Drawing.Point(545, 38);
            this.ListPotentialActions.Name = "ListPotentialActions";
            this.ListPotentialActions.Size = new System.Drawing.Size(327, 69);
            this.ListPotentialActions.TabIndex = 1;
            this.ListPotentialActions.ValueMember = "Action";
            this.ListPotentialActions.SelectedIndexChanged += new System.EventHandler(this.ListActions_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(545, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(327, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available Actions";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ListActions
            // 
            this.ListActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListActions.DisplayMember = "Name";
            this.ListActions.FormattingEnabled = true;
            this.ListActions.Location = new System.Drawing.Point(149, 38);
            this.ListActions.Name = "ListActions";
            this.ListActions.Size = new System.Drawing.Size(340, 69);
            this.ListActions.TabIndex = 5;
            this.ListActions.ValueMember = "Action";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Actions";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonSaveCommand
            // 
            this.ButtonSaveCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSaveCommand.Location = new System.Drawing.Point(717, 159);
            this.ButtonSaveCommand.Name = "ButtonSaveCommand";
            this.ButtonSaveCommand.Size = new System.Drawing.Size(75, 23);
            this.ButtonSaveCommand.TabIndex = 7;
            this.ButtonSaveCommand.Text = "&OK";
            this.ButtonSaveCommand.UseVisualStyleBackColor = true;
            this.ButtonSaveCommand.Click += new System.EventHandler(this.ButtonSaveCommand_Click);
            // 
            // ButtonCancelCommand
            // 
            this.ButtonCancelCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancelCommand.Location = new System.Drawing.Point(798, 159);
            this.ButtonCancelCommand.Name = "ButtonCancelCommand";
            this.ButtonCancelCommand.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancelCommand.TabIndex = 8;
            this.ButtonCancelCommand.Text = "&Cancel";
            this.ButtonCancelCommand.UseVisualStyleBackColor = true;
            // 
            // CommandBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 194);
            this.Controls.Add(this.ButtonCancelCommand);
            this.Controls.Add(this.ButtonSaveCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ListActions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListPotentialActions);
            this.Controls.Add(this.UserSpeechTrigger);
            this.Name = "CommandBuilderForm";
            this.Text = "CommandBuilderForm";
            this.Load += new System.EventHandler(this.CommandBuilderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserSpeechTrigger;
        private System.Windows.Forms.ListBox ListPotentialActions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ListActions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonSaveCommand;
        private System.Windows.Forms.Button ButtonCancelCommand;
    }
}