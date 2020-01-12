using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Minecraft_Server_Manager
{
    public partial class Form1 : Form
    {

        Process minecraftProcess;
        StreamWriter mcInputStream;


        public delegate void fpTextBoxCallback_t(string strText);
        public fpTextBoxCallback_t fpTextBoxCallback;        

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
            InitializeComponent();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick); 
            timer.Interval = (5000) * (1);              
            timer.Enabled = true;                       
            timer.Start();                              


            List<string> weatherList = new List<string>();
            weatherList.Add("clear");
            weatherList.Add("rain");
            weatherList.Add("thunder");

            List<string> gameRuleList = new List<string>();
            gameRuleList.Add("commandblockoutput");
            gameRuleList.Add("commandblocksenabled");
            gameRuleList.Add("dodaylightcycle");
            gameRuleList.Add("doentitydrops");
            gameRuleList.Add("dofiretick");
            gameRuleList.Add("doimmediaterespawn");
            gameRuleList.Add("doinsomnia");
            gameRuleList.Add("domobloot");
            gameRuleList.Add("domobspawning");
            gameRuleList.Add("dotiledrops");
            gameRuleList.Add("doweathercycle");
            gameRuleList.Add("drowningdamage");
            gameRuleList.Add("falldamage");
            gameRuleList.Add("firedamage");
            gameRuleList.Add("functioncommandlimit");
            gameRuleList.Add("keepinventory");
            gameRuleList.Add("maxcommandchainlength");
            gameRuleList.Add("mobgriefing");
            gameRuleList.Add("naturalregeneration");
            gameRuleList.Add("pvp");
            gameRuleList.Add("randomtickspeed");
            gameRuleList.Add("sendcommandfeedback");
            gameRuleList.Add("showcoordinates");
            gameRuleList.Add("showdeathmessages");
            gameRuleList.Add("tntexplodes");


            weatherComboBox.DataSource = weatherList;

            gameRuleComboBox.DataSource = gameRuleList;

            
        } // End Constructor


        public void AddTextToOutputTextBox(string strText)
        {
            string blah = strText.Replace("\r\n", "");
            try
            {
                if (strText.Contains("players online"))
                {
                   strText = strText.Replace("\r\n", "");
                }
                if (blah.Contains(", xuid") || blah.Contains(", port"))
                {
                    this.txtOutput.AppendText(strText);
                    txtOutput.ScrollToCaret();
                }
                else if (strText.Contains("players online") || (!blah.Contains(" ") && strText.Length > 0) || blah.Contains(", ") )
                {
                    this.playerTxtOutput.AppendText(strText);
                }
                else
                {
                    this.txtOutput.AppendText(strText);
                    txtOutput.ScrollToCaret();
                }
                
            }
            catch (Exception ex)
            {

            }           


        } 


        //private void btnQuit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        mcInputStream.WriteLine("stop");
        //        Thread.Sleep(1000);
        //        mcInputStream.Close();
        //        minecraftProcess.Close();
        //        minecraftProcess.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    Application.Exit();

        //} 


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
            txtOutput.AppendText("\r\n\r\nThe server has been shutdown.\r\n");
        }


        private void backupButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
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
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                mcInputStream.WriteLine("stop");
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
            }
            catch
            {

            }
        }
        void timer_Tick(object sender, EventArgs e)
        {            
            try
            {                   
                playerTxtOutput.Clear();
                mcInputStream.WriteLine("list");                
            }
            catch
            {

            }
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
            mcInputStream.WriteLine("say THE SERVER IS GOING DOWN FOR A BACKUP IN 10 SECONDS");
            txtOutput.AppendText("\r\n\r\nTelling players the server is going down in 10 seconds\r\n");            
            
            Thread.Sleep(10000);
            txtOutput.AppendText("\r\nStopping Server\r\n");
            mcInputStream.WriteLine("stop");
            Thread.Sleep(5000);
            string source_dir = "";
            string destination_dir = "";

            source_dir = @"worlds";
            destination_dir = @"backups\worlds" + DateTime.Now.ToString("hhmmttMMddyyyy");


            txtOutput.AppendText("\r\nStarting Backup\r\n\r\n");
            foreach (string dir in System.IO.Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destination_dir, dir.Substring(source_dir.Length + 1)));               
            }

            foreach (string file_name in System.IO.Directory.GetFiles(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Copy(file_name, System.IO.Path.Combine(destination_dir, file_name.Substring(source_dir.Length + 1)));
                txtOutput.AppendText("Backing up: " + file_name + "    TO:    " + destination_dir + file_name + "\r\n\r\n");
                txtOutput.ScrollToCaret();
            }
            Thread.Sleep(5000);
            txtOutput.AppendText("\r\nBackup Complete. Starting server\r\n\r\n");

            startServerButton_Click(sender, e);
            
        }
    }


}