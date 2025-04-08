namespace UploadImage
{
    partial class FormUserProfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserProfil));
            this.listBox_Users = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_ImageUpload = new System.Windows.Forms.Button();
            this.dateTimePicker_Belepes = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox_UserProfilImage = new System.Windows.Forms.PictureBox();
            this.button_NewUser = new System.Windows.Forms.Button();
            this.textBox_ImageUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog_imageUpload = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_UserProfilImage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Users
            // 
            this.listBox_Users.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_Users.FormattingEnabled = true;
            this.listBox_Users.ItemHeight = 16;
            this.listBox_Users.Location = new System.Drawing.Point(0, 0);
            this.listBox_Users.Name = "listBox_Users";
            this.listBox_Users.Size = new System.Drawing.Size(197, 467);
            this.listBox_Users.TabIndex = 0;
            this.listBox_Users.SelectedIndexChanged += new System.EventHandler(this.listBox_Users_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ImageUpload);
            this.groupBox1.Controls.Add(this.dateTimePicker_Belepes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pictureBox_UserProfilImage);
            this.groupBox1.Controls.Add(this.button_NewUser);
            this.groupBox1.Controls.Add(this.textBox_ImageUrl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_Description);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Username);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(197, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 467);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiválasztott felhasználó";
            // 
            // button_ImageUpload
            // 
            this.button_ImageUpload.Location = new System.Drawing.Point(531, 285);
            this.button_ImageUpload.Name = "button_ImageUpload";
            this.button_ImageUpload.Size = new System.Drawing.Size(155, 31);
            this.button_ImageUpload.TabIndex = 12;
            this.button_ImageUpload.Text = "Kép választás";
            this.button_ImageUpload.UseVisualStyleBackColor = true;
            this.button_ImageUpload.Click += new System.EventHandler(this.button_ImageUpload_Click);
            // 
            // dateTimePicker_Belepes
            // 
            this.dateTimePicker_Belepes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Belepes.Location = new System.Drawing.Point(167, 261);
            this.dateTimePicker_Belepes.Name = "dateTimePicker_Belepes";
            this.dateTimePicker_Belepes.Size = new System.Drawing.Size(162, 22);
            this.dateTimePicker_Belepes.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Regisztrálva";
            // 
            // pictureBox_UserProfilImage
            // 
            this.pictureBox_UserProfilImage.Location = new System.Drawing.Point(531, 34);
            this.pictureBox_UserProfilImage.Name = "pictureBox_UserProfilImage";
            this.pictureBox_UserProfilImage.Size = new System.Drawing.Size(155, 222);
            this.pictureBox_UserProfilImage.TabIndex = 9;
            this.pictureBox_UserProfilImage.TabStop = false;
            // 
            // button_NewUser
            // 
            this.button_NewUser.Location = new System.Drawing.Point(44, 340);
            this.button_NewUser.Name = "button_NewUser";
            this.button_NewUser.Size = new System.Drawing.Size(642, 45);
            this.button_NewUser.TabIndex = 8;
            this.button_NewUser.Text = "Új felhasználó";
            this.button_NewUser.UseVisualStyleBackColor = true;
            this.button_NewUser.Click += new System.EventHandler(this.button_NewUser_Click);
            // 
            // textBox_ImageUrl
            // 
            this.textBox_ImageUrl.Location = new System.Drawing.Point(167, 216);
            this.textBox_ImageUrl.Name = "textBox_ImageUrl";
            this.textBox_ImageUrl.ReadOnly = true;
            this.textBox_ImageUrl.Size = new System.Drawing.Size(263, 22);
            this.textBox_ImageUrl.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Képfájl neve";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(167, 158);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(316, 22);
            this.textBox_Description.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Megjegyzés";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(167, 106);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(159, 22);
            this.textBox_Username.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Felhasználó neve";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(167, 45);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 22);
            this.textBox_id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Azonosító";
            // 
            // openFileDialog_imageUpload
            // 
            this.openFileDialog_imageUpload.FileName = "openFileDialog1";
            // 
            // FormUserProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_Users);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormUserProfil";
            this.Text = "Regisztrált felhasználók";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_UserProfilImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Users;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ImageUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_NewUser;
        private System.Windows.Forms.PictureBox pictureBox_UserProfilImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Belepes;
        private System.Windows.Forms.Button button_ImageUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog_imageUpload;
    }
}

