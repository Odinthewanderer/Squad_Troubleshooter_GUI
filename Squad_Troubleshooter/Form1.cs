using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Squad_Troubleshooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Deletes the squad folder in %LocalAppData% (this will wipe your video / control settings in game). 
        // a good option if a patch has been released and something doesn't seem right.
        private void nukeBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Nuke AppData config files\n");
            output_textbox.AppendText("=========================================\n");

            var path = Environment.GetEnvironmentVariable("LocalAppData");
            path = path + "\\Squad";

            try
            {
                // DEBUG STATEMENT : REMOVE WHEN COMPLETED
                //output_textbox.AppendText(path);

                //System.IO.Directory.Delete(path, true);
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
            }
            catch (IOException ie)
            {
                output_textbox.AppendText(ie.Message);
                return;
            }
            finally
            {
                output_textbox.AppendText("AppData directory ( " + path + " ) has been successfully nuked!");

            }
        }

        // Generates a Windows Event log, good to do after Squad Crashes to desktop and you can't figure out why, 
        // it will place the log file on your desktop, upload it to somewhere on the internet and attach it on 
        // the forums or email it to support@joinsquad.com for myself to take a look at it.
        private void generateBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Generate Windows event logs\n");
            output_textbox.AppendText("=========================================\n");

            string strCmdText;
            strCmdText = "/C wevtutil epl Application \"%userprofile%\\Desktop\\SQUADEventLogs.evtx\"";

            // DEBUG STATEMENT : REMOVE WHEN COMPLETE
            //output_textbox.AppendText(strCmdText);

            output_textbox.AppendText("Generating log files...\n");
            try
            {
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                output_textbox.AppendText("\n");
            }
            catch (Exception ex)
            {
                output_textbox.AppendText(ex.Message);
                return;
            }
            finally
            { 
                output_textbox.AppendText("Log files have been generated and are now on your desktop\n");
                output_textbox.AppendText("Log is saved as \'SQUADEventLogs.evtx\'\n");
                output_textbox.AppendText("Please send all log files to support@joinsquad.com\n");
            }
        }

        // Launches the EasyAntiCheat installer in the Squad install directory, make sure you pick squad as your game.
        private void reinstallBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Reinstall Easy Anticheat (EAC)\n");
            output_textbox.AppendText("=========================================\n");

            try
            {
                Process.Start("C:\\Program Files(x86)\\Steam\\steamapps\\common\\Squad\\EasyAntiCheat\\EasyAntiCheat_Setup.exe");
                //Process.Start("E:\\SteamLibrary\\steamapps\\common\\Squad\\EasyAntiCheat\\EasyAntiCheat_Setup.exe");
            }
            catch (Exception ex)
            {
                output_textbox.AppendText(ex.Message + "\n");
                return;
            }
            finally
            {
                output_textbox.AppendText("EAC has been reinstalled");
            }
        }

        // Copies all squad log files including UE4 Dump files to your desktop into a SQUAD logs folder, zip it up 
        // or send individual files.
        private void copyBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Copy Squad Logs to Desktop\n");
            output_textbox.AppendText("=========================================\n");

            string fileName = "Squad.log";
            var path = Environment.GetEnvironmentVariable("LocalAppData");
            path = path + "\\Squad\\Saved\\Logs\\" + fileName;

            var destPath = Environment.GetEnvironmentVariable("USERPROFILE");
            destPath = destPath + "\\Desktop\\Squad.log";

            // DEBUG STATEMENT : REMOVE WHEN COMPLETED
            //output_textbox.AppendText("FILE LOCATION: ");
            //output_textbox.AppendText(path);
            //output_textbox.AppendText("DESTINATION LOCATION: ");
            //output_textbox.AppendText(destPath);

            try
            {
                output_textbox.AppendText("Copying...\n");
                System.IO.File.Copy(path, destPath, true);
            }
            catch (IOException ie)
            {
                output_textbox.AppendText(ie.Message);
                return;
            }
            output_textbox.AppendText("Copy Complete!\n");
        }

        // Attempts to silently install VC Redistributables 2013 and 2015, if any error occurs you may have to 
        // make sure your copy of windows is up to date, make sure no updates are available
        private void installBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Install VC Redistributable 2013 + 2015\n");
            output_textbox.AppendText("=========================================\n");

            try
            {
                string sysCmd1 = "/C C:\\Program Files (x86)\\Steam\\steamapps\\common\\Squad\\_CommonRedist\\vcredist\\2013\\vcredist_x64.exe //install //passive //norestart";
                string sysCmd2 = "/C C:\\Program Files (x86)\\Steam\\steamapps\\common\\Squad\\_CommonRedist\\vcredist\\2015\\vc_redist.x64.exe //install //passive //norestart";

                Process.Start(sysCmd1);
                Process.Start(sysCmd2);
            }
            catch (Exception ex)
            {
                output_textbox.AppendText(ex.Message + "\n");
                return;
            }
            finally
            {
                output_textbox.AppendText("VC Redistributable installations complete");
            }
        }

        // Disables Windows firewall, as a troubleshooting step if your having networking issues
        private void disableBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Disable Windows Firewall\n");
            output_textbox.AppendText("=========================================\n");

            try
            {
                output_textbox.AppendText("Disabling the Windows firewall...");
                string sysCmd = "/C netsh advfirewall set allprofiles state off";
                System.Diagnostics.Process.Start("CMD.exe", sysCmd);
                output_textbox.AppendText("\n");
            }
            catch (Exception ex)
            {
                output_textbox.AppendText(ex.Message);
                return;
            }
            finally
            {
                output_textbox.AppendText("Firewall Disabled\n");
            }
        }

        // Enable Windows firewall, (for when F didn't solve your issue and you want to undo)
        private void enableBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Enable Windows Firewall\n");
            output_textbox.AppendText("=========================================\n");

            try
            {
                output_textbox.AppendText("Enabling the Windows firewall...");
                string sysCmd = "/C netsh advfirewall set allprofiles state on";
                System.Diagnostics.Process.Start("CMD.exe", sysCmd);
                output_textbox.AppendText("\n");
            }
            catch (Exception ex)
            {
                output_textbox.AppendText(ex.Message);
                return;
            }
            finally
            {
                output_textbox.AppendText("Firewall Enabled\n");
            }
        }

        // will provide a URL to visit with the confirmed fix for server browser crashes.
        private void getHelpBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Get help with game crashing on Server Browser\n");
            output_textbox.AppendText("=========================================\n");

            output_textbox.AppendText("If you are experiancing game crashes when using the Server Browser in game copy the following URL and visit the forums: \n");
            output_textbox.AppendText("http://goo.gl/yvTOfS \n");
        }
    }
}