using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace Weatherman
{
    partial class Weatherman
    {
        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

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
            this.PowerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Dialogue = new System.Windows.Forms.Label();
            this.TextTimer = new System.Windows.Forms.Timer(this.components);
            this.UserInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nsahack = new System.Windows.Forms.ProgressBar();
            this.weathermanLoad = new System.Windows.Forms.ProgressBar();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.email = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.viewContent = new System.Windows.Forms.Button();
            this.filecontent = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.email.SuspendLayout();
            this.filecontent.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.Location = new System.Drawing.Point(24, 415);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(46, 23);
            this.PowerButton.TabIndex = 0;
            this.PowerButton.Text = "Power";
            this.PowerButton.UseVisualStyleBackColor = true;
            this.PowerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Press Start 2P", 13.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(101, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = ">";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Dialogue
            // 
            this.Dialogue.AutoSize = true;
            this.Dialogue.Font = new System.Drawing.Font("Atari Classic Chunky", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dialogue.Location = new System.Drawing.Point(93, 54);
            this.Dialogue.Name = "Dialogue";
            this.Dialogue.Size = new System.Drawing.Size(0, 19);
            this.Dialogue.TabIndex = 3;
            this.Dialogue.Click += new System.EventHandler(this.label2_Click);
            // 
            // TextTimer
            // 
            this.TextTimer.Interval = 50;
            this.TextTimer.Tick += new System.EventHandler(this.TextTimer_Tick);
            // 
            // UserInput
            // 
            this.UserInput.BackColor = System.Drawing.SystemColors.MenuText;
            this.UserInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserInput.Font = new System.Drawing.Font("Atari Classic Chunky", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInput.ForeColor = System.Drawing.SystemColors.Menu;
            this.UserInput.Location = new System.Drawing.Point(129, 417);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(572, 19);
            this.UserInput.TabIndex = 4;
            this.UserInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.UserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInput_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.CausesValidation = false;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(97, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 25);
            this.panel1.TabIndex = 5;
            // 
            // nsahack
            // 
            this.nsahack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nsahack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nsahack.Location = new System.Drawing.Point(97, 385);
            this.nsahack.Name = "nsahack";
            this.nsahack.Size = new System.Drawing.Size(604, 23);
            this.nsahack.TabIndex = 6;
            // 
            // weathermanLoad
            // 
            this.weathermanLoad.Location = new System.Drawing.Point(97, 379);
            this.weathermanLoad.Name = "weathermanLoad";
            this.weathermanLoad.Size = new System.Drawing.Size(604, 29);
            this.weathermanLoad.TabIndex = 7;
            this.weathermanLoad.Visible = false;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 200;
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.email.Controls.Add(this.viewContent);
            this.email.Controls.Add(this.richTextBox1);
            this.email.Controls.Add(this.label4);
            this.email.Controls.Add(this.textBox2);
            this.email.Controls.Add(this.label3);
            this.email.Controls.Add(this.textBox1);
            this.email.Controls.Add(this.label2);
            this.email.Location = new System.Drawing.Point(634, 12);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(175, 226);
            this.email.TabIndex = 8;
            this.email.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "nsa@freedomfighters.net";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "From:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "KingWeather@LegitLawyers.ng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Message:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(6, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(156, 89);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "Helo. Look at this funny cat pictures!                                      __   " +
    "                                      Files to send:                            " +
    "                      funnycat.sh";
            // 
            // viewContent
            // 
            this.viewContent.Location = new System.Drawing.Point(6, 196);
            this.viewContent.Name = "viewContent";
            this.viewContent.Size = new System.Drawing.Size(156, 23);
            this.viewContent.TabIndex = 6;
            this.viewContent.Text = "View File Content";
            this.viewContent.UseVisualStyleBackColor = true;
            this.viewContent.Click += new System.EventHandler(this.viewContent_Click);
            // 
            // filecontent
            // 
            this.filecontent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.filecontent.Controls.Add(this.richTextBox2);
            this.filecontent.Location = new System.Drawing.Point(634, 245);
            this.filecontent.Name = "filecontent";
            this.filecontent.Size = new System.Drawing.Size(175, 106);
            this.filecontent.TabIndex = 9;
            this.filecontent.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(169, 100);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "mv /security /dev/null                             cat /etc/passwords.md >> myfil" +
    "e.txt                       ";
            // 
            // Weatherman
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(821, 453);
            this.Controls.Add(this.filecontent);
            this.Controls.Add(this.email);
            this.Controls.Add(this.weathermanLoad);
            this.Controls.Add(this.nsahack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dialogue);
            this.Controls.Add(this.PowerButton);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Weatherman";
            this.Text = "Weatherman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.email.ResumeLayout(false);
            this.email.PerformLayout();
            this.filecontent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PowerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Dialogue;
        private System.Windows.Forms.Timer TextTimer;
        private TextBox UserInput;
        private Panel panel1;
        private ProgressBar nsahack;
        private ProgressBar weathermanLoad;
        private Timer loadingTimer;
        private Panel email;
        private Label label2;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button viewContent;
        private Panel filecontent;
        private RichTextBox richTextBox2;
    }
}

