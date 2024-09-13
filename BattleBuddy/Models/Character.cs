using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using BattleBuddy.Helpers;

namespace BattleBuddy.Models
{
    internal class Character : ChangeNotifier
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _class;
        public string Class
        {
            get { return _class; }
            set { _class = value; OnPropertyChanged(nameof(Class)); }
        }

        private int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; OnPropertyChanged(nameof(Level)); }
        }

        private int _maxHitpoints;
        public int MaxHitpoints
        {
            get { return _maxHitpoints; }
            set { _maxHitpoints = value; OnPropertyChanged(nameof(MaxHitpoints)); }
        }
        
        private int _currentHitpoints;
        public int CurrentHitpoints
        {
            get { return _currentHitpoints; }
            set 
            { 
                if (MaxHitpoints > 0)
                {
                    _currentHitpoints = value;
                    HealthRatio = (int)Math.Round((double)((100 * value) / MaxHitpoints));
                    OnPropertyChanged(nameof(CurrentHitpoints));
                    OnPropertyChanged(nameof(HealthRatio));
                }
                else
                {
                    _currentHitpoints = MaxHitpoints;
                }
            }
        }
        
        private int _armorClass;
        public int ArmorClass
        {
            get { return _armorClass; }
            set { _armorClass = value; OnPropertyChanged(nameof(ArmorClass)); }
        }

        #region Ability Scores

        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set { _strength = value; OnPropertyChanged(nameof(Strength)); }
        }
        
        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value; OnPropertyChanged(nameof(Dexterity)); }
        }
        
        private int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set { _constitution = value; OnPropertyChanged(nameof(Constitution)); }
        }
        
        private int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; OnPropertyChanged(nameof(Intelligence)); }
        }
        
        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set { _wisdom = value; OnPropertyChanged(nameof(Wisdom)); }
        }
        
        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set { _charisma = value; OnPropertyChanged(nameof(Charisma)); }
        }

        #endregion Ability Scores

        public int PassivePerception
        {
            get
            {
                return 10 + Modifier_Perception + AdditionalBonus_PassivePerception;
            }
            set
            {

            }
        }

        public int PassiveInsight
        {
            get
            {
                return 10 + Modifier_Insight + AdditionalBonus_PassiveInsight;
            }
            set
            {

            }
        }

        public int PassiveInvestigation
        {
            get
            {
                return 10 + Modifier_Investigation + AdditionalBonus_PassiveInvestigation;
            }
            set
            {

            }
        }

        #region Proficiencies

        public int ProficiencyBonus 
        { 
            get 
            {
                if (Level < 5) return 2;
                else if (Level < 9) return 3;
                else if (Level < 13) return 4;
                else if (Level < 17) return 5;
                else if (Level < 21) return 6;
                else return 0;
            } 
        }

        #region Saving Throw Proficiencies 
        private bool _hasProficiency_Strength_Save = false;
        public bool HasProficiency_Strength_Save
        {
            get { return _hasProficiency_Strength_Save; }
            set { _hasProficiency_Strength_Save = value; OnPropertyChanged(nameof(HasProficiency_Strength_Save)); }
        }

        private bool _hasProficiency_Dexterity_Save = false;
        public bool HasProficiency_Dexterity_Save
        {
            get { return _hasProficiency_Dexterity_Save; }
            set { _hasProficiency_Dexterity_Save = value; OnPropertyChanged(nameof(HasProficiency_Dexterity_Save)); }
        }

        private bool _hasProficiency_Constitution_Save = false;
        public bool HasProficiency_Constitution_Save
        {
            get { return _hasProficiency_Constitution_Save; }
            set { _hasProficiency_Constitution_Save = value; OnPropertyChanged(nameof(HasProficiency_Constitution_Save)); }
        }

        private bool _hasProficiency_Intelligence_Save = false;
        public bool HasProficiency_Intelligence_Save
        {
            get { return _hasProficiency_Intelligence_Save; }
            set { _hasProficiency_Intelligence_Save = value; OnPropertyChanged(nameof(HasProficiency_Intelligence_Save)); }
        }

        private bool _hasProficiency_Wisdom_Save = false;
        public bool HasProficiency_Wisdom_Save
        {
            get { return _hasProficiency_Wisdom_Save; }
            set { _hasProficiency_Wisdom_Save = value; OnPropertyChanged(nameof(HasProficiency_Wisdom_Save)); }
        }

        private bool _hasProficiency_Charisma_Save = false;
        public bool HasProficiency_Charisma_Save
        {
            get { return _hasProficiency_Charisma_Save; }
            set { _hasProficiency_Charisma_Save = value; OnPropertyChanged(nameof(HasProficiency_Charisma_Save)); }
        }
        #endregion Saving Throw Proficiencies 

        #region Skill Proficiencies

        private bool _hasProficiency_Acrobatics = false;
        public bool HasProficiency_Acrobatics
        {
            get { return _hasProficiency_Acrobatics; }
            set { _hasProficiency_Acrobatics = value; OnPropertyChanged(nameof(HasProficiency_Acrobatics)); }
        }

        private bool _hasProficiency_Animal_Handling = false;
        public bool HasProficiency_Animal_Handling
        {
            get { return _hasProficiency_Animal_Handling; }
            set { _hasProficiency_Animal_Handling = value; OnPropertyChanged(nameof(HasProficiency_Animal_Handling)); }
        }

        private bool _hasProficiency_Arcana = false;
        public bool HasProficiency_Arcana
        {
            get { return _hasProficiency_Arcana; }
            set { _hasProficiency_Arcana = value; OnPropertyChanged(nameof(HasProficiency_Arcana)); }
        }

        private bool _hasProficiency_Athletics = false;
        public bool HasProficiency_Athletics
        {
            get { return _hasProficiency_Athletics; }
            set { _hasProficiency_Athletics = value; OnPropertyChanged(nameof(HasProficiency_Athletics)); }
        }

        private bool _hasProficiency_Deception = false;
        public bool HasProficiency_Deception
        {
            get { return _hasProficiency_Deception; }
            set { _hasProficiency_Deception = value; OnPropertyChanged(nameof(HasProficiency_Deception)); }
        }

        private bool _hasProficiency_History = false;
        public bool HasProficiency_History
        {
            get { return _hasProficiency_History; }
            set { _hasProficiency_History = value; OnPropertyChanged(nameof(HasProficiency_History)); }
        }

        private bool _hasProficiency_Insight = false;
        public bool HasProficiency_Insight
        {
            get { return _hasProficiency_Insight; }
            set { _hasProficiency_Insight = value; OnPropertyChanged(nameof(HasProficiency_Insight)); }
        }

        private bool _hasProficiency_Intimidation = false;
        public bool HasProficiency_Intimidation
        {
            get { return _hasProficiency_Intimidation; }
            set { _hasProficiency_Intimidation = value; OnPropertyChanged(nameof(HasProficiency_Intimidation)); }
        }

        private bool _hasProficiency_Investigation = false;
        public bool HasProficiency_Investigation
        {
            get { return _hasProficiency_Investigation; }
            set { _hasProficiency_Investigation = value; OnPropertyChanged(nameof(HasProficiency_Investigation)); }
        }

        private bool _hasProficiency_Medicine = false;
        public bool HasProficiency_Medicine
        {
            get { return _hasProficiency_Medicine; }
            set { _hasProficiency_Medicine = value; OnPropertyChanged(nameof(HasProficiency_Medicine)); }
        }

        private bool _hasProficiency_Nature = false;
        public bool HasProficiency_Nature
        {
            get { return _hasProficiency_Nature; }
            set { _hasProficiency_Nature = value; OnPropertyChanged(nameof(HasProficiency_Nature)); }
        }

        private bool _hasProficiency_Perception = false;
        public bool HasProficiency_Perception
        {
            get { return _hasProficiency_Perception; }
            set { _hasProficiency_Perception = value; OnPropertyChanged(nameof(HasProficiency_Perception)); }
        }

        private bool _hasProficiency_Performance = false;
        public bool HasProficiency_Performance
        {
            get { return _hasProficiency_Performance; }
            set { _hasProficiency_Performance = value; OnPropertyChanged(nameof(HasProficiency_Performance)); }
        }

        private bool _hasProficiency_Persuasion = false;
        public bool HasProficiency_Persuasion
        {
            get { return _hasProficiency_Persuasion; }
            set { _hasProficiency_Persuasion = value; OnPropertyChanged(nameof(HasProficiency_Persuasion)); }
        }

        private bool _hasProficiency_Religion = false;
        public bool HasProficiency_Religion
        {
            get { return _hasProficiency_Religion; }
            set { _hasProficiency_Religion = value; OnPropertyChanged(nameof(HasProficiency_Religion)); }
        }

        private bool _hasProficiency_Sleight_Of_Hand = false;
        public bool HasProficiency_Sleight_Of_Hand
        {
            get { return _hasProficiency_Sleight_Of_Hand; }
            set { _hasProficiency_Sleight_Of_Hand = value; OnPropertyChanged(nameof(HasProficiency_Sleight_Of_Hand)); }
        }

        private bool _hasProficiency_Stealth = false;
        public bool HasProficiency_Stealth
        {
            get { return _hasProficiency_Stealth; }
            set { _hasProficiency_Stealth = value; OnPropertyChanged(nameof(HasProficiency_Stealth)); }
        }

        private bool _hasProficiency_Survival = false;
        public bool HasProficiency_Survival
        {
            get { return _hasProficiency_Survival; }
            set { _hasProficiency_Survival = value; OnPropertyChanged(nameof(HasProficiency_Survival)); }
        }

        #endregion Skill Proficiencies

        #region Skill Expertise

        private bool _hasExpertise_Acrobatics = false;
        public bool HasExpertise_Acrobatics
        {
            get { return _hasExpertise_Acrobatics; }
            set { _hasExpertise_Acrobatics = value; OnPropertyChanged(nameof(HasExpertise_Acrobatics)); }
        }

        private bool _hasExpertise_Animal_Handling = false;
        public bool HasExpertise_Animal_Handling
        {
            get { return _hasExpertise_Animal_Handling; }
            set { _hasExpertise_Animal_Handling = value; OnPropertyChanged(nameof(HasExpertise_Animal_Handling)); }
        }

        private bool _hasExpertise_Arcana = false;
        public bool HasExpertise_Arcana
        {
            get { return _hasExpertise_Arcana; }
            set { _hasExpertise_Arcana = value; OnPropertyChanged(nameof(HasExpertise_Arcana)); }
        }

        private bool _hasExpertise_Athletics = false;
        public bool HasExpertise_Athletics
        {
            get { return _hasExpertise_Athletics; }
            set { _hasExpertise_Athletics = value; OnPropertyChanged(nameof(HasExpertise_Athletics)); }
        }

        private bool _hasExpertise_Deception = false;
        public bool HasExpertise_Deception
        {
            get { return _hasExpertise_Deception; }
            set { _hasExpertise_Deception = value; OnPropertyChanged(nameof(HasExpertise_Deception)); }
        }

        private bool _hasExpertise_History = false;
        public bool HasExpertise_History
        {
            get { return _hasExpertise_History; }
            set { _hasExpertise_History = value; OnPropertyChanged(nameof(HasExpertise_History)); }
        }

        private bool _hasExpertise_Insight = false;
        public bool HasExpertise_Insight
        {
            get { return _hasExpertise_Insight; }
            set { _hasExpertise_Insight = value; OnPropertyChanged(nameof(HasExpertise_Insight)); }
        }

        private bool _hasExpertise_Intimidation = false;
        public bool HasExpertise_Intimidation
        {
            get { return _hasExpertise_Intimidation; }
            set { _hasExpertise_Intimidation = value; OnPropertyChanged(nameof(HasExpertise_Intimidation)); }
        }

        private bool _hasExpertise_Investigation = false;
        public bool HasExpertise_Investigation
        {
            get { return _hasExpertise_Investigation; }
            set { _hasExpertise_Investigation = value; OnPropertyChanged(nameof(HasExpertise_Investigation)); }
        }

        private bool _hasExpertise_Medicine = false;
        public bool HasExpertise_Medicine
        {
            get { return _hasExpertise_Medicine; }
            set { _hasExpertise_Medicine = value; OnPropertyChanged(nameof(HasExpertise_Medicine)); }
        }

        private bool _hasExpertise_Nature = false;
        public bool HasExpertise_Nature
        {
            get { return _hasExpertise_Nature; }
            set { _hasExpertise_Nature = value; OnPropertyChanged(nameof(HasExpertise_Nature)); }
        }

        private bool _hasExpertise_Perception = false;
        public bool HasExpertise_Perception
        {
            get { return _hasExpertise_Perception; }
            set { _hasExpertise_Perception = value; OnPropertyChanged(nameof(HasExpertise_Perception)); }
        }

        private bool _hasExpertise_Performance = false;
        public bool HasExpertise_Performance
        {
            get { return _hasExpertise_Performance; }
            set { _hasExpertise_Performance = value; OnPropertyChanged(nameof(HasExpertise_Performance)); }
        }

        private bool _hasExpertise_Persuasion = false;
        public bool HasExpertise_Persuasion
        {
            get { return _hasExpertise_Persuasion; }
            set { _hasExpertise_Persuasion = value; OnPropertyChanged(nameof(HasExpertise_Persuasion)); }
        }

        private bool _hasExpertise_Religion = false;
        public bool HasExpertise_Religion
        {
            get { return _hasExpertise_Religion; }
            set { _hasExpertise_Religion = value; OnPropertyChanged(nameof(HasExpertise_Religion)); }
        }

        private bool _hasExpertise_Sleight_Of_Hand = false;
        public bool HasExpertise_Sleight_Of_Hand
        {
            get { return _hasExpertise_Sleight_Of_Hand; }
            set { _hasExpertise_Sleight_Of_Hand = value; OnPropertyChanged(nameof(HasExpertise_Sleight_Of_Hand)); }
        }

        private bool _hasExpertise_Stealth = false;
        public bool HasExpertise_Stealth
        {
            get { return _hasExpertise_Stealth; }
            set { _hasExpertise_Stealth = value; OnPropertyChanged(nameof(HasExpertise_Stealth)); }
        }

        private bool _hasExpertise_Survival = false;
        public bool HasExpertise_Survival
        {
            get { return _hasExpertise_Survival; }
            set { _hasExpertise_Survival = value; OnPropertyChanged(nameof(HasExpertise_Survival)); }
        }
        #endregion Skill Expertise

        #endregion Proficiencies

        #region Modifiers

        #region Ability Modifiers
        public int Modifier_Strength { get { return Convert.ToInt32(Math.Floor(((double)Strength - 10) / 2)); } set { } }
        public int Modifier_Dexterity { get { return Convert.ToInt32(Math.Floor(((double)Dexterity - 10) / 2)); } set { } }
        public int Modifier_Constitution { get { return Convert.ToInt32(Math.Floor(((double)Constitution - 10) / 2)); } set { } }
        public int Modifier_Intelligence { get { return Convert.ToInt32(Math.Floor(((double)Intelligence - 10) / 2)); } set { } }
        public int Modifier_Wisdom { get { return Convert.ToInt32(Math.Floor(((double)Wisdom - 10) / 2)); } set { } }
        public int Modifier_Charisma { get { return Convert.ToInt32(Math.Floor(((double)Charisma - 10) / 2)); } set { } }

        #endregion Ability Modifiers

        #region Saving Throw Modifiers
        public int Modifier_StrengthSavingThrow 
        { 
            get 
            {
                if (HasProficiency_Strength_Save) return Modifier_Strength + ProficiencyBonus + AdditionalBonus_StrengthSavingThrow;
                else return Modifier_Strength + AdditionalBonus_StrengthSavingThrow;
            } 
            set
            {

            }
        }
        public int Modifier_DexteritySavingThrow
        {
            get
            {
                if (HasProficiency_Dexterity_Save) return Modifier_Dexterity + ProficiencyBonus + AdditionalBonus_DexteritySavingThrow;
                else return Modifier_Dexterity + AdditionalBonus_DexteritySavingThrow;
            }
            set
            {

            }
        }
        public int Modifier_ConstitutionSavingThrow
        {
            get
            {
                if (HasProficiency_Constitution_Save) return Modifier_Constitution + ProficiencyBonus + AdditionalBonus_ConstitutionSavingThrow;
                else return Modifier_Constitution + AdditionalBonus_ConstitutionSavingThrow;
            }
            set
            {

            }
        }
        public int Modifier_IntelligenceSavingThrow
        {
            get
            {
                if (HasProficiency_Intelligence_Save) return Modifier_Intelligence + ProficiencyBonus + AdditionalBonus_IntelligenceSavingThrow;
                else return Modifier_Intelligence + AdditionalBonus_IntelligenceSavingThrow;
            }
            set
            {

            }
        }
        public int Modifier_WisdomSavingThrow
        {
            get
            {
                if (HasProficiency_Wisdom_Save) return Modifier_Wisdom + ProficiencyBonus + AdditionalBonus_WisdomSavingThrow;
                else return Modifier_Wisdom + AdditionalBonus_WisdomSavingThrow;
            }
            set
            {

            }
        }
        public int Modifier_CharismaSavingThrow
        {
            get
            {
                if (HasProficiency_Charisma_Save) return Modifier_Charisma + ProficiencyBonus + AdditionalBonus_CharismaSavingThrow;
                else return Modifier_Charisma + AdditionalBonus_CharismaSavingThrow;
            }
            set
            {

            }
        }

        #endregion Saving Throw Modifiers

        #region Skill Modifiers
        public int Modifier_Acrobatics
        {
            get
            {
                if (HasExpertise_Acrobatics) return Modifier_Dexterity + (2 * ProficiencyBonus) + AdditionalBonus_Acrobatics;
                else if (HasProficiency_Acrobatics) return Modifier_Dexterity + ProficiencyBonus + AdditionalBonus_Acrobatics;
                else return Modifier_Dexterity + AdditionalBonus_Acrobatics;
            }
            set
            {

            }
        }
        public int Modifier_AnimalHandling
        {
            get
            {
                if (HasExpertise_Animal_Handling) return Modifier_Wisdom + (2 * ProficiencyBonus) + AdditionalBonus_Animal_Handling;
                else if (HasProficiency_Animal_Handling) return Modifier_Wisdom + ProficiencyBonus + AdditionalBonus_Animal_Handling;
                else return Modifier_Wisdom + AdditionalBonus_Animal_Handling;
            }
            set
            {

            }
        }
        public int Modifier_Arcana
        {
            get
            {
                if (HasExpertise_Arcana) return Modifier_Intelligence + (2 * ProficiencyBonus) + AdditionalBonus_Arcana;
                else if (HasProficiency_Arcana) return Modifier_Intelligence + ProficiencyBonus + AdditionalBonus_Arcana;
                else return Modifier_Intelligence + AdditionalBonus_Arcana;
            }
            set
            {

            }
        }
        public int Modifier_Athletics
        {
            get
            {
                if (HasExpertise_Athletics) return Modifier_Strength + (2 * ProficiencyBonus) + AdditionalBonus_Athletics;
                else if (HasProficiency_Athletics) return Modifier_Strength + ProficiencyBonus + AdditionalBonus_Athletics;
                else return Modifier_Strength + AdditionalBonus_Athletics;
            }
            set
            {

            }
        }
        public int Modifier_Deception
        {
            get
            {
                if (HasExpertise_Deception) return Modifier_Charisma + (2 * ProficiencyBonus) + AdditionalBonus_Deception;
                else if (HasProficiency_Deception) return Modifier_Charisma + ProficiencyBonus + AdditionalBonus_Deception;
                else return Modifier_Charisma + AdditionalBonus_Deception;
            }
            set
            {

            }
        }
        public int Modifier_History
        {
            get
            {
                if (HasExpertise_History) return Modifier_Intelligence + (2 * ProficiencyBonus) + AdditionalBonus_History;
                else if (HasProficiency_History) return Modifier_Intelligence + ProficiencyBonus + AdditionalBonus_History;
                else return Modifier_Intelligence + AdditionalBonus_History;
            }
            set
            {

            }
        }
        public int Modifier_Insight
        {
            get
            {
                if (HasExpertise_Insight) return Modifier_Wisdom + (2 * ProficiencyBonus) + AdditionalBonus_Insight;
                else if (HasProficiency_Insight) return Modifier_Wisdom + ProficiencyBonus + AdditionalBonus_Insight;
                else return Modifier_Wisdom + AdditionalBonus_Insight;
            }
            set
            {

            }
        }
        public int Modifier_Intimidation
        {
            get
            {
                if (HasExpertise_Intimidation) return Modifier_Charisma + (2 * ProficiencyBonus) + AdditionalBonus_Intimidation;
                else if (HasProficiency_Intimidation) return Modifier_Charisma + ProficiencyBonus + AdditionalBonus_Intimidation;
                else return Modifier_Charisma + AdditionalBonus_Intimidation;
            }
            set
            {

            }
        }
        public int Modifier_Investigation
        {
            get
            {
                if (HasExpertise_Investigation) return Modifier_Intelligence + (2 * ProficiencyBonus + AdditionalBonus_Investigation);
                else if (HasProficiency_Investigation) return Modifier_Intelligence + ProficiencyBonus + AdditionalBonus_Investigation;
                else return Modifier_Intelligence + AdditionalBonus_Investigation;
            }
            set
            {

            }
        }
        public int Modifier_Medicine
        {
            get
            {
                if (HasExpertise_Medicine) return Modifier_Wisdom + (2 * ProficiencyBonus) + AdditionalBonus_Medicine;
                else if (HasProficiency_Medicine) return Modifier_Wisdom + ProficiencyBonus + AdditionalBonus_Medicine;
                else return Modifier_Wisdom + AdditionalBonus_Medicine;
            }
            set
            {

            }
        }
        public int Modifier_Nature
        {
            get
            {
                if (HasExpertise_Nature) return Modifier_Intelligence + (2 * ProficiencyBonus) + AdditionalBonus_Nature;
                else if (HasProficiency_Nature) return Modifier_Intelligence + ProficiencyBonus + AdditionalBonus_Nature;
                else return Modifier_Intelligence + AdditionalBonus_Nature;
            }
            set
            {

            }
        }
        public int Modifier_Perception
        {
            get
            {
                if (HasExpertise_Perception) return Modifier_Wisdom + (2 * ProficiencyBonus) + AdditionalBonus_Perception;
                else if (HasProficiency_Perception) return Modifier_Wisdom + ProficiencyBonus + AdditionalBonus_Perception;
                else return Modifier_Wisdom + AdditionalBonus_Perception;
            }
            set
            {

            }
        }
        public int Modifier_Performance
        {
            get
            {
                if (HasExpertise_Performance) return Modifier_Charisma + (2 * ProficiencyBonus) + AdditionalBonus_Performance;
                else if (HasProficiency_Performance) return Modifier_Charisma + ProficiencyBonus + AdditionalBonus_Performance;
                else return Modifier_Charisma + AdditionalBonus_Performance;
            }
            set
            {

            }
        }
        public int Modifier_Persuasion
        {
            get
            {
                if (HasExpertise_Persuasion) return Modifier_Charisma + (2 * ProficiencyBonus) + AdditionalBonus_Persuasion;
                else if (HasProficiency_Persuasion) return Modifier_Charisma + ProficiencyBonus + AdditionalBonus_Persuasion;
                else return Modifier_Charisma + AdditionalBonus_Persuasion;
            }
            set
            {

            }
        }
        public int Modifier_Religion
        {
            get
            {
                if (HasExpertise_Religion) return Modifier_Intelligence + (2 * ProficiencyBonus) + AdditionalBonus_Religion;
                else if (HasProficiency_Religion) return Modifier_Intelligence + ProficiencyBonus + AdditionalBonus_Religion;
                else return Modifier_Intelligence + AdditionalBonus_Religion;
            }
            set
            {

            }
        }
        public int Modifier_SleightOfHand
        {
            get
            {
                if (HasExpertise_Sleight_Of_Hand) return Modifier_Dexterity + (2 * ProficiencyBonus) + AdditionalBonus_Sleight_Of_Hand;
                else if (HasProficiency_Sleight_Of_Hand) return Modifier_Dexterity + ProficiencyBonus + AdditionalBonus_Sleight_Of_Hand;
                else return Modifier_Dexterity + AdditionalBonus_Sleight_Of_Hand;
            }
            set
            {

            }
        }
        public int Modifier_Stealth
        {
            get
            {
                if (HasExpertise_Stealth) return Modifier_Dexterity + (2 * ProficiencyBonus) + AdditionalBonus_Stealth;
                else if (HasProficiency_Stealth) return Modifier_Dexterity + ProficiencyBonus + AdditionalBonus_Stealth;
                else return Modifier_Dexterity + AdditionalBonus_Stealth;
            }
            set
            {

            }
        }
        public int Modifier_Survival
        {
            get
            {
                if (HasExpertise_Survival) return Modifier_Wisdom + (2 * ProficiencyBonus) + AdditionalBonus_Survival;
                else if (HasProficiency_Survival) return Modifier_Wisdom + ProficiencyBonus + AdditionalBonus_Survival;
                else return Modifier_Wisdom + AdditionalBonus_Survival;
            }
            set
            {

            }
        }


        #endregion Skill Modifiers

        #region Additional Bonuses

        private int _additionalBonus_Initiative = 0;
        public int AdditionalBonus_Initiative
        {
            get { return _additionalBonus_Initiative; }
            set { _additionalBonus_Initiative = value; OnPropertyChanged(nameof(AdditionalBonus_Initiative)); }
        }

        private int _additionalBonus_PassiveInsight = 0;
        public int AdditionalBonus_PassiveInsight
        {
            get { return _additionalBonus_PassiveInsight; }
            set { _additionalBonus_PassiveInsight = value; OnPropertyChanged(nameof(AdditionalBonus_PassiveInsight)); }
        }

        private int _additionalBonus_PassiveInvestigation = 0;
        public int AdditionalBonus_PassiveInvestigation
        {
            get { return _additionalBonus_PassiveInvestigation; }
            set { _additionalBonus_PassiveInvestigation = value; OnPropertyChanged(nameof(AdditionalBonus_PassiveInvestigation)); }
        }

        private int _additionalBonus_PassivePerception = 0;
        public int AdditionalBonus_PassivePerception
        {
            get { return _additionalBonus_PassivePerception; }
            set { _additionalBonus_PassivePerception = value; OnPropertyChanged(nameof(AdditionalBonus_PassivePerception)); }
        }

        #region Saving Throw Additional Bonuses

        private int _additionalBonus_StrengthSavingThrow = 0;
        public int AdditionalBonus_StrengthSavingThrow
        {
            get { return _additionalBonus_StrengthSavingThrow; }
            set { _additionalBonus_StrengthSavingThrow = value; OnPropertyChanged(nameof(AdditionalBonus_StrengthSavingThrow)); }
        }

        private int _additionalBonus_DexteritySavingThrow = 0;
        public int AdditionalBonus_DexteritySavingThrow
        {
            get { return _additionalBonus_DexteritySavingThrow; }
            set { _additionalBonus_DexteritySavingThrow = value; OnPropertyChanged(nameof(AdditionalBonus_DexteritySavingThrow)); }
        }

        private int _additionalBonus_ConstitutionSavingThrow = 0;
        public int AdditionalBonus_ConstitutionSavingThrow
        {
            get { return _additionalBonus_ConstitutionSavingThrow; }
            set { _additionalBonus_ConstitutionSavingThrow = value; OnPropertyChanged(nameof(AdditionalBonus_ConstitutionSavingThrow)); }
        }

        private int _additionalBonus_IntelligenceSavingThrow = 0;
        public int AdditionalBonus_IntelligenceSavingThrow
        {
            get { return _additionalBonus_IntelligenceSavingThrow; }
            set { _additionalBonus_IntelligenceSavingThrow = value; OnPropertyChanged(nameof(AdditionalBonus_IntelligenceSavingThrow)); }
        }

        private int _additionalBonus_WisdomSavingThrow = 0;
        public int AdditionalBonus_WisdomSavingThrow
        {
            get { return _additionalBonus_WisdomSavingThrow; }
            set { _additionalBonus_WisdomSavingThrow = value; OnPropertyChanged(nameof(AdditionalBonus_WisdomSavingThrow)); }
        }

        private int _additionalBonus_CharismaSavingThrow = 0;
        public int AdditionalBonus_CharismaSavingThrow
        {
            get { return _additionalBonus_CharismaSavingThrow; }
            set { _additionalBonus_CharismaSavingThrow = value; OnPropertyChanged(nameof(AdditionalBonus_CharismaSavingThrow)); }
        }

        #endregion Saving Throw Additional Bonuses

        #region Skill Additional Bonuses

        private int _additionalBonus_Acrobatics = 0;
        public int AdditionalBonus_Acrobatics
        {
            get { return _additionalBonus_Acrobatics; }
            set { _additionalBonus_Acrobatics = value; OnPropertyChanged(nameof(AdditionalBonus_Acrobatics)); }
        }

        private int _additionalBonus_Animal_Handling = 0;
        public int AdditionalBonus_Animal_Handling
        {
            get { return _additionalBonus_Animal_Handling; }
            set { _additionalBonus_Animal_Handling = value; OnPropertyChanged(nameof(AdditionalBonus_Animal_Handling)); }
        }

        private int _additionalBonus_Arcana = 0;
        public int AdditionalBonus_Arcana
        {
            get { return _additionalBonus_Arcana; }
            set { _additionalBonus_Arcana = value; OnPropertyChanged(nameof(AdditionalBonus_Arcana)); }
        }

        private int _additionalBonus_Athletics = 0;
        public int AdditionalBonus_Athletics
        {
            get { return _additionalBonus_Athletics; }
            set { _additionalBonus_Athletics = value; OnPropertyChanged(nameof(AdditionalBonus_Athletics)); }
        }

        private int _additionalBonus_Deception = 0;
        public int AdditionalBonus_Deception
        {
            get { return _additionalBonus_Deception; }
            set { _additionalBonus_Deception = value; OnPropertyChanged(nameof(AdditionalBonus_Deception)); }
        }

        private int _additionalBonus_History = 0;
        public int AdditionalBonus_History
        {
            get { return _additionalBonus_History; }
            set { _additionalBonus_History = value; OnPropertyChanged(nameof(AdditionalBonus_History)); }
        }

        private int _additionalBonus_Insight = 0;
        public int AdditionalBonus_Insight
        {
            get { return _additionalBonus_Insight; }
            set { _additionalBonus_Insight = value; OnPropertyChanged(nameof(AdditionalBonus_Insight)); }
        }

        private int _additionalBonus_Intimidation = 0;
        public int AdditionalBonus_Intimidation
        {
            get { return _additionalBonus_Intimidation; }
            set { _additionalBonus_Intimidation = value; OnPropertyChanged(nameof(AdditionalBonus_Intimidation)); }
        }

        private int _additionalBonus_Investigation = 0;
        public int AdditionalBonus_Investigation
        {
            get { return _additionalBonus_Investigation; }
            set { _additionalBonus_Investigation = value; OnPropertyChanged(nameof(AdditionalBonus_Investigation)); }
        }

        private int _additionalBonus_Medicine = 0;
        public int AdditionalBonus_Medicine
        {
            get { return _additionalBonus_Medicine; }
            set { _additionalBonus_Medicine = value; OnPropertyChanged(nameof(AdditionalBonus_Medicine)); }
        }

        private int _additionalBonus_Nature = 0;
        public int AdditionalBonus_Nature
        {
            get { return _additionalBonus_Nature; }
            set { _additionalBonus_Nature = value; OnPropertyChanged(nameof(AdditionalBonus_Nature)); }
        }

        private int _additionalBonus_Perception = 0;
        public int AdditionalBonus_Perception
        {
            get { return _additionalBonus_Perception; }
            set { _additionalBonus_Perception = value; OnPropertyChanged(nameof(AdditionalBonus_Perception)); }
        }

        private int _additionalBonus_Performance = 0;
        public int AdditionalBonus_Performance
        {
            get { return _additionalBonus_Performance; }
            set { _additionalBonus_Performance = value; OnPropertyChanged(nameof(AdditionalBonus_Performance)); }
        }

        private int _additionalBonus_Persuasion = 0;
        public int AdditionalBonus_Persuasion
        {
            get { return _additionalBonus_Persuasion; }
            set { _additionalBonus_Persuasion = value; OnPropertyChanged(nameof(AdditionalBonus_Persuasion)); }
        }

        private int _additionalBonus_Religion = 0;
        public int AdditionalBonus_Religion
        {
            get { return _additionalBonus_Religion; }
            set { _additionalBonus_Religion = value; OnPropertyChanged(nameof(AdditionalBonus_Religion)); }
        }

        private int _additionalBonus_Sleight_Of_Hand = 0;
        public int AdditionalBonus_Sleight_Of_Hand
        {
            get { return _additionalBonus_Sleight_Of_Hand; }
            set { _additionalBonus_Sleight_Of_Hand = value; OnPropertyChanged(nameof(AdditionalBonus_Sleight_Of_Hand)); }
        }

        private int _additionalBonus_Stealth = 0;
        public int AdditionalBonus_Stealth
        {
            get { return _additionalBonus_Stealth; }
            set { _additionalBonus_Stealth = value; OnPropertyChanged(nameof(AdditionalBonus_Stealth)); }
        }

        private int _additionalBonus_Survival = 0;
        public int AdditionalBonus_Survival
        {
            get { return _additionalBonus_Survival; }
            set { _additionalBonus_Survival = value; OnPropertyChanged(nameof(AdditionalBonus_Survival)); }
        }

        #endregion Skill Additional Bonuses

        #endregion Additional Bonuses 

        public int Modifier_Initiative
        {
            get
            {
                return Modifier_Dexterity + AdditionalBonus_Initiative;
            }
            set
            {

            }
        }

        #endregion Modifiers

        private int _healthRatio;
        public int HealthRatio
        {
            get { return _healthRatio; }
            set { _healthRatio = value; OnPropertyChanged(nameof(HealthRatio)); }
        }

        #region Conditions

        //CharacterConditions is used to read trackers from XML then is processed into CharacterConditionsList on startup
        private string _characterConditions = "";
        public string CharacterConditions
        {
            get { return _characterConditions; }
            set { _characterConditions = value; OnPropertyChanged(nameof(CharacterConditions)); }
        }

        //Main Conditions Data
        private ObservableCollection<string> _characterConditionsList;
        public ObservableCollection<string> CharacterConditionsList
        {
            get { return _characterConditionsList; }
            set { _characterConditionsList = value; }
        }

        #endregion Conditions

        #region Spells

        private bool _isSpellcaster = false;
        public bool IsSpellcaster
        {
            get { return _isSpellcaster; }
            set { _isSpellcaster = value; OnPropertyChanged(nameof(IsSpellcaster)); }
        }

        private ObservableCollection<string> _spellsKnown;
        public ObservableCollection<string> SpellsKnown
        {
            get { return _spellsKnown; }
            set { _spellsKnown = value; }
        }

        private string _maxSpellSlots = "";
        public string MaxSpellSlots
        {
            get { return _maxSpellSlots; }
            set { _maxSpellSlots = value; OnPropertyChanged(nameof(MaxSpellSlots)); }
        }

        private string _currentSpellSlots = "";
        public string CurrentSpellSlots
        {
            get { return _currentSpellSlots; }
            set { _currentSpellSlots = value; OnPropertyChanged(nameof(CurrentSpellSlots)); }
        }

        private bool _isConcentrating = false;
        public bool IsConcentrating
        {
            get { return _isConcentrating; }
            set { _isConcentrating = value; OnPropertyChanged(nameof(IsConcentrating)); }
        }

        #endregion Spells

        #region Customization

        private string _imagePath = @"C:\Users\james\source\repos\BattleBuddy\BattleBuddy\Images\d20-icon-5.png";
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnPropertyChanged(nameof(ImagePath)); }
        }

        public Uri ImageUri
        {
            get { return new Uri(_imagePath); }
        }

        private Color _primaryCharacterColor;
        public Color PrimaryCharacterColor
        {
            get { return _primaryCharacterColor; }
            set { _primaryCharacterColor = value; OnPropertyChanged(nameof(PrimaryCharacterColor)); }
        }

        private Color _secondaryCharacterColor;
        public Color SecondaryCharacterColor
        {
            get { return _secondaryCharacterColor; }
            set { _secondaryCharacterColor = value; OnPropertyChanged(nameof(SecondaryCharacterColor)); }
        }

        private Color _tertiaryCharacterColor;
        public Color TertiaryCharacterColor
        {
            get { return _tertiaryCharacterColor; }
            set { _tertiaryCharacterColor = value; OnPropertyChanged(nameof(TertiaryCharacterColor)); }
        }

        private ObservableCollection<string> _characterQuotes;
        public ObservableCollection<string> CharacterQuotes
        {
            get { return _characterQuotes; }
            set { _characterQuotes = value; }
        }

        #endregion Customization

        #region Trackers

        //CharacterTrackers is used to read trackers from XML then is processed into CharacterTrackersList on startup
        private string _characterTrackers = "";
        public string CharacterTrackers
        {
            get { return _characterTrackers; }
            set { _characterTrackers = value; OnPropertyChanged(nameof(CharacterTrackers)); }
        }

        //Main Tracker Data
        private ObservableCollection<CharacterTracker> _characterTrackersList;
        public ObservableCollection<CharacterTracker> CharacterTrackersList
        {
            get { return _characterTrackersList; }
            set { _characterTrackersList = value; }
        }

        #endregion Trackers

        #region Testing


        #endregion Testing

        public Character() 
        {
            CharacterConditionsList = new ObservableCollection<string>();
            CharacterQuotes = new ObservableCollection<string>();
            CharacterTrackersList = new ObservableCollection<CharacterTracker>();
            SpellsKnown = new ObservableCollection<string>();
        }
    }
}
