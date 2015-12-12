using Helenium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helenium.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ConfigurationForm : Form
    {
        /// <summary>
        /// The m_config
        /// </summary>
        ConfigData m_config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationForm"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public ConfigurationForm(ConfigData config)
        {
            this.m_config = config;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            MainForm mainForm = Owner as MainForm;
            int t;
            if (int.TryParse(tbDelayMs.Text, out t))
            {
                m_config.DelayMs = t;
                if (mainForm != null)
                    mainForm.ResetNavigateTimer();
            }
            m_config.UrlPattern = tbPattern.Text;
            m_config.IsDebugger = cbDebugger.Checked;
            m_config.LogPath = tbLogPath.Text.TrimEnd('\\', ' ');
            if (int.TryParse(tbMaxLevel.Text, out t))
            {
                m_config.MaxLevel = t;
            }
            m_config.UserData.PersonaName = textBoxName.Text;
            m_config.UserData.WebProficiency = nudWebProficiency.Value / 100;
            m_config.UserData.TaskCompexity = nudTaskComplexity.Value / 100;
            m_config.UserData.TaskImportance = nudTaskImportance.Value / 100;
            m_config.UserData.NoiseLevel = nudNoiseLevel.Value / 100;
            m_config.UserData.DeviceConvenience = nudDeviceConvenience.Value / 100;
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the ConfigurationForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            tbDelayMs.Text = m_config.DelayMs.ToString();
            tbPattern.Text = m_config.UrlPattern;
            cbDebugger.Checked = m_config.IsDebugger;
            tbLogPath.Text = m_config.LogPath;
            tbMaxLevel.Text = m_config.MaxLevel.ToString();
            textBoxName.Text = m_config.UserData.PersonaName;
            nudWebProficiency.Value = m_config.UserData.WebProficiency * 100;
            nudTaskComplexity.Value = m_config.UserData.TaskCompexity * 100;
            nudTaskImportance.Value = m_config.UserData.TaskImportance * 100;
            nudNoiseLevel.Value = m_config.UserData.NoiseLevel * 100;
            nudDeviceConvenience.Value = m_config.UserData.DeviceConvenience * 100;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            AverageTypingSpeed.Text = m_config.UserData.GetAverageTypingSpeed().ToString();
            MouseClickDistance.Text = m_config.UserData.GetMouseClickDistance().ToString();
            WrongKeyPressProbability.Text = m_config.UserData.GetWrongKeyPressProbability().ToString();
            VisualRecognitionPrecision.Text = m_config.UserData.GetVisualRecognitionPrecision().ToString();
            AverageActionDelay.Text = m_config.UserData.GetAverageActionDelay().ToString();
            SuddenSleepProbability.Text = m_config.UserData.GetSuddenSleepProbability().ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int w = panel1.ClientSize.Width;
            int h = panel1.ClientSize.Height;

            var pp = new Point[] {
                new Point(5,5),
            new Point( 10+((int)m_config.UserData.GetAverageTypingSpeed()*(w-15)/200), 5),
            new Point( 10+((int)m_config.UserData.GetMouseClickDistance() *(w-15)/200), 5 + (h-10)/6),
            new Point(10 + ((int)m_config.UserData.GetWrongKeyPressProbability() * (w - 15) / 1), 5 + (h - 10) / 6*2),
            new Point(10 + ((int)m_config.UserData.GetVisualRecognitionPrecision() * (w - 15) / 1), 5 + (h - 10) / 6*3),
            new Point(10 + ((int)m_config.UserData.GetAverageActionDelay() * (w - 15) / 10000), 5 + (h - 10) / 6*4),
            new Point(10 + ((int)m_config.UserData.GetMomentaryActionDelay() * (w - 15) / 10000), 5 + (h - 10) / 6*5),
            new Point(10 + ((int)m_config.UserData.GetSuddenSleepProbability() * (w - 15) / 1), 5 + (h - 10) / 6*6),
            new Point(5, h-5)
            };

            e.Graphics.FillPolygon(Brushes.Green, pp);

        }
    }
}
