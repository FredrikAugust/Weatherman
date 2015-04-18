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
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.Location = new System.Drawing.Point(12, 418);
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
            this.label1.Location = new System.Drawing.Point(133, 341);
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
            this.Dialogue.Location = new System.Drawing.Point(125, 28);
            this.Dialogue.Name = "Dialogue";
            this.Dialogue.Size = new System.Drawing.Size(0, 19);
            this.Dialogue.TabIndex = 3;
            this.Dialogue.Click += new System.EventHandler(this.label2_Click);
            // 
            // TextTimer
            // 
            this.TextTimer.Tick += new System.EventHandler(this.TextTimer_Tick);
            // 
            // UserInput
            // 
            this.UserInput.BackColor = System.Drawing.SystemColors.MenuText;
            this.UserInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserInput.Font = new System.Drawing.Font("Atari Classic Chunky", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInput.ForeColor = System.Drawing.SystemColors.Menu;
            this.UserInput.Location = new System.Drawing.Point(161, 340);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(572, 19);
            this.UserInput.TabIndex = 4;
            this.UserInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.CausesValidation = false;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(129, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 25);
            this.panel1.TabIndex = 5;
            // 
            // Weatherman
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(821, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dialogue);
            this.Controls.Add(this.PowerButton);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Weatherman";
            this.Text = "Weatherman";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

