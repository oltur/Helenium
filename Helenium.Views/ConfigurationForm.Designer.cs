namespace Helenium.Views
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbPattern = new System.Windows.Forms.TextBox();
            this.cbDebugger = new System.Windows.Forms.CheckBox();
            this.tbLogPath = new System.Windows.Forms.TextBox();
            this.tbMaxLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDelayMs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudTaskImportance = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nudTaskComplexity = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudNoiseLevel = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudDeviceConvenience = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudWebProficiency = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxPersonas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuddenSleepProbability = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.MomentaryActionDelay = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.AverageActionDelay = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.VisualRecognitionPrecision = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.WrongKeyPressProbability = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.MouseClickDistance = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.AverageTypingSpeed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.userDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskImportance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskComplexity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoiseLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeviceConvenience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWebProficiency)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.tbPattern);
            this.tabPage1.Controls.Add(this.cbDebugger);
            this.tabPage1.Controls.Add(this.tbLogPath);
            this.tabPage1.Controls.Add(this.tbMaxLevel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbDelayMs);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbPattern
            // 
            resources.ApplyResources(this.tbPattern, "tbPattern");
            this.tbPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPattern.Name = "tbPattern";
            // 
            // cbDebugger
            // 
            resources.ApplyResources(this.cbDebugger, "cbDebugger");
            this.cbDebugger.Name = "cbDebugger";
            this.cbDebugger.UseVisualStyleBackColor = true;
            // 
            // tbLogPath
            // 
            resources.ApplyResources(this.tbLogPath, "tbLogPath");
            this.tbLogPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogPath.Name = "tbLogPath";
            // 
            // tbMaxLevel
            // 
            resources.ApplyResources(this.tbMaxLevel, "tbMaxLevel");
            this.tbMaxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaxLevel.Name = "tbMaxLevel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbDelayMs
            // 
            resources.ApplyResources(this.tbDelayMs, "tbDelayMs");
            this.tbDelayMs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDelayMs.Name = "tbDelayMs";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.textBoxName);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.nudTaskImportance);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.nudTaskComplexity);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.nudNoiseLevel);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.nudDeviceConvenience);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.nudWebProficiency);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.comboBoxPersonas);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.Name = "textBoxName";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // nudTaskImportance
            // 
            resources.ApplyResources(this.nudTaskImportance, "nudTaskImportance");
            this.nudTaskImportance.Name = "nudTaskImportance";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // nudTaskComplexity
            // 
            resources.ApplyResources(this.nudTaskComplexity, "nudTaskComplexity");
            this.nudTaskComplexity.Name = "nudTaskComplexity";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // nudNoiseLevel
            // 
            resources.ApplyResources(this.nudNoiseLevel, "nudNoiseLevel");
            this.nudNoiseLevel.Name = "nudNoiseLevel";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // nudDeviceConvenience
            // 
            resources.ApplyResources(this.nudDeviceConvenience, "nudDeviceConvenience");
            this.nudDeviceConvenience.Name = "nudDeviceConvenience";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // nudWebProficiency
            // 
            resources.ApplyResources(this.nudWebProficiency, "nudWebProficiency");
            this.nudWebProficiency.Name = "nudWebProficiency";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboBoxPersonas
            // 
            resources.ApplyResources(this.comboBoxPersonas, "comboBoxPersonas");
            this.comboBoxPersonas.FormattingEnabled = true;
            this.comboBoxPersonas.Name = "comboBoxPersonas";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.SuddenSleepProbability);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.MomentaryActionDelay);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.AverageActionDelay);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.VisualRecognitionPrecision);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.WrongKeyPressProbability);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.MouseClickDistance);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.AverageTypingSpeed);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SuddenSleepProbability
            // 
            resources.ApplyResources(this.SuddenSleepProbability, "SuddenSleepProbability");
            this.SuddenSleepProbability.Name = "SuddenSleepProbability";
            this.SuddenSleepProbability.ReadOnly = true;
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // MomentaryActionDelay
            // 
            resources.ApplyResources(this.MomentaryActionDelay, "MomentaryActionDelay");
            this.MomentaryActionDelay.Name = "MomentaryActionDelay";
            this.MomentaryActionDelay.ReadOnly = true;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // AverageActionDelay
            // 
            resources.ApplyResources(this.AverageActionDelay, "AverageActionDelay");
            this.AverageActionDelay.Name = "AverageActionDelay";
            this.AverageActionDelay.ReadOnly = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // VisualRecognitionPrecision
            // 
            resources.ApplyResources(this.VisualRecognitionPrecision, "VisualRecognitionPrecision");
            this.VisualRecognitionPrecision.Name = "VisualRecognitionPrecision";
            this.VisualRecognitionPrecision.ReadOnly = true;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // WrongKeyPressProbability
            // 
            resources.ApplyResources(this.WrongKeyPressProbability, "WrongKeyPressProbability");
            this.WrongKeyPressProbability.Name = "WrongKeyPressProbability";
            this.WrongKeyPressProbability.ReadOnly = true;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // MouseClickDistance
            // 
            resources.ApplyResources(this.MouseClickDistance, "MouseClickDistance");
            this.MouseClickDistance.Name = "MouseClickDistance";
            this.MouseClickDistance.ReadOnly = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // AverageTypingSpeed
            // 
            resources.ApplyResources(this.AverageTypingSpeed, "AverageTypingSpeed");
            this.AverageTypingSpeed.Name = "AverageTypingSpeed";
            this.AverageTypingSpeed.ReadOnly = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // userDataBindingSource
            // 
            this.userDataBindingSource.DataSource = typeof(Helenium.Models.UserData);
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskImportance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskComplexity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoiseLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeviceConvenience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWebProficiency)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbPattern;
        private System.Windows.Forms.CheckBox cbDebugger;
        private System.Windows.Forms.TextBox tbLogPath;
        private System.Windows.Forms.TextBox tbMaxLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDelayMs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown nudWebProficiency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxPersonas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudTaskImportance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudTaskComplexity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudNoiseLevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudDeviceConvenience;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox SuddenSleepProbability;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox MomentaryActionDelay;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox AverageActionDelay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox VisualRecognitionPrecision;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox WrongKeyPressProbability;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox MouseClickDistance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox AverageTypingSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource userDataBindingSource;
    }
}