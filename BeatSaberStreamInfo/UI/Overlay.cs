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
        FontFamily Font;
        DateTime lastWrite;

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

            Font = fonts.Families[0];
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            lastWrite = DateTime.Now;

            label_multiplier.Font = new Font(Font, 50);
            label_score.Font = new Font(Font, 30);
            label_progress.Font = new Font(Font, 20);

            label_combo.Font = new Font(Font, 50);
            label_combotext.Font = new Font(Font, 25);
            label_notes.Font = new Font(Font, 20);

            label_energy.Font = new Font(Font, 18);
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
