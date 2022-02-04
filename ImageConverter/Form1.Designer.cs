namespace ImageConverter
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
            this.button_Open = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Convert = new System.Windows.Forms.Button();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxPalette = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSpace = new System.Windows.Forms.Label();
            this.pictureBoxReserved = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonRemoveReserved = new System.Windows.Forms.Button();
            this.buttonAddReserved = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReserved)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Open.ForeColor = System.Drawing.Color.Aquamarine;
            this.button_Open.Location = new System.Drawing.Point(33, 521);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(124, 29);
            this.button_Open.TabIndex = 1;
            this.button_Open.Text = "Open Image";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // button_save
            // 
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.ForeColor = System.Drawing.Color.Aquamarine;
            this.button_save.Location = new System.Drawing.Point(1308, 507);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(159, 44);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No preview available";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label2.Location = new System.Drawing.Point(799, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "No preview available";
            // 
            // button_Convert
            // 
            this.button_Convert.BackgroundImage = global::ImageConverter.Properties.Resources.forward;
            this.button_Convert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Convert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Convert.ForeColor = System.Drawing.Color.Turquoise;
            this.button_Convert.Location = new System.Drawing.Point(718, 254);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(54, 53);
            this.button_Convert.TabIndex = 4;
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.pictureBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRight.Image = global::ImageConverter.Properties.Resources.semi_tansparent_logo1;
            this.pictureBoxRight.Location = new System.Drawing.Point(778, 12);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(700, 550);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 0;
            this.pictureBoxRight.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.pictureBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLeft.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.Image")));
            this.pictureBoxLeft.InitialImage = null;
            this.pictureBoxLeft.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(700, 550);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxPalette
            // 
            this.pictureBoxPalette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxPalette.Location = new System.Drawing.Point(789, 509);
            this.pictureBoxPalette.Name = "pictureBoxPalette";
            this.pictureBoxPalette.Size = new System.Drawing.Size(512, 40);
            this.pictureBoxPalette.TabIndex = 8;
            this.pictureBoxPalette.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(723, 379);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(45, 72);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label3.Location = new System.Drawing.Point(716, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 40);
            this.label3.TabIndex = 10;
            this.label3.Text = "Conversion Space";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSpace
            // 
            this.labelSpace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSpace.AutoSize = true;
            this.labelSpace.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpace.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.labelSpace.Location = new System.Drawing.Point(725, 466);
            this.labelSpace.Name = "labelSpace";
            this.labelSpace.Size = new System.Drawing.Size(38, 17);
            this.labelSpace.TabIndex = 11;
            this.labelSpace.Text = "RGB";
            this.labelSpace.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxReserved
            // 
            this.pictureBoxReserved.Location = new System.Drawing.Point(724, 27);
            this.pictureBoxReserved.Name = "pictureBoxReserved";
            this.pictureBoxReserved.Size = new System.Drawing.Size(44, 166);
            this.pictureBoxReserved.TabIndex = 13;
            this.pictureBoxReserved.TabStop = false;
            this.pictureBoxReserved.Click += new System.EventHandler(this.pictureBoxReserved_Click);
            // 
            // buttonRemoveReserved
            // 
            this.buttonRemoveReserved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveReserved.Location = new System.Drawing.Point(745, 199);
            this.buttonRemoveReserved.Name = "buttonRemoveReserved";
            this.buttonRemoveReserved.Size = new System.Drawing.Size(23, 25);
            this.buttonRemoveReserved.TabIndex = 14;
            this.buttonRemoveReserved.Text = "-";
            this.buttonRemoveReserved.UseVisualStyleBackColor = true;
            this.buttonRemoveReserved.Click += new System.EventHandler(this.buttonRemoveReserved_Click);
            // 
            // buttonAddReserved
            // 
            this.buttonAddReserved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonAddReserved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddReserved.ForeColor = System.Drawing.Color.Lime;
            this.buttonAddReserved.Location = new System.Drawing.Point(719, 199);
            this.buttonAddReserved.Name = "buttonAddReserved";
            this.buttonAddReserved.Size = new System.Drawing.Size(23, 25);
            this.buttonAddReserved.TabIndex = 15;
            this.buttonAddReserved.Text = "+";
            this.buttonAddReserved.UseVisualStyleBackColor = true;
            this.buttonAddReserved.Click += new System.EventHandler(this.buttonAddReserved_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label4.Location = new System.Drawing.Point(718, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Reserved";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1490, 574);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddReserved);
            this.Controls.Add(this.buttonRemoveReserved);
            this.Controls.Add(this.pictureBoxReserved);
            this.Controls.Add(this.labelSpace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBoxPalette);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Convert);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NE Texture Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReserved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxPalette;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSpace;
        private System.Windows.Forms.PictureBox pictureBoxReserved;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonRemoveReserved;
        private System.Windows.Forms.Button buttonAddReserved;
        private System.Windows.Forms.Label label4;
    }
}

