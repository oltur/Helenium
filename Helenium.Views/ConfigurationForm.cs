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
        }

    }
}
