using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AccMeter2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            LabelX.Text = data.Acceleration.X.ToString("F1");
            LabelY.Text = data.Acceleration.Y.ToString("F1");
            LabelZ.Text = data.Acceleration.Z.ToString("F1");
        }

        private void StartClicked(object s, EventArgs e)
        {
            if (Accelerometer.IsMonitoring) return;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.Default);
        }

        private void StopClicked(object s, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring) return;
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Stop();
        }

    }
}
