using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft_Server_Manager
{
    class ServerBackup
    {     
        public static void BackupFiles()
        {
            var form = Form1._Form1;
            string source_dir = "";
            string destination_dir = "";

            source_dir = @"worlds";
            destination_dir = @"backups\worlds" + DateTime.Now.ToString("hhmmssttMMddyyyy");
            form.TextOutput("\r\nStarting File Backup\r\n\r\n");

            form.AppendToLog("Starting File Backup");
            foreach (string dir in System.IO.Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destination_dir, dir.Substring(source_dir.Length + 1)));
            }

            foreach (string file_name in System.IO.Directory.GetFiles(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Copy(file_name, System.IO.Path.Combine(destination_dir, file_name.Substring(source_dir.Length + 1)));
                //form.TextOutput("Backing up: " + file_name + "    TO:    " + destination_dir + file_name + "\r\n\r\n");
                File.AppendAllText(@"ServerLog.txt", DateTime.Now.ToString() + " " + "Backing up: " + file_name + "    TO:    " + destination_dir + file_name + "\r\n");
                form.TextScroll();

            }
            form.TextOutput("Files backed up to: " + destination_dir);
            form.TextOutput("\r\nFile Backup Complete.\r\n\r\n");
        }

        public static void StartBackup()
        {
            var form = Form1._Form1;
            form.MineCraftTextInput("save hold");
        }
        public static void QueryBackup()
        {
            var form = Form1._Form1;            
            form.MineCraftTextInput("save query");
        }
        public static void FinishBackup()
        {
            var form = Form1._Form1;            
            form.MineCraftTextInput("save resume");
        }


    }
}
