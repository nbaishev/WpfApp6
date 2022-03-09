using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string windDirection;
        private int windSpeed;
        private byte precipitation;
        public sbyte Temp
        {
            get => (sbyte)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        private string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }
        private int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }
        private byte Precipitation
        {
            get => precipitation;
            set => precipitation = value;
        }
        public WeatherControl(sbyte temp, string windDirection, int windSpeed, byte precipitation)
        {
            this.Temp = temp;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.Precipitation = precipitation;
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(sbyte),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return -51;
        }

        public void Print()
        {
            Console.WriteLine($"{Temp} {WindDirection} {WindSpeed} {Precipitation}");
        }
    }
}
