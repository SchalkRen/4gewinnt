namespace _4Gewinnt
{
    partial class Winnerp1
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
            this.Winnerlabel = new System.Windows.Forms.Label();
            this.continueplayingbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Winnerplayer2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Winnerplayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // Winnerlabel
            // 
            this.Winnerlabel.AutoSize = true;
            this.Winnerlabel.Location = new System.Drawing.Point(159, 93);
            this.Winnerlabel.Name = "Winnerlabel";
            this.Winnerlabel.Size = new System.Drawing.Size(68, 13);
            this.Winnerlabel.TabIndex = 0;
            this.Winnerlabel.Text = "Player 1 won";
            // 
            // continueplayingbutton
            // 
            this.continueplayingbutton.Location = new System.Drawing.Point(152, 12);
            this.continueplayingbutton.Name = "continueplayingbutton";
            this.continueplayingbutton.Size = new System.Drawing.Size(95, 38);
            this.continueplayingbutton.TabIndex = 3;
            this.continueplayingbutton.Text = "Play again";
            this.continueplayingbutton.UseVisualStyleBackColor = true;
            this.continueplayingbutton.Click += new System.EventHandler(this.continueplayingbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Press the button to continue playing or start a new game";
            // 
            // Winnerplayer2
            // 
            //this.Winnerplayer2.Image = global::_4Gewinnt.Properties.Resources.WinnerP1;
            this.Winnerplayer2.Location = new System.Drawing.Point(-3, -39);
            this.Winnerplayer2.Name = "Winnerplayer2";
            this.Winnerplayer2.Size = new System.Drawing.Size(417, 360);
            this.Winnerplayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Winnerplayer2.TabIndex = 2;
            this.Winnerplayer2.TabStop = false;
            this.Winnerplayer2.Click += new System.EventHandler(this.Winnerplayer2_Click);
            // 
            // Winnerp1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 257);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.continueplayingbutton);
            this.Controls.Add(this.Winnerlabel);
            this.Controls.Add(this.Winnerplayer2);
            this.Name = "Winnerp1";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.Winnerplayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Winnerlabel;
        private System.Windows.Forms.Button continueplayingbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Winnerplayer2;
    }
}