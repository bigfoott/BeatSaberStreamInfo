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
            this.label_timetext = new System.Windows.Forms.Label();
            this.label_accuracy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_energy
            // 
            this.label_energy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_energy.BackColor = System.Drawing.Color.Transparent;
            this.label_energy.Font = new System.Drawing.Font("Teko", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_energy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_energy.Location = new System.Drawing.Point(3, 186);
            this.label_energy.Name = "label_energy";
            this.label_energy.Size = new System.Drawing.Size(549, 36);
            this.label_energy.TabIndex = 13;
            this.label_energy.Text = "HP  █████████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░  (50%)";
            this.label_energy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_energy.Click += new System.EventHandler(this.label_energy_Click);
            // 
            // label_notes
            // 
            this.label_notes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_notes.BackColor = System.Drawing.Color.Transparent;
            this.label_notes.Font = new System.Drawing.Font("Teko", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_notes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_notes.Location = new System.Drawing.Point(273, 144);
            this.label_notes.Name = "label_notes";
            this.label_notes.Size = new System.Drawing.Size(266, 49);
            this.label_notes.TabIndex = 12;
            this.label_notes.Text = "0/0 (0%)";
            this.label_notes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_notes.Click += new System.EventHandler(this.label_notes_Click);
            // 
            // label_progress
            // 
            this.label_progress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_progress.BackColor = System.Drawing.Color.Transparent;
            this.label_progress.Font = new System.Drawing.Font("Teko", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_progress.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_progress.Location = new System.Drawing.Point(3, 144);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(262, 62);
            this.label_progress.TabIndex = 11;
            this.label_progress.Text = "0:00/0:00 (0%)";
            this.label_progress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_progress.Click += new System.EventHandler(this.label_progress_Click);
            // 
            // label_combotext
            // 
            this.label_combotext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_combotext.BackColor = System.Drawing.Color.Transparent;
            this.label_combotext.Font = new System.Drawing.Font("Teko", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_combotext.Location = new System.Drawing.Point(298, 8);
            this.label_combotext.Name = "label_combotext";
            this.label_combotext.Size = new System.Drawing.Size(218, 68);
            this.label_combotext.TabIndex = 10;
            this.label_combotext.Text = "COMBO";
            this.label_combotext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label_combotext.Click += new System.EventHandler(this.label_combotext_Click);
            // 
            // label_combo
            // 
            this.label_combo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_combo.BackColor = System.Drawing.Color.Transparent;
            this.label_combo.Font = new System.Drawing.Font("Teko", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_combo.Location = new System.Drawing.Point(291, 56);
            this.label_combo.Name = "label_combo";
            this.label_combo.Size = new System.Drawing.Size(234, 67);
            this.label_combo.TabIndex = 9;
            this.label_combo.Text = "0";
            this.label_combo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_combo.Click += new System.EventHandler(this.label_combo_Click);
            // 
            // label_score
            // 
            this.label_score.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_score.BackColor = System.Drawing.Color.Transparent;
            this.label_score.Font = new System.Drawing.Font("Teko", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_score.Location = new System.Drawing.Point(29, 84);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(212, 40);
            this.label_score.TabIndex = 8;
            this.label_score.Text = "0";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_score.Click += new System.EventHandler(this.label_score_Click);
            // 
            // label_multiplier
            // 
            this.label_multiplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_multiplier.BackColor = System.Drawing.Color.Transparent;
            this.label_multiplier.Font = new System.Drawing.Font("Teko", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_multiplier.Location = new System.Drawing.Point(42, 21);
            this.label_multiplier.Name = "label_multiplier";
            this.label_multiplier.Size = new System.Drawing.Size(183, 91);
            this.label_multiplier.TabIndex = 7;
            this.label_multiplier.Text = "1x";
            this.label_multiplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label_multiplier.Click += new System.EventHandler(this.label_multiplier_Click);
            // 
            // label_timetext
            // 
            this.label_timetext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_timetext.BackColor = System.Drawing.Color.Transparent;
            this.label_timetext.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timetext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_timetext.Location = new System.Drawing.Point(111, 128);
            this.label_timetext.Name = "label_timetext";
            this.label_timetext.Size = new System.Drawing.Size(44, 20);
            this.label_timetext.TabIndex = 14;
            this.label_timetext.Text = "TIME";
            this.label_timetext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_accuracy
            // 
            this.label_accuracy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_accuracy.BackColor = System.Drawing.Color.Transparent;
            this.label_accuracy.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_accuracy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_accuracy.Location = new System.Drawing.Point(350, 128);
            this.label_accuracy.Name = "label_accuracy";
            this.label_accuracy.Size = new System.Drawing.Size(109, 21);
            this.label_accuracy.TabIndex = 15;
            this.label_accuracy.Text = "ACCURACY";
            this.label_accuracy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(550, 250);
            this.Controls.Add(this.label_accuracy);
            this.Controls.Add(this.label_timetext);
            this.Controls.Add(this.label_energy);
            this.Controls.Add(this.label_notes);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.label_combotext);
            this.Controls.Add(this.label_combo);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_multiplier);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(566, 288);
            this.Name = "Overlay";
            this.Text = "Overlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overlay_FormClosing);
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.ResizeEnd += new System.EventHandler(this.Overlay_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Overlay_KeyUp);
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
        private System.Windows.Forms.Label label_timetext;
        private System.Windows.Forms.Label label_accuracy;
    }
}