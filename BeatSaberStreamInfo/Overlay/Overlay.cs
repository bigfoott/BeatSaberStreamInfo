using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatSaberStreamInfo
{
    public partial class Overlay : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        
        private PrivateFontCollection fonts = new PrivateFontCollection();
        FontFamily MainFont;

        private bool locked = true;

        public Overlay()
        {
            InitializeComponent();

            byte[] fontData = Resources.teko;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Resources.teko.Length);
            AddFontMemResourceEx(fontPtr, (uint)Resources.teko.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            MainFont = fonts.Families[0];
        }
        
        private void Overlay_Load(object sender, EventArgs e)
        {
            string[] pos = File.ReadAllLines(Path.Combine(Plugin.dir, "overlaydata.txt"));
            Size = new Size(int.Parse(pos[0].Split(',')[0]), int.Parse(pos[0].Split(',')[1]));
            Location = new Point(int.Parse(pos[1].Split(',')[0]), int.Parse(pos[1].Split(',')[1]));
            
            label_energy.Location = new Point(int.Parse(pos[2].Split(',')[0]), int.Parse(pos[2].Split(',')[1]));
            panel_accuracy.Location = new Point(int.Parse(pos[3].Split(',')[0]), int.Parse(pos[3].Split(',')[1]));
            panel_time.Location = new Point(int.Parse(pos[4].Split(',')[0]), int.Parse(pos[4].Split(',')[1]));
            panel_multiplier.Location = new Point(int.Parse(pos[5].Split(',')[0]), int.Parse(pos[5].Split(',')[1]));
            panel_score.Location = new Point(int.Parse(pos[6].Split(',')[0]), int.Parse(pos[6].Split(',')[1]));
            panel_combo.Location = new Point(int.Parse(pos[7].Split(',')[0]), int.Parse(pos[7].Split(',')[1]));

            ForeColor = Color.FromName(ModPrefs.GetString("StreamInfo", "TextColor", "White", true));
            BackColor = Color.FromName(ModPrefs.GetString("StreamInfo", "BackgroundColor", "Black", true));

            if (ModPrefs.GetBool("StreamInfo", "UseBackgroundImage", false, true) && File.Exists(Path.Combine(Plugin.dir, "image.png")))
                BackgroundImage = Image.FromFile(Path.Combine(Plugin.dir, "image.png"));
            
            label_multiplier.Font = new Font(MainFont, 50);
            label_score.Font = new Font(MainFont, 30);
            label_progress.Font = new Font(MainFont, 20);

            label_combo.Font = new Font(MainFont, 50);
            label_combotext.Font = new Font(MainFont, 15);
            label_notes.Font = new Font(MainFont, 20);

            label_timetext.Font = new Font(MainFont, 15);
            label_accuracy.Font = new Font(MainFont, 15);
            label_scoretext.Font = new Font(MainFont, 15);
            label_multitext.Font = new Font(MainFont, 15);

            label_energy.Font = new Font(MainFont, 18);

            Text = "Overlay (" + Size.Width + "x" + Size.Height + ") (Locked: " + locked + ")";
        }
        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] lines =
            {
                Size.Width + "," + Size.Height,
                Location.X + "," + Location.Y,
                label_energy.Location.X + "," + label_energy.Location.Y,
                panel_accuracy.Location.X + "," + panel_accuracy.Location.Y,
                panel_time.Location.X + "," + panel_time.Location.Y,
                panel_multiplier.Location.X + "," + panel_multiplier.Location.Y,
                panel_score.Location.X + "," + panel_score.Location.Y,
                panel_combo.Location.X + "," + panel_combo.Location.Y
            };
            File.WriteAllLines(Path.Combine(Plugin.dir, "overlaydata.txt"), lines);
        }
        private void Overlay_ResizeEnd(object sender, EventArgs e)
        {
            Text = "Overlay (" + Size.Width + "x" + Size.Height + ") (Locked: " + locked + ")";
            Refresh();
        }
        private void Overlay_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                ForeColor = Color.FromName(ModPrefs.GetString("StreamInfo", "TextColor", "White", true));
                BackColor = Color.FromName(ModPrefs.GetString("StreamInfo", "BackgroundColor", "Black", true));

                if (ModPrefs.GetBool("StreamInfo", "UseBackgroundImage", false, true) && File.Exists(Path.Combine(Plugin.dir, "image.png")))
                    BackgroundImage = Image.FromFile(Path.Combine(Plugin.dir, "image.png"));
                else
                    BackgroundImage = null;
                Refresh();
            }   
            else if (e.KeyCode == Keys.L)
            {
                locked = !locked;

                Text = "Overlay (" + Size.Width + "x" + Size.Height + ") (Locked: " + locked + ")";
            }
        }

        public void ShutDown()
        {
            Close();
        }
        public void UpdateText(string multiplier, string score, string progress, string combo, string notes, string energy)
        {
            int percent = Convert.ToInt32(energy);
            energy = "HP  (" + percent + "%)  ";
            if (percent == -1)
                energy = "BAILED OUT";
            else if (percent == -2)
                energy = "FAILED";
            else if (percent == -3)
                energy = "NO FAIL";
            else
            {
                int count = Convert.ToInt32(percent) / 2;
                for (int i = 0; i < count; i++)
                    energy += "█";
                for (int i = 0; i < 50 - count; i++)
                    energy += "░";
            }

            label_multiplier.Text = multiplier + "x";
            label_score.Text = score;
            label_progress.Text = progress;
            label_combo.Text = combo;
            label_notes.Text = notes;
            label_energy.Text = energy;
        }
        
        Point p_multiplier = new Point(0,0);
        Point p_combo = new Point(0, 0);
        Point p_score = new Point(0, 0);
        Point p_accuracy = new Point(0, 0);
        Point p_time = new Point(0, 0);
        Point p_energy = new Point(0, 0);
        
        private void panel_multiplier_MouseDown(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                p_multiplier.X = e.X;
                p_multiplier.Y = e.Y;
                panel_multiplier.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void panel_multiplier_MouseUp(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                panel_multiplier.Location = new Point(e.X - p_multiplier.X + panel_multiplier.Location.X, e.Y - p_multiplier.Y + panel_multiplier.Location.Y);
                p_multiplier = new Point(0, 0);
                panel_multiplier.BorderStyle = BorderStyle.None;
            }
                
        }

        private void panel_combo_MouseDown(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                p_combo.X = e.X;
                p_combo.Y = e.Y;
                panel_combo.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void panel_combo_MouseUp(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                panel_combo.Location = new Point(e.X - p_combo.X + panel_combo.Location.X, e.Y - p_combo.Y + panel_combo.Location.Y);
                p_combo = new Point(0, 0);
                panel_combo.BorderStyle = BorderStyle.None;
            }
        }

        private void panel_score_MouseDown(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                p_score.X = e.X;
                p_score.Y = e.Y;
                panel_score.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void panel_score_MouseUp(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                panel_score.Location = new Point(e.X - p_score.X + panel_score.Location.X, e.Y - p_score.Y + panel_score.Location.Y);
                p_score = new Point(0, 0);
                panel_score.BorderStyle = BorderStyle.None;
            }
        }
        
        private void panel_accuracy_MouseDown(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                p_accuracy.X = e.X;
                p_accuracy.Y = e.Y;
                panel_accuracy.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void panel_accuracy_MouseUp(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                panel_accuracy.Location = new Point(e.X - p_accuracy.X + panel_accuracy.Location.X, e.Y - p_accuracy.Y + panel_accuracy.Location.Y);
                p_accuracy = new Point(0, 0);
                panel_accuracy.BorderStyle = BorderStyle.None;
            }
        }

        private void panel_time_MouseDown(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                p_time.X = e.X;
                p_time.Y = e.Y;
                panel_time.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void panel_time_MouseUp(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                panel_time.Location = new Point(e.X - p_time.X + panel_time.Location.X, e.Y - p_time.Y + panel_time.Location.Y);
                p_time = new Point(0, 0);
                panel_time.BorderStyle = BorderStyle.None;
            }
        }

        private void label_energy_MouseDown(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                p_energy.X = e.X;
                p_energy.Y = e.Y;
                label_energy.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void label_energy_MouseUp(object sender, MouseEventArgs e)
        {
            if (!locked)
            {
                label_energy.Location = new Point(e.X - p_energy.X + label_energy.Location.X, e.Y - p_energy.Y + label_energy.Location.Y);
                p_energy = new Point(0, 0);
                label_energy.BorderStyle = BorderStyle.None;
            }
        }
    }
}
