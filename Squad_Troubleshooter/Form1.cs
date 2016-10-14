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
using Microsoft.Win32;
using System.Security.Permissions;


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
                System.IO.Directory.Delete(path, true);
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
            installTool(1);
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

        private string getSteamPath()
        {
            string steamPath = "";
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.OpenSubKey(@"Software\Valve\Steam");

            if (regKey != null)
            {
                steamPath = (regKey.GetValue("SteamPath").ToString());
            }

            return steamPath;
        }

        private string getSquadLibraryPath(string steamPath)
        {
            string line = "";
            //string[] possiblePaths = new string[5];
            //string pattern = "\"[0-9]\"";
            //System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);

            string SQUAD_LIBRARY_PATH = "";
            string SQUAD_EXE_PATH = "";
            string DEFAULT_PATH = (System.IO.Path.Combine(steamPath, "steamapps", "common", "Squad")).Replace("/", "\\");
            string STEAM_PATH = steamPath.Replace("/", "\\");
            string VDF_PATH = (System.IO.Path.Combine(steamPath, "steamapps", "libraryfolders.vdf")).Replace("/", "\\");
            
            StreamReader file = new StreamReader(VDF_PATH);
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("\"1\""))
                {
                    line = line.Replace("\t", " ");
                    line = line.Replace("\"", "");
                    line = line.Replace(" ", "");
                    line = line.Remove(0, 1);
                    line = line.Replace("\\\\", "\\");
                    SQUAD_EXE_PATH = System.IO.Path.Combine(line, "steamapps", "common", "Squad", "Squad.exe");
                }
            }
            file.Close();
            
            if(File.Exists(SQUAD_EXE_PATH))
            {
                return (SQUAD_LIBRARY_PATH);
            }
            else
            {
                return DEFAULT_PATH;
            }
        }


        private bool installTool(int toolToInstall)
        {
            // This will install the requested tool.
            // 1. EAC
            // 2. vc_redist (2013)
            // 3. vc_redist (2015)

            string steamPath = getSteamPath();
            string libraryPath = getSquadLibraryPath(steamPath);

            string VCREDIST_PATH_2013 = System.IO.Path.Combine(libraryPath, "_CommonRedist", "vcredist", "2013", "vc_redist.x64.exe");
            string VCREDIST_PATH_2015 = System.IO.Path.Combine(libraryPath, "_CommonRedist", "vcredist", "2015", "vc_redist.x64.exe");
            string EAC_PATH = System.IO.Path.Combine(libraryPath, "EasyAntiCheat", "EasyAntiCheat_Setup.exe");

            switch (toolToInstall)
            {
                case 1:
                    // RUN EAC INSTALLER
                    if (File.Exists(EAC_PATH))
                    {
                        output_textbox.AppendText("Instlaling EasyAntiCheat_Setup.exe...");
                        try
                        {
                            string installCommand = "/C " + EAC_PATH;
                            var process = Process.Start(installCommand);
                            process.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            output_textbox.AppendText(ex.Message + "\n");
                            break;
                        }
                        finally
                        {
                            output_textbox.AppendText("EAC installation complete");
                        }
                    }
                    else
                    {
                        output_textbox.AppendText("No binaries for EasyAntiCheat_Setup.exe...\n");
                        output_textbox.AppendText("Skipping EasyAntiCheat_Setup.exe install...");
                    }
                    break;
                case 2:
                    // RUN VC_REDIST (2013) INSTALLER
                    if (File.Exists(VCREDIST_PATH_2013))
                    {
                        output_textbox.AppendText("Installing vc_redist.x64.exe...");
                        try
                        {
                            string installCommand = "/C " + VCREDIST_PATH_2013 + " //install //passive //norestart";
                            var process = Process.Start(installCommand);
                            process.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            output_textbox.AppendText(ex.Message + "\n");
                            break;
                        }
                        finally
                        {
                            output_textbox.AppendText("VC Redistributable installation complete");
                        }
                    }
                    else
                    {
                        output_textbox.AppendText("No binaries for vc_redist.x64.exe...\n");
                        output_textbox.AppendText("Skipping vc_redist.x64.exe (2013) install...");
                    }
                    break;
                case 3:
                    // RUN VC_REDIST (2015) INSTALLER
                    if (File.Exists(VCREDIST_PATH_2015))
                    {
                        output_textbox.AppendText("Installing vc_redist.x64.exe...");
                        try
                        {
                            string installCommand = "/C " + VCREDIST_PATH_2015 + " //install //passive //norestart";
                            Process.Start(installCommand);
                        }
                        catch (Exception ex)
                        {
                            output_textbox.AppendText(ex.Message + "\n");
                            break;
                        }
                        finally
                        {
                            output_textbox.AppendText("VC Redistributable installation complete");
                        }
                    }
                    else
                    {
                        output_textbox.AppendText("No binaries for vc_redist.x64.exe...\n");
                        output_textbox.AppendText("Skipping vc_redist.x64.exe (2015) install...");
                    }
                    break;
                default:
                    // OUTPUT ERROR AND EXIT
                    output_textbox.AppendText("Something went wrong...");
                    break;
            }
            return false;
        }

        // Attempts to silently install VC Redistributables 2013 and 2015, if any error occurs you may have to 
        // make sure your copy of windows is up to date, make sure no updates are available
        private void installBtn_Click(object sender, EventArgs e)
        {
            installTool(2);
            installTool(3);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}