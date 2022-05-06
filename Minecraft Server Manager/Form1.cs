using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Globalization;

namespace Minecraft_Server_Manager
{
    public partial class Form1 : Form
    {

        Process minecraftProcess;
        StreamWriter mcInputStream;

        string players = "Loading Player List.....";
        string players2 = "";

        public static bool backupStatus = false;
        private System.Threading.Timer timer;

        public delegate void fpTextBoxCallback_t(string strText);
        public fpTextBoxCallback_t fpTextBoxCallback;        

        public Form1()
        {            
            string startServer = ConfigurationManager.AppSettings["startServer"].ToString();
            string automaticBackups = ConfigurationManager.AppSettings["automaticBackups"].ToString();
            
            Lists lists = new Lists();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
            InitializeComponent();
            _Form1 = this;


            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick); 
            timer.Interval = (5000) * (1);              
            timer.Enabled = true;                       
            timer.Start();

            //dateTimePicker1.Text = date;

            //Fill Listboxes on form
            List<string> weatherList = lists.WeatherList();
            List<string> gameRuleList = lists.GameRuleList();
           

            if (startServer == "true")
            {
                startServerCheckbox.Checked = true;
            }

            if (automaticBackups == "true")
            {
                int backupInterval = Convert.ToInt32(ConfigurationManager.AppSettings["backupInterval"]);
                automaticBackupsCheckBox.Checked = true;
                //SetUpTimer();
                backupLabel.Text = "Backup Interval: " + backupInterval + " Minutes";
                BackupTimer(backupInterval);
            }

            weatherComboBox.DataSource = weatherList;

            gameRuleComboBox.DataSource = gameRuleList;

            if(startServer == "true")
            {
                startServerButton_Click(null, EventArgs.Empty);
            }

            
        } // End Constructor

        public static Form1 _Form1;

        int restartTryLimit = 0;

        private void BackupTimer(int interval)
        {
            System.Windows.Forms.Timer backupTimer = new System.Windows.Forms.Timer();
            backupTimer.Tick += new EventHandler(BackupTimer_Tick);
            backupTimer.Interval = interval * 1000 * 60;
            backupTimer.Enabled = true;
            backupTimer.Start();
        }
        public void AddTextToOutputTextBox(string strText)
        {
            
            string modifiedText = strText.Replace("\r\n", "");
            try
            {

                
                if(modifiedText.Contains("db/MANIFEST") || modifiedText.Contains("Saving..."))
                {
                    return;
                }
                if (modifiedText.Contains("CrashReporter") && restartTryLimit < 3)
                {
                    Thread.Sleep(5000);
                    startServerButton_Click(null, EventArgs.Empty);
                    restartTryLimit++;
                    return;
                }
                if (modifiedText.Contains("Server Started."))
                {
                    restartTryLimit = 0;
                }
                if (modifiedText.Contains("Network port occupied, can't start server."))
                {
                    this.txtOutput.AppendText(strText);
                    txtOutput.ScrollToCaret();
                    File.AppendAllText(@"ServerLog.txt", strText);
                    return;
                }
                if (modifiedText.Contains("commandblock") && modifiedText.Contains("="))
                {
                    string removeComma = modifiedText.Replace(", ", "\r\n");
                    gameRulesTxt.Text = removeComma;
                    return;
                }
                if (strText.Contains("players online"))
                {
                   strText = strText.Replace("\r\n", "");
                }
                if (modifiedText.Contains(", xuid") || modifiedText.Contains(", port"))
                {
                    this.txtOutput.AppendText(strText);
                    txtOutput.ScrollToCaret();
                    File.AppendAllText(@"ServerLog.txt",strText);
                }
                else if (strText.Contains("players online"))
                {                    
                    players = players + strText + "\r\n";
                }               

                else if (strText.Contains("players online") || (!modifiedText.Contains(" ") && strText.Length > 0) || modifiedText.Contains(", ") )
                {
                    string removeCR = strText.Replace("\r\n","");
                    removeCR = removeCR.Replace(" ", "");
                    string[] names = removeCR.Split(',');                 
                    Array.Sort(names);
                    string result = string.Join("\r\n", names);                 
                    players = players + result;
                    
                }
                else if (modifiedText.Contains("Data saved. Files are now ready to be copied."))
                {
                    this.txtOutput.AppendText("\r\n" + modifiedText + "\r\n");
                    backupStatus = true;
                }
                else
                {
                    this.txtOutput.AppendText(strText);
                    txtOutput.ScrollToCaret();
                    File.AppendAllText(@"ServerLog.txt", strText);
                }
                
            }
            catch (Exception ex)
            {

            }           


        } 

        private void ConsoleOutputHandler(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                if (this.InvokeRequired)
                    this.Invoke(fpTextBoxCallback, Environment.NewLine + outLine.Data);
                else
                    fpTextBoxCallback(Environment.NewLine + outLine.Data);
            }
            
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.minecraftProcess.HasExited)
                {
                    txtOutput.AppendText("\r\n\r\nThe server has been shutdown.\r\n");
                    AppendToLog("The server has been shutdown");
                    return;
                }
                mcInputStream.WriteLine(txtInputCommand.Text);

            }
            catch
            {

            }
        }


        public void ProcessExited(object sender, EventArgs e)
        {
            TextOutput("\r\n\r\nThe server has been shutdown.\r\n");
            AppendToLog("The server has been shutdown");

        }
        public void AppendToLog(string logText)
        {
            File.AppendAllText(@"ServerLog.txt", "\r\n" + DateTime.Now.ToString() + " " + logText + "\r\n");
        }
        public void TextOutput(string text)
        {
            this.Invoke(new MethodInvoker(delegate { txtOutput.AppendText(text); }));
        }
        public void TextScroll()
        {
            this.Invoke(new MethodInvoker(delegate { txtOutput.ScrollToCaret(); }));
        }
        public void MineCraftTextInput(string text)
        {
            this.Invoke(new MethodInvoker(delegate { mcInputStream.WriteLine(text); }));
        }
        private void backupButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                startServerButton.Enabled = false;
                string processFileName = "";


                processFileName = @"bedrock_server.exe";


                minecraftProcess = new System.Diagnostics.Process();

                minecraftProcess.StartInfo.FileName = processFileName;

                AddTextToOutputTextBox("Using this terminal: " + minecraftProcess.StartInfo.FileName);

                minecraftProcess.StartInfo.UseShellExecute = false;
                minecraftProcess.StartInfo.CreateNoWindow = true;
                minecraftProcess.StartInfo.RedirectStandardInput = true;
                minecraftProcess.StartInfo.RedirectStandardOutput = true;
                minecraftProcess.StartInfo.RedirectStandardError = true;

                minecraftProcess.EnableRaisingEvents = true;
                minecraftProcess.Exited += new EventHandler(ProcessExited);
                minecraftProcess.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
                minecraftProcess.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);

                minecraftProcess.Start();

                mcInputStream = minecraftProcess.StandardInput;
                minecraftProcess.BeginOutputReadLine();
                minecraftProcess.BeginErrorReadLine();

                mcInputStream.WriteLine("gamerule");
            }
            catch
            {
                MessageBox.Show("Please make sure the Minecraft Server Manager.exe is in your Minecraft Server folder");
            }
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                mcInputStream.WriteLine("stop");
                playerTxtOutput.Clear();
                gameRulesTxt.Clear();
                startServerButton.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnProcessExit(object sender, EventArgs e)
        {           
            mcInputStream.WriteLine("stop");
            Thread.Sleep(5000);
        }

        private void weatherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void setWeatherButton_Click(object sender, EventArgs e)
        {
            try
            {
                mcInputStream.WriteLine("weather " + weatherComboBox.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void opPlayerButton_Click(object sender, EventArgs e)
        {
            try
            {
                mcInputStream.WriteLine("op " + opPlayerTextBox1.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deOpPlayerButton_Click(object sender, EventArgs e)
        {
            try
            {
                mcInputStream.WriteLine("deop " + deOpTextBox1.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string trueFalse = " false";
            if (trueGRRadioButton.Checked)
                trueFalse = " true";
            if (falseGRRadioButton2.Checked)
                trueFalse = " false";
            try
            {
                mcInputStream.WriteLine("gamerule " + gameRuleComboBox.SelectedItem + trueFalse);
                mcInputStream.WriteLine("gamerule ");
            }
            catch
            {

            }
        }
        void timer_Tick(object sender, EventArgs e)
        {            
            try
            {                
                if(players != players2)
                {
                    playerTxtOutput.Clear();
                    playerTxtOutput.Text = players;
                }
                //playerTxtOutput.Clear();
                mcInputStream.WriteLine("list");                
                players = players2;                
            }
            catch
            {

            }
        }
        void BackupTimer_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void txtInputCommand_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
                btnExecute_Click(sender, e);
           
        }

        private void weatherComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                setWeatherButton_Click(sender, e);
        }

        private void opPlayerTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                opPlayerButton_Click(sender, e);
        }

        private void deOpTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                deOpPlayerButton_Click(sender, e);
        }

        private void gameRuleComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void trueGRRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void falseGRRadioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            TextOutput("\r\nStarting the server backup.\r\n");
            ServerBackup.StartBackup();

            while (backupStatus == false)
            {                
                ServerBackup.QueryBackup();
                Thread.Sleep(1000);
            }            

            ServerBackup.BackupFiles();

            ServerBackup.FinishBackup();
            backupStatus = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);            
            configuration.Save(ConfigurationSaveMode.Modified);
            if (startServerCheckbox.Checked)
            {
                configuration.AppSettings.Settings["startServer"].Value = "true";
                configuration.Save(ConfigurationSaveMode.Modified);
            }
            if (!startServerCheckbox.Checked)
            {                
                configuration.AppSettings.Settings["startServer"].Value = "false";
                configuration.Save(ConfigurationSaveMode.Modified);
            }

        }


        private void automaticBackupsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.Save(ConfigurationSaveMode.Modified);
            if (automaticBackupsCheckBox.Checked)
            {
                configuration.AppSettings.Settings["automaticBackups"].Value = "true";
                configuration.Save(ConfigurationSaveMode.Modified);
                backupLabel.Show();
            }
            if (!automaticBackupsCheckBox.Checked)
            {
                configuration.AppSettings.Settings["automaticBackups"].Value = "false";
                configuration.Save(ConfigurationSaveMode.Modified);
                backupLabel.Hide();
            }

        }

    }
}


