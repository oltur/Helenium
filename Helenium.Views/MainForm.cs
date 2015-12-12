using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using mshtml;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.ObjectModel;
using Helenium.Models;
using Helenium.Tools;
using Helenium.DAL;

namespace Helenium.Views
{
    /// <summary>
    /// Main App Form implementation
    /// </summary>
    public partial class MainForm : Form
    {
        #region Varibales
        /// <summary>
        /// The database
        /// </summary>
        private HeleniumDbContext db = new HeleniumDbContext();
        /// <summary>
        /// The script
        /// </summary>
        private const string script = @"
{0};
function SCRIPT_DC5C201F_C7E3_4379_8B4E_61DE116A76C8() {{ 

  window.onerror = function(message, url, lineNumber) 
  {{ 
    window.external.ErrorHandler(message, url, lineNumber);
    return true;
  }}

  window.onload = function() 
  {{ 
    var base = document.URL.substr(0,document.URL.lastIndexOf('/'));
    var level_DC5C201F_C7E3_4379_8B4E_61DE116A76C8 = {1};
    var result = '';
    for(var i = 0, l=document.links.length; i<l; i++) {{
      window.external.AddUrl(document.links[i], level_DC5C201F_C7E3_4379_8B4E_61DE116A76C8 + 1); 
    }}
  window.external.AppendScreenshot();
  }}

}}
";
 
        /// <summary>
        /// The configuration
        /// </summary>
        ConfigData Config;
        /// <summary>
        /// The form script manager
        /// </summary>
        private ScriptManager FormScriptManager;
        /// <summary>
        /// The locker
        /// </summary>
        private object locker;
        /// <summary>
        /// The has navigated
        /// </summary>
        private bool hasNavigated = true;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            try
            {
                Config = db.ConfigData.Include("UserData").First();
                db.Entry(Config).Collection(c => c.Errors).Load();
             }
            catch
            {
                ConfigDataInitializer.DoInit(db);
                
                Config = db.ConfigData.Include("UserData").First();
                db.Entry(Config).Collection(c => c.Errors).Load();
            }

            ResetNavigateTimer();
            locker = new object();

            FormScriptManager = new ScriptManager(this);
            wbMain.ObjectForScripting = FormScriptManager;
            wbMain.Navigated +=
                delegate
                {
                    lock (locker)
                    {
                        try
                        {
                            string t = string.Format(script, Config.IsDebugger ? "debugger;" : "", FormScriptManager.LastLevel);

                            HtmlElement scriptElement = wbMain.Document.CreateElement("script");
                            IHTMLScriptElement domElement = (IHTMLScriptElement)scriptElement.DomElement;
                            domElement.text = t;
                            var t2 = wbMain.Document.GetElementsByTagName("html");
                            var t3 = t2[0];
                            var tt = t3.AppendChild(scriptElement);
                            string result =
                                (string)
                                wbMain.Document.InvokeScript("SCRIPT_DC5C201F_C7E3_4379_8B4E_61DE116A76C8");
                        }
                        catch (Exception ex) 
                        {
                            AppendLog(Resources.Resources.ScriptError + ": " + ex.Message, true);
                        }
                    }
                };

            SHDocVw.WebBrowser wb2 = (SHDocVw.WebBrowser)wbMain.ActiveXInstance;
            wb2.NavigateError += wb2_NavigateError;
        }
        #endregion

        #region Interface
        /// <summary>
        /// Resets the navigate timer.
        /// </summary>
        internal void ResetNavigateTimer()
        {
            navigateTimer.Stop();
            navigateTimer.Interval = Config.DelayMs;
            navigateTimer.Start();
        }


        /// <summary>
        /// Determines whether [is URL visited] [the specified URL].
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public bool IsUrlVisited(string url)
        {
            return Config.Urls.Any(x => x.URL == url && x.Visited);
        }

        /// <summary>
        /// Determines whether [is URL added] [the specified URL].
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public bool IsUrlAdded(string url)
        {
            return Config.Urls.Any(x => x.URL == url);
        }

        /// <summary>
        /// Adds the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="level">The level.</param>
        public void AddUrl(string url, int level)
        {
            if (!IsUrlAdded(url) && level <= Config.MaxLevel)
                Config.AddUrl(url, false, level);
        }
        #endregion

        #region Implementation

        /// <summary>
        /// Appends the log.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="forceSave">if set to <c>true</c> [force save].</param>
        private void AppendLog(string msg, bool forceSave = false)
        {
            Config.AppendLog(msg, forceSave);
            if (forceSave)
                db.SaveChanges();
        }

        /// <summary>
        /// Shows the HTML.
        /// </summary>
        private void ShowHtml()
        {
            if (Config.HasChanged)
            {
                wbLog.InvokeIfRequired(() =>
                {
                    HtmlDocument doc = this.wbLog.Document;
                    //doc.Write(Html.ToString());
                    wbLog.DocumentText = Config.GetLog();

                    //wbLog.Document.Body.ScrollIntoView(false);
                });
            }
        }

        /// <summary>
        /// Appends the screenshot.
        /// </summary>
        private void AppendScreenshot()
        {
            Application.DoEvents();
            Thread.Sleep(10);
            Application.DoEvents();
            Bitmap bmp = wbMain.DrawToImage();
            var image = new Bitmap(bmp, 500, bmp.Height * 500 / bmp.Width);
            AppendLog(ControlExtensions.GetDataURL(image));
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Config.IsRunnning = false;
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of the btnContinue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            AppendLog(Resources.Resources.Testiscontinued, true);
            Config.IsRunnning = true;
        }

        /// <summary>
        /// Handles the Click event of the btnStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            AppendLog(Resources.Resources.Testispaused, true);
            ShowHtml();
            Config.IsRunnning = false;
        }

        int navigatedCounter = 0;
        /// <summary>
        /// Handles the Tick event of the navigateTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void navigateTimer_Tick(object sender, EventArgs e)
        {
            if (!hasNavigated)
            {
                if(navigatedCounter++ > 10)
                {
                    hasNavigated = true;
                    navigatedCounter = 0;
                }
            }
            else
            {
                if (Config.IsRunnning)
                {
                    lock (locker)
                    {
                        NavigateToNextPage();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Tick event of the updateUItimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void updateUItimer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
            Application.DoEvents();
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Config.IsRunnning = false;
            Thread.Sleep(Config.DelayMs);
            foreach (var err in Config.Errors.ToList())
            {
                db.ErrorData.Remove(err);
            }
            Config.Clear();
            db.SaveChanges();

        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Config.IsRunnning)
            {
                if (MessageBox.Show(this, Resources.Resources.Stopthetestandclosetheapplication, Resources.Resources.Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    AppendLog(Resources.Resources.Teststopped, true);
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                AppendLog("Test stopped", true);
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            var cf = new ConfigurationForm(Config);
            cf.ShowDialog(this);
            db.SaveChanges();
        }
        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Config.Errors.ToList().ForEach(x => sb.AppendLine(x.Message));
            MessageBox.Show(sb.ToString());
        }

        /// <summary>
        /// Updates the UI.
        /// </summary>
        private void UpdateUI()
        {
            if (Config.HasChanged)
            {
                StringBuilder builder = new StringBuilder();
                foreach (URLData url in Config.Urls)
                {
                     builder.AppendLine(url.ToString());
                }
                tbVisitedURLs.Text = builder.ToString();
                ShowHtml();
                var t = Config.Urls;
                if (t != null)
                    lblURLInfo.Text = string.Format(Resources.Resources.TVT, t.Count(), t.Count(u => u.Visited), t.Count(u => !u.Visited));

                db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// WB2_s the navigate error.
        /// </summary>
        /// <param name="pDisp">The p disp.</param>
        /// <param name="URL">The URL.</param>
        /// <param name="Frame">The frame.</param>
        /// <param name="StatusCode">The status code.</param>
        /// <param name="Cancel">if set to <c>true</c> [cancel].</param>
        void wb2_NavigateError(object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel)
        {
            lock (locker)
            {
                AppendLog("<p style='color:red'>" + Resources.Resources.HTTPerror + ": " + ((int)StatusCode).ToString() + ", url: " + URL + "</p>");
                Cancel = false;
            }
        }
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var cf = new ConfigurationForm(Config);
            if (cf.ShowDialog(this) == DialogResult.OK)
            {
                db.SaveChanges();

                AppendLog(string.Format(Resources.Resources.Testisstarted,Environment.UserName,Environment.MachineName), false);

                AddUrl(tbStartURL.Text, 0);
                Config.IsRunnning = true;
            }
        }

        /// <summary>
        /// Navigates to next page.
        /// </summary>
        private void NavigateToNextPage()
        {
            var urlData = Config.Urls.FirstOrDefault(u => !u.Visited);

            if (urlData != null)
            {
                if (!hasNavigated)
                    return;

                try
                {
                    string t = Config.UrlPattern;
                    if (string.IsNullOrWhiteSpace(t) || urlData.URL.Contains(t.Trim()))
                    {
                        FormScriptManager.LastLevel = urlData.Level;
                        hasNavigated = false;
                        wbMain.Navigate(urlData.URL);

                        AppendLog(Resources.Resources.Tobevisited + ": " + urlData.ToString());
                    }

                    if (Config.Urls.First(x => x.URL == urlData.URL) == null)
                        Config.AddUrl(urlData);
                    else
                        Config.Urls.First(x => x.URL == urlData.URL).Visited = true;
                }
                catch (Exception ex)
                {
                    AppendLog(Resources.Resources.Internalerror + ": " + ex.Message, true);
                }
            }
            else
            {
                AppendLog(Resources.Resources.NomoreURLStovisit, true);
                Config.IsRunnning = false;
            }
        }
        #endregion

        #region ScriptManager
        /// <summary>
        /// App interface for JavaScript scripting
        /// </summary>
        [ComVisible(true)]
        public class ScriptManager
        {
            // Variable to store the form.
            /// <summary>
            /// The m form
            /// </summary>
            private MainForm mForm;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="form">Parent form</param>
            public ScriptManager(MainForm form)
            {
                // Save the form so it can be referenced later.
                mForm = form;
            }

            /// <summary>
            /// The last level
            /// </summary>
            public int LastLevel;

            /// <summary>
            /// Determines whether [is URL visited] [the specified URL].
            /// </summary>
            /// <param name="url">The URL.</param>
            /// <returns></returns>
            public bool IsUrlVisited(string url)
            {
                return IsUrlVisited(url);
            }

            /// <summary>
            /// Determines whether [is URL added] [the specified URL].
            /// </summary>
            /// <param name="url">The URL.</param>
            /// <returns></returns>
            public bool IsUrlAdded(string url)
            {
                return mForm.IsUrlAdded(url);
            }

            /// <summary>
            /// Adds the URL.
            /// </summary>
            /// <param name="url">The URL.</param>
            /// <param name="level">The level.</param>
            public void AddUrl(string url, int level)
            {
                mForm.AddUrl(url, level);
            }

            /// <summary>
            /// Appends the screenshot.
            /// </summary>
            public void AppendScreenshot()
            {
                try
                {
                    Thread.Sleep(50);
                    mForm.AppendScreenshot();
                }
                finally
                {
                    mForm.hasNavigated = true;
                }

            }

            /// <summary>
            /// Logs the error in JavaScript.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="url">The URL.</param>
            /// <param name="lineNumber">The line number.</param>
            public void ErrorHandler(string message, string url, int lineNumber)
            {
                string s = "<p style='color:red'>"+Resources.Resources.ScriptError+": " + message + ", url: " + url + ", line:" + lineNumber.ToString() + "</p>";
                mForm.AppendLog(s);
                mForm.Config.Errors.Add(new ErrorData { Message = s, Parent = mForm.Config });
            }
        }
        #endregion

    }
}
