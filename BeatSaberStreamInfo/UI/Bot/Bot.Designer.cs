namespace BeatSaberStreamInfo.UI.Bot
{
    partial class Bot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bot));
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.check_nowplaying = new System.Windows.Forms.CheckBox();
            this.button_reload = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.check_endstats = new System.Windows.Forms.CheckBox();
            this.label_autosettings = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(8, 8);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(83, 23);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(8, 37);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(83, 23);
            this.button_disconnect.TabIndex = 1;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            // 
            // check_nowplaying
            // 
            this.check_nowplaying.AutoSize = true;
            this.check_nowplaying.Location = new System.Drawing.Point(12, 130);
            this.check_nowplaying.Name = "check_nowplaying";
            this.check_nowplaying.Size = new System.Drawing.Size(85, 17);
            this.check_nowplaying.TabIndex = 2;
            this.check_nowplaying.Text = "Now Playing";
            this.check_nowplaying.UseVisualStyleBackColor = true;
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(8, 65);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(83, 23);
            this.button_reload.TabIndex = 4;
            this.button_reload.Text = "Reload Config";
            this.button_reload.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(367, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status: Disconnected";
            // 
            // check_endstats
            // 
            this.check_endstats.AutoSize = true;
            this.check_endstats.Location = new System.Drawing.Point(12, 150);
            this.check_endstats.Name = "check_endstats";
            this.check_endstats.Size = new System.Drawing.Size(72, 17);
            this.check_endstats.TabIndex = 7;
            this.check_endstats.Text = "End Stats";
            this.check_endstats.UseVisualStyleBackColor = true;
            // 
            // label_autosettings
            // 
            this.label_autosettings.AutoSize = true;
            this.label_autosettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_autosettings.Location = new System.Drawing.Point(9, 111);
            this.label_autosettings.Name = "label_autosettings";
            this.label_autosettings.Size = new System.Drawing.Size(87, 13);
            this.label_autosettings.TabIndex = 8;
            this.label_autosettings.Text = "Auto Settings:";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(116, 30);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(291, 206);
            this.log.TabIndex = 9;
            this.log.Text = "";
            // 
            // Bot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 248);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label_autosettings);
            this.Controls.Add(this.check_endstats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.check_nowplaying);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(291, 208);
            this.Name = "Bot";
            this.Text = "Bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.CheckBox check_nowplaying;
        private System.Windows.Forms.Button button_reload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_endstats;
        private System.Windows.Forms.Label label_autosettings;
        private System.Windows.Forms.RichTextBox log;
    }
}