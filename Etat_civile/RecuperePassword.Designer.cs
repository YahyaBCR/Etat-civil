
namespace Etat_civile
{
    partial class RecuperePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperePassword));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblemail = new System.Windows.Forms.Label();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNouvelle = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.Location = new System.Drawing.Point(799, 376);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(216, 19);
            this.lblemail.TabIndex = 4;
            this.lblemail.Text = "elkabousomar0@gmail.com";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.AutoRoundedCorners = true;
            this.guna2GradientButton1.BorderRadius = 21;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.Enabled = false;
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Yellow;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Green;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientButton1.Location = new System.Drawing.Point(871, 430);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(194, 45);
            this.guna2GradientButton1.TabIndex = 5;
            this.guna2GradientButton1.Text = "Confirmer";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // txtConfirm
            // 
            this.txtConfirm.Animated = true;
            this.txtConfirm.AutoRoundedCorners = true;
            this.txtConfirm.BorderRadius = 20;
            this.txtConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirm.DefaultText = "";
            this.txtConfirm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirm.Location = new System.Drawing.Point(802, 222);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '\0';
            this.txtConfirm.PlaceholderText = "Code de verification";
            this.txtConfirm.SelectedText = "";
            this.txtConfirm.Size = new System.Drawing.Size(320, 43);
            this.txtConfirm.TabIndex = 6;
            this.txtConfirm.TextChanged += new System.EventHandler(this.txtConfirm_TextChanged);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Animated = true;
            this.txtConfirmPass.AutoRoundedCorners = true;
            this.txtConfirmPass.BorderRadius = 20;
            this.txtConfirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPass.DefaultText = "";
            this.txtConfirmPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirmPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtConfirmPass.IconLeft")));
            this.txtConfirmPass.Location = new System.Drawing.Point(802, 312);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '●';
            this.txtConfirmPass.PlaceholderText = "Confirmer le mot de passe";
            this.txtConfirmPass.SelectedText = "";
            this.txtConfirmPass.Size = new System.Drawing.Size(320, 43);
            this.txtConfirmPass.TabIndex = 9;
            this.txtConfirmPass.Visible = false;
            this.txtConfirmPass.TextChanged += new System.EventHandler(this.txtConfirmPass_TextChanged);
            // 
            // txtNouvelle
            // 
            this.txtNouvelle.Animated = true;
            this.txtNouvelle.AutoRoundedCorners = true;
            this.txtNouvelle.BorderRadius = 20;
            this.txtNouvelle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNouvelle.DefaultText = "";
            this.txtNouvelle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNouvelle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNouvelle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNouvelle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNouvelle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNouvelle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNouvelle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNouvelle.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtNouvelle.IconLeft")));
            this.txtNouvelle.Location = new System.Drawing.Point(802, 243);
            this.txtNouvelle.Name = "txtNouvelle";
            this.txtNouvelle.PasswordChar = '●';
            this.txtNouvelle.PlaceholderText = "Nouvelle mot de passe";
            this.txtNouvelle.SelectedText = "";
            this.txtNouvelle.Size = new System.Drawing.Size(320, 43);
            this.txtNouvelle.TabIndex = 8;
            this.txtNouvelle.Visible = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::Etat_civile.Properties.Resources.logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(871, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(180, 180);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::Etat_civile.Properties.Resources.Cote_dIvoire_moi;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(68, 58);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(457, 435);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 3;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2PictureBox2);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Orange;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(650, 524);
            this.guna2CustomGradientPanel1.TabIndex = 10;
            // 
            // RecuperePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1260, 524);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtNouvelle);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.guna2GradientButton1);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecuperePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecuperePassword";
            this.Load += new System.EventHandler(this.RecuperePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirm;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.Label lblemail;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPass;
        private Guna.UI2.WinForms.Guna2TextBox txtNouvelle;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}