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
            
            try
            {
                var path = Environment.GetEnvironmentVariable("LocalAppData");
                path = path + "\\Squad";

                // DEBUG STATEMENT : REMOVE WHEN COMPLETED
                //output_textbox.AppendText(path);

                System.IO.Directory.Delete(path, true);
                output_textbox.AppendText("AppData directory ( " + path + " ) has been successfully nuked!");
            }
            catch (IOException ie)
            {
                output_textbox.AppendText(ie.Message);
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
        }

        // Launches the EasyAntiCheat installer in the Squad install directory, make sure you pick squad as your game.
        private void reinstallBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Reinstall Easy Anticheat (EAC)\n");
            output_textbox.AppendText("=========================================\n");
        }

        // Copies all squad log files including UE4 Dump files to your desktop into a SQUAD logs folder, zip it up 
        // or send individual files.
        private void copyBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Copy Squad Logs to Desktop\n");
            output_textbox.AppendText("=========================================\n");
        }

        // Attempts to silently install VC Redistributables 2013 and 2015, if any error occurs you may have to 
        // make sure your copy of windows is up to date, make sure no updates are available
        private void installBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Install VC Redistributable 2013 + 2015\n");
            output_textbox.AppendText("=========================================\n");
        }

        // Disables Windows firewall, as a troubleshooting step if your having networking issues
        private void disableBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Disable Windows Firewall\n");
            output_textbox.AppendText("=========================================\n");
        }

        // Enable Windows firewall, (for when F didn't solve your issue and you want to undo)
        private void enableBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Enable Windows Firewall\n");
            output_textbox.AppendText("=========================================\n");
        }

        // will provide a URL to visit with the confirmed fix for server browser crashes.
        private void getHelpBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText("Get help with game crashing on Server Browser\n");
            output_textbox.AppendText("=========================================\n");
        }
    }
}
