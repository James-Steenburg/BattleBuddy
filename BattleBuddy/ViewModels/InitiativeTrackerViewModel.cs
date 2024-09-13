using BattleBuddy.Commands;
using BattleBuddy.Helpers;
using BattleBuddy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace BattleBuddy.ViewModels
{
    class InitiativeTrackerViewModel : ChangeNotifier
    {
        private InitiativeTrackerModel _initiativeTrackerModel;
        public InitiativeTrackerModel TargetInitiativeTrackerModel
        {
            get { return _initiativeTrackerModel; }
            set { _initiativeTrackerModel = value; OnPropertyChanged(nameof(TargetInitiativeTrackerModel)); }
        }

        private ObservableCollection<InitiativeTrackerModel> _initiativeTrackerModels;
        public ObservableCollection<InitiativeTrackerModel> InitiativeTrackerModels
        {
            get { return _initiativeTrackerModels; }
            set { _initiativeTrackerModels = value; }
        }

        public ICommand InitAddCommmand => new RelayCommand(ExecuteInitAddCommand, null);
        public void ExecuteInitAddCommand(object obj)
        {
            InitiativeTrackerModels.Add(TargetInitiativeTrackerModel);
            TargetInitiativeTrackerModel = new InitiativeTrackerModel();
        }

        public ICommand InitDeleteCommmand => new RelayCommand(ExecuteInitDeleteCommand, null);
        public void ExecuteInitDeleteCommand(object target)
        {
            if (target == null) return;
            if (!InitiativeTrackerModels.Contains(target)) return;

            InitiativeTrackerModels.Remove((InitiativeTrackerModel)target);
        }

        private ColorPaletteModel _palette = new ColorPaletteModel();
        public ColorPaletteModel Palette
        {
            get { return _palette; }
            set { _palette = value; OnPropertyChanged(nameof(Palette)); }
        }

        public InitiativeTrackerViewModel(List<Color> ColorList)
        {
            Palette.Palette_TitleColor = ColorList[0];
            Palette.Palette_BackgroundColor = ColorList[1];
            Palette.Palette_BorderColor = ColorList[2];
            Palette.Palette_ButtonColor = ColorList[3];
            Palette.Palette_ButtonHoverColor = ColorList[4];
            Palette.Palette_IconColor = ColorList[5];
            Palette.Palette_IconHoverColor = ColorList[6];
            Palette.Palette_DefaultCharacterColor1 = ColorList[7];
            Palette.Palette_DefaultCharacterColor2 = ColorList[8];
            Palette.Palette_DefaultCharacterColor3 = ColorList[9];

            InitiativeTrackerModels = new ObservableCollection<InitiativeTrackerModel>();
            TargetInitiativeTrackerModel = new InitiativeTrackerModel();
        }

    }
}
