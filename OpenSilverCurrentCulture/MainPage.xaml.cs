using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace OpenSilverCurrentCulture
{
    public partial class MainPage : Page
    {
        private DispatcherTimer _timer;

        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            TB.Text = $"The Culture is set to {Thread.CurrentThread.CurrentCulture.Name}. Thread Id is {Thread.CurrentThread.ManagedThreadId}";
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TB.Text += Environment.NewLine +
                       $"Current Culture is {Thread.CurrentThread.CurrentCulture.Name}. Thread Id is {Thread.CurrentThread.ManagedThreadId}";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += Environment.NewLine + "I Did Something";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;
            TB.Text += Environment.NewLine + $"Culture inside click handler {culture}. Thread Id is {Thread.CurrentThread.ManagedThreadId}";
        }
    }
}
