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
        public static void Backup()
        {
            var form = Form1._Form1;
            form.MineCraftTextInput("say THE SERVER IS GOING DOWN FOR A BACKUP IN 10 SECONDS");
            form.TextOutput("\r\n\r\nTelling players the server is going down in 10 seconds\r\n");

            form.AppendToLog("Telling players the server is going down in 10 seconds");
            Thread.Sleep(10000);
            form.TextOutput("\r\nStopping Server\r\n");


            form.AppendToLog("Stopping Server");

            form.MineCraftTextInput("stop");

            Thread.Sleep(5000);
            string source_dir = "";
            string destination_dir = "";

            source_dir = @"worlds";
            destination_dir = @"backups\worlds" + DateTime.Now.ToString("hhmmttMMddyyyy");
            form.TextOutput("\r\nStarting Backup\r\n\r\n");

            form.AppendToLog("Starting Backup");
            foreach (string dir in System.IO.Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destination_dir, dir.Substring(source_dir.Length + 1)));
            }

            foreach (string file_name in System.IO.Directory.GetFiles(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Copy(file_name, System.IO.Path.Combine(destination_dir, file_name.Substring(source_dir.Length + 1)));
                form.TextOutput("Backing up: " + file_name + "    TO:    " + destination_dir + file_name + "\r\n\r\n");
                File.AppendAllText(@"ServerLog.txt", DateTime.Now.ToString() + " " + "Backing up: " + file_name + "    TO:    " + destination_dir + file_name + "\r\n");
                form.TextScroll();

            }
            Thread.Sleep(5000);
            form.TextOutput("\r\nBackup Complete. Starting server\r\n\r\n");
            form.AppendToLog("Starting Server");
        }
    }
}
