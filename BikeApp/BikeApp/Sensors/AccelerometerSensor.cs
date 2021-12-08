using Acr.UserDialogs;
using BikeApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BikeApp.Sensors
{
    public class AccelerometerSensor
    {
        private MeasurementPage parentInstance;
        private bool isAlertActive;
        private bool shakeDetection;
        const SensorSpeed speed = SensorSpeed.UI;
        public double XAcceleration { get; set; } = 0;
        public double YAcceleration { get; set; } = 0;
        public double ZAcceleration { get; set; } = 0;
        public double GForceValue { get; set; } = 0;

        public AccelerometerSensor(MeasurementPage parentInstance)
        {
            this.parentInstance = parentInstance;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            if(shakeDetection)
                DisplayDialog("Accelerometer", "Shake detected", "Ok");
        }

        
        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.Stop();
                    DisplayDialog("Accelerometer", "Accelerometer stopped", "Ok");
                }
                else
                {
                    Accelerometer.Start(speed);
                    DisplayDialog("Accelerometer", "Accelerometer started", "Ok");
                }       
            }
            catch (FeatureNotSupportedException)
            {
                DisplayDialog("Accelerometer", "This feature isn't available on your device", "Ok");
            }
            catch (Exception e)
            {
                DisplayDialog("Accelerometer", $"Unknown exception: {e.Message}", "Ok");
            }
        }

        public void ToggleShakeDetection()
        {
            if (!Accelerometer.IsMonitoring)
                DisplayDialog("Accelerometer", "Shake detection will be working only if accelerometer is toggled", "Ok");

            shakeDetection = !shakeDetection;
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading; 
            XAcceleration = Math.Round(data.Acceleration.X, 2);
            YAcceleration = Math.Round(data.Acceleration.Y, 2);
            ZAcceleration = Math.Round(data.Acceleration.Z, 2);
            GForceValue = Math.Round(Math.Sqrt(XAcceleration * XAcceleration + YAcceleration * YAcceleration + ZAcceleration * ZAcceleration), 2);

            parentInstance.UpdateReadings(XAcceleration, YAcceleration, ZAcceleration, GForceValue);
        }

        public double GetXAxisAcceleration() => XAcceleration;
        public double GetYAxisAcceleration() => YAcceleration;
        public double GetZAxisAcceleration() => ZAcceleration;
        public bool GetState() => Accelerometer.IsMonitoring;
        private void DisplayDialog(string title, string message, string cancel)
        {
            if(!isAlertActive)
            {
                var config = new AlertConfig();
                config.Title = title;
                config.Message = message;
                config.OkText = cancel;
                config.OnAction += AlertAccepted;

                isAlertActive = true;
                UserDialogs.Instance.Alert(config);
            }
        }
        private void AlertAccepted() => isAlertActive = false;
    }
}
