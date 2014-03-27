﻿namespace Data_Gatherer_CSharp_Example
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.connect = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.SerialOutPut = new System.Windows.Forms.RichTextBox();
            this.light = new System.Windows.Forms.Button();
            this.vibrate = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.NumericUpDown();
            this.go = new System.Windows.Forms.Button();
            this.address = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type com port name:";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(210, 8);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(90, 23);
            this.connect.TabIndex = 2;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(118, 10);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(86, 20);
            this.port.TabIndex = 3;
            this.port.Text = "COM1";
            // 
            // SerialOutPut
            // 
            this.SerialOutPut.Location = new System.Drawing.Point(12, 126);
            this.SerialOutPut.Name = "SerialOutPut";
            this.SerialOutPut.Size = new System.Drawing.Size(288, 236);
            this.SerialOutPut.TabIndex = 4;
            this.SerialOutPut.Text = "";
            // 
            // light
            // 
            this.light.Location = new System.Drawing.Point(10, 40);
            this.light.Name = "light";
            this.light.Size = new System.Drawing.Size(75, 23);
            this.light.TabIndex = 5;
            this.light.Text = "Light On";
            this.light.UseVisualStyleBackColor = true;
            this.light.Click += new System.EventHandler(this.light_Click);
            // 
            // vibrate
            // 
            this.vibrate.Location = new System.Drawing.Point(10, 69);
            this.vibrate.Name = "vibrate";
            this.vibrate.Size = new System.Drawing.Size(77, 23);
            this.vibrate.TabIndex = 6;
            this.vibrate.Text = "Vibrate";
            this.vibrate.UseVisualStyleBackColor = true;
            this.vibrate.Click += new System.EventHandler(this.vibrate_Click);
            // 
            // time
            // 
            this.time.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.time.Location = new System.Drawing.Point(93, 69);
            this.time.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.time.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(111, 20);
            this.time.TabIndex = 7;
            this.time.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(10, 98);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(77, 23);
            this.go.TabIndex = 8;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(93, 100);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(207, 20);
            this.address.TabIndex = 9;
            this.address.Text = "http://www.google.co.uk";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 374);
            this.Controls.Add(this.address);
            this.Controls.Add(this.go);
            this.Controls.Add(this.time);
            this.Controls.Add(this.vibrate);
            this.Controls.Add(this.light);
            this.Controls.Add(this.SerialOutPut);
            this.Controls.Add(this.port);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Data Gatherer C# Example";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.RichTextBox SerialOutPut;
        private System.Windows.Forms.Button light;
        private System.Windows.Forms.Button vibrate;
        private System.Windows.Forms.NumericUpDown time;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.TextBox address;
    }
}

