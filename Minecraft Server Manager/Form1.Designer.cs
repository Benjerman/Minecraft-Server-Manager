namespace Minecraft_Server_Manager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.startServerButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.weatherComboBox = new System.Windows.Forms.ComboBox();
            this.setWeatherButton = new System.Windows.Forms.Button();
            this.opPlayerButton = new System.Windows.Forms.Button();
            this.opPlayerTextBox1 = new System.Windows.Forms.TextBox();
            this.deOpPlayerButton = new System.Windows.Forms.Button();
            this.deOpTextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gameRuleComboBox = new System.Windows.Forms.ComboBox();
            this.trueGRRadioButton = new System.Windows.Forms.RadioButton();
            this.falseGRRadioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.playerTxtOutput = new System.Windows.Forms.TextBox();
            this.txtInputCommand = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.startServerCheckbox = new System.Windows.Forms.CheckBox();
            this.gameRulesTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.automaticBackupsCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOutput.Location = new System.Drawing.Point(9, 238);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(528, 378);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.Location = new System.Drawing.Point(543, 199);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 20);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // backupButton
            // 
            this.backupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backupButton.Location = new System.Drawing.Point(12, 121);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(103, 42);
            this.backupButton.TabIndex = 4;
            this.backupButton.Text = "Backup World";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // startServerButton
            // 
            this.startServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startServerButton.Location = new System.Drawing.Point(12, 25);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(103, 42);
            this.startServerButton.TabIndex = 5;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // stopServerButton
            // 
            this.stopServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopServerButton.Location = new System.Drawing.Point(12, 73);
            this.stopServerButton.Name = "stopServerButton";
            this.stopServerButton.Size = new System.Drawing.Size(103, 42);
            this.stopServerButton.TabIndex = 6;
            this.stopServerButton.Text = "Stop Server";
            this.stopServerButton.UseVisualStyleBackColor = true;
            this.stopServerButton.Click += new System.EventHandler(this.stopServerButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server Administration";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Server Output";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enter Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Admin Commands";
            // 
            // weatherComboBox
            // 
            this.weatherComboBox.FormattingEnabled = true;
            this.weatherComboBox.Location = new System.Drawing.Point(262, 26);
            this.weatherComboBox.Name = "weatherComboBox";
            this.weatherComboBox.Size = new System.Drawing.Size(121, 21);
            this.weatherComboBox.TabIndex = 11;
            this.weatherComboBox.SelectedIndexChanged += new System.EventHandler(this.weatherComboBox_SelectedIndexChanged);
            this.weatherComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.weatherComboBox_KeyDown);
            // 
            // setWeatherButton
            // 
            this.setWeatherButton.Location = new System.Drawing.Point(181, 25);
            this.setWeatherButton.Name = "setWeatherButton";
            this.setWeatherButton.Size = new System.Drawing.Size(75, 21);
            this.setWeatherButton.TabIndex = 12;
            this.setWeatherButton.Text = "Set Weather";
            this.setWeatherButton.UseVisualStyleBackColor = true;
            this.setWeatherButton.Click += new System.EventHandler(this.setWeatherButton_Click);
            // 
            // opPlayerButton
            // 
            this.opPlayerButton.Location = new System.Drawing.Point(181, 52);
            this.opPlayerButton.Name = "opPlayerButton";
            this.opPlayerButton.Size = new System.Drawing.Size(75, 21);
            this.opPlayerButton.TabIndex = 13;
            this.opPlayerButton.Text = "OP Player";
            this.opPlayerButton.UseVisualStyleBackColor = true;
            this.opPlayerButton.Click += new System.EventHandler(this.opPlayerButton_Click);
            // 
            // opPlayerTextBox1
            // 
            this.opPlayerTextBox1.Location = new System.Drawing.Point(262, 53);
            this.opPlayerTextBox1.Name = "opPlayerTextBox1";
            this.opPlayerTextBox1.Size = new System.Drawing.Size(121, 20);
            this.opPlayerTextBox1.TabIndex = 14;
            this.opPlayerTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.opPlayerTextBox1_KeyDown);
            // 
            // deOpPlayerButton
            // 
            this.deOpPlayerButton.Location = new System.Drawing.Point(181, 79);
            this.deOpPlayerButton.Name = "deOpPlayerButton";
            this.deOpPlayerButton.Size = new System.Drawing.Size(75, 21);
            this.deOpPlayerButton.TabIndex = 15;
            this.deOpPlayerButton.Text = "DeOp Player";
            this.deOpPlayerButton.UseVisualStyleBackColor = true;
            this.deOpPlayerButton.Click += new System.EventHandler(this.deOpPlayerButton_Click);
            // 
            // deOpTextBox1
            // 
            this.deOpTextBox1.Location = new System.Drawing.Point(262, 80);
            this.deOpTextBox1.Name = "deOpTextBox1";
            this.deOpTextBox1.Size = new System.Drawing.Size(121, 20);
            this.deOpTextBox1.TabIndex = 16;
            this.deOpTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deOpTextBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Game Rule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameRuleComboBox
            // 
            this.gameRuleComboBox.FormattingEnabled = true;
            this.gameRuleComboBox.Location = new System.Drawing.Point(262, 106);
            this.gameRuleComboBox.Name = "gameRuleComboBox";
            this.gameRuleComboBox.Size = new System.Drawing.Size(121, 21);
            this.gameRuleComboBox.TabIndex = 18;
            this.gameRuleComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameRuleComboBox_KeyDown);
            // 
            // trueGRRadioButton
            // 
            this.trueGRRadioButton.AutoSize = true;
            this.trueGRRadioButton.Location = new System.Drawing.Point(389, 109);
            this.trueGRRadioButton.Name = "trueGRRadioButton";
            this.trueGRRadioButton.Size = new System.Drawing.Size(47, 17);
            this.trueGRRadioButton.TabIndex = 19;
            this.trueGRRadioButton.TabStop = true;
            this.trueGRRadioButton.Text = "True";
            this.trueGRRadioButton.UseVisualStyleBackColor = true;
            this.trueGRRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trueGRRadioButton_KeyDown);
            // 
            // falseGRRadioButton2
            // 
            this.falseGRRadioButton2.AutoSize = true;
            this.falseGRRadioButton2.Location = new System.Drawing.Point(442, 109);
            this.falseGRRadioButton2.Name = "falseGRRadioButton2";
            this.falseGRRadioButton2.Size = new System.Drawing.Size(50, 17);
            this.falseGRRadioButton2.TabIndex = 20;
            this.falseGRRadioButton2.TabStop = true;
            this.falseGRRadioButton2.Text = "False";
            this.falseGRRadioButton2.UseVisualStyleBackColor = true;
            this.falseGRRadioButton2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.falseGRRadioButton2_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(751, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Players Online:";
            // 
            // playerTxtOutput
            // 
            this.playerTxtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playerTxtOutput.Location = new System.Drawing.Point(754, 238);
            this.playerTxtOutput.Multiline = true;
            this.playerTxtOutput.Name = "playerTxtOutput";
            this.playerTxtOutput.Size = new System.Drawing.Size(162, 378);
            this.playerTxtOutput.TabIndex = 22;
            // 
            // txtInputCommand
            // 
            this.txtInputCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInputCommand.Location = new System.Drawing.Point(9, 199);
            this.txtInputCommand.Name = "txtInputCommand";
            this.txtInputCommand.Size = new System.Drawing.Size(528, 20);
            this.txtInputCommand.TabIndex = 23;
            this.txtInputCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputCommand_KeyDown);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // startServerCheckbox
            // 
            this.startServerCheckbox.AutoSize = true;
            this.startServerCheckbox.Location = new System.Drawing.Point(748, 8);
            this.startServerCheckbox.Name = "startServerCheckbox";
            this.startServerCheckbox.Size = new System.Drawing.Size(144, 17);
            this.startServerCheckbox.TabIndex = 24;
            this.startServerCheckbox.Text = "Start server automatically";
            this.startServerCheckbox.UseVisualStyleBackColor = true;
            this.startServerCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // gameRulesTxt
            // 
            this.gameRulesTxt.Location = new System.Drawing.Point(543, 238);
            this.gameRulesTxt.Multiline = true;
            this.gameRulesTxt.Name = "gameRulesTxt";
            this.gameRulesTxt.Size = new System.Drawing.Size(205, 378);
            this.gameRulesTxt.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Current Game Rules";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(748, 73);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(168, 20);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.Value = new System.DateTime(2020, 1, 18, 12, 1, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // automaticBackupsCheckBox
            // 
            this.automaticBackupsCheckBox.AutoSize = true;
            this.automaticBackupsCheckBox.Location = new System.Drawing.Point(748, 31);
            this.automaticBackupsCheckBox.Name = "automaticBackupsCheckBox";
            this.automaticBackupsCheckBox.Size = new System.Drawing.Size(117, 17);
            this.automaticBackupsCheckBox.TabIndex = 28;
            this.automaticBackupsCheckBox.Text = "Automatic backups";
            this.automaticBackupsCheckBox.UseVisualStyleBackColor = true;
            this.automaticBackupsCheckBox.CheckedChanged += new System.EventHandler(this.automaticBackupsCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(745, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Backup time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 628);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.automaticBackupsCheckBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gameRulesTxt);
            this.Controls.Add(this.startServerCheckbox);
            this.Controls.Add(this.txtInputCommand);
            this.Controls.Add(this.playerTxtOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.falseGRRadioButton2);
            this.Controls.Add(this.trueGRRadioButton);
            this.Controls.Add(this.gameRuleComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deOpTextBox1);
            this.Controls.Add(this.deOpPlayerButton);
            this.Controls.Add(this.opPlayerTextBox1);
            this.Controls.Add(this.opPlayerButton);
            this.Controls.Add(this.setWeatherButton);
            this.Controls.Add(this.weatherComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopServerButton);
            this.Controls.Add(this.startServerButton);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Minecraft Bedrock Server Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Button stopServerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox weatherComboBox;
        private System.Windows.Forms.Button setWeatherButton;
        private System.Windows.Forms.Button opPlayerButton;
        private System.Windows.Forms.TextBox opPlayerTextBox1;
        private System.Windows.Forms.Button deOpPlayerButton;
        private System.Windows.Forms.TextBox deOpTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox gameRuleComboBox;
        private System.Windows.Forms.RadioButton trueGRRadioButton;
        private System.Windows.Forms.RadioButton falseGRRadioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox playerTxtOutput;
        private System.Windows.Forms.TextBox txtInputCommand;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox startServerCheckbox;
        private System.Windows.Forms.TextBox gameRulesTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox automaticBackupsCheckBox;
        private System.Windows.Forms.Label label7;
    }
}

