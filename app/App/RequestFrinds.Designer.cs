namespace App
{
    partial class RequestFrinds
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.backToGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.MistyRose;
            this.listBox1.Font = new System.Drawing.Font("David", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(248, 94);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(329, 303);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // yes
            // 
            this.yes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yes.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yes.ForeColor = System.Drawing.Color.Navy;
            this.yes.Location = new System.Drawing.Point(626, 94);
            this.yes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(181, 61);
            this.yes.TabIndex = 1;
            this.yes.Text = "Accept";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // no
            // 
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.no.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.ForeColor = System.Drawing.Color.Navy;
            this.no.Location = new System.Drawing.Point(626, 333);
            this.no.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(181, 64);
            this.no.TabIndex = 2;
            this.no.Text = "denide";
            this.no.UseVisualStyleBackColor = true;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // backToGame
            // 
            this.backToGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backToGame.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToGame.ForeColor = System.Drawing.Color.Navy;
            this.backToGame.Location = new System.Drawing.Point(39, 498);
            this.backToGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backToGame.Name = "backToGame";
            this.backToGame.Size = new System.Drawing.Size(180, 60);
            this.backToGame.TabIndex = 3;
            this.backToGame.Text = "< back";
            this.backToGame.UseVisualStyleBackColor = true;
            this.backToGame.Click += new System.EventHandler(this.backToGame_Click);
            // 
            // RequestFrinds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1196, 660);
            this.Controls.Add(this.backToGame);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RequestFrinds";
            this.Text = "RequestFrinds";
            this.Load += new System.EventHandler(this.RequestFrinds_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button backToGame;
    }
}