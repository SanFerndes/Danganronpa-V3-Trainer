using System;
using System.Windows;
using System.Diagnostics;
using HandyControl.Controls;

namespace Danganronpa_V3_Trainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : GlowWindow
    {
        private Process[] danganronpaProcessName;

        private bool isOpen = false;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            WaitForDanganronpa();
        }

        private void WaitForDanganronpa()
        {
            //If the process isn't found.
            if (DanganronpaIsNotOpen())
            {
                isOpen = false;

                LoopLookForDanganronpa();
            }
            //If the process is found.
            else if (!DanganronpaIsNotOpen())
            {
                isOpen = true;

                HideLoadingScreen();
                ShowTrainer();
            }
        }

        private bool DanganronpaIsNotOpen()
        {
            danganronpaProcessName = Process.GetProcessesByName("Dangan3Win");

            return danganronpaProcessName.Length == 0;
        }

        private void LoopLookForDanganronpa()
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;

            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!DanganronpaIsNotOpen())
            {
                HideLoadingScreen();
                ShowTrainer();

                dispatcherTimer.Stop();
            }
            else
            {
                if (DanganronpaIsNotOpen())
                {
                    isOpen = false;
                }
            }
        }

        private void HideLoadingScreen()
        {
            loadingScreen.Visibility = Visibility.Hidden;
        }

        private void ShowTrainer()
        {
            Trainer.Visibility = Visibility.Visible;
        }
    }
}
