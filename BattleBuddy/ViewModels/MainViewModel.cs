using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using BattleBuddy.Commands;
using BattleBuddy.Helpers;
using BattleBuddy.Models;
using FontAwesome.Sharp;
using BattleBuddy.XML;
using BattleBuddy.Views;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BattleBuddy.ViewModels
{
    internal class MainViewModel : ChangeNotifier
    {
        XMLFileIO io = new XMLFileIO();

        #region ---Properties---

        public string AppVersion { get; } = "1.0.0";

        private string _partyName;
        public string PartyName
        {
            get { return _partyName; }
            set { _partyName = value; OnPropertyChanged(nameof(PartyName)); }
        }

        private Character _targetCharacter;
        public Character TargetCharacter
        {
            get { return _targetCharacter; }
            set { _targetCharacter = value; OnPropertyChanged(nameof(TargetCharacter)); }
        }

        private ObservableCollection<CharacterAbilityBonus> _targetCharacterBonuses;
        public ObservableCollection<CharacterAbilityBonus> TargetCharacterBonuses
        {
            get { return _targetCharacterBonuses; }
            set { _targetCharacterBonuses = value; }
        }

        private Character _selectedCharacter;
        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { _selectedCharacter = value; OnPropertyChanged(nameof(SelectedCharacter)); }
        }

        private ObservableCollection<Character> _characters; //ONLY WHEN ADDED/OR REMOVED (NOT FOR INTERNAL PROPERTY CHANGES)
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        private ObservableCollection<CharacterCondition> _characterConditions;
        public ObservableCollection<CharacterCondition> CharacterConditions
        {
            get { return _characterConditions; }
            set { _characterConditions = value; }
        }

        private UserSettings _userSettings;
        public UserSettings UserSettings
        {
            get { return _userSettings; }
            set { _userSettings = value; OnPropertyChanged(nameof(UserSettings)); }
        }

        private ChangeNotifier _currentChildView;
        public ChangeNotifier CurrentChildView
        {
            get { return _currentChildView; }
            set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); }
        }

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; OnPropertyChanged(nameof(Caption)); }
        }
        
        private IconChar _icon;
        public IconChar Icon
        {
            get { return _icon; }
            set { _icon = value; OnPropertyChanged(nameof(Icon)); }
        }

        private bool _displayPartySummaryTab;
        public bool DisplayPartySummaryTab
        {
            get { return _displayPartySummaryTab; }
            set { _displayPartySummaryTab = value; OnPropertyChanged(nameof(DisplayPartySummaryTab)); }
        }

        private bool _displayCharacterDetailTab;
        public bool DisplayCharacterDetailTab
        {
            get { return _displayCharacterDetailTab; }
            set { _displayCharacterDetailTab = value; OnPropertyChanged(nameof(DisplayCharacterDetailTab)); }
        }

        private bool _displaySettingsOptionsTab;
        public bool DisplaySettingsOptionsTab
        {
            get { return _displaySettingsOptionsTab; }
            set { _displaySettingsOptionsTab = value; OnPropertyChanged(nameof(DisplaySettingsOptionsTab)); }
        }

        private bool _displayCreateCharacterTab;
        public bool DisplayCreateCharacterTab
        {
            get { return _displayCreateCharacterTab; }
            set { _displayCreateCharacterTab = value; OnPropertyChanged(nameof(DisplayCreateCharacterTab)); }
        }

        private string _defaultSettingsFilePath;
        public string DefaultSettingsFilePath
        {
            get { return _defaultSettingsFilePath; }
            set { _defaultSettingsFilePath = value; OnPropertyChanged(nameof(DefaultSettingsFilePath)); }
        }

        private string _defaultPartyFilePath;
        public string DefaultPartyFilePath
        {
            get { return _defaultPartyFilePath; }
            set { _defaultPartyFilePath = value; OnPropertyChanged(nameof(DefaultPartyFilePath)); }
        }

        private string _backgroundImageFilePath;
        public string BackgroundImageFilePath
        {
            get { return _backgroundImageFilePath; }
            set { _backgroundImageFilePath = value; OnPropertyChanged(nameof(BackgroundImageFilePath)); }
        }

        private ObservableCollection<string> _conditionTagsList;
        public ObservableCollection<string> ConditionTagList
        {
            get { return _conditionTagsList; }
            set { _conditionTagsList = value; }
        }

        private double _opacitySliderValue = 60;
        public double OpacitySliderValue
        {
            get { return _opacitySliderValue; }
            set
            {
                _opacitySliderValue = value;
                OnPropertyChanged(nameof(OpacitySliderValue));
                OnPropertyChanged(nameof(OpacitySetting));
            }
        }
        public double OpacitySetting
        {
            get { return OpacitySliderValue / 100; }
        }

        #endregion ---Properties---

        //Currently unused. Delete?

        public ICommand CMDDelete => new RelayCommand(DeleteCharacter, null);
        public void DeleteCharacter(object character)
        {
            if (character == null) return;
            if (!Characters.Contains(character)) return;

            Characters.Remove((Character)character);
        }

        #region ---Commands---

        public ICommand CMDAdd => new RelayCommand(AddCharacter, null); 
        public void AddCharacter(object character)
        {
            if(!IsAnyPropertyNull(TargetCharacter))
            {
                ProcessAbilityBonuses();
                TargetCharacter.CharacterConditions = "";
                TargetCharacter.CurrentHitpoints = TargetCharacter.MaxHitpoints;
                Characters.Add(TargetCharacter); //Add it to thecollection
                TargetCharacter = new Character(); //resetting it.
            }
            else
            {
                System.Windows.MessageBox.Show("A value must be entered in each field.","Error");
            }
            
        }

        public ICommand ChangeChildViewCommand => new RelayCommand(ExecuteChangeChildViewCommand, null);
        public void ExecuteChangeChildViewCommand(object obj)
        {
            int desiredPage;
            if (obj == null) return;
            if(Int32.TryParse(obj.ToString(), out desiredPage))
            {
                switch (desiredPage)
                {
                    case 0:
                        DisplayCharacterDetailTab = false;
                        DisplaySettingsOptionsTab = false;
                        DisplayCreateCharacterTab = false;

                        Icon = IconChar.Users;
                        Caption = PartyName;
                        DisplayPartySummaryTab = true;
                        break;
                    case 1:
                        DisplayPartySummaryTab = false;
                        DisplaySettingsOptionsTab = false;
                        DisplayCreateCharacterTab = false;

                        Icon = IconChar.User;
                        DisplayCharacterDetailTab = true;
                        break;
                    case 2:
                        DisplayPartySummaryTab = false;
                        DisplayCharacterDetailTab = false;
                        DisplayCreateCharacterTab = false;

                        Caption = "Settings";
                        Icon = IconChar.Gears;
                        DisplaySettingsOptionsTab = true;
                        break;
                    case 3:
                        DisplayPartySummaryTab = false;
                        DisplayCharacterDetailTab = false;
                        DisplaySettingsOptionsTab = false;

                        Caption = "Create a Character";
                        Icon = IconChar.UserPlus;
                        DisplayCreateCharacterTab = true;
                        break;
                    default:
                        DisplayPartySummaryTab = false;
                        DisplayCharacterDetailTab = false;
                        DisplaySettingsOptionsTab = false;
                        DisplayCreateCharacterTab = false;
                        break;
                }
            }
            else
            {
                //Determine selected character
                List<object> obj_arr = (List<object>)obj;
                if(Characters.Any(c => c.Name == obj_arr[1].ToString()))
                {
                    var selectedChar = Characters.Where(x => x.Name == obj_arr[1].ToString()).FirstOrDefault();
                    int index = Characters.IndexOf(selectedChar);
                    if(SelectedCharacter != Characters[index])
                    {
                        //Needed to show tab animation change when changing from one CharacterDetailView to another CharacterDetailView
                        //but not show the animation when repeatedly clicking the same CharacterDetailView
                        DisplayCharacterDetailTab = false;
                    }
                    SelectedCharacter = Characters[index];

                }

                //check for tags and update
                ConditionTagList.Clear();
                if (SelectedCharacter.CharacterConditions.Contains(";"))
                {
                    string[] conditions = SelectedCharacter.CharacterConditions.Split(';');

                    List<string> conditionsList = new List<string>(conditions.Take(conditions.Length - 1));
                    foreach (string s in conditionsList)
                    {
                        ConditionTagList.Add(s);
                    }
                }

                //Determine Page to go to, should always be 1 in this case
                desiredPage = Int32.Parse(obj_arr[0].ToString());
                switch (desiredPage)
                {
                    case 0:
                        DisplayCharacterDetailTab = false;
                        DisplaySettingsOptionsTab = false;
                        DisplayCreateCharacterTab = false;

                        DisplayPartySummaryTab = true;
                        break;
                    case 1:
                        DisplayPartySummaryTab = false;
                        DisplaySettingsOptionsTab = false;
                        DisplayCreateCharacterTab = false;

                        char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/', '&', '(' };
                        string[] parsedClass = SelectedCharacter.Class.Split(delimiterChars);
                        switch(parsedClass[0])
                        {
                            case "Fighter":
                                Icon = IconChar.ShieldHalved;
                                break;
                            case "Bard":
                                Icon = IconChar.Drum;
                                break;
                            case "Barbarian":
                                Icon = IconChar.FaceAngry;
                                break;
                            case "Blood":
                                Icon = IconChar.Droplet;
                                break;
                            case "Rogue":
                                Icon = IconChar.UserNinja;
                                break;
                            case "Druid":
                                Icon = IconChar.Spider; //or frog?
                                break;
                            case "Cleric":
                                Icon = IconChar.HandsPraying; //or ankh?
                                break;
                            case "Paladin":
                                Icon = IconChar.BoltLightning;
                                break;
                            case "Artificer":
                                Icon = IconChar.ScrewdriverWrench;
                                break;
                            case "Warlock":
                                Icon = IconChar.Chain;
                                break;
                            case "Wizard":
                                Icon = IconChar.HatWizard;
                                break;
                            case "Ranger":
                                Icon = IconChar.Paw;
                                break;
                            case "Sorcerer":
                                Icon = IconChar.Fire;
                                break;
                            default:
                                Icon = IconChar.User;
                                break;
                        }

                        Caption = SelectedCharacter.Name;
                        DisplayCharacterDetailTab = true;
                        break;
                    case 2:
                        DisplayPartySummaryTab = false;
                        DisplayCharacterDetailTab = false;
                        DisplayCreateCharacterTab = false;

                        DisplaySettingsOptionsTab = true;
                        break;
                    case 3:
                        DisplayPartySummaryTab = false;
                        DisplayCharacterDetailTab = false;
                        DisplaySettingsOptionsTab = false;

                        DisplayCreateCharacterTab = true;
                        break;
                    default:
                        DisplayPartySummaryTab = false;
                        DisplayCharacterDetailTab = false;
                        DisplaySettingsOptionsTab = false;
                        DisplayCreateCharacterTab = false;
                        break;
                }
            }
        }

        public ICommand ExportPartyCommand => new RelayCommand(ExecuteExportPartyCommand, null);
        public void ExecuteExportPartyCommand(object obj)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "XML file (*.xml)|*.xml"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                //XMLFileIO io = new XMLFileIO();
                io.SavePartyToFile(PartyName, Characters, saveFileDialog.FileName);
            }
        }

        public ICommand ImportPartyCommand => new RelayCommand(ExecuteImportPartyCommand, null);
        public void ExecuteImportPartyCommand(object obj)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "XML file (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                //XMLFileIO io = new XMLFileIO();
                io.LoadPartyFromFile(openFileDialog.FileName);

                UpdateCharactersConditionsLists();
                UpdateCharactersTrackersList(); 
            }
        }

        public ICommand SaveCommand => new RelayCommand(ExecuteSaveCommand, null);
        public void ExecuteSaveCommand(object obj)
        {
            //XMLFileIO io = new XMLFileIO(); //testing global
            io.SavePartyToFile(PartyName, Characters);
            io.XmlStoredUserSettings = UserSettings;
            io.SaveUserSettingsToFile(UserSettings, CharacterConditions);
        }

        public ICommand DamageCharacterCommand => new RelayCommand(ExecuteDamageCharacterCommand, null);
        public void ExecuteDamageCharacterCommand(object obj)
        {
            InputNumberDialogWindow inputWin = new InputNumberDialogWindow("Enter Amount of Damage:", "");
            //if(inputWin.ShowDialog() == true) { System.Windows.MessageBox.Show(inputWin.IntAnswer.ToString()); }
            string msg = "";

            if (inputWin.ShowDialog() == true && Characters.Any(c => c.Name == obj.ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj.ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                Characters[index].CurrentHitpoints -= inputWin.IntAnswer;
                if (Characters[index].CurrentHitpoints < 0)
                {
                    Characters[index].CurrentHitpoints = 0;
                    msg = Characters[index].Name + " has taken " + inputWin.IntAnswer.ToString() + " damage, leaving them at 0!";
                }
                else if (Characters[index].IsConcentrating)
                {
                    double halvedDamage = inputWin.IntAnswer / 2;
                    int halvedDamage_int = Convert.ToInt32(Math.Floor(halvedDamage));
                    int concentrationDC = 10;
                    if(halvedDamage_int > concentrationDC) { concentrationDC = halvedDamage_int; }
                    msg = Characters[index].Name + " has taken " + inputWin.IntAnswer.ToString() + " damage.\n" + Characters[index].Name + " must make a DC " + concentrationDC + " concentration saving throw.";
                }
                else
                {
                    msg = Characters[index].Name + " has taken " + inputWin.IntAnswer.ToString() + " damage.";
                }
                System.Windows.MessageBox.Show(msg);
            }
        }

        public ICommand HealCharacterCommand => new RelayCommand(ExecuteHealCharacterCommand, null);
        public void ExecuteHealCharacterCommand(object obj)
        {
            InputNumberDialogWindow inputWin = new InputNumberDialogWindow("Enter Amount of Healing:", "");
            //if (inputWin.ShowDialog() == true) { System.Windows.MessageBox.Show(inputWin.IntAnswer.ToString()); }
            string msg = "";

            if (inputWin.ShowDialog() == true && Characters.Any(c => c.Name == obj.ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj.ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                Characters[index].CurrentHitpoints += inputWin.IntAnswer;
                if(Characters[index].CurrentHitpoints > Characters[index].MaxHitpoints)
                {
                    Characters[index].CurrentHitpoints = Characters[index].MaxHitpoints;
                    msg = Characters[index].Name + " has healed " + inputWin.IntAnswer.ToString() + " hitpoints, healing them to full health!";
                }
                else
                {
                    msg = Characters[index].Name + " has healed " + inputWin.IntAnswer.ToString() + " hitpoints.";
                }
                System.Windows.MessageBox.Show(msg);
            }
        }

        public ICommand OpenCanvasCommand => new RelayCommand(ExecuteOpenCanvasCommand, null);
        public void ExecuteOpenCanvasCommand(object obj)
        {
            CanvasWindow cw = new CanvasWindow();
            cw.Show();
        }

        public ICommand AddTagCommand => new RelayCommand(ExecuteAddTagCommand, null);
        public void ExecuteAddTagCommand(object obj)
        {
            ObservableCollection<string> conditionNameList = new ObservableCollection<string>();
            foreach (CharacterCondition c in CharacterConditions)
            {
                conditionNameList.Add(c.ConditionName);
            }
            ConditionBoxWindow cbw = new ConditionBoxWindow(conditionNameList);

            if (cbw.ShowDialog() == true && cbw.SelectedCondition != null)
            {
                var selectedChar = Characters.Where(x => x.Name == obj.ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);
                Characters[index].CharacterConditions = Characters[index].CharacterConditions + cbw.SelectedCondition + ";";
                ConditionTagList.Add(cbw.SelectedCondition);
                Characters[index].CharacterConditionsList.Add(cbw.SelectedCondition);

                if(cbw.SelectedCondition == "Concentration")
                {
                    Characters[index].IsConcentrating = true;
                }
            }

        }

        public ICommand RemoveTagCommand => new RelayCommand(ExecuteRemoveTagCommand, null);
        public void ExecuteRemoveTagCommand(object obj)
        {
            //obj[0] returns the button -> use this to determine what condition needs to be removed
            //obj[1] returns the selected character's name -> use this to know who to remove the condition from
            List<object> obj_arr = (List<object>)obj;
            if (Characters.Any(c => c.Name == obj_arr[1].ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj_arr[1].ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                if (Characters[index].CharacterConditions.Contains(";"))
                {
                    string[] conditions = Characters[index].CharacterConditions.Split(';');

                    List<string> conditionsList = new List<string>(conditions.Take(conditions.Length - 1));
                    conditionsList.RemoveAt(conditionsList.IndexOf(obj_arr[0].ToString()));

                    Characters[index].CharacterConditions = "";
                    foreach (string s in conditionsList)
                    {
                        Characters[index].CharacterConditions = Characters[index].CharacterConditions + s + ";";
                    }
                    ConditionTagList.Remove(obj_arr[0].ToString());
                    Characters[index].CharacterConditionsList.Remove(obj_arr[0].ToString());

                    if (obj_arr[0].ToString() == "Concentration")
                    {
                        Characters[index].IsConcentrating = false;
                    }
                }

            }

        }

        public ICommand ShowTagDetailsCommand => new RelayCommand(ExecuteShowTagDetailsCommand, null);
        public void ExecuteShowTagDetailsCommand(object obj)
        {
            //obj returns the button -> use this to determine what condition and display details
            if (CharacterConditions.Any(c => c.ConditionName == obj.ToString()))
            {
                var selectedCondition = CharacterConditions.Where(x => x.ConditionName == obj.ToString()).FirstOrDefault();
                int index = CharacterConditions.IndexOf(selectedCondition);

                System.Windows.MessageBox.Show(CharacterConditions[index].ConditionDescription, CharacterConditions[index].ConditionName);
            }

        }

        public ICommand ShowInitiativeTrackerCommand => new RelayCommand(ExecuteShowInitiativeTracker, null);
        public void ExecuteShowInitiativeTracker(object obj)
        {
            List<Color> ColorList = new List<Color>
            {
                TitleColor,
                BackgroundColor,
                BorderColor,
                ButtonColor,
                ButtonHoverColor,
                IconColor,
                IconHoverColor,
                DefaultCharacterColor1,
                DefaultCharacterColor2,
                DefaultCharacterColor3
            };

            InitiativeTrackerWindow itw = new InitiativeTrackerWindow(ColorList);
            itw.Show();
        }

        public ICommand AddCharacterTrackerCommand => new RelayCommand(ExecuteAddCharacterTrackerCommand, null);
        public void ExecuteAddCharacterTrackerCommand(object obj)
        {
            CreateCharacterTrackerWindow createCharacterTrackerWindow = new CreateCharacterTrackerWindow();

            if (createCharacterTrackerWindow.ShowDialog() == true && Characters.Any(c => c.Name == obj.ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj.ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                if (createCharacterTrackerWindow.TrackerName.Contains(";") || createCharacterTrackerWindow.TrackerName.Contains("/"))
                {
                    System.Windows.MessageBox.Show("Tracker names cannot include characters: ';' or '/'","Error");
                }
                else
                {
                    Characters[index].CharacterTrackersList.Add(
                    new CharacterTracker
                    {
                        TrackerName = createCharacterTrackerWindow.TrackerName,
                        TrackerAvailableUses = createCharacterTrackerWindow.TrackerAvailableUses,
                        TrackerMaxUses = createCharacterTrackerWindow.TrackerMaxUses
                    });
                }
            }
        }

        public ICommand IncreaseTrackerValueCommand => new RelayCommand(ExecuteIncreaseTrackerValue, null);
        public void ExecuteIncreaseTrackerValue(object obj)
        {
            //obj[0] returns the TrackerName
            //obj[1] returns the selected character's name -> use this to know who to remove the condition from
            List<object> obj_arr = (List<object>)obj;
            if (Characters.Any(c => c.Name == obj_arr[1].ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj_arr[1].ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                if (Characters[index].CharacterTrackersList.Any(t => t.TrackerName == obj_arr[0].ToString()))
                {
                    var selectedTracker = Characters[index].CharacterTrackersList.Where(tr => tr.TrackerName == obj_arr[0].ToString()).FirstOrDefault();
                    int trackerIndex = Characters[index].CharacterTrackersList.IndexOf(selectedTracker);

                    if (Characters[index].CharacterTrackersList[trackerIndex].TrackerAvailableUses < Characters[index].CharacterTrackersList[trackerIndex].TrackerMaxUses)
                    {
                        Characters[index].CharacterTrackersList[trackerIndex].TrackerAvailableUses++;
                    }
                }
            }
        }

        public ICommand DecreaseTrackerValueCommand => new RelayCommand(ExecuteDecreaseTrackerValue, null);
        public void ExecuteDecreaseTrackerValue(object obj)
        {
            //obj[0] returns the TrackerName
            //obj[1] returns the selected character's name -> use this to know who to remove the condition from
            List<object> obj_arr = (List<object>)obj;
            if (Characters.Any(c => c.Name == obj_arr[1].ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj_arr[1].ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                if (Characters[index].CharacterTrackersList.Any(t => t.TrackerName == obj_arr[0].ToString()))
                {
                    var selectedTracker = Characters[index].CharacterTrackersList.Where(tr => tr.TrackerName == obj_arr[0].ToString()).FirstOrDefault();
                    int trackerIndex = Characters[index].CharacterTrackersList.IndexOf(selectedTracker);

                    if (Characters[index].CharacterTrackersList[trackerIndex].TrackerAvailableUses > 0)
                    {
                        Characters[index].CharacterTrackersList[trackerIndex].TrackerAvailableUses--;
                    }
                }
            }
        }

        public ICommand ResetTrackerValueCommand => new RelayCommand(ExecuteResetTrackerValue, null);
        public void ExecuteResetTrackerValue(object obj)
        {
            //obj[0] returns the TrackerName
            //obj[1] returns the selected character's name -> use this to know who to remove the condition from
            List<object> obj_arr = (List<object>)obj;
            if (Characters.Any(c => c.Name == obj_arr[1].ToString()))
            {
                var selectedChar = Characters.Where(x => x.Name == obj_arr[1].ToString()).FirstOrDefault();
                int index = Characters.IndexOf(selectedChar);

                if (Characters[index].CharacterTrackersList.Any(t => t.TrackerName == obj_arr[0].ToString()))
                {
                    var selectedTracker = Characters[index].CharacterTrackersList.Where(tr => tr.TrackerName == obj_arr[0].ToString()).FirstOrDefault();
                    int trackerIndex = Characters[index].CharacterTrackersList.IndexOf(selectedTracker);

                    Characters[index].CharacterTrackersList[trackerIndex].TrackerAvailableUses = Characters[index].CharacterTrackersList[trackerIndex].TrackerMaxUses;
                }
            }
        }

        public ICommand ShowAddAbilityBonusWindowCommand => new RelayCommand(ExecuteShowAddAbilityBonusWindowCommand, null);
        public void ExecuteShowAddAbilityBonusWindowCommand(object obj)
        {
            AbilityBonusBoxWindow abbw = new AbilityBonusBoxWindow();

            if (abbw.ShowDialog() == true)
            {
                TargetCharacterBonuses.Add(
                    new CharacterAbilityBonus
                    {
                        AbilityName = abbw.TargetAbilityName,
                        IsAbilityProficient = abbw.IsTargetAbilityProficient,
                        IsAbilityExpert = abbw.IsTargetAbilityExpert,
                        AbilityAdditionalBonus = abbw.TargetAbilityAdditionalBonus
                    });
            }
        }

        public ICommand RemoveAbilityBonusCommand => new RelayCommand(ExecuteRemoveAbilityBonusCommand, null);
        public void ExecuteRemoveAbilityBonusCommand(object obj)
        {
            TargetCharacterBonuses.Remove((CharacterAbilityBonus)obj);
        }

        public ICommand ShowAddTargetTrackerWindowCommand => new RelayCommand(ExecuteShowAddTargetTrackerWindowCommand, null);
        public void ExecuteShowAddTargetTrackerWindowCommand(object obj)
        {
            CreateCharacterTrackerWindow cctw = new CreateCharacterTrackerWindow();

            if (cctw.ShowDialog() == true)
            {
                if(cctw.TrackerName.Contains(";") || cctw.TrackerName.Contains("/"))
                {
                    System.Windows.MessageBox.Show("Tracker names cannot include characters: ';' or '/'","Error");
                }
                else
                {
                    TargetCharacter.CharacterTrackersList.Add(
                    new CharacterTracker
                    {
                        TrackerName = cctw.TrackerName,
                        TrackerAvailableUses = cctw.TrackerAvailableUses,
                        TrackerMaxUses = cctw.TrackerMaxUses
                    });
                }
            }
        }

        public ICommand RemoveTargetTrackerWindowCommand => new RelayCommand(ExecuteRemoveTargetTrackerWindowCommand, null);
        public void ExecuteRemoveTargetTrackerWindowCommand(object obj)
        {
            TargetCharacter.CharacterTrackersList.Remove((CharacterTracker)obj);
        }

        public ICommand BrowseTargetCharacterImageCommand => new RelayCommand(ExecuteBrowseTargetCharacterImageCommand, null);
        public void ExecuteBrowseTargetCharacterImageCommand(object obj)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files | *.jpg; *.jpeg; *.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                TargetCharacter.ImagePath = openFileDialog.FileName;
            }
        }

        public ICommand BrowseBackgroundImageCommand => new RelayCommand(ExecuteBrowseBackgroundImageCommand, null);
        public void ExecuteBrowseBackgroundImageCommand(object obj)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files | *.jpg; *.jpeg; *.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                BackgroundImageFilePath = openFileDialog.FileName;
            }
        }

        public ICommand BrowseDefaultPartyFileCommand => new RelayCommand(ExecuteBrowseDefaultPartyFileCommand, null);
        public void ExecuteBrowseDefaultPartyFileCommand(object obj)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "XML file (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                DefaultPartyFilePath = openFileDialog.FileName;
            }
        }

        public ICommand OpenGITProjectPageCommand => new RelayCommand(ExecuteOpenGITProjectPageCommand, null);
        public void ExecuteOpenGITProjectPageCommand(object obj)
        {
            var destinationurl = "https://github.com/James-Steenburg";
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }

        #endregion ---Commands---

        private void UpdateCharactersConditionsLists()
        {
            foreach (Character c in Characters)
            {
                if(c.CharacterConditions.Contains(";"))
                {
                    string[] conditions = c.CharacterConditions.Split(';');
                    List<string> conditionsList = new List<string>(conditions.Take(conditions.Length - 1));
                    foreach (string s in conditionsList)
                    {
                        c.CharacterConditionsList.Add(s);
                    }
                }
            }
        }

        private void UpdateCharactersTrackersList()
        {
            foreach (Character c in Characters)
            {
                if (c.CharacterTrackers.Contains(";"))
                {
                    string[] trackers = c.CharacterTrackers.Split(';');
                    List<string> trackersList = new List<string>(trackers.Take(trackers.Length - 1));
                    foreach (string s in trackersList)
                    {
                        string[] trackerData = s.Split('/');
                        //List<string> trackerDataList = new List<string>(trackerData.Take(trackerData.Length - 1));
                        try
                        {
                            c.CharacterTrackersList.Add(
                            new CharacterTracker
                            {
                                TrackerName = trackerData[0],
                                TrackerAvailableUses = Convert.ToInt32(trackerData[1]),
                                TrackerMaxUses = Convert.ToInt32(trackerData[2])
                            });
                        }
                        catch
                        {
                            //error message or skip
                        }
                    }
                }
            }
        }
        
        private void ProcessAbilityBonuses()
        {
            foreach (CharacterAbilityBonus bonus in TargetCharacterBonuses)
            {
                switch (bonus.AbilityName)
                {
                    case "Strength Saving Throw":
                        TargetCharacter.HasProficiency_Strength_Save = bonus.IsAbilityProficient;
                        TargetCharacter.AdditionalBonus_StrengthSavingThrow = bonus.AbilityAdditionalBonus;
                        break;
                    case "Dexterity Saving Throw":
                        TargetCharacter.HasProficiency_Dexterity_Save = bonus.IsAbilityProficient;
                        TargetCharacter.AdditionalBonus_DexteritySavingThrow = bonus.AbilityAdditionalBonus;
                        break;
                    case "Constitution Saving Throw":
                        TargetCharacter.HasProficiency_Constitution_Save = bonus.IsAbilityProficient;
                        TargetCharacter.AdditionalBonus_ConstitutionSavingThrow = bonus.AbilityAdditionalBonus;
                        break;
                    case "Intelligence Saving Throw":
                        TargetCharacter.HasProficiency_Intelligence_Save = bonus.IsAbilityProficient;
                        TargetCharacter.AdditionalBonus_IntelligenceSavingThrow = bonus.AbilityAdditionalBonus;
                        break;
                    case "Wisdom Saving Throw":
                        TargetCharacter.HasProficiency_Wisdom_Save = bonus.IsAbilityProficient;
                        TargetCharacter.AdditionalBonus_WisdomSavingThrow = bonus.AbilityAdditionalBonus;
                        break;
                    case "Charisma Saving Throw":
                        TargetCharacter.HasProficiency_Charisma_Save = bonus.IsAbilityProficient;
                        TargetCharacter.AdditionalBonus_CharismaSavingThrow = bonus.AbilityAdditionalBonus;
                        break;
                    case "Passive Insight":
                        TargetCharacter.AdditionalBonus_PassiveInsight = bonus.AbilityAdditionalBonus;
                        break;
                    case "Passive Investigation":
                        TargetCharacter.AdditionalBonus_PassiveInvestigation = bonus.AbilityAdditionalBonus;
                        break;
                    case "Passive Perception":
                        TargetCharacter.AdditionalBonus_PassivePerception = bonus.AbilityAdditionalBonus;
                        break;
                    case "Initiative":
                        TargetCharacter.AdditionalBonus_Initiative = bonus.AbilityAdditionalBonus;
                        break;
                    case "Acrobatics":
                        TargetCharacter.HasProficiency_Acrobatics = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Acrobatics = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Acrobatics = bonus.AbilityAdditionalBonus;
                        break;
                    case "Animal Handling":
                        TargetCharacter.HasProficiency_Animal_Handling = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Animal_Handling = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Animal_Handling = bonus.AbilityAdditionalBonus;
                        break;
                    case "Arcana":
                        TargetCharacter.HasProficiency_Arcana = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Arcana = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Arcana = bonus.AbilityAdditionalBonus;
                        break;
                    case "Athletics":
                        TargetCharacter.HasProficiency_Athletics = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Athletics = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Athletics = bonus.AbilityAdditionalBonus;
                        break;
                    case "Deception":
                        TargetCharacter.HasProficiency_Deception = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Deception = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Deception = bonus.AbilityAdditionalBonus;
                        break;
                    case "History":
                        TargetCharacter.HasProficiency_History = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_History = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_History = bonus.AbilityAdditionalBonus;
                        break;
                    case "Insight":
                        TargetCharacter.HasProficiency_Insight = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Insight = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Insight = bonus.AbilityAdditionalBonus;
                        break;
                    case "Intimidation":
                        TargetCharacter.HasProficiency_Intimidation = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Intimidation = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Intimidation = bonus.AbilityAdditionalBonus;
                        break;
                    case "Investigation":
                        TargetCharacter.HasProficiency_Investigation = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Investigation = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Investigation = bonus.AbilityAdditionalBonus;
                        break;
                    case "Medicine":
                        TargetCharacter.HasProficiency_Medicine = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Medicine = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Medicine = bonus.AbilityAdditionalBonus;
                        break;
                    case "Nature":
                        TargetCharacter.HasProficiency_Nature = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Nature = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Nature = bonus.AbilityAdditionalBonus;
                        break;
                    case "Perception":
                        TargetCharacter.HasProficiency_Perception = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Perception = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Perception = bonus.AbilityAdditionalBonus;
                        break;
                    case "Performance":
                        TargetCharacter.HasProficiency_Performance = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Performance = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Performance = bonus.AbilityAdditionalBonus;
                        break;
                    case "Persuasion":
                        TargetCharacter.HasProficiency_Persuasion = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Persuasion = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Persuasion = bonus.AbilityAdditionalBonus;
                        break;
                    case "Religion":
                        TargetCharacter.HasProficiency_Religion = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Religion = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Religion = bonus.AbilityAdditionalBonus;
                        break;
                    case "Sleight of Hand":
                        TargetCharacter.HasProficiency_Sleight_Of_Hand = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Sleight_Of_Hand = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Sleight_Of_Hand = bonus.AbilityAdditionalBonus;
                        break;
                    case "Stealth":
                        TargetCharacter.HasProficiency_Stealth = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Stealth = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Stealth = bonus.AbilityAdditionalBonus;
                        break;
                    case "Survival":
                        TargetCharacter.HasProficiency_Survival = bonus.IsAbilityProficient;
                        TargetCharacter.HasExpertise_Survival = bonus.IsAbilityExpert;
                        TargetCharacter.AdditionalBonus_Survival = bonus.AbilityAdditionalBonus;
                        break;
                }
            }
        }

        public bool IsAnyPropertyNull(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (value == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #region ---testing commands / to be deleted

        public ICommand TestCommand => new RelayCommand(ExecuteTestCommand, null);
        public void ExecuteTestCommand(object obj)
        {
            TestViews.TestColorsWindow tcw = new TestViews.TestColorsWindow();
            tcw.Show();
        }

        public ICommand RestoreDefaultsCommand => new RelayCommand(ExecuteRestoreDefaultsCommand, null);
        public void ExecuteRestoreDefaultsCommand(object obj)
        {
            if(System.Windows.MessageBox.Show("Do you want to overwrite current settings with their default values?", "Restore Defaults", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                //Restore defaults

                UserSettings.ApplicationTheme = 0; 
                UserSettings.BackgroundImageFilePath = null; //todo: change this to application resources folder image
                UserSettings.ConditionList.Clear();
                UserSettings.DefaultPartyFilePath = null; //todo: change this to application data folder empty party file?
                UserSettings.InHexModeCharacterList = false;
                UserSettings.InTouchScreenMode = false;
                UserSettings.UseBackgroundImage = true;
                UserSettings.UseCharacterUniqueColorsInDetailView = false;
                UserSettings.UseCharacterUniqueColorsInSummaryView = false;
            }
            else
            {
                //Do nothing
            }
        }


        #endregion ---testing commands / to be deleted

        public Uri SelectedImagePath
        {
            get { return _selectedImagePath; }
            set { _selectedImagePath = value; OnPropertyChanged(nameof(SelectedImagePath)); }
        }
        private Uri _selectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg");

        public ICommand ChangeImageBackgroundCommand => new RelayCommand(ExecuteChangeImageBackgroundCommand, null);
        public void ExecuteChangeImageBackgroundCommand(object obj)
        {
            int imgIndex = Int32.Parse(obj.ToString());
            switch(imgIndex)
            {
                case 0: //Default Theme
                    SelectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg");
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg";
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg";
                    TitleColor = Color.FromRgb(0xD5, 0xCF, 0xF5); //TODO: Update these to correct/final default colors
                    BackgroundColor = Color.FromRgb(0x21, 0x0F, 0x55);
                    BorderColor = Color.FromRgb(0x83, 0x6E, 0xFB);
                    ButtonColor = Color.FromRgb(0x78, 0x4D, 0xFD);
                    ButtonHoverColor = Color.FromRgb(0xFF, 0x44, 0x22);
                    IconColor = Color.FromRgb(0x33, 0xAA, 0x11);
                    IconHoverColor = Color.FromRgb(0xFF, 0x1A, 0x1C);
                    DefaultCharacterColor1 = Color.FromArgb(0xFF, 0x0F, 0x10, 0x62); //FF0F1062
                    DefaultCharacterColor2 = Color.FromArgb(0xFF, 0x23, 0x24, 0x77); //FF232477
                    DefaultCharacterColor3 = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF); //00FFFFFF
                    break;
                case 1: //CR Vox Machina Theme
                    SelectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\VoxMachina.jpg");
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\VoxMachina.jpg";
                    TitleColor = Color.FromRgb(0xF5, 0xCF, 0x11); //TODO: Update these to correct/final default colors
                    BackgroundColor = Color.FromRgb(0x9D, 0xC0, 0x99);
                    BorderColor = Color.FromRgb(0x3B, 0xFF, 0x27);
                    ButtonColor = Color.FromRgb(0x51, 0x6F, 0x4D);
                    ButtonHoverColor = Color.FromRgb(0xFF, 0x44, 0x22);
                    IconColor = Color.FromRgb(0x33, 0xAA, 0x11);
                    IconHoverColor = Color.FromRgb(0xFF, 0x1A, 0x1C);
                    DefaultCharacterColor1 = Color.FromArgb(0xFF, 0x0F, 0x10, 0x62); //FF0F1062
                    DefaultCharacterColor2 = Color.FromArgb(0xFF, 0x23, 0x24, 0x77); //FF232477
                    DefaultCharacterColor3 = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF); //00FFFFFF
                    break;
                case 2: //CR Mighty Nein Theme
                    SelectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\MightyNein.jpg");
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\MightyNein.jpg";
                    break;
                case 3: //D&D Forest Theme
                    SelectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\dndforest.jpg");
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\dndforest.jpg";
                    break;
                case 4: //Custom Theme
                    SelectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\AbstractBkg.jpg");
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\VoxMachina.jpg";
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg";
                    TitleColor = UserSettings.Custom_TitleColor;
                    BackgroundColor = UserSettings.Custom_BackgroundColor;
                    BorderColor = UserSettings.Custom_BorderColor;
                    ButtonColor = UserSettings.Custom_ButtonColor;
                    ButtonHoverColor = UserSettings.Custom_ButtonHoverColor;
                    IconColor = UserSettings.Custom_IconColor;
                    IconHoverColor = UserSettings.Custom_IconHoverColor;
                    DefaultCharacterColor1 = UserSettings.Custom_DefaultCharacterColor1;
                    DefaultCharacterColor2 = UserSettings.Custom_DefaultCharacterColor2;
                    DefaultCharacterColor3 = UserSettings.Custom_DefaultCharacterColor3;
                    break;
                default: //Default Theme
                    SelectedImagePath = new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg");
                    UserSettings.BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg";
                    break;
            }
            
        }

        #region Color Palette

        private Color _titleColor = Color.FromRgb(0xD5, 0xCF, 0xF5); //Color.FromRgb(0xE0, 0xE1, 0xF1);
        public Color TitleColor
        {
            get { return _titleColor; }
            set 
            { 
                _titleColor = value; 
                OnPropertyChanged(nameof(TitleColor));
                OnPropertyChanged(nameof(TextColor));
            }
        }

        public Color TextColor
        {
            get
            {
                HslColor hsl_TitleColor = new HslColor(TitleColor);
                return hsl_TitleColor.Lighten(1.2).ToRgb();
            }
        }

        private Color _backgroundColor = Color.FromRgb(0x21, 0x0F, 0x55);
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
                OnPropertyChanged(nameof(BackgroundColor_Darker1));
                OnPropertyChanged(nameof(BackgroundColor_Darker2));
                OnPropertyChanged(nameof(BackgroundColor_Darker3));
                OnPropertyChanged(nameof(BackgroundColor_Lighter1));
                OnPropertyChanged(nameof(BackgroundColor_Lighter2));
                OnPropertyChanged(nameof(BackgroundColor_Lighter3));
            }
        }

        public Color BackgroundColor_Darker1
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(BackgroundColor);
                return hsl_BackgroundColor.Lighten(0.9).ToRgb();
            }
        }
        public Color BackgroundColor_Darker2
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(BackgroundColor);
                return hsl_BackgroundColor.Lighten(0.8).ToRgb();
            }
        }
        public Color BackgroundColor_Darker3
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(BackgroundColor);
                return hsl_BackgroundColor.Lighten(0.7).ToRgb();
            }
        }
        public Color BackgroundColor_Lighter1
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(BackgroundColor);
                return hsl_BackgroundColor.Lighten(1.1).ToRgb();
            }
        }
        public Color BackgroundColor_Lighter2
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(BackgroundColor);
                return hsl_BackgroundColor.Lighten(1.2).ToRgb();
            }
        }
        public Color BackgroundColor_Lighter3
        {
            get
            {
                HslColor hsl_BackgroundColor = new HslColor(BackgroundColor);
                return hsl_BackgroundColor.Lighten(1.3).ToRgb();
            }
        }

        private Color _borderColor = Color.FromRgb(0x83, 0x6E, 0xFB);
        public Color BorderColor
        {
            get { return _borderColor; }
            set 
            { 
                _borderColor = value; 
                OnPropertyChanged(nameof(BorderColor));
                OnPropertyChanged(nameof(BorderColor_Darker));
                OnPropertyChanged(nameof(BorderColor_Lighter));
            }
        }

        public Color BorderColor_Darker
        {
            get
            {
                HslColor hsl_BorderColor = new HslColor(BorderColor);
                return hsl_BorderColor.Lighten(0.7).ToRgb();
            }
        }
        public Color BorderColor_Lighter
        {
            get
            {
                HslColor hsl_BorderColor = new HslColor(BorderColor);
                return hsl_BorderColor.Lighten(1.3).ToRgb();
            }
        }

        private Color _buttonColor = Color.FromRgb(0x78, 0x4D, 0xFD);
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set 
            { 
                _buttonColor = value; 
                OnPropertyChanged(nameof(ButtonColor));
                OnPropertyChanged(nameof(ButtonColor_Darker));
            }
        }

        public Color ButtonColor_Darker
        {
            get
            {
                HslColor hsl_BorderColor = new HslColor(ButtonColor);
                return hsl_BorderColor.Lighten(0.7).ToRgb();
            }
        }

        private Color _buttonHoverColor = Color.FromRgb(0xFF, 0x44, 0x22);
        public Color ButtonHoverColor
        {
            get { return _buttonHoverColor; }
            set { _buttonHoverColor = value; OnPropertyChanged(nameof(ButtonHoverColor)); }
        }

        private Color _iconColor = Color.FromRgb(0x33, 0xAA, 0x11); //(0x94, 0x97, 0xCD);
        public Color IconColor
        {
            get { return _iconColor; }
            set { _iconColor = value; OnPropertyChanged(nameof(IconColor)); }
        }

        private Color _iconHoverColor = Color.FromRgb(0xFF, 0x1A, 0x1C); //(0x94, 0x97, 0xCD);
        public Color IconHoverColor
        {
            get { return _iconHoverColor; }
            set { _iconHoverColor = value; OnPropertyChanged(nameof(IconHoverColor)); }
        }

        private Color _defaultCharacterColor1;
        public Color DefaultCharacterColor1
        {
            get { return _defaultCharacterColor1; }
            set { _defaultCharacterColor1 = value; OnPropertyChanged(nameof(DefaultCharacterColor1)); }
        }

        private Color _defaultCharacterColor2;
        public Color DefaultCharacterColor2
        {
            get { return _defaultCharacterColor2; }
            set { _defaultCharacterColor2 = value; OnPropertyChanged(nameof(DefaultCharacterColor2)); }
        }

        private Color _defaultCharacterColor3;
        public Color DefaultCharacterColor3
        {
            get { return _defaultCharacterColor3; }
            set { _defaultCharacterColor3 = value; OnPropertyChanged(nameof(DefaultCharacterColor3)); }
        }

        #endregion Color Palette


        //For Testing:
        
        private Color _testColor = Color.FromRgb(0x24, 0x10, 0x5F);
        public Color TestColor
        {
            get { return _testColor; }
            set 
            { 
                try
                {
                    _testColor = value;
                    OnPropertyChanged(nameof(TestColor));
                    OnPropertyChanged(nameof(TestColorD3));
                }
                catch
                {
                    System.Windows.MessageBox.Show("Not a recognized color format.");
                }
                
            }
        }

        public Color TestColorD3
        {
            get
            {
                HslColor hsl_TestColor = new HslColor(TestColor);
                return hsl_TestColor.Lighten(0.7).ToRgb();
            }
        }

        public MainViewModel()
        {
            //test
            //BackgroundImageFilePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg";
            //BackgroundImageFilePath = "/Images/BasicDragon.jpg";
            //ImageBrush backgroundImg = new ImageBrush();
            //backgroundImg.ImageSource = new BitmapImage(new Uri(BackgroundImageFilePath, UriKind.Relative));
            //BitmapImage backgroundImg = new BitmapImage(new Uri(@"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\BasicDragon.jpg"));
            //ImageBrush myImageBrush = new ImageBrush(backgroundImg);

            //actuals
            Characters = new ObservableCollection<Character>();
            TargetCharacter = new Character();
            SelectedCharacter = new Character();
            ConditionTagList = new ObservableCollection<string>();
            TargetCharacterBonuses = new ObservableCollection<CharacterAbilityBonus>();

            Characters.Add(new Character 
            {
                Name = "RandomGuy",
                Class = "Fighter",
                Level = 3,
                MaxHitpoints = 22,
                CurrentHitpoints = 20,
                ArmorClass = 11,
                Strength = 10,
                Dexterity = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10
            });

            Characters.Add(new Character
            {
                Name = "Billy",
                Class = "Cleric",
                Level = 3,
                MaxHitpoints = 22,
                CurrentHitpoints = 20,
                ArmorClass = 11,
                Strength = 10,
                Dexterity = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10
            });

            Characters.Add(new Character
            {
                Name = "Nette",
                Class = "Bard",
                Level = 3,
                MaxHitpoints = 22,
                CurrentHitpoints = 20,
                ArmorClass = 11,
                Strength = 10,
                Dexterity = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10
            });

            //Uncomment the following when not working on test views:
            
            
            Characters.Clear();

            io.LoadUserSettingsFromFile();
            UserSettings = io.XmlStoredUserSettings;
            CharacterConditions = io.ConditionCollection;

            io.LoadPartyFromFile();
            Characters = io.CharacterCollection;
            PartyName = io.PartyName;

            UpdateCharactersConditionsLists();
            UpdateCharactersTrackersList();



            BackgroundImageFilePath = UserSettings.BackgroundImageFilePath; //BackgroundImageFilePath is bound to default image path in Settings
                                                                                //need to upgdate to where if that is changed, it will update settings
            SelectedImagePath = new Uri(BackgroundImageFilePath);
            DefaultPartyFilePath = UserSettings.DefaultPartyFilePath;
            //DefaultSettingsFilePath = ....
            //io.LoadUserSettingsFromFile();
            //DefaultPartyFilePath = io. ....
            //io.LoadPartyFromFile();

            //default to party summary
            DisplayCharacterDetailTab = false;
            DisplaySettingsOptionsTab = false;
            DisplayCreateCharacterTab = false;

            Icon = IconChar.Users;
            Caption = PartyName;
            DisplayPartySummaryTab = true;

            //WinBorderColor1 = Color.FromRgb(0x6D, 0x2F, 0xFF);
            //SecondaryBackColor1 = Colors.Black;
            //SecondaryBackColor1 = Color.FromRgb(0x24, 0x10, 0x5F);
        }
    }
}
