using System;
using System.Windows;
using System.Diagnostics;
using HandyControl.Controls;
using System.Linq;

namespace Danganronpa_V3_Trainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : GlowWindow
    {
        private Process[] danganronpaProcessName;

        private Memory.Mem memory = new Memory.Mem();

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
                LoopLookForDanganronpa();
            }
            //If the process is found.
            else if (!DanganronpaIsNotOpen())
            {
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
        }

        private void HideLoadingScreen()
        {
            loadingScreen.Visibility = Visibility.Hidden;
        }

        private void ShowTrainer()
        {
            Trainer.Visibility = Visibility.Visible;
        }

        private void topMostToggle_Checked(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void topMostToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
        }

        private void infiniteCasinoCoinsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memory.OpenProcess(Process.GetProcessesByName("Dangan3Win").FirstOrDefault().Id);
            }
            catch (Exception exc)
            {
                HandyControl.Controls.MessageBox.Show("Please open Danganronpa first!", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            memory.WriteMemory("Dangan3Win.exe+D20080,aee0", "int", "999999999");

            HandyControl.Controls.MessageBox.Show("Infinite Casino Coins updated successfuly!", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void infiniteMonoCoinsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memory.OpenProcess(Process.GetProcessesByName("Dangan3Win").FirstOrDefault().Id);
            }
            catch (Exception exc)
            {
                HandyControl.Controls.MessageBox.Show("Please open Danganronpa first!", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            memory.WriteMemory("Dangan3Win.exe+D20080,2636", "int", "999");

            HandyControl.Controls.MessageBox.Show("Infinite Mono Coins updated successfuly!", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void infiniteEXPButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memory.OpenProcess(Process.GetProcessesByName("Dangan3Win").FirstOrDefault().Id);
            }
            catch (Exception exc)
            {
                HandyControl.Controls.MessageBox.Show("Please open Danganronpa first!", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            memory.WriteMemory("Dangan3Win.exe+D20080,2410", "int", "999999");

            HandyControl.Controls.MessageBox.Show("Infinite EXP updated successfuly!", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
