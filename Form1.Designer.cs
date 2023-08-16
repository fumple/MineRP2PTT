namespace PTT
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentDevice = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.shortcutTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.muteCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aktualne urządzenie:";
            // 
            // labelCurrentDevice
            // 
            this.labelCurrentDevice.AutoSize = true;
            this.labelCurrentDevice.Location = new System.Drawing.Point(12, 26);
            this.labelCurrentDevice.Name = "labelCurrentDevice";
            this.labelCurrentDevice.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentDevice.TabIndex = 4;
            this.labelCurrentDevice.Text = "label2";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(15, 42);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(128, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Odśwież";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // shortcutTextBox
            // 
            this.shortcutTextBox.Location = new System.Drawing.Point(15, 84);
            this.shortcutTextBox.Name = "shortcutTextBox";
            this.shortcutTextBox.Size = new System.Drawing.Size(128, 20);
            this.shortcutTextBox.TabIndex = 6;
            this.shortcutTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shortcutTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Skrót klawiszowy:";
            // 
            // muteCheckbox
            // 
            this.muteCheckbox.AutoSize = true;
            this.muteCheckbox.Location = new System.Drawing.Point(15, 136);
            this.muteCheckbox.Name = "muteCheckbox";
            this.muteCheckbox.Size = new System.Drawing.Size(161, 17);
            this.muteCheckbox.TabIndex = 9;
            this.muteCheckbox.Text = "Twój mikrofon jest odciszony";
            this.muteCheckbox.UseVisualStyleBackColor = true;
            this.muteCheckbox.CheckedChanged += new System.EventHandler(this.muteCheckbox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PTT.Properties.Resources.logofinal;
            this.pictureBox1.Location = new System.Drawing.Point(261, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Zapisz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 165);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.muteCheckbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortcutTextBox);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelCurrentDevice);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MineRP Push To Talk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentDevice;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox shortcutTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox muteCheckbox;
        private System.Windows.Forms.Button button1;
    }
}

