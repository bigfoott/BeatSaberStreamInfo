namespace BeatSaberStreamInfo
{
    partial class Overlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overlay));
            this.label_energy = new System.Windows.Forms.Label();
            this.label_notes = new System.Windows.Forms.Label();
            this.label_progress = new System.Windows.Forms.Label();
            this.label_combotext = new System.Windows.Forms.Label();
            this.label_combo = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.label_multiplier = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_energy
            // 
            this.label_energy.BackColor = System.Drawing.Color.Transparent;
            this.label_energy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_energy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_energy.Location = new System.Drawing.Point(1, 193);
            this.label_energy.Name = "label_energy";
            this.label_energy.Size = new System.Drawing.Size(549, 82);
            this.label_energy.TabIndex = 13;
            this.label_energy.Text = "█████████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░  (50%)";
            this.label_energy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_notes
            // 
            this.label_notes.BackColor = System.Drawing.Color.Transparent;
            this.label_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_notes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_notes.Location = new System.Drawing.Point(272, 142);
            this.label_notes.Name = "label_notes";
            this.label_notes.Size = new System.Drawing.Size(266, 49);
            this.label_notes.TabIndex = 12;
            this.label_notes.Text = "0/0 (0%)";
            this.label_notes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_progress
            // 
            this.label_progress.BackColor = System.Drawing.Color.Transparent;
            this.label_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_progress.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_progress.Location = new System.Drawing.Point(2, 139);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(263, 62);
            this.label_progress.TabIndex = 11;
            this.label_progress.Text = " 0:00/0:00 (0%)";
            this.label_progress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_combotext
            // 
            this.label_combotext.BackColor = System.Drawing.Color.Transparent;
            this.label_combotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label_combotext.Location = new System.Drawing.Point(297, 24);
            this.label_combotext.Name = "label_combotext";
            this.label_combotext.Size = new System.Drawing.Size(218, 68);
            this.label_combotext.TabIndex = 10;
            this.label_combotext.Text = "COMBO";
            this.label_combotext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_combo
            // 
            this.label_combo.BackColor = System.Drawing.Color.Transparent;
            this.label_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_combo.Location = new System.Drawing.Point(289, 69);
            this.label_combo.Name = "label_combo";
            this.label_combo.Size = new System.Drawing.Size(234, 101);
            this.label_combo.TabIndex = 9;
            this.label_combo.Text = "0";
            this.label_combo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_score
            // 
            this.label_score.BackColor = System.Drawing.Color.Transparent;
            this.label_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label_score.Location = new System.Drawing.Point(27, 94);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(212, 47);
            this.label_score.TabIndex = 8;
            this.label_score.Text = "0";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_multiplier
            // 
            this.label_multiplier.BackColor = System.Drawing.Color.Transparent;
            this.label_multiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_multiplier.Location = new System.Drawing.Point(41, 41);
            this.label_multiplier.Name = "label_multiplier";
            this.label_multiplier.Size = new System.Drawing.Size(185, 75);
            this.label_multiplier.TabIndex = 7;
            this.label_multiplier.Text = "1x";
            this.label_multiplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(551, 250);
            this.Controls.Add(this.label_energy);
            this.Controls.Add(this.label_notes);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.label_combotext);
            this.Controls.Add(this.label_combo);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_multiplier);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(567, 288);
            this.MinimumSize = new System.Drawing.Size(567, 288);
            this.Name = "Overlay";
            this.Text = "Overlay";
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_energy;
        private System.Windows.Forms.Label label_notes;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.Label label_combotext;
        private System.Windows.Forms.Label label_combo;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label label_multiplier;
    }
}