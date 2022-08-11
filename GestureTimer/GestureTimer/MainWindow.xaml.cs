using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestureTimer
{

    public static class ImageOperations
    {
        public static Bitmap ToBitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
        public static void ToGrayScale(Bitmap Bmp)
        {
            int rgb;
            System.Drawing.Color c;

            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(rgb, rgb, rgb));


                }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pauseButton.Background = new SolidColorBrush(Colors.Red);
            flipButton.Background = new SolidColorBrush(Colors.Red);
            bnwButton.Background = new SolidColorBrush(Colors.Red);
            timerPaused = true;
            imageIndex = -1;

            InitTimer();
        }

        private string folderPath = string.Empty;

        private List<string> imagesPathList = new List<string>();

        public BitmapImage bmi = new BitmapImage();
        public BitmapImage blackAndWhiteBmi = new BitmapImage();

        private int timerGlobalTime = 5 * 60;
        private int timeElapsed = 0;
        private bool timerPaused = true;
        private int imageIndex = -1;
        private bool bnwOn = false;
        private bool flipOn = false;

        private void FlipImage()
        {
            if(bnwOn)
            {
                Bitmap tmpBmp = ImageOperations.ToBitmap(blackAndWhiteBmi);
                tmpBmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                blackAndWhiteBmi = ImageOperations.ToBitmapImage(tmpBmp);

                image.BeginInit();
                image.Source = blackAndWhiteBmi;
                image.EndInit();
            }
            else
            {
                Bitmap tmpBmp = ImageOperations.ToBitmap(bmi);
                tmpBmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                bmi = ImageOperations.ToBitmapImage(tmpBmp);

                image.BeginInit();
                image.Source = bmi;
                image.EndInit();
            }
            

        }



        private void BlackAndWhiteImage()
        {
            if(bnwOn)
            {
                Bitmap tmpBmp = ImageOperations.ToBitmap(bmi);


                ImageOperations.ToGrayScale(tmpBmp);

                blackAndWhiteBmi = ImageOperations.ToBitmapImage(tmpBmp);

                image.BeginInit();
                image.Source = blackAndWhiteBmi;
                image.EndInit();
            }
            else
            {
                image.BeginInit();
                image.Source = bmi;
                image.EndInit();
            }
        }

        private void SwitchFlip()
        {
            if (flipOn)
            {
                flipOn = false;
                flipButton.Background = new SolidColorBrush(Colors.Red);
                if (imageIndex >= 0 && imagesPathList.Count > 0)
                {
                    FlipImage();
                }
            }
            else
            {
                flipOn = true;
                flipButton.Background = new SolidColorBrush(Colors.Green);
                if (imageIndex >= 0 && imagesPathList.Count > 0)
                {
                    FlipImage();
                }
            }
        }
        private void SwitchBnw()
        {
            if(bnwOn)
            {
                bnwOn = false;
                bnwButton.Background = new SolidColorBrush(Colors.Red);
                if (imageIndex >= 0 && imagesPathList.Count > 0)
                {
                    BlackAndWhiteImage();
                }
            }
            else
            {
                bnwOn = true;
                bnwButton.Background = new SolidColorBrush(Colors.Green);
                if (imageIndex >= 0 && imagesPathList.Count > 0)
                {
                    BlackAndWhiteImage();
                }
            }
        }

        private void SetTimerToTime(int seconds)
        {
            timerGlobalTime = seconds;

            if(seconds == -1)
            {
                timeLeftBox.Text = "Unlimited";
            }

            timeElapsed = 0;

        }
        private void timeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = timeComboBox.SelectedIndex;
            if (selectedIndex < 0) return;
            else if (selectedIndex == 0) SetTimerToTime(10);
            else if (selectedIndex == 1) SetTimerToTime(20);
            else if (selectedIndex == 2) SetTimerToTime(30);
            else if (selectedIndex == 3) SetTimerToTime(40);
            else if (selectedIndex == 4) SetTimerToTime(50);
            else if (selectedIndex == 5) SetTimerToTime(1 * 60);
            else if (selectedIndex == 6) SetTimerToTime(2 * 60);
            else if (selectedIndex == 7) SetTimerToTime(3 * 60);
            else if (selectedIndex == 8) SetTimerToTime(4 * 60);
            else if (selectedIndex == 9) SetTimerToTime(5 * 60);
            else if (selectedIndex == 10) SetTimerToTime(10 * 60);
            else if (selectedIndex == 11) SetTimerToTime(20 * 60);
            else if (selectedIndex == 12) SetTimerToTime(30 * 60);
            else if (selectedIndex == 13) SetTimerToTime(1 * 60 * 60);
            else if (selectedIndex == 14) SetTimerToTime(2 * 60 * 60);
            else if (selectedIndex == 15) SetTimerToTime(-1);


            int timeLeft = timerGlobalTime - timeElapsed;
            int hours = timeLeft / (60 * 60);
            timeLeft -= hours * 60 * 60;
            int minutes = timeLeft / 60;
            timeLeft -= minutes * 60;
            int seconds = timeLeft;

            if (timeLeftBox != null && timeComboBox.SelectedIndex != 15)
                timeLeftBox.Text = (hours < 10 ? "0" : "") + hours + ":" + (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
            else if (timeLeftBox != null)
                timeLeftBox.Text = "Unlimited";
        }

        private static Random rng = new Random();

        private void selectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            imagesPathList.Clear();

            var lt = new ObservableCollection<string>();
            var dicFileList = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.ToLower().EndsWith(".png") || s.ToLower().EndsWith(".jpg") || s.ToLower().EndsWith(".jpeg") || s.ToLower().EndsWith(".bmp"));
            foreach (string element in dicFileList)
            {
                imagesPathList.Add(element);
            }

            

            if (imagesPathList.Count > 0) imageIndex = -1;
            else return;

            imagesPathList = imagesPathList.OrderBy(a => rng.Next()).ToList();
            timerPaused = true;
            pauseButton.Background = new SolidColorBrush(Colors.Red);
            flipOn = false;
            flipButton.Background = new SolidColorBrush(Colors.Red);
            bnwOn = false;
            bnwButton.Background = new SolidColorBrush(Colors.Red);
            NextImage();
            



        }

        private Timer timer = new Timer();
        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();
        }

        private void NextImage()
        {
            if(++imageIndex >= imagesPathList.Count)
            {
                imageIndex = 0;
            }

            if (imagesPathList.Count > 0)
            {
                
                bmi = new BitmapImage(new Uri(imagesPathList[imageIndex].ToString(), UriKind.Absolute));
                blackAndWhiteBmi = bmi.Clone();
                image.BeginInit();
                image.Source = bmi;
                image.EndInit();

                if (bnwOn) BlackAndWhiteImage();
                if (flipOn) FlipImage();
                timeElapsed = 0;
            }

        }

        private void PreviousImage()
        {
            if (--imageIndex < 0)
            {
                imageIndex = 0;
            }

            if (imagesPathList.Count > 0)
            {
                
                bmi = new BitmapImage(new Uri(imagesPathList[imageIndex].ToString(), UriKind.Absolute));
                blackAndWhiteBmi = bmi.Clone();
                image.BeginInit();
                image.Source = bmi;
                image.EndInit();

                if (bnwOn) BlackAndWhiteImage();
                if (flipOn) FlipImage();
                timeElapsed = 0;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(imageIndex >= 0 && timerPaused == false && timeComboBox.SelectedIndex != 15)
            {
                timeElapsed += 1;
                if(timeElapsed > timerGlobalTime)
                {
                    NextImage();
                    timeElapsed = 0;
                }

                int timeLeft = timerGlobalTime - timeElapsed;
                int hours = timeLeft / (60 * 60);
                timeLeft -= hours * 60 * 60;
                int minutes = timeLeft / 60;
                timeLeft -= minutes * 60;
                int seconds = timeLeft;

                if (timeLeftBox != null)
                    timeLeftBox.Text = (hours < 10 ? "0" : "") + hours + ":" + (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;

            }
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if(timerPaused)
            {
                timerPaused = false;
                pauseButton.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                timerPaused = true;
                pauseButton.Background = new SolidColorBrush(Colors.Red);
            }
            

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            NextImage();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousImage();
        }

        private void flipButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchFlip();
        }

        private void bnwButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchBnw();
        }
    }
}
