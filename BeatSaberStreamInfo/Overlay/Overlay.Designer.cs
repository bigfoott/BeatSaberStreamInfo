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
            this.label_combo = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.label_multiplier = new System.Windows.Forms.Label();
            this.label_timetext = new System.Windows.Forms.Label();
            this.label_accuracy = new System.Windows.Forms.Label();
            this.label_scoretext = new System.Windows.Forms.Label();
            this.label_multitext = new System.Windows.Forms.Label();
            this.panel_combo = new System.Windows.Forms.Panel();
            this.label_combotext = new System.Windows.Forms.Label();
            this.panel_score = new System.Windows.Forms.Panel();
            this.panel_multiplier = new System.Windows.Forms.Panel();
            this.panel_time = new System.Windows.Forms.Panel();
            this.panel_accuracy = new System.Windows.Forms.Panel();
            this.panel_combo.SuspendLayout();
            this.panel_score.SuspendLayout();
            this.panel_multiplier.SuspendLayout();
            this.panel_time.SuspendLayout();
            this.panel_accuracy.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_energy
            // 
            this.label_energy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_energy.BackColor = System.Drawing.Color.Transparent;
            this.label_energy.Font = new System.Drawing.Font("Teko", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_energy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_energy.Location = new System.Drawing.Point(75, 198);
            this.label_energy.Margin = new System.Windows.Forms.Padding(0);
            this.label_energy.Name = "label_energy";
            this.label_energy.Size = new System.Drawing.Size(399, 36);
            this.label_energy.TabIndex = 13;
            this.label_energy.Text = "HP  (50%)  █████████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░";
            this.label_energy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_energy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_energy_MouseDown);
            this.label_energy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_energy_MouseUp);
            // 
            // label_notes
            // 
            this.label_notes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_notes.BackColor = System.Drawing.Color.Transparent;
            this.label_notes.Font = new System.Drawing.Font("Teko", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_notes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_notes.Location = new System.Drawing.Point(-18, 18);
            this.label_notes.Margin = new System.Windows.Forms.Padding(0);
            this.label_notes.Name = "label_notes";
            this.label_notes.Size = new System.Drawing.Size(266, 42);
            this.label_notes.TabIndex = 12;
            this.label_notes.Text = "0/0 (0%)";
            this.label_notes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_notes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_accuracy_MouseDown);
            this.label_notes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_accuracy_MouseUp);
            // 
            // label_progress
            // 
            this.label_progress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_progress.BackColor = System.Drawing.Color.Transparent;
            this.label_progress.Font = new System.Drawing.Font("Teko", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_progress.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_progress.Location = new System.Drawing.Point(-12, 17);
            this.label_progress.Margin = new System.Windows.Forms.Padding(0);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(249, 52);
            this.label_progress.TabIndex = 11;
            this.label_progress.Text = "0:00/0:00 (0%)";
            this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_progress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_time_MouseDown);
            this.label_progress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_time_MouseUp);
            // 
            // label_combo
            // 
            this.label_combo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_combo.BackColor = System.Drawing.Color.Transparent;
            this.label_combo.Font = new System.Drawing.Font("Teko", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_combo.Location = new System.Drawing.Point(1, 27);
            this.label_combo.Margin = new System.Windows.Forms.Padding(0);
            this.label_combo.Name = "label_combo";
            this.label_combo.Size = new System.Drawing.Size(234, 59);
            this.label_combo.TabIndex = 9;
            this.label_combo.Text = "0";
            this.label_combo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_combo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_combo_MouseDown);
            this.label_combo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_combo_MouseUp);
            // 
            // label_score
            // 
            this.label_score.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_score.BackColor = System.Drawing.Color.Transparent;
            this.label_score.Font = new System.Drawing.Font("Teko", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_score.Location = new System.Drawing.Point(1, 26);
            this.label_score.Margin = new System.Windows.Forms.Padding(0);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(212, 40);
            this.label_score.TabIndex = 8;
            this.label_score.Text = "0";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_score.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_score_MouseDown);
            this.label_score.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_score_MouseUp);
            // 
            // label_multiplier
            // 
            this.label_multiplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_multiplier.BackColor = System.Drawing.Color.Transparent;
            this.label_multiplier.Font = new System.Drawing.Font("Teko", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_multiplier.Location = new System.Drawing.Point(4, 28);
            this.label_multiplier.Margin = new System.Windows.Forms.Padding(0);
            this.label_multiplier.Name = "label_multiplier";
            this.label_multiplier.Size = new System.Drawing.Size(133, 59);
            this.label_multiplier.TabIndex = 7;
            this.label_multiplier.Text = "1x";
            this.label_multiplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_multiplier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_multiplier_MouseDown);
            this.label_multiplier.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_multiplier_MouseUp);
            // 
            // label_timetext
            // 
            this.label_timetext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_timetext.BackColor = System.Drawing.Color.Transparent;
            this.label_timetext.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timetext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_timetext.Location = new System.Drawing.Point(94, 1);
            this.label_timetext.Margin = new System.Windows.Forms.Padding(0);
            this.label_timetext.Name = "label_timetext";
            this.label_timetext.Size = new System.Drawing.Size(45, 20);
            this.label_timetext.TabIndex = 14;
            this.label_timetext.Text = "TIME";
            this.label_timetext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_timetext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_time_MouseDown);
            this.label_timetext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_time_MouseUp);
            // 
            // label_accuracy
            // 
            this.label_accuracy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_accuracy.BackColor = System.Drawing.Color.Transparent;
            this.label_accuracy.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_accuracy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_accuracy.Location = new System.Drawing.Point(60, 2);
            this.label_accuracy.Margin = new System.Windows.Forms.Padding(0);
            this.label_accuracy.Name = "label_accuracy";
            this.label_accuracy.Size = new System.Drawing.Size(109, 21);
            this.label_accuracy.TabIndex = 15;
            this.label_accuracy.Text = "ACCURACY";
            this.label_accuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_accuracy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_accuracy_MouseDown);
            this.label_accuracy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_accuracy_MouseUp);
            // 
            // label_scoretext
            // 
            this.label_scoretext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_scoretext.BackColor = System.Drawing.Color.Transparent;
            this.label_scoretext.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_scoretext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_scoretext.Location = new System.Drawing.Point(73, 1);
            this.label_scoretext.Margin = new System.Windows.Forms.Padding(0);
            this.label_scoretext.Name = "label_scoretext";
            this.label_scoretext.Size = new System.Drawing.Size(67, 27);
            this.label_scoretext.TabIndex = 16;
            this.label_scoretext.Text = "SCORE";
            this.label_scoretext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_scoretext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_score_MouseDown);
            this.label_scoretext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_score_MouseUp);
            // 
            // label_multitext
            // 
            this.label_multitext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_multitext.BackColor = System.Drawing.Color.Transparent;
            this.label_multitext.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_multitext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_multitext.Location = new System.Drawing.Point(28, 1);
            this.label_multitext.Margin = new System.Windows.Forms.Padding(0);
            this.label_multitext.Name = "label_multitext";
            this.label_multitext.Size = new System.Drawing.Size(85, 20);
            this.label_multitext.TabIndex = 17;
            this.label_multitext.Text = "MULTIPLIER";
            this.label_multitext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_multitext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_multiplier_MouseDown);
            this.label_multitext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_multiplier_MouseUp);
            // 
            // panel_combo
            // 
            this.panel_combo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_combo.BackColor = System.Drawing.Color.Transparent;
            this.panel_combo.Controls.Add(this.label_combotext);
            this.panel_combo.Controls.Add(this.label_combo);
            this.panel_combo.Location = new System.Drawing.Point(303, 19);
            this.panel_combo.Name = "panel_combo";
            this.panel_combo.Size = new System.Drawing.Size(234, 90);
            this.panel_combo.TabIndex = 18;
            this.panel_combo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_combo_MouseDown);
            this.panel_combo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_combo_MouseUp);
            // 
            // label_combotext
            // 
            this.label_combotext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_combotext.BackColor = System.Drawing.Color.Transparent;
            this.label_combotext.Font = new System.Drawing.Font("Teko", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_combotext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_combotext.Location = new System.Drawing.Point(75, 4);
            this.label_combotext.Margin = new System.Windows.Forms.Padding(0);
            this.label_combotext.Name = "label_combotext";
            this.label_combotext.Size = new System.Drawing.Size(85, 20);
            this.label_combotext.TabIndex = 18;
            this.label_combotext.Text = "COMBO";
            this.label_combotext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_combotext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_combo_MouseDown);
            this.label_combotext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_combo_MouseUp);
            // 
            // panel_score
            // 
            this.panel_score.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_score.BackColor = System.Drawing.Color.Transparent;
            this.panel_score.Controls.Add(this.label_score);
            this.panel_score.Controls.Add(this.label_scoretext);
            this.panel_score.Location = new System.Drawing.Point(170, 83);
            this.panel_score.Name = "panel_score";
            this.panel_score.Size = new System.Drawing.Size(214, 69);
            this.panel_score.TabIndex = 19;
            this.panel_score.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_score_MouseDown);
            this.panel_score.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_score_MouseUp);
            // 
            // panel_multiplier
            // 
            this.panel_multiplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_multiplier.BackColor = System.Drawing.Color.Transparent;
            this.panel_multiplier.Controls.Add(this.label_multitext);
            this.panel_multiplier.Controls.Add(this.label_multiplier);
            this.panel_multiplier.Location = new System.Drawing.Point(61, 19);
            this.panel_multiplier.Name = "panel_multiplier";
            this.panel_multiplier.Size = new System.Drawing.Size(141, 90);
            this.panel_multiplier.TabIndex = 21;
            this.panel_multiplier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_multiplier_MouseDown);
            this.panel_multiplier.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_multiplier_MouseUp);
            // 
            // panel_time
            // 
            this.panel_time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_time.BackColor = System.Drawing.Color.Transparent;
            this.panel_time.Controls.Add(this.label_timetext);
            this.panel_time.Controls.Add(this.label_progress);
            this.panel_time.Location = new System.Drawing.Point(16, 132);
            this.panel_time.Name = "panel_time";
            this.panel_time.Size = new System.Drawing.Size(230, 75);
            this.panel_time.TabIndex = 22;
            this.panel_time.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_time_MouseDown);
            this.panel_time.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_time_MouseUp);
            // 
            // panel_accuracy
            // 
            this.panel_accuracy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_accuracy.BackColor = System.Drawing.Color.Transparent;
            this.panel_accuracy.Controls.Add(this.label_accuracy);
            this.panel_accuracy.Controls.Add(this.label_notes);
            this.panel_accuracy.Location = new System.Drawing.Point(307, 134);
            this.panel_accuracy.Name = "panel_accuracy";
            this.panel_accuracy.Size = new System.Drawing.Size(234, 58);
            this.panel_accuracy.TabIndex = 23;
            this.panel_accuracy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_accuracy_MouseDown);
            this.panel_accuracy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_accuracy_MouseUp);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(550, 250);
            this.Controls.Add(this.panel_score);
            this.Controls.Add(this.label_energy);
            this.Controls.Add(this.panel_accuracy);
            this.Controls.Add(this.panel_time);
            this.Controls.Add(this.panel_multiplier);
            this.Controls.Add(this.panel_combo);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(566, 288);
            this.Name = "Overlay";
            this.Text = "Overlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overlay_FormClosing);
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.ResizeEnd += new System.EventHandler(this.Overlay_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Overlay_KeyUp);
            this.panel_combo.ResumeLayout(false);
            this.panel_score.ResumeLayout(false);
            this.panel_multiplier.ResumeLayout(false);
            this.panel_time.ResumeLayout(false);
            this.panel_accuracy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_energy;
        private System.Windows.Forms.Label label_notes;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.Label label_combo;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label label_multiplier;
        private System.Windows.Forms.Label label_timetext;
        private System.Windows.Forms.Label label_accuracy;
        private System.Windows.Forms.Label label_scoretext;
        private System.Windows.Forms.Label label_multitext;
        private System.Windows.Forms.Panel panel_combo;
        private System.Windows.Forms.Panel panel_score;
        private System.Windows.Forms.Panel panel_accuracy;
        private System.Windows.Forms.Panel panel_multiplier;
        private System.Windows.Forms.Panel panel_time;
        private System.Windows.Forms.Label label_combotext;
    }
}