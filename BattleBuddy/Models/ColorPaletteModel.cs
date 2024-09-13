using BattleBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BattleBuddy.Models
{
    class ColorPaletteModel : ChangeNotifier
    {
        private Color _titleColor = Color.FromRgb(0xD5, 0xCF, 0xF5); //Color.FromRgb(0xE0, 0xE1, 0xF1);
        public Color Palette_TitleColor
        {
            get { return _titleColor; }
            set
            {
                _titleColor = value;
                OnPropertyChanged(nameof(Palette_TitleColor));
                OnPropertyChanged(nameof(Palette_TextColor));
            }
        }

        public Color Palette_TextColor
        {
            get
            {
                HslColor hsl_TitleColor = new HslColor(Palette_TitleColor);
                return hsl_TitleColor.Lighten(1.2).ToRgb();
            }
        }

        private Color _backgroundColor = Color.FromRgb(0x21, 0x0F, 0x55);
        public Color Palette_BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(Palette_BackgroundColor));
                OnPropertyChanged(nameof(Palette_BackgroundColor_Darker1));
                OnPropertyChanged(nameof(Palette_BackgroundColor_Darker2));
                OnPropertyChanged(nameof(Palette_BackgroundColor_Darker3));
                OnPropertyChanged(nameof(Palette_BackgroundColor_Lighter1));
                OnPropertyChanged(nameof(Palette_BackgroundColor_Lighter2));
                OnPropertyChanged(nameof(Palette_BackgroundColor_Lighter3));
            }
        }

        public Color Palette_BackgroundColor_Darker1
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(Palette_BackgroundColor);
                return hsl_BackgroundColor.Lighten(0.9).ToRgb();
            }
        }
        public Color Palette_BackgroundColor_Darker2
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(Palette_BackgroundColor);
                return hsl_BackgroundColor.Lighten(0.8).ToRgb();
            }
        }
        public Color Palette_BackgroundColor_Darker3
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(Palette_BackgroundColor);
                return hsl_BackgroundColor.Lighten(0.7).ToRgb();
            }
        }
        public Color Palette_BackgroundColor_Lighter1
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(Palette_BackgroundColor);
                return hsl_BackgroundColor.Lighten(1.1).ToRgb();
            }
        }
        public Color Palette_BackgroundColor_Lighter2
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(Palette_BackgroundColor);
                return hsl_BackgroundColor.Lighten(1.2).ToRgb();
            }
        }
        public Color Palette_BackgroundColor_Lighter3
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(Palette_BackgroundColor);
                return hsl_BackgroundColor.Lighten(1.3).ToRgb();
            }
        }

        private Color _borderColor = Color.FromRgb(0x83, 0x6E, 0xFB);
        public Color Palette_BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                OnPropertyChanged(nameof(Palette_BorderColor));
                OnPropertyChanged(nameof(Palette_BorderColor_Darker));
                OnPropertyChanged(nameof(Palette_BorderColor_Lighter));
            }
        }

        public Color Palette_BorderColor_Darker
        {
            get
            {
                HslColor hsl_BorderColor = new HslColor(Palette_BorderColor);
                return hsl_BorderColor.Lighten(0.7).ToRgb();
            }
        }
        public Color Palette_BorderColor_Lighter
        {
            get
            {
                HslColor hsl_BorderColor = new HslColor(Palette_BorderColor);
                return hsl_BorderColor.Lighten(1.3).ToRgb();
            }
        }

        private Color _buttonColor = Color.FromRgb(0x78, 0x4D, 0xFD);
        public Color Palette_ButtonColor
        {
            get { return _buttonColor; }
            set { _buttonColor = value; OnPropertyChanged(nameof(Palette_ButtonColor)); }
        }

        private Color _buttonHoverColor = Color.FromRgb(0x83, 0x6E, 0xFB);
        public Color Palette_ButtonHoverColor
        {
            get { return _buttonHoverColor; }
            set { _buttonHoverColor = value; OnPropertyChanged(nameof(Palette_ButtonHoverColor)); }
        }

        private Color _iconColor = Color.FromRgb(0x33, 0xAA, 0x11); //(0x94, 0x97, 0xCD);
        public Color Palette_IconColor
        {
            get { return _iconColor; }
            set { _iconColor = value; OnPropertyChanged(nameof(Palette_IconColor)); }
        }

        private Color _iconHoverColor = Color.FromRgb(0x33, 0xAA, 0xFF); //(0x94, 0x97, 0xCD);
        public Color Palette_IconHoverColor
        {
            get { return _iconHoverColor; }
            set { _iconHoverColor = value; OnPropertyChanged(nameof(Palette_IconHoverColor)); }
        }

        private Color _defaultCharacterColor1;
        public Color Palette_DefaultCharacterColor1
        {
            get { return _defaultCharacterColor1; }
            set { _defaultCharacterColor1 = value; OnPropertyChanged(nameof(Palette_DefaultCharacterColor1)); }
        }

        private Color _defaultCharacterColor2;
        public Color Palette_DefaultCharacterColor2
        {
            get { return _defaultCharacterColor2; }
            set { _defaultCharacterColor2 = value; OnPropertyChanged(nameof(Palette_DefaultCharacterColor2)); }
        }

        private Color _defaultCharacterColor3;
        public Color Palette_DefaultCharacterColor3
        {
            get { return _defaultCharacterColor3; }
            set { _defaultCharacterColor3 = value; OnPropertyChanged(nameof(Palette_DefaultCharacterColor3)); }
        }

    }
}
