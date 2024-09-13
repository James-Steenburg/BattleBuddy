using BattleBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BattleBuddy.Models
{
    internal class UserSettings : ChangeNotifier
    {
        private string _defaultPartyFilePath;
        public string DefaultPartyFilePath
        {
            get { return _defaultPartyFilePath; }
            set { _defaultPartyFilePath = value; OnPropertyChanged(nameof(DefaultPartyFilePath)); }
        }

        public string _backgroundImageFilePath;
        public string BackgroundImageFilePath
        {
            get { return _backgroundImageFilePath; }
            set { _backgroundImageFilePath = value; OnPropertyChanged(nameof(BackgroundImageFilePath)); }
        }

        private bool _useBackgroundImage;
        public bool UseBackgroundImage
        {
            get { return _useBackgroundImage; }
            set { _useBackgroundImage = value; OnPropertyChanged(nameof(UseBackgroundImage)); }
        }

        private int _applicationTheme;
        public int ApplicationTheme
        {
            get { return _applicationTheme; }
            set { _applicationTheme = value; OnPropertyChanged(nameof(ApplicationTheme)); }
        }

        private ObservableCollection<CharacterCondition> _conditionList;
        public ObservableCollection<CharacterCondition> ConditionList
        {
            get { return _conditionList; }
            set { _conditionList = value; }
        }
        
        private bool _useCharacterUniqueColorsInDetailView;
        public bool UseCharacterUniqueColorsInDetailView
        {
            get { return _useCharacterUniqueColorsInDetailView; }
            set { _useCharacterUniqueColorsInDetailView = value; OnPropertyChanged(nameof(UseCharacterUniqueColorsInDetailView)); }
        }

        private bool _useCharacterUniqueColorsInSummaryView;
        public bool UseCharacterUniqueColorsInSummaryView
        {
            get { return _useCharacterUniqueColorsInSummaryView; }
            set { _useCharacterUniqueColorsInSummaryView = value; OnPropertyChanged(nameof(UseCharacterUniqueColorsInSummaryView)); }
        }

        //TODO: Replace default colors with correct/final default colors
        private Color _titleColor = Color.FromRgb(0xD5, 0xCF, 0xF5); //Color.FromRgb(0xE0, 0xE1, 0xF1);
        public Color Custom_TitleColor
        {
            get { return _titleColor; }
            set
            {
                _titleColor = value;
                OnPropertyChanged(nameof(Custom_TitleColor));
            }
        }

        private Color _backgroundColor = Color.FromRgb(0x21, 0x0F, 0x55);
        public Color Custom_BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(Custom_BackgroundColor));
            }
        }

        private Color _borderColor = Color.FromRgb(0x83, 0x6E, 0xFB);
        public Color Custom_BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                OnPropertyChanged(nameof(Custom_BorderColor));
            }
        }

        private Color _buttonColor = Color.FromRgb(0x78, 0x4D, 0xFD);
        public Color Custom_ButtonColor
        {
            get { return _buttonColor; }
            set { _buttonColor = value; OnPropertyChanged(nameof(Custom_ButtonColor)); }
        }

        private Color _buttonHoverColor = Color.FromRgb(0x83, 0x6E, 0xFB);
        public Color Custom_ButtonHoverColor
        {
            get { return _buttonHoverColor; }
            set { _buttonHoverColor = value; OnPropertyChanged(nameof(Custom_ButtonHoverColor)); }
        }

        private Color _iconColor = Color.FromRgb(0x33, 0xAA, 0x11); //(0x94, 0x97, 0xCD);
        public Color Custom_IconColor
        {
            get { return _iconColor; }
            set { _iconColor = value; OnPropertyChanged(nameof(Custom_IconColor)); }
        }

        private Color _iconHoverColor = Color.FromRgb(0x33, 0xAA, 0xFF); //(0x94, 0x97, 0xCD);
        public Color Custom_IconHoverColor
        {
            get { return _iconHoverColor; }
            set { _iconHoverColor = value; OnPropertyChanged(nameof(Custom_IconHoverColor)); }
        }

        private Color _defaultCharacterColor1;
        public Color Custom_DefaultCharacterColor1
        {
            get { return _defaultCharacterColor1; }
            set { _defaultCharacterColor1 = value; OnPropertyChanged(nameof(Custom_DefaultCharacterColor1)); }
        }

        private Color _defaultCharacterColor2;
        public Color Custom_DefaultCharacterColor2
        {
            get { return _defaultCharacterColor2; }
            set { _defaultCharacterColor2 = value; OnPropertyChanged(nameof(Custom_DefaultCharacterColor2)); }
        }

        private Color _defaultCharacterColor3;
        public Color Custom_DefaultCharacterColor3
        {
            get { return _defaultCharacterColor3; }
            set { _defaultCharacterColor3 = value; OnPropertyChanged(nameof(Custom_DefaultCharacterColor3)); }
        }

        //Future settings

        private bool _inTouchScreenMode;
        public bool InTouchScreenMode
        {
            get { return _inTouchScreenMode; }
            set { _inTouchScreenMode = value; OnPropertyChanged(nameof(InTouchScreenMode)); }
        }

        private bool _inHexModeCharacterList;
        public bool InHexModeCharacterList
        {
            get { return _inHexModeCharacterList; }
            set { _inHexModeCharacterList = value; OnPropertyChanged(nameof(InHexModeCharacterList)); }
        }
    }
}
