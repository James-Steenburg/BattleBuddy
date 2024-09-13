using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace BattleBuddy.TestViews
{
    /// <summary>
    /// Interaction logic for TestColorsWindow.xaml
    /// </summary>
    public partial class TestColorsWindow : Window
    {
        /*
        private Color _testColor = Color.FromRgb(0x24, 0x10, 0x5F);
        public Color TestColor
        {
            get { return _testColor; }
            set { _testColor = value; OnPropertyChanged(nameof(TestColor)); }
        }
        */
        public Color TestColor_d3;
        public Color TestColor_d2;
        public Color TestColor_d1;
        public Color TestColor_l3;
        public Color TestColor_l2;
        public Color TestColor_11;
        HslColor hslTestColor;

        public TestColorsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Color TestColor = (Color)ColorConverter.ConvertFromString(txtBoxTestColorInput.Text);
                hslTestColor = new HslColor(TestColor);
                HSLTestColorBlock.Text = hslTestColor.h.ToString() + ", " + hslTestColor.s.ToString() + ", " + hslTestColor.l.ToString();

                HslColor hslTestColor_d3 = hslTestColor.Lighten(0.7);
                HslColor hslTestColor_d2 = hslTestColor.Lighten(0.8);
                HslColor hslTestColor_d1 = hslTestColor.Lighten(0.9);
                HslColor hslTestColor_l3 = hslTestColor.Lighten(1.3);
                HslColor hslTestColor_l2 = hslTestColor.Lighten(1.2);
                HslColor hslTestColor_11 = hslTestColor.Lighten(1.1);

                TestColor_d3 = hslTestColor_d3.ToRgb();
                TestColor_d2 = hslTestColor_d2.ToRgb();
                TestColor_d1 = hslTestColor_d1.ToRgb();
                TestColor_l3 = hslTestColor_l3.ToRgb();
                TestColor_l2 = hslTestColor_l2.ToRgb();
                TestColor_11 = hslTestColor_11.ToRgb();

                Debug.WriteLine("base\t" + TestColor);
                Debug.WriteLine("d3 \t" + TestColor_d3);
                Debug.WriteLine("d2 \t" + TestColor_d2);
                Debug.WriteLine("d1 \t" + TestColor_d1);
                Debug.WriteLine("l3 \t" + TestColor_l3);
                Debug.WriteLine("l2 \t" + TestColor_l2);
                Debug.WriteLine("l1 \t" + TestColor_11);

                SolidColorBrush baseColor = new SolidColorBrush(TestColor);
                SolidColorBrush d3 = new SolidColorBrush(TestColor_d3);
                SolidColorBrush d2 = new SolidColorBrush(TestColor_d2);
                SolidColorBrush d1 = new SolidColorBrush(TestColor_d1);
                SolidColorBrush l3 = new SolidColorBrush(TestColor_l3);
                SolidColorBrush l2 = new SolidColorBrush(TestColor_l2);
                SolidColorBrush l1 = new SolidColorBrush(TestColor_11);

                TestColorBlock.Background = baseColor;
                TestColord3Block.Background = d3;
                TestColord2Block.Background = d2;
                TestColord1Block.Background = d1;
                TestColorl3Block.Background = l3;
                TestColorl2Block.Background = l2;
                TestColorl1Block.Background = l1;

                HSLTestColord3Block.Text = hslTestColor_d3.h.ToString() + ", " + hslTestColor_d3.s.ToString() + ", " + hslTestColor_d3.l.ToString();
                HSLTestColord2Block.Text = hslTestColor_d2.h.ToString() + ", " + hslTestColor_d2.s.ToString() + ", " + hslTestColor_d2.l.ToString();
                HSLTestColord1Block.Text = hslTestColor_d1.h.ToString() + ", " + hslTestColor_d1.s.ToString() + ", " + hslTestColor_d1.l.ToString();
                HSLTestColorl3Block.Text = hslTestColor_l3.h.ToString() + ", " + hslTestColor_l3.s.ToString() + ", " + hslTestColor_l3.l.ToString();
                HSLTestColorl2Block.Text = hslTestColor_l2.h.ToString() + ", " + hslTestColor_l2.s.ToString() + ", " + hslTestColor_l2.l.ToString();
                HSLTestColorl1Block.Text = hslTestColor_11.h.ToString() + ", " + hslTestColor_11.s.ToString() + ", " + hslTestColor_11.l.ToString();
            }
            catch
            {
                System.Windows.MessageBox.Show("Error");
            }
        }
    }

    public class HslColor
    {
        public readonly double h, s, l, a;

        public HslColor(double h, double s, double l, double a)
        {
            this.h = h;
            this.s = s;
            this.l = l;
            this.a = a;
        }

        public HslColor(System.Windows.Media.Color rgb)
        {
            RgbToHls(rgb.R, rgb.G, rgb.B, out h, out l, out s);
            a = rgb.A / 255.0;
        }

        public System.Windows.Media.Color ToRgb()
        {
            int r, g, b;
            HlsToRgb(h, l, s, out r, out g, out b);
            return System.Windows.Media.Color.FromArgb((byte)(a * 255.0), (byte)r, (byte)g, (byte)b);
        }

        public HslColor Lighten(double amount)
        {
            return new HslColor(h, s, Clamp(l * amount, 0, 1), a);
        }

        private static double Clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;

            return value;
        }

        // Convert an RGB value into an HLS value.
        static void RgbToHls(int r, int g, int b,
            out double h, out double l, out double s)
        {
            // Convert RGB to a 0.0 to 1.0 range.
            double double_r = r / 255.0;
            double double_g = g / 255.0;
            double double_b = b / 255.0;

            // Get the maximum and minimum RGB components.
            double max = double_r;
            if (max < double_g) max = double_g;
            if (max < double_b) max = double_b;

            double min = double_r;
            if (min > double_g) min = double_g;
            if (min > double_b) min = double_b;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double r_dist = (max - double_r) / diff;
                double g_dist = (max - double_g) / diff;
                double b_dist = (max - double_b) / diff;

                if (double_r == max) h = b_dist - g_dist;
                else if (double_g == max) h = 2 + r_dist - b_dist;
                else h = 4 + g_dist - r_dist;

                h = h * 60;
                if (h < 0) h += 360;
            }

        }

        // Convert an HLS value into an RGB value.
        static void HlsToRgb(double h, double l, double s,
            out int r, out int g, out int b)
        {
            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QqhToRgb(p1, p2, h + 120);
                double_g = QqhToRgb(p1, p2, h);
                double_b = QqhToRgb(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            r = (int)(double_r * 255.0);
            g = (int)(double_g * 255.0);
            b = (int)(double_b * 255.0);
        }

        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }
    }
}
