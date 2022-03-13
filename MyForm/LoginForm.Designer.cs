
namespace StaffManagement
{
    partial class LoginForm
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
            this.LoginBtn = new System.Windows.Forms.Button();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuickLoginAsAdminBtn = new System.Windows.Forms.Button();
            this.QuickLoginAsEmployeeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(314, 231);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(210, 31);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // username_tb
            // 
            this.username_tb.Location = new System.Drawing.Point(314, 154);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(210, 22);
            this.username_tb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "username";
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(314, 182);
            this.password_tb.Name = "password_tb";
            this.password_tb.PasswordChar = '*';
            this.password_tb.Size = new System.Drawing.Size(210, 22);
            this.password_tb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // QuickLoginAsAdminBtn
            // 
            this.QuickLoginAsAdminBtn.Location = new System.Drawing.Point(238, 371);
            this.QuickLoginAsAdminBtn.Name = "QuickLoginAsAdminBtn";
            this.QuickLoginAsAdminBtn.Size = new System.Drawing.Size(292, 31);
            this.QuickLoginAsAdminBtn.TabIndex = 3;
            this.QuickLoginAsAdminBtn.Text = "Quick login as admin";
            this.QuickLoginAsAdminBtn.UseVisualStyleBackColor = true;
            this.QuickLoginAsAdminBtn.Click += new System.EventHandler(this.QuickLoginAsAdminBtn_Click);
            // 
            // QuickLoginAsEmployeeBtn
            // 
            this.QuickLoginAsEmployeeBtn.Location = new System.Drawing.Point(238, 408);
            this.QuickLoginAsEmployeeBtn.Name = "QuickLoginAsEmployeeBtn";
            this.QuickLoginAsEmployeeBtn.Size = new System.Drawing.Size(292, 31);
            this.QuickLoginAsEmployeeBtn.TabIndex = 3;
            this.QuickLoginAsEmployeeBtn.Text = "Quick login as employee";
            this.QuickLoginAsEmployeeBtn.UseVisualStyleBackColor = true;
            this.QuickLoginAsEmployeeBtn.Click += new System.EventHandler(this.QuickLoginAsEmployeeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "For developer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StaffManagement.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "HR management system";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 481);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuickLoginAsEmployeeBtn);
            this.Controls.Add(this.QuickLoginAsAdminBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.username_tb);
            this.Controls.Add(this.LoginBtn);
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox username_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button QuickLoginAsAdminBtn;
        private System.Windows.Forms.Button QuickLoginAsEmployeeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}

