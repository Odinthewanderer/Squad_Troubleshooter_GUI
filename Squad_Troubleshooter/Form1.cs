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
using System.Globalization;
using System.Resources;
using System.Threading;

namespace Squad_Troubleshooter
{
    public partial class Form1 : Form
    {

        private string SELECTED_LANGUAGE = "ENGLISH";
        private static string DEFAULT_SQUAD_PATH = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Squad";
        private string CURRENT_SQUAD_PATH = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pathLbl.Text = "DEFAULT SQUAD PATH: " + DEFAULT_SQUAD_PATH;
            SELECTED_LANGUAGE = "ENGLISH";
            englishToolStripMenuItem.Checked = true;
            germanToolStripMenuItem.Checked = false;
            polishToolStripMenuItem.Checked = false;
            frenchToolStripMenuItem.Checked = false;
            chineseToolStripMenuItem.Checked = false;
            russianToolStripMenuItem.Checked = false;
            swedishToolStripMenuItem.Checked = false;
            dutchToolStripMenuItem.Checked = false;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            switchLanguage();
        }

        // Deletes the squad folder in %LocalAppData% (this will wipe your video / control settings in game). 
        // a good option if a patch has been released and something doesn't seem right.
        private void nukeBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.NUKE_BUTTON + "\n");
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
                output_textbox.AppendText(Properties.Language.strings.NUKE_OUTPUT1 + "( " + path + " ) " + Properties.Language.strings.NUKE_OUTPUT2 + "\n");
            }
        }

        // Generates a Windows Event log, good to do after Squad Crashes to desktop and you can't figure out why, 
        // it will place the log file on your desktop, upload it to somewhere on the internet and attach it on 
        // the forums or email it to support@joinsquad.com for myself to take a look at it.
        private void generateBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.GENERATE_BUTTON + "\n");
            output_textbox.AppendText("=========================================\n");

            string strCmdText;
            strCmdText = "/C wevtutil epl Application \"%userprofile%\\Desktop\\SQUADEventLogs.evtx\"";
            
            output_textbox.AppendText(Properties.Language.strings.GENERATING_OUTPUT1 + "\n");
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
                output_textbox.AppendText(Properties.Language.strings.GENERATING_OUTPUT2 + "\n");
                output_textbox.AppendText(Properties.Language.strings.GENERATING_OUTPUT3 + "\'SQUADEventLogs.evtx\'\n");
                output_textbox.AppendText(Properties.Language.strings.GENERATING_OUTPUT4 + "\n");
            }
        }

        private bool testPath(string PATH_TO_TEST)
        {
            return (File.Exists(System.IO.Path.Combine(PATH_TO_TEST, "Squad.exe")));
        }

        // Launches the EasyAntiCheat installer in the Squad install directory, make sure you pick squad as your game.
        private void reinstallBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            DialogResult dialogResult = MessageBox.Show(Properties.Language.strings.PATH_CONFIRM + "\n" + DEFAULT_SQUAD_PATH, Properties.Language.strings.CONFIRM_TITLE, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CURRENT_SQUAD_PATH = DEFAULT_SQUAD_PATH;
            }
            else
            {
                FolderBrowserDialog directoryBroswer = new FolderBrowserDialog();
                DialogResult result = directoryBroswer.ShowDialog();

                if (!string.IsNullOrWhiteSpace(directoryBroswer.SelectedPath))
                {
                    CURRENT_SQUAD_PATH = directoryBroswer.SelectedPath;
                }
            }
            pathLbl.Text = CURRENT_SQUAD_PATH;
            if(testPath(System.IO.Path.Combine(CURRENT_SQUAD_PATH, "Squad.exe")))
            {
                output_textbox.AppendText(System.IO.Path.Combine(CURRENT_SQUAD_PATH, "Squad.exe") + "\n");
                installTool(1, CURRENT_SQUAD_PATH);
            }
            else
            {
                output_textbox.AppendText(Properties.Language.strings.REINSTALL_ERROR_OUTPUT1 + "\n");
                output_textbox.AppendText(Properties.Language.strings.REINSTALL_ERROR_OUTPUT2 + "\n");
            }
        }

        // Copies all squad log files including UE4 Dump files to your desktop into a SQUAD logs folder, zip it up 
        // or send individual files.
        private void copyBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.COPY_OUTPUT1 + "\n");
            output_textbox.AppendText("=========================================\n");

            string fileName = "Squad.log";
            var path = Environment.GetEnvironmentVariable("LocalAppData");
            path = path + "\\Squad\\Saved\\Logs\\" + fileName;

            var destPath = Environment.GetEnvironmentVariable("USERPROFILE");
            destPath = destPath + "\\Desktop\\Squad.log";

            try
            {
                output_textbox.AppendText(Properties.Language.strings.COPY_OUTPUT2 + "\n");
                System.IO.File.Copy(path, destPath, true);
            }
            catch (IOException ie)
            {
                output_textbox.AppendText(ie.Message);
                return;
            }
            output_textbox.AppendText(Properties.Language.strings.COPY_OUTPUT3 + "\n");
        }

        private bool installTool(int toolToInstall, string INSTALL_PATH)
        {
            // This will install the requested tool.
            // 1. EAC
            // 2. vc_redist (2013)
            // 3. vc_redist (2015)

            string VCREDIST_PATH_2013 = System.IO.Path.Combine(INSTALL_PATH, "_CommonRedist", "vcredist", "2013", "vc_redist.x64.exe");
            string VCREDIST_PATH_2015 = System.IO.Path.Combine(INSTALL_PATH, "_CommonRedist", "vcredist", "2015", "vc_redist.x64.exe");
            string EAC_PATH = System.IO.Path.Combine(INSTALL_PATH, "EasyAntiCheat", "EasyAntiCheat_Setup.exe");

            switch (toolToInstall)
            {
                case 1:
                    // RUN EAC INSTALLER
                    if (File.Exists(EAC_PATH))
                    {
                        output_textbox.AppendText(Properties.Language.strings.REINSTALL_OUTPUT1 + "\n");
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
                            output_textbox.AppendText(Properties.Language.strings.REINSTALL_OUTPUT2 + "\n");
                        }
                    }
                    else
                    {
                        output_textbox.AppendText(Properties.Language.strings.REINSTALL_ERROR_OUTPUT1 + "\n");
                        output_textbox.AppendText(Properties.Language.strings.REINSTALL_ERROR_OUTPUT2 + "\n");
                    }
                    break;
                case 2:
                    // RUN VC_REDIST (2013) INSTALLER
                    if (File.Exists(VCREDIST_PATH_2013))
                    {
                        output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2013_OUTPUT1 + "\n");
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
                            output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2013_OUTPUT2 + "\n");
                        }
                    }
                    else
                    {
                        output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2013_ERROR_OUTPUT1 + "\n");
                        output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2013_ERROR_OUTPUT2 + "\n");
                    }
                    break;
                case 3:
                    // RUN VC_REDIST (2015) INSTALLER
                    if (File.Exists(VCREDIST_PATH_2015))
                    {
                        output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2015_OUTPUT1 + "\n");
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
                            output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2015_OUTPUT2 + "\n");
                        }
                    }
                    else
                    {
                        output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2015_ERROR_OUTPUT1 + "\n");
                        output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2015_ERROR_OUTPUT2 + "\n");
                    }
                    break;
                default:
                    // OUTPUT ERROR AND EXIT
                    output_textbox.AppendText(Properties.Language.strings.UNKNOWN_ERROR + "\n");
                    break;
            }
            return false;
        }

        // Attempts to silently install VC Redistributables 2013 and 2015, if any error occurs you may have to 
        // make sure your copy of windows is up to date, make sure no updates are available
        private void installBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.Clear();
            DialogResult dialogResult = MessageBox.Show(Properties.Language.strings.PATH_CONFIRM + "\n" + DEFAULT_SQUAD_PATH, Properties.Language.strings.CONFIRM_TITLE, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CURRENT_SQUAD_PATH = DEFAULT_SQUAD_PATH;
            }
            else
            {
                FolderBrowserDialog directoryBroswer = new FolderBrowserDialog();
                DialogResult result = directoryBroswer.ShowDialog();

                if (!string.IsNullOrWhiteSpace(directoryBroswer.SelectedPath))
                {
                    CURRENT_SQUAD_PATH = directoryBroswer.SelectedPath;
                }
            }
            pathLbl.Text = CURRENT_SQUAD_PATH;
            if (testPath(System.IO.Path.Combine(CURRENT_SQUAD_PATH, "Squad.exe")))
            {
                output_textbox.AppendText(System.IO.Path.Combine(CURRENT_SQUAD_PATH, "Squad.exe") + "\n");
                installTool(2, CURRENT_SQUAD_PATH);
                installTool(3, CURRENT_SQUAD_PATH);
            }
            else
            {
                output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2013_ERROR_OUTPUT1 + "\n");
                output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2013_ERROR_OUTPUT2 + "\n");
                output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2015_ERROR_OUTPUT1 + "\n");
                output_textbox.AppendText(Properties.Language.strings.INSTALL_VCREDIST_2015_ERROR_OUTPUT2 + "\n");
            }
        }

        // Disables Windows firewall, as a troubleshooting step if your having networking issues
        private void disableBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.DISABLE_FIREWALL_BUTTON + "\n");
            output_textbox.AppendText("=========================================\n");

            try
            {
                output_textbox.AppendText(Properties.Language.strings.DISABLE_OUTPUT1 + "\n");
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
                output_textbox.AppendText(Properties.Language.strings.DISABLE_OUTPUT2 + "\n");
            }
        }

        // Enable Windows firewall, (for when F didn't solve your issue and you want to undo)
        private void enableBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.ENABLE_FIREWALL_BUTTON + "\n");
            output_textbox.AppendText("=========================================\n");

            try
            {
                output_textbox.AppendText(Properties.Language.strings.ENABLE_OUTPUT1 + "\n");
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
                output_textbox.AppendText(Properties.Language.strings.ENABLE_OUTPUT2 + "\n");
            }
        }

        // will provide a URL to visit with the confirmed fix for server browser crashes.
        private void getHelpBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.SERVER_BROWSER_BUTTON + "\n");
            output_textbox.AppendText("=========================================\n");

            output_textbox.AppendText(Properties.Language.strings.GET_HELP_OUTPUT1 + "\n");
            output_textbox.AppendText(Properties.Language.strings.GET_HELP_OUTPUT2 + "\n");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void switchLanguage()
        {
            output_textbox.Clear();
            if (SELECTED_LANGUAGE == "ENGLISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            }
            else if (SELECTED_LANGUAGE == "GERMAN")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            }
            else if (SELECTED_LANGUAGE == "POLISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pl-PL");
            }
            else if (SELECTED_LANGUAGE == "FRENCH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR");
            }
            else if (SELECTED_LANGUAGE == "CHINESE")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-CN");
            }
            else if (SELECTED_LANGUAGE == "RUSSIAN")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            }
            else if (SELECTED_LANGUAGE == "SWEDISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sv-SE");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
            }
            else if (SELECTED_LANGUAGE == "DUTCH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("nl-NL");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("nl-NL");
            }
            else if (SELECTED_LANGUAGE == "SPANISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("es-ES");
            }
            else if (SELECTED_LANGUAGE == "PORTUGESE-BRAZILIAN")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
            }

            //MessageBox.Show(Properties.Language.strings.APP_TITLE);
            fileToolStripMenuItem.Text = Properties.Language.strings.FILE_MENU_PARENT;
            exitToolStripMenuItem.Text = Properties.Language.strings.FILE_MENU_EXIT;

            languagesToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_PARENT;
            englishToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_ENGLISH;
            spanishToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_SPANISH;
            chineseToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_CHINESE;
            dutchToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_DUTCH;
            frenchToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_FRENCH;
            germanToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_GERMAN;
            polishToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_POLISH;
            russianToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_RUSSIAN;
            swedishToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_SWEDISH;
            portugeseBrazilianToolStripMenuItem.Text = Properties.Language.strings.LANGUAGES_MENU_PORTUGUESE_BRAZILIAN;

            nukeBtn.Text = Properties.Language.strings.NUKE_BUTTON;
            copyBtn.Text = Properties.Language.strings.LOGS_BUTTON;
            generateBtn.Text = Properties.Language.strings.GENERATE_BUTTON;
            reinstallBtn.Text = Properties.Language.strings.EAC_BUTTON;
            installBtn.Text = Properties.Language.strings.VCREDIST_BUTTON;
            disableBtn.Text = Properties.Language.strings.DISABLE_FIREWALL_BUTTON;
            enableBtn.Text = Properties.Language.strings.ENABLE_FIREWALL_BUTTON;
            getHelpBtn.Text = Properties.Language.strings.SERVER_BROWSER_BUTTON;
        }

        private void toggleChecked(object sender)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach(ToolStripMenuItem language in languagesToolStripMenuItem.DropDownItems)
            {
                language.Checked = language == item;
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(englishToolStripMenuItem);
            SELECTED_LANGUAGE = "ENGLISH";
            switchLanguage();
        }

        private void germanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(germanToolStripMenuItem);
            SELECTED_LANGUAGE = "GERMAN";
            switchLanguage();
        }

        private void polishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(polishToolStripMenuItem);
            SELECTED_LANGUAGE = "POLISH";
            switchLanguage();
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(frenchToolStripMenuItem);
            SELECTED_LANGUAGE = "FRENCH";
            switchLanguage();
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(chineseToolStripMenuItem);
            SELECTED_LANGUAGE = "CHINESE";
            switchLanguage();
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(russianToolStripMenuItem);
            SELECTED_LANGUAGE = "RUSSIAN";
            switchLanguage();
        }

        private void swedishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(swedishToolStripMenuItem);
            SELECTED_LANGUAGE = "SWEDISH";
            switchLanguage();
        }

        private void dutchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(dutchToolStripMenuItem);
            SELECTED_LANGUAGE = "DUTCH";
            switchLanguage();
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(spanishToolStripMenuItem);
            SELECTED_LANGUAGE = "SPANISH";
            switchLanguage();
        }

        private void portugeseBrazilianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(portugeseBrazilianToolStripMenuItem);
            SELECTED_LANGUAGE = "PORTUGESE-BRAZILIAN";
            switchLanguage();
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directoryBroswer = new FolderBrowserDialog();
            DialogResult result = directoryBroswer.ShowDialog();

            if (!string.IsNullOrWhiteSpace(directoryBroswer.SelectedPath))
            {
                MessageBox.Show(directoryBroswer.SelectedPath);
            }
            else
            {
                MessageBox.Show("NULL");
            }
        }
    }
}