using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pauseButton.Background = new SolidColorBrush(Colors.Red);
            timerPaused = true;
            imageIndex = -1;

            InitTimer();
        }

        private string folderPath = string.Empty;

        private List<string> imagesPathList = new List<string>();

        private int timerGlobalTime = 5 * 60;
        private int timeElapsed = 0;
        private bool timerPaused = true;
        private int imageIndex = -1;



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

            

            if (imagesPathList.Count > 0) imageIndex = 0;
            else return;

            imagesPathList = imagesPathList.OrderBy(a => rng.Next()).ToList();
            timerPaused = true;
            pauseButton.Background = new SolidColorBrush(Colors.Red);
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
                timeElapsed = 0;
                BitmapImage bmi = new BitmapImage(new Uri(imagesPathList[imageIndex].ToString(), UriKind.Absolute));
                image.BeginInit();
                image.Source = bmi;
                image.EndInit();

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
                timeElapsed = 0;
                BitmapImage bmi = new BitmapImage(new Uri(imagesPathList[imageIndex].ToString(), UriKind.Absolute));
                image.BeginInit();
                image.Source = bmi;
                image.EndInit();

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(imageIndex >= 0 && timerPaused == false && timeComboBox.SelectedIndex != 15)
            {
                timeElapsed += 1;
                if(timeElapsed > timerGlobalTime)
                {
                    timeElapsed = 0;
                    NextImage();
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
    }
}
