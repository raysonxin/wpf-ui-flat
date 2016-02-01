using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FlatApp.UI.Controls;

namespace FlatApp.UI.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FlatWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            rtxt.AppendText("sdkfjskdjfksdjfksjdkfjskagahsigfiwagjiwagiasjigj");
        }

        double progressValue = 0;
        DispatcherTimer timer = new DispatcherTimer();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnTest.IsShowTitle = !btnTest.IsShowTitle;
            progressValue = 0;
           
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;
            timer.Start();
        }



        void timer_Tick(object sender, EventArgs e)
        {
            progressValue += 0.05;
            circleBar2.Value = progressValue;
            circleBar.Value = progressValue;
            if (progressValue >= 1)
            {
                timer.Stop();
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
