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
            this.button_clear = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.check_endstats = new System.Windows.Forms.CheckBox();
            this.label_autosettings = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.RichTextBox();
            this.label_commands = new System.Windows.Forms.Label();
            this.check_cmdsearch = new System.Windows.Forms.CheckBox();
            this.check_cmdnp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(6, 6);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(94, 23);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(6, 35);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(94, 23);
            this.button_disconnect.TabIndex = 1;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // check_nowplaying
            // 
            this.check_nowplaying.AutoSize = true;
            this.check_nowplaying.Checked = true;
            this.check_nowplaying.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_nowplaying.Location = new System.Drawing.Point(6, 171);
            this.check_nowplaying.Name = "check_nowplaying";
            this.check_nowplaying.Size = new System.Drawing.Size(85, 17);
            this.check_nowplaying.TabIndex = 2;
            this.check_nowplaying.Text = "Now Playing";
            this.check_nowplaying.UseVisualStyleBackColor = true;
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(6, 63);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(94, 23);
            this.button_reload.TabIndex = 4;
            this.button_reload.Text = "Reload Config";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.Location = new System.Drawing.Point(245, 4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(41, 24);
            this.button_clear.TabIndex = 5;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(103, 11);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(129, 13);
            this.label_status.TabIndex = 6;
            this.label_status.Text = "Status: Disconnected";
            // 
            // check_endstats
            // 
            this.check_endstats.AutoSize = true;
            this.check_endstats.Location = new System.Drawing.Point(6, 185);
            this.check_endstats.Name = "check_endstats";
            this.check_endstats.Size = new System.Drawing.Size(72, 17);
            this.check_endstats.TabIndex = 7;
            this.check_endstats.Text = "End Stats";
            this.check_endstats.UseVisualStyleBackColor = true;
            // 
            // label_autosettings
            // 
            this.label_autosettings.AutoSize = true;
            this.label_autosettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_autosettings.Location = new System.Drawing.Point(3, 155);
            this.label_autosettings.Name = "label_autosettings";
            this.label_autosettings.Size = new System.Drawing.Size(73, 13);
            this.label_autosettings.TabIndex = 8;
            this.label_autosettings.Text = "Auto Settings:";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(106, 30);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(180, 161);
            this.log.TabIndex = 9;
            this.log.Text = "";
            // 
            // label_commands
            // 
            this.label_commands.AutoSize = true;
            this.label_commands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_commands.Location = new System.Drawing.Point(3, 95);
            this.label_commands.Name = "label_commands";
            this.label_commands.Size = new System.Drawing.Size(62, 13);
            this.label_commands.TabIndex = 10;
            this.label_commands.Text = "Commands:";
            // 
            // check_cmdsearch
            // 
            this.check_cmdsearch.AutoSize = true;
            this.check_cmdsearch.Checked = true;
            this.check_cmdsearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_cmdsearch.Location = new System.Drawing.Point(6, 112);
            this.check_cmdsearch.Name = "check_cmdsearch";
            this.check_cmdsearch.Size = new System.Drawing.Size(61, 17);
            this.check_cmdsearch.TabIndex = 11;
            this.check_cmdsearch.Text = "!search";
            this.check_cmdsearch.UseVisualStyleBackColor = true;
            // 
            // check_cmdnp
            // 
            this.check_cmdnp.AutoSize = true;
            this.check_cmdnp.Checked = true;
            this.check_cmdnp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_cmdnp.Location = new System.Drawing.Point(6, 126);
            this.check_cmdnp.Name = "check_cmdnp";
            this.check_cmdnp.Size = new System.Drawing.Size(82, 17);
            this.check_cmdnp.TabIndex = 12;
            this.check_cmdnp.Text = "!nowplaying";
            this.check_cmdnp.UseVisualStyleBackColor = true;
            // 
            // Bot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 203);
            this.Controls.Add(this.check_cmdnp);
            this.Controls.Add(this.check_cmdsearch);
            this.Controls.Add(this.label_commands);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label_autosettings);
            this.Controls.Add(this.check_endstats);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.check_nowplaying);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(314, 241);
            this.Name = "Bot";
            this.Text = "Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bot_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bot_FormClosed);
            this.Load += new System.EventHandler(this.Bot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.CheckBox check_nowplaying;
        private System.Windows.Forms.Button button_reload;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.CheckBox check_endstats;
        private System.Windows.Forms.Label label_autosettings;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Label label_commands;
        private System.Windows.Forms.CheckBox check_cmdsearch;
        private System.Windows.Forms.CheckBox check_cmdnp;
    }
}