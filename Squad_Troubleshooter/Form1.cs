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
        private static string DEFAULT_SQUAD_PATH = @"C:\Program Files (x86)\Steam\steamapps\common\Squad";
        private string CURRENT_SQUAD_PATH = "";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function goes through the Propertiest.Settings.Default and loads the lang and the path properties.
        /// This enables the path and language settings to persist after closing the tool.
        /// </summary>
        private void loadSettings()
        {
            SELECTED_LANGUAGE = Properties.Settings.Default["lang"].ToString();
            CURRENT_SQUAD_PATH = Properties.Settings.Default["path"].ToString();
            if (SELECTED_LANGUAGE == "ENGLISH")
            {
                englishToolStripMenuItem.Checked = true;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "GERMAN")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = true;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "POLISH")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = true;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "FRENCH")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = true;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "CHINESE")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = true;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "RUSSIAN")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = true;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "SWEDISH")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = true;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "DUTCH")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = true;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "SPANISH")
            {
                englishToolStripMenuItem.Checked = false;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = true;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
            else if (SELECTED_LANGUAGE == "PORTUGUESE-BRAZILIAN")
            {
                englishToolStripMenuItem.Checked = true;
                germanToolStripMenuItem.Checked = false;
                polishToolStripMenuItem.Checked = false;
                frenchToolStripMenuItem.Checked = false;
                chineseToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                swedishToolStripMenuItem.Checked = false;
                dutchToolStripMenuItem.Checked = false;
                spanishToolStripMenuItem.Checked = false;
                portugeseBrazilianToolStripMenuItem.Checked = false;
            }
        }

        /// <summary>
        /// This is the Form Load function. These actions occur everytime the tool is opened. It loads settings for
        /// persistent data. Sets the label, and switches the language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
            pathLbl.Text = "SQUAD INSTALL PATH: " + CURRENT_SQUAD_PATH;
            switchLanguage();
        }

        /// <summary>
        /// This function is the delete AppData configuration button click event. This goes to the directory
        /// %LOCALAPPDATA%\Squad and deletes the directory. This will wipe your video / control settings in game.
        /// This can be a good option if a patch has been released and something doesn't seem quite right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This generates a Windows Event Log, good to do after Squad crashes to desktop and you can't figure
        /// out why. It will place the log file on your Desktop. You can upload it to somewhere on the internet and
        /// attach it on the forums or email it to support@joinsquad.com for Squad support to take a look at.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///  This function will test whether a given path holds the Squad executables.
        /// </summary>
        /// <param name="PATH_TO_TEST"></param>
        /// <returns></returns>
        private bool testPath(string PATH_TO_TEST)
        {
            return (File.Exists(System.IO.Path.Combine(PATH_TO_TEST, "Squad.exe")));
        }
        
        /// <summary>
        /// Launches the EasyAntiCheat installer in the Squad install directory. Make sure you pick Squad as your game. You
        /// can either use the default Squad path, or pick a new path (which does persist through tool sessions).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            pathLbl.Text = "SQUAD INSTALL PATH: " + CURRENT_SQUAD_PATH;
            Properties.Settings.Default["path"] = CURRENT_SQUAD_PATH;
            Properties.Settings.Default.Save();
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
        
        /// <summary>
        /// Copies all squad logs including UE4 Dump files to your desktop into a SQUAD logs folder, zip it up
        /// or send individual files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This is the tool that will reinstall EAC, install VC_REDIST 2013 + 2015.
        /// </summary>
        /// <param name="toolToInstall"></param>
        /// <param name="INSTALL_PATH"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Attempts to silently install VC Redistributables 2013 and 2015. If any error occurs you may have to
        /// make sure your copy of Windows is up to date, make sure no updates are available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            pathLbl.Text = "SQUAD INSTALL PATH: " + CURRENT_SQUAD_PATH;
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
        
        /// <summary>
        /// Disables Windows firewall as a troubleshooting step if you are having networking issues.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Enables Windows firewall (for when Disabling your firewall did not solve your issue and you want to undo).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// It will provide a URL to visit with the confirmed fixes for the server browser crashes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getHelpBtn_Click(object sender, EventArgs e)
        {
            output_textbox.Clear();
            output_textbox.AppendText(Properties.Language.strings.SERVER_BROWSER_BUTTON + "\n");
            output_textbox.AppendText("=========================================\n");

            output_textbox.AppendText(Properties.Language.strings.GET_HELP_OUTPUT1 + "\n");
            output_textbox.AppendText(Properties.Language.strings.GET_HELP_OUTPUT2 + "\n");
        }

        /// <summary>
        /// This handles the Exit button click for the ToolStripMenuItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// This function will set the new CurrentCulture and CurrentUICulture and switch to the newly selected language.
        /// </summary>
        private void switchLanguage()
        {
            output_textbox.Clear();
            if (SELECTED_LANGUAGE == "ENGLISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                //Properties.Resources.lang = "ENGLISH";
                Properties.Settings.Default["lang"] = "ENGLISH";
            }
            else if (SELECTED_LANGUAGE == "GERMAN")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
                Properties.Settings.Default["lang"] = "GERMAN";
            }
            else if (SELECTED_LANGUAGE == "POLISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pl-PL");
                Properties.Settings.Default["lang"] = "POLISH";
            }
            else if (SELECTED_LANGUAGE == "FRENCH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR");
                Properties.Settings.Default["lang"] = "FRENCH";
            }
            else if (SELECTED_LANGUAGE == "CHINESE")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-CN");
                Properties.Settings.Default["lang"] = "CHINESE";
            }
            else if (SELECTED_LANGUAGE == "RUSSIAN")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
                Properties.Settings.Default["lang"] = "RUSSIAN";
            }
            else if (SELECTED_LANGUAGE == "SWEDISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sv-SE");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
                Properties.Settings.Default["lang"] = "SWEDISH";
            }
            else if (SELECTED_LANGUAGE == "DUTCH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("nl-NL");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("nl-NL");
                Properties.Settings.Default["lang"] = "DUTCH";
            }
            else if (SELECTED_LANGUAGE == "SPANISH")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("es-ES");
                Properties.Settings.Default["lang"] = "SPANISH";
            }
            else if (SELECTED_LANGUAGE == "PORTUGUESE-BRAZILIAN")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
                Properties.Settings.Default["lang"] = "PORTUGUESE-BRAZILIAN";
            }

            Properties.Settings.Default.Save();

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

        /// <summary>
        /// This will iterate through the Languages list and switch the checked item to the newly selected language.
        /// </summary>
        /// <param name="sender"></param>
        private void toggleChecked(object sender)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach(ToolStripMenuItem language in languagesToolStripMenuItem.DropDownItems)
            {
                language.Checked = language == item;
            }
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(englishToolStripMenuItem);
            SELECTED_LANGUAGE = "ENGLISH";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void germanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(germanToolStripMenuItem);
            SELECTED_LANGUAGE = "GERMAN";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void polishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(polishToolStripMenuItem);
            SELECTED_LANGUAGE = "POLISH";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(frenchToolStripMenuItem);
            SELECTED_LANGUAGE = "FRENCH";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(chineseToolStripMenuItem);
            SELECTED_LANGUAGE = "CHINESE";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(russianToolStripMenuItem);
            SELECTED_LANGUAGE = "RUSSIAN";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void swedishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(swedishToolStripMenuItem);
            SELECTED_LANGUAGE = "SWEDISH";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dutchToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    toggleChecked(dutchToolStripMenuItem);
        //    SELECTED_LANGUAGE = "DUTCH";
        //    switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(spanishToolStripMenuItem);
            SELECTED_LANGUAGE = "SPANISH";
            switchLanguage();
        }

        /// <summary>
        /// Switches to new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portugeseBrazilianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleChecked(portugeseBrazilianToolStripMenuItem);
            SELECTED_LANGUAGE = "PORTUGUESE-BRAZILIAN";
            switchLanguage();
        }
    }
}