using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FinanceV1
{
    public partial class FrmFNCamPic : Form
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }
        string picID = string.Empty;
        public FrmFNCamPic(string pId)
        {
            InitializeComponent();
            picID = pId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Start"))
            {
                CaptureCamera();
                button1.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                button1.Text = "Start";
                isCameraRunning = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                // Take snapshot of the current image generate by OpenCV in the Picture Box
                Bitmap snapshot = new Bitmap(pictureBox1.Image);

                // Save in some directory
                // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                if (File.Exists(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", picID)))
                    File.Delete(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", picID));

                snapshot.Save(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", picID), ImageFormat.Png);//Guid.NewGuid()
            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
            this.Close();
        }
    }
}
