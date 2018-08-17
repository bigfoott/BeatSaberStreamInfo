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

        private Dictionary<string, string> config;

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

        private Dictionary<string, string> LoadConfig()
        {
            var c = new Dictionary<string, string>();

            List<string> ValidSettings = new List<string> { "BackgroundColor", "TextColor", "UseBackgroundImage" };
            string[] lines = File.ReadAllLines(Path.Combine(Plugin.dir, "OverlayConfig.txt"));
            foreach (string setting in ValidSettings)
            {
                if (lines.Any(l => l.StartsWith(setting + "=") && l.Length > setting.Length + 1))
                    c.Add(setting, lines.First(l => l.StartsWith(setting + "=")).Substring(setting.Length + 1));
                else
                    c.Add(setting, "");
            }

            return c;
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            config = LoadConfig();

            ForeColor = Color.FromName(config["TextColor"]);
            BackColor = Color.FromName(config["BackgroundColor"]);

            if (config["UseBackgroundImage"].ToLower() == "true" && File.Exists(Path.Combine(Plugin.dir, "image.png")))
                BackgroundImage = Image.FromFile(Path.Combine(Plugin.dir, "image.png"));
            
            label_multiplier.Font = new Font(MainFont, 50);
            label_score.Font = new Font(MainFont, 30);
            label_progress.Font = new Font(MainFont, 20);

            label_combo.Font = new Font(MainFont, 50);
            label_combotext.Font = new Font(MainFont, 25);
            label_notes.Font = new Font(MainFont, 20);

            label_energy.Font = new Font(MainFont, 18);
        }

        public void UpdateText(string multiplier, string score, string progress, string combo, string notes, string energy)
        {
            int percent = Convert.ToInt32(energy);
            string bar = "";
            int count = Convert.ToInt32(percent) / 2;
            for (int i = 0; i < count; i++)
                bar += "█";
            for (int i = 0; i < 50 - count; i++)
                bar += "░";

            label_multiplier.Text = multiplier + "x";
            label_score.Text = score;
            label_progress.Text = progress;
            label_combo.Text = combo;
            label_notes.Text = notes;
            label_energy.Text = bar + "  (" + percent + "%)";
        }
    }
}
