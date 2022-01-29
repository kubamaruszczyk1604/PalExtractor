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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Open.ForeColor = System.Drawing.Color.Aquamarine;
            this.button_Open.Location = new System.Drawing.Point(12, 573);
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
            this.button_save.Location = new System.Drawing.Point(1320, 574);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(124, 28);
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
            this.label2.Location = new System.Drawing.Point(783, 28);
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
            this.button_Convert.Location = new System.Drawing.Point(718, 251);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(40, 38);
            this.button_Convert.TabIndex = 4;
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.pictureBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRight.Image = global::ImageConverter.Properties.Resources.semi_tansparent_logo1;
            this.pictureBoxRight.Location = new System.Drawing.Point(762, 13);
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
            this.pictureBoxPalette.Location = new System.Drawing.Point(777, 569);
            this.pictureBoxPalette.Name = "pictureBoxPalette";
            this.pictureBoxPalette.Size = new System.Drawing.Size(512, 40);
            this.pictureBoxPalette.TabIndex = 8;
            this.pictureBoxPalette.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1473, 614);
            this.Controls.Add(this.pictureBoxPalette);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Convert);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
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
    }
}

