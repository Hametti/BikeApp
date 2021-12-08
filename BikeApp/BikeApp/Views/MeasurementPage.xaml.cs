using BikeApp.Data.Themes;
using BikeApp.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    public partial class MeasurementPage : ContentPage
    {
        private readonly AccelerometerSensor _accelerometer;
        private bool isAlertVisible;
        private double maxGForce = 0;
        public MeasurementPage()
        {
            InitializeComponent();
            _accelerometer = new AccelerometerSensor(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            ((ContentPage)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
            ((Label)FindByName("AccelerometerLabel")).TextColor = Color.FromHex(CurrentTheme.TextColor);
        }

        public void UpdateReadings(double xAxis, double yAxis, double zAxis, double Gforce)
        {
            XAxis.Text = $"X Axis: {xAxis}";
            YAxis.Text = $"Y Axis: {yAxis}";
            ZAxis.Text = $"Z Axis: {zAxis}";
            GForce.Text = $"G force: {Gforce}";
            MaximumGForce.Text = $"Max G force: {maxGForce}";

            if (Gforce > maxGForce)
                maxGForce = Gforce;
        }
        private void AccelerometerSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            _accelerometer.ToggleAccelerometer();

            if (!_accelerometer.GetState())
                ResetValues();
        }

        private void ResetValues()
        {
            XAxis.Text = "X Axis: Unknown";
            YAxis.Text = "Y Axis: Unknown";
            ZAxis.Text = "Z Axis: Unknown";
            GForce.Text = "G force: Unknown";
        }

        private void ShakeDetectionSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            _accelerometer.ToggleShakeDetection();
        }
    }
}