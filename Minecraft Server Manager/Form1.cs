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
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
            InitializeComponent();

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
            try
            {
                this.txtOutput.AppendText(strText);
            }
            catch (Exception ex)
            {

            }
        } 


        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                mcInputStream.WriteLine("stop");
                Thread.Sleep(1000);
                mcInputStream.Close();
                minecraftProcess.Close();
                minecraftProcess.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Application.Exit();

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
            if (this.minecraftProcess.HasExited)
            {
                MessageBox.Show("The server has been shutdown.", "Info");
                return;
            }

            mcInputStream.WriteLine(txtInputCommand.Text);
        }


        public void ProcessExited(object sender, EventArgs e)
        {
            MessageBox.Show("The server has been shutdown.", "Info");
        }


        private void backupButton_Click(object sender, EventArgs e)
        {
            mcInputStream.WriteLine("say THE SERVER IS GOING DOWN FOR A BACKUP IN 10 SECONDS");
            MessageBox.Show("Telling players the server is going down in 10 seconds, Please click ok to contiue with the backup");
            Thread.Sleep(10000);
            mcInputStream.WriteLine("stop");
            Thread.Sleep(1000);
            string source_dir = "";
            string destination_dir = "";

            source_dir = @"worlds";
            destination_dir = @"backups\worlds" + DateTime.Now.ToString("hhmmttMMddyyyy");



            foreach (string dir in System.IO.Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destination_dir, dir.Substring(source_dir.Length + 1)));

            }

            foreach (string file_name in System.IO.Directory.GetFiles(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Copy(file_name, System.IO.Path.Combine(destination_dir, file_name.Substring(source_dir.Length + 1)));
            }

            MessageBox.Show("Backup Complete. Please start the server again");


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
            mcInputStream.WriteLine("stop");
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
            mcInputStream.WriteLine("weather " + weatherComboBox.SelectedItem);
        }

        private void opPlayerButton_Click(object sender, EventArgs e)
        {
            mcInputStream.WriteLine("op " + opPlayerTextBox1.Text.ToString());
        }

        private void deOpPlayerButton_Click(object sender, EventArgs e)
        {
            mcInputStream.WriteLine("deop " + deOpTextBox1.Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string trueFalse = " false";
            if (trueGRRadioButton.Checked)
                trueFalse = " true";
            if (falseGRRadioButton2.Checked)
                trueFalse = " false";

            mcInputStream.WriteLine("gamerule " + gameRuleComboBox.SelectedItem + trueFalse);
        }
    }


}