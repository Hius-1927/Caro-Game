using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace GameCaro
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            EnsureResources();
            Application.Run(new Form1());
        }

        static void EnsureResources()
        {
            try
            {
                string resDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                if (!Directory.Exists(resDir))
                {
                    Directory.CreateDirectory(resDir);
                }

                string p1Path = Path.Combine(resDir, "P1.png");
                if (!File.Exists(p1Path))
                {
                    using (Bitmap bmp = new Bitmap(100, 100))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                        using (Pen pen = new Pen(Color.Red, 10))
                        {
                            g.DrawLine(pen, 15, 15, 85, 85);
                            g.DrawLine(pen, 85, 15, 15, 85);
                        }
                        bmp.Save(p1Path, ImageFormat.Png);
                    }
                }

                string p2Path = Path.Combine(resDir, "P2.png");
                if (!File.Exists(p2Path))
                {
                    using (Bitmap bmp = new Bitmap(100, 100))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                        using (Pen pen = new Pen(Color.Blue, 10))
                        {
                            g.DrawEllipse(pen, 15, 15, 70, 70);
                        }
                        bmp.Save(p2Path, ImageFormat.Png);
                    }
                }

                string caroPath = Path.Combine(resDir, "caro.png");
                if (!File.Exists(caroPath))
                {
                    using (Bitmap bmp = new Bitmap(263, 263))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.LightGray);
                        using (Pen pen = new Pen(Color.Gray, 1))
                        {
                            for (int i = 0; i < 263; i += 20)
                            {
                                g.DrawLine(pen, i, 0, i, 263);
                                g.DrawLine(pen, 0, i, 263, i);
                            }
                        }
                        using (Pen pen = new Pen(Color.Red, 5))
                        {
                            g.DrawLine(pen, 40, 40, 80, 80);
                            g.DrawLine(pen, 80, 40, 40, 80);
                        }
                        using (Pen pen = new Pen(Color.Blue, 5))
                        {
                            g.DrawEllipse(pen, 160, 160, 40, 40);
                        }
                        g.DrawString("CARO LAN", new Font("Arial", 24, FontStyle.Bold), Brushes.DarkSlateGray, new PointF(40, 110));
                        bmp.Save(caroPath, ImageFormat.Png);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing resources: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}