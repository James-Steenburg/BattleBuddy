using BattleBuddy.Helpers;
using BattleBuddy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace BattleBuddy.XML
{
    class XMLFileIO : ChangeNotifier
    {
        public string XMLPath1 = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
        public string XMLPath2 = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
        public string XMLPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\WorkingParty.xml"));
        //public string XMLPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\BattleBudy\XML\WorkingParty.xml"));


        //C:\Users\james\source\repos\BattleBuddy\BattleBuddy\XML\WorkingParty.xml

        private string _partyName = "Name the Party in Settings";
        public string PartyName
        {
            get { return _partyName; }
            set { _partyName = value; OnPropertyChanged(nameof(PartyName)); }
        }

        public ObservableCollection<Character> CharacterCollection { get; } = new ObservableCollection<Character>();

        public ObservableCollection<CharacterCondition> ConditionCollection { get; } = new ObservableCollection<CharacterCondition>();

        private UserSettings _xmlStoredUserSettings;
        public UserSettings XmlStoredUserSettings
        {
            get { return _xmlStoredUserSettings; }
            set { _xmlStoredUserSettings = value; OnPropertyChanged(nameof(XmlStoredUserSettings)); }
        }

        public void SavePartyToFile(string partyName, ObservableCollection<Character> party)
        {

            string savePath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\TestParty.xml"));

            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Party");
            XmlAttribute partyNameAttribute = doc.CreateAttribute("PartyName");
            partyNameAttribute.Value = partyName;
            rootNode.Attributes.Append(partyNameAttribute);

            doc.AppendChild(rootNode);

            XmlNode characterNode;
            XmlAttribute nameAttribute;
            XmlAttribute classAttribute;
            XmlAttribute levelAttribute;
            XmlAttribute maxHitpointsAttribute;
            XmlAttribute currentHitpointsAttribute;
            XmlAttribute armorClassAttribute;
            XmlAttribute strengthAttribute;
            XmlAttribute dexterityAttribute;
            XmlAttribute constitutionAttribute;
            XmlAttribute intelligenceAttribute;
            XmlAttribute wisdomAttribute;
            XmlAttribute charismaAttribute;

            XmlAttribute hasProf_StrengthSavingThrowAttribute;
            XmlAttribute hasProf_DexteritySavingThrowAttribute;
            XmlAttribute hasProf_ConstitutionSavingThrowAttribute;
            XmlAttribute hasProf_IntelligenceSavingThrowAttribute;
            XmlAttribute hasProf_WisdomSavingThrowAttribute;
            XmlAttribute hasProf_CharismaSavingThrowAttribute;

            XmlAttribute hasProf_AcrobaticsAttribute;
            XmlAttribute hasProf_AnimalHandlingAttribute;
            XmlAttribute hasProf_ArcanaAttribute;
            XmlAttribute hasProf_AthleticsAttribute;
            XmlAttribute hasProf_DeceptionAttribute;
            XmlAttribute hasProf_HistoryAttribute;
            XmlAttribute hasProf_InsightAttribute;
            XmlAttribute hasProf_IntimidationAttribute;
            XmlAttribute hasProf_InvestigationAttribute;
            XmlAttribute hasProf_MedicineAttribute;
            XmlAttribute hasProf_NatureAttribute;
            XmlAttribute hasProf_PerceptionAttribute;
            XmlAttribute hasProf_PerformanceAttribute;
            XmlAttribute hasProf_PersuasionAttribute;
            XmlAttribute hasProf_ReligionAttribute;
            XmlAttribute hasProf_SleightOfHandAttribute;
            XmlAttribute hasProf_StealthAttribute; 
            XmlAttribute hasProf_SurvivalAttribute;

            XmlAttribute hasExp_AcrobaticsAttribute;
            XmlAttribute hasExp_AnimalHandlingAttribute;
            XmlAttribute hasExp_ArcanaAttribute;
            XmlAttribute hasExp_AthleticsAttribute;
            XmlAttribute hasExp_DeceptionAttribute;
            XmlAttribute hasExp_HistoryAttribute;
            XmlAttribute hasExp_InsightAttribute;
            XmlAttribute hasExp_IntimidationAttribute;
            XmlAttribute hasExp_InvestigationAttribute;
            XmlAttribute hasExp_MedicineAttribute;
            XmlAttribute hasExp_NatureAttribute;
            XmlAttribute hasExp_PerceptionAttribute;
            XmlAttribute hasExp_PerformanceAttribute;
            XmlAttribute hasExp_PersuasionAttribute;
            XmlAttribute hasExp_ReligionAttribute;
            XmlAttribute hasExp_SleightOfHandAttribute;
            XmlAttribute hasExp_StealthAttribute;
            XmlAttribute hasExp_SurvivalAttribute;

            XmlAttribute addBonus_InitiativeAttribute;
            XmlAttribute addBonus_PassiveInsightAttribute;
            XmlAttribute addBonus_PassiveInvestigationAttribute;
            XmlAttribute addBonus_PassivePerceptionAttribute;

            XmlAttribute addBonus_StrengthSavingThrowAttribute;
            XmlAttribute addBonus_DexteritySavingThrowAttribute;
            XmlAttribute addBonus_ConstitutionSavingThrowAttribute;
            XmlAttribute addBonus_IntelligenceSavingThrowAttribute;
            XmlAttribute addBonus_WisdomSavingThrowAttribute;
            XmlAttribute addBonus_CharismaSavingThrowAttribute;

            XmlAttribute addBonus_AcrobaticsAttribute;
            XmlAttribute addBonus_AnimalHandlingAttribute;
            XmlAttribute addBonus_ArcanaAttribute;
            XmlAttribute addBonus_AthleticsAttribute;
            XmlAttribute addBonus_DeceptionAttribute;
            XmlAttribute addBonus_HistoryAttribute;
            XmlAttribute addBonus_InsightAttribute;
            XmlAttribute addBonus_IntimidationAttribute;
            XmlAttribute addBonus_InvestigationAttribute;
            XmlAttribute addBonus_MedicineAttribute;
            XmlAttribute addBonus_NatureAttribute;
            XmlAttribute addBonus_PerceptionAttribute;
            XmlAttribute addBonus_PerformanceAttribute;
            XmlAttribute addBonus_PersuasionAttribute;
            XmlAttribute addBonus_ReligionAttribute;
            XmlAttribute addBonus_SleightOfHandAttribute;
            XmlAttribute addBonus_StealthAttribute;
            XmlAttribute addBonus_SurvivalAttribute;

            XmlAttribute conditionsAttribute;
            XmlAttribute trackersAttribute;

            XmlAttribute imagePathAttribute;
            XmlAttribute primaryCharacterColorAttribute;
            XmlAttribute secondaryCharacterColorAttribute;
            XmlAttribute teriaryCharacterColorAttribute;


            foreach (Character character in party)
            {
                string characterTrackers = "";
                foreach (CharacterTracker tracker in character.CharacterTrackersList)
                {
                    characterTrackers = characterTrackers + tracker.TrackerName + "/" + tracker.TrackerAvailableUses + "/" + tracker.TrackerMaxUses + ";";
                }

                characterNode = doc.CreateElement("Character");
                nameAttribute = doc.CreateAttribute("Name");
                classAttribute = doc.CreateAttribute("Class");
                levelAttribute = doc.CreateAttribute("Level");
                maxHitpointsAttribute = doc.CreateAttribute("MaxHitpoints");
                currentHitpointsAttribute = doc.CreateAttribute("CurrentHitpoints");
                armorClassAttribute = doc.CreateAttribute("ArmorClass");
                strengthAttribute = doc.CreateAttribute("Strength");
                dexterityAttribute = doc.CreateAttribute("Dexterity");
                constitutionAttribute = doc.CreateAttribute("Constitution");
                intelligenceAttribute = doc.CreateAttribute("Intelligence");
                wisdomAttribute = doc.CreateAttribute("Wisdom");
                charismaAttribute = doc.CreateAttribute("Charisma");

                hasProf_StrengthSavingThrowAttribute = doc.CreateAttribute("hasProf_StrengthSavingThrow");
                hasProf_DexteritySavingThrowAttribute = doc.CreateAttribute("hasProf_DexteritySavingThrow");
                hasProf_ConstitutionSavingThrowAttribute = doc.CreateAttribute("hasProf_ConstitutionSavingThrow");
                hasProf_IntelligenceSavingThrowAttribute = doc.CreateAttribute("hasProf_IntelligenceSavingThrow");
                hasProf_WisdomSavingThrowAttribute = doc.CreateAttribute("hasProf_WisdomSavingThrow");
                hasProf_CharismaSavingThrowAttribute = doc.CreateAttribute("hasProf_CharismaSavingThrow");

                hasProf_AcrobaticsAttribute = doc.CreateAttribute("hasProf_Acrobatics");
                hasProf_AnimalHandlingAttribute = doc.CreateAttribute("hasProf_AnimalHandling");
                hasProf_ArcanaAttribute = doc.CreateAttribute("hasProf_Arcana");
                hasProf_AthleticsAttribute = doc.CreateAttribute("hasProf_Athletics");
                hasProf_DeceptionAttribute = doc.CreateAttribute("hasProf_Deception");
                hasProf_HistoryAttribute = doc.CreateAttribute("hasProf_History");
                hasProf_InsightAttribute = doc.CreateAttribute("hasProf_Insight");
                hasProf_IntimidationAttribute = doc.CreateAttribute("hasProf_Intimidation");
                hasProf_InvestigationAttribute = doc.CreateAttribute("hasProf_Investigation");
                hasProf_MedicineAttribute = doc.CreateAttribute("hasProf_Medicine");
                hasProf_NatureAttribute = doc.CreateAttribute("hasProf_Nature");
                hasProf_PerceptionAttribute = doc.CreateAttribute("hasProf_Perception");
                hasProf_PerformanceAttribute = doc.CreateAttribute("hasProf_Performance");
                hasProf_PersuasionAttribute = doc.CreateAttribute("hasProf_Persuasion");
                hasProf_ReligionAttribute = doc.CreateAttribute("hasProf_Religion");
                hasProf_SleightOfHandAttribute = doc.CreateAttribute("hasProf_SleightOfHand");
                hasProf_StealthAttribute = doc.CreateAttribute("hasProf_Stealth");
                hasProf_SurvivalAttribute = doc.CreateAttribute("hasProf_Survival");

                hasExp_AcrobaticsAttribute = doc.CreateAttribute("hasExp_Acrobatics");
                hasExp_AnimalHandlingAttribute = doc.CreateAttribute("hasExp_AnimalHandling");
                hasExp_ArcanaAttribute = doc.CreateAttribute("hasExp_AnimalHandling");
                hasExp_AthleticsAttribute = doc.CreateAttribute("hasExp_Athletics");
                hasExp_DeceptionAttribute = doc.CreateAttribute("hasExp_Deception");
                hasExp_HistoryAttribute = doc.CreateAttribute("hasExp_History");
                hasExp_InsightAttribute = doc.CreateAttribute("hasExp_Insight");
                hasExp_IntimidationAttribute = doc.CreateAttribute("hasExp_Intimidation");
                hasExp_InvestigationAttribute = doc.CreateAttribute("hasExp_Investigation");
                hasExp_MedicineAttribute = doc.CreateAttribute("hasExp_Medicine");
                hasExp_NatureAttribute = doc.CreateAttribute("hasExp_Nature");
                hasExp_PerceptionAttribute = doc.CreateAttribute("hasExp_Perception");
                hasExp_PerformanceAttribute = doc.CreateAttribute("hasExp_Performance");
                hasExp_PersuasionAttribute = doc.CreateAttribute("hasExp_Persuasion");
                hasExp_ReligionAttribute = doc.CreateAttribute("hasExp_Religion");
                hasExp_SleightOfHandAttribute = doc.CreateAttribute("hasExp_SleightOfHand");
                hasExp_StealthAttribute = doc.CreateAttribute("hasExp_Stealth");
                hasExp_SurvivalAttribute = doc.CreateAttribute("hasExp_Survival");

                addBonus_InitiativeAttribute = doc.CreateAttribute("addBonus_Initiative");
                addBonus_PassiveInsightAttribute = doc.CreateAttribute("addBonus_PassiveInsight");
                addBonus_PassiveInvestigationAttribute = doc.CreateAttribute("addBonus_PassiveInvestigation");
                addBonus_PassivePerceptionAttribute = doc.CreateAttribute("addBonus_PassivePerception");

                addBonus_StrengthSavingThrowAttribute = doc.CreateAttribute("addBonus_StrengthSavingThrow");
                addBonus_DexteritySavingThrowAttribute = doc.CreateAttribute("addBonus_DexteritySavingThrow");
                addBonus_ConstitutionSavingThrowAttribute = doc.CreateAttribute("addBonus_ConstitutionSavingThrow");
                addBonus_IntelligenceSavingThrowAttribute = doc.CreateAttribute("addBonus_IntelligenceSavingThrow");
                addBonus_WisdomSavingThrowAttribute = doc.CreateAttribute("addBonus_WisdomSavingThrow");
                addBonus_CharismaSavingThrowAttribute = doc.CreateAttribute("addBonus_CharismaSavingThrow");

                addBonus_AcrobaticsAttribute = doc.CreateAttribute("addBonus_Acrobatics");
                addBonus_AnimalHandlingAttribute = doc.CreateAttribute("addBonus_AnimalHandling");
                addBonus_ArcanaAttribute = doc.CreateAttribute("addBonus_Arcana");
                addBonus_AthleticsAttribute = doc.CreateAttribute("addBonus_Athletics");
                addBonus_DeceptionAttribute = doc.CreateAttribute("addBonus_Deception");
                addBonus_HistoryAttribute = doc.CreateAttribute("addBonus_History");
                addBonus_InsightAttribute = doc.CreateAttribute("addBonus_Insight");
                addBonus_IntimidationAttribute = doc.CreateAttribute("addBonus_Intimidation");
                addBonus_InvestigationAttribute = doc.CreateAttribute("addBonus_Investigation");
                addBonus_MedicineAttribute = doc.CreateAttribute("addBonus_Medicine");
                addBonus_NatureAttribute = doc.CreateAttribute("addBonus_Nature");
                addBonus_PerceptionAttribute = doc.CreateAttribute("addBonus_Perception");
                addBonus_PerformanceAttribute = doc.CreateAttribute("addBonus_Performance");
                addBonus_PersuasionAttribute = doc.CreateAttribute("addBonus_Persuasion");
                addBonus_ReligionAttribute = doc.CreateAttribute("addBonus_Religion");
                addBonus_SleightOfHandAttribute = doc.CreateAttribute("addBonus_SleightOfHand");
                addBonus_StealthAttribute = doc.CreateAttribute("addBonus_Stealth");
                addBonus_SurvivalAttribute = doc.CreateAttribute("addBonus_Survival");

                conditionsAttribute = doc.CreateAttribute("Conditions");
                trackersAttribute = doc.CreateAttribute("Trackers");

                imagePathAttribute = doc.CreateAttribute("ImagePath");
                primaryCharacterColorAttribute = doc.CreateAttribute("PrimaryCharacterColor");
                secondaryCharacterColorAttribute = doc.CreateAttribute("SecondaryCharacterColor");
                teriaryCharacterColorAttribute = doc.CreateAttribute("TertiaryCharacterColor");

                nameAttribute.Value = character.Name;
                classAttribute.Value = character.Class;
                levelAttribute.Value = character.Level.ToString();
                maxHitpointsAttribute.Value = character.MaxHitpoints.ToString();
                currentHitpointsAttribute.Value = character.CurrentHitpoints.ToString();
                armorClassAttribute.Value = character.ArmorClass.ToString();
                strengthAttribute.Value = character.Strength.ToString();
                dexterityAttribute.Value = character.Dexterity.ToString();
                constitutionAttribute.Value = character.Constitution.ToString();
                intelligenceAttribute.Value = character.Intelligence.ToString();
                wisdomAttribute.Value = character.Wisdom.ToString();
                charismaAttribute.Value = character.Charisma.ToString();

                hasProf_StrengthSavingThrowAttribute.Value = character.HasProficiency_Strength_Save.ToString();
                hasProf_DexteritySavingThrowAttribute.Value = character.HasProficiency_Dexterity_Save.ToString();
                hasProf_ConstitutionSavingThrowAttribute.Value = character.HasProficiency_Constitution_Save.ToString();
                hasProf_IntelligenceSavingThrowAttribute.Value = character.HasProficiency_Intelligence_Save.ToString();
                hasProf_WisdomSavingThrowAttribute.Value = character.HasProficiency_Wisdom_Save.ToString();
                hasProf_CharismaSavingThrowAttribute.Value = character.HasProficiency_Charisma_Save.ToString();

                hasProf_AcrobaticsAttribute.Value = character.HasProficiency_Acrobatics.ToString();
                hasProf_AnimalHandlingAttribute.Value = character.HasProficiency_Animal_Handling.ToString();
                hasProf_ArcanaAttribute.Value = character.HasProficiency_Arcana.ToString();
                hasProf_AthleticsAttribute.Value = character.HasProficiency_Athletics.ToString();
                hasProf_DeceptionAttribute.Value = character.HasProficiency_Deception.ToString();
                hasProf_HistoryAttribute.Value = character.HasProficiency_History.ToString();
                hasProf_InsightAttribute.Value = character.HasProficiency_Insight.ToString();
                hasProf_IntimidationAttribute.Value = character.HasProficiency_Intimidation.ToString();
                hasProf_InvestigationAttribute.Value = character.HasProficiency_Investigation.ToString();
                hasProf_MedicineAttribute.Value = character.HasProficiency_Medicine.ToString();
                hasProf_NatureAttribute.Value = character.HasProficiency_Nature.ToString();
                hasProf_PerceptionAttribute.Value = character.HasProficiency_Perception.ToString();
                hasProf_PerformanceAttribute.Value = character.HasProficiency_Performance.ToString();
                hasProf_PersuasionAttribute.Value = character.HasProficiency_Persuasion.ToString();
                hasProf_ReligionAttribute.Value = character.HasProficiency_Religion.ToString();
                hasProf_SleightOfHandAttribute.Value = character.HasProficiency_Sleight_Of_Hand.ToString();
                hasProf_StealthAttribute.Value = character.HasProficiency_Stealth.ToString();
                hasProf_SurvivalAttribute.Value = character.HasProficiency_Survival.ToString();

                hasExp_AcrobaticsAttribute.Value = character.HasExpertise_Acrobatics.ToString();
                hasExp_AnimalHandlingAttribute.Value = character.HasExpertise_Animal_Handling.ToString();
                hasExp_ArcanaAttribute.Value = character.HasExpertise_Arcana.ToString();
                hasExp_AthleticsAttribute.Value = character.HasExpertise_Athletics.ToString();
                hasExp_DeceptionAttribute.Value = character.HasExpertise_Deception.ToString();
                hasExp_HistoryAttribute.Value = character.HasExpertise_History.ToString();
                hasExp_InsightAttribute.Value = character.HasExpertise_Insight.ToString();
                hasExp_IntimidationAttribute.Value = character.HasExpertise_Intimidation.ToString();
                hasExp_InvestigationAttribute.Value = character.HasExpertise_Investigation.ToString();
                hasExp_MedicineAttribute.Value = character.HasExpertise_Medicine.ToString();
                hasExp_NatureAttribute.Value = character.HasExpertise_Nature.ToString();
                hasExp_PerceptionAttribute.Value = character.HasExpertise_Perception.ToString();
                hasExp_PerformanceAttribute.Value = character.HasExpertise_Performance.ToString();
                hasExp_PersuasionAttribute.Value = character.HasExpertise_Persuasion.ToString();
                hasExp_ReligionAttribute.Value = character.HasExpertise_Religion.ToString();
                hasExp_SleightOfHandAttribute.Value = character.HasExpertise_Sleight_Of_Hand.ToString();
                hasExp_StealthAttribute.Value = character.HasExpertise_Stealth.ToString();
                hasExp_SurvivalAttribute.Value = character.HasExpertise_Survival.ToString();

                addBonus_InitiativeAttribute.Value = character.AdditionalBonus_Initiative.ToString();
                addBonus_PassiveInsightAttribute.Value = character.AdditionalBonus_PassiveInsight.ToString();
                addBonus_PassiveInvestigationAttribute.Value = character.AdditionalBonus_PassiveInvestigation.ToString();
                addBonus_PassivePerceptionAttribute.Value = character.AdditionalBonus_PassivePerception.ToString();

                addBonus_StrengthSavingThrowAttribute.Value = character.AdditionalBonus_StrengthSavingThrow.ToString();
                addBonus_DexteritySavingThrowAttribute.Value = character.AdditionalBonus_DexteritySavingThrow.ToString();
                addBonus_ConstitutionSavingThrowAttribute.Value = character.AdditionalBonus_ConstitutionSavingThrow.ToString();
                addBonus_IntelligenceSavingThrowAttribute.Value = character.AdditionalBonus_IntelligenceSavingThrow.ToString();
                addBonus_WisdomSavingThrowAttribute.Value = character.AdditionalBonus_WisdomSavingThrow.ToString();
                addBonus_CharismaSavingThrowAttribute.Value = character.AdditionalBonus_CharismaSavingThrow.ToString();

                addBonus_AcrobaticsAttribute.Value = character.AdditionalBonus_Acrobatics.ToString();
                addBonus_AnimalHandlingAttribute.Value = character.AdditionalBonus_Animal_Handling.ToString();
                addBonus_ArcanaAttribute.Value = character.AdditionalBonus_Arcana.ToString();
                addBonus_AthleticsAttribute.Value = character.AdditionalBonus_Athletics.ToString();
                addBonus_DeceptionAttribute.Value = character.AdditionalBonus_Deception.ToString();
                addBonus_HistoryAttribute.Value = character.AdditionalBonus_History.ToString();
                addBonus_InsightAttribute.Value = character.AdditionalBonus_Insight.ToString();
                addBonus_IntimidationAttribute.Value = character.AdditionalBonus_Intimidation.ToString();
                addBonus_InvestigationAttribute.Value = character.AdditionalBonus_Investigation.ToString();
                addBonus_MedicineAttribute.Value = character.AdditionalBonus_Medicine.ToString();
                addBonus_NatureAttribute.Value = character.AdditionalBonus_Nature.ToString();
                addBonus_PerceptionAttribute.Value = character.AdditionalBonus_Perception.ToString();
                addBonus_PerformanceAttribute.Value = character.AdditionalBonus_Performance.ToString();
                addBonus_PersuasionAttribute.Value = character.AdditionalBonus_Performance.ToString();
                addBonus_ReligionAttribute.Value = character.AdditionalBonus_Religion.ToString();
                addBonus_SleightOfHandAttribute.Value = character.AdditionalBonus_Sleight_Of_Hand.ToString();
                addBonus_StealthAttribute.Value = character.AdditionalBonus_Stealth.ToString();
                addBonus_SurvivalAttribute.Value = character.AdditionalBonus_Survival.ToString();

                conditionsAttribute.Value = character.CharacterConditions.ToString();
                trackersAttribute.Value = characterTrackers;

                imagePathAttribute.Value = character.ImagePath.ToString();
                primaryCharacterColorAttribute.Value = character.PrimaryCharacterColor.ToString();
                secondaryCharacterColorAttribute.Value = character.SecondaryCharacterColor.ToString();
                teriaryCharacterColorAttribute.Value = character.TertiaryCharacterColor.ToString();

                characterNode.Attributes.Append(nameAttribute);
                characterNode.Attributes.Append(classAttribute);
                characterNode.Attributes.Append(levelAttribute);
                characterNode.Attributes.Append(maxHitpointsAttribute);
                characterNode.Attributes.Append(currentHitpointsAttribute);
                characterNode.Attributes.Append(armorClassAttribute);
                characterNode.Attributes.Append(strengthAttribute);
                characterNode.Attributes.Append(dexterityAttribute);
                characterNode.Attributes.Append(constitutionAttribute);
                characterNode.Attributes.Append(intelligenceAttribute);
                characterNode.Attributes.Append(wisdomAttribute);
                characterNode.Attributes.Append(charismaAttribute);

                characterNode.Attributes.Append(hasProf_StrengthSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_DexteritySavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_ConstitutionSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_IntelligenceSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_WisdomSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_CharismaSavingThrowAttribute);

                characterNode.Attributes.Append(hasProf_AcrobaticsAttribute);
                characterNode.Attributes.Append(hasProf_AnimalHandlingAttribute);
                characterNode.Attributes.Append(hasProf_ArcanaAttribute);
                characterNode.Attributes.Append(hasProf_AthleticsAttribute);
                characterNode.Attributes.Append(hasProf_DeceptionAttribute);
                characterNode.Attributes.Append(hasProf_HistoryAttribute);
                characterNode.Attributes.Append(hasProf_InsightAttribute);
                characterNode.Attributes.Append(hasProf_IntimidationAttribute);
                characterNode.Attributes.Append(hasProf_InvestigationAttribute);
                characterNode.Attributes.Append(hasProf_MedicineAttribute);
                characterNode.Attributes.Append(hasProf_NatureAttribute);
                characterNode.Attributes.Append(hasProf_PerceptionAttribute);
                characterNode.Attributes.Append(hasProf_PerformanceAttribute);
                characterNode.Attributes.Append(hasProf_PersuasionAttribute);
                characterNode.Attributes.Append(hasProf_ReligionAttribute);
                characterNode.Attributes.Append(hasProf_SleightOfHandAttribute);
                characterNode.Attributes.Append(hasProf_StealthAttribute);
                characterNode.Attributes.Append(hasProf_SurvivalAttribute);

                characterNode.Attributes.Append(hasExp_AcrobaticsAttribute);
                characterNode.Attributes.Append(hasExp_AnimalHandlingAttribute);
                characterNode.Attributes.Append(hasExp_ArcanaAttribute);
                characterNode.Attributes.Append(hasExp_AthleticsAttribute);
                characterNode.Attributes.Append(hasExp_DeceptionAttribute);
                characterNode.Attributes.Append(hasExp_HistoryAttribute);
                characterNode.Attributes.Append(hasExp_InsightAttribute);
                characterNode.Attributes.Append(hasExp_IntimidationAttribute);
                characterNode.Attributes.Append(hasExp_InvestigationAttribute);
                characterNode.Attributes.Append(hasExp_MedicineAttribute);
                characterNode.Attributes.Append(hasExp_NatureAttribute);
                characterNode.Attributes.Append(hasExp_PerceptionAttribute);
                characterNode.Attributes.Append(hasExp_PerformanceAttribute);
                characterNode.Attributes.Append(hasExp_PersuasionAttribute);
                characterNode.Attributes.Append(hasExp_ReligionAttribute);
                characterNode.Attributes.Append(hasExp_SleightOfHandAttribute);
                characterNode.Attributes.Append(hasExp_StealthAttribute);
                characterNode.Attributes.Append(hasExp_SurvivalAttribute);

                characterNode.Attributes.Append(addBonus_InitiativeAttribute);
                characterNode.Attributes.Append(addBonus_PassiveInsightAttribute);
                characterNode.Attributes.Append(addBonus_PassiveInvestigationAttribute);
                characterNode.Attributes.Append(addBonus_PassivePerceptionAttribute);

                characterNode.Attributes.Append(addBonus_StrengthSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_DexteritySavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_ConstitutionSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_IntelligenceSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_WisdomSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_CharismaSavingThrowAttribute);

                characterNode.Attributes.Append(addBonus_AcrobaticsAttribute);
                characterNode.Attributes.Append(addBonus_AnimalHandlingAttribute);
                characterNode.Attributes.Append(addBonus_ArcanaAttribute);
                characterNode.Attributes.Append(addBonus_AthleticsAttribute);
                characterNode.Attributes.Append(addBonus_DeceptionAttribute);
                characterNode.Attributes.Append(addBonus_HistoryAttribute);
                characterNode.Attributes.Append(addBonus_InsightAttribute);
                characterNode.Attributes.Append(addBonus_IntimidationAttribute);
                characterNode.Attributes.Append(addBonus_InvestigationAttribute);
                characterNode.Attributes.Append(addBonus_MedicineAttribute);
                characterNode.Attributes.Append(addBonus_NatureAttribute);
                characterNode.Attributes.Append(addBonus_PerceptionAttribute);
                characterNode.Attributes.Append(addBonus_PerformanceAttribute);
                characterNode.Attributes.Append(addBonus_PersuasionAttribute);
                characterNode.Attributes.Append(addBonus_ReligionAttribute);
                characterNode.Attributes.Append(addBonus_SleightOfHandAttribute);
                characterNode.Attributes.Append(addBonus_StealthAttribute);
                characterNode.Attributes.Append(addBonus_SurvivalAttribute);

                characterNode.Attributes.Append(conditionsAttribute);
                characterNode.Attributes.Append(trackersAttribute);

                characterNode.Attributes.Append(imagePathAttribute);
                characterNode.Attributes.Append(primaryCharacterColorAttribute);
                characterNode.Attributes.Append(secondaryCharacterColorAttribute);
                characterNode.Attributes.Append(teriaryCharacterColorAttribute);

                characterNode.InnerText = character.Name+"\n";

                rootNode.AppendChild(characterNode);
            }

            XmlWriterSettings xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace,
                NewLineOnAttributes = true
            };


            using (XmlWriter writer = XmlWriter.Create(savePath, xmlSettings))
            {
                doc.Save(writer);
            }

            MessageBox.Show("Party Data Saved!","Battle Buddy");
        }

        public void SavePartyToFile(string partyName, ObservableCollection<Character> party, string savePath)
        {

            //string savePath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\TestParty.xml"));

            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Party");
            XmlAttribute partyNameAttribute = doc.CreateAttribute("PartyName");
            partyNameAttribute.Value = partyName;
            rootNode.Attributes.Append(partyNameAttribute);

            doc.AppendChild(rootNode);

            XmlNode characterNode;
            XmlAttribute nameAttribute;
            XmlAttribute classAttribute;
            XmlAttribute levelAttribute;
            XmlAttribute maxHitpointsAttribute;
            XmlAttribute currentHitpointsAttribute;
            XmlAttribute armorClassAttribute;
            XmlAttribute strengthAttribute;
            XmlAttribute dexterityAttribute;
            XmlAttribute constitutionAttribute;
            XmlAttribute intelligenceAttribute;
            XmlAttribute wisdomAttribute;
            XmlAttribute charismaAttribute;

            XmlAttribute hasProf_StrengthSavingThrowAttribute;
            XmlAttribute hasProf_DexteritySavingThrowAttribute;
            XmlAttribute hasProf_ConstitutionSavingThrowAttribute;
            XmlAttribute hasProf_IntelligenceSavingThrowAttribute;
            XmlAttribute hasProf_WisdomSavingThrowAttribute;
            XmlAttribute hasProf_CharismaSavingThrowAttribute;

            XmlAttribute hasProf_AcrobaticsAttribute;
            XmlAttribute hasProf_AnimalHandlingAttribute;
            XmlAttribute hasProf_ArcanaAttribute;
            XmlAttribute hasProf_AthleticsAttribute;
            XmlAttribute hasProf_DeceptionAttribute;
            XmlAttribute hasProf_HistoryAttribute;
            XmlAttribute hasProf_InsightAttribute;
            XmlAttribute hasProf_IntimidationAttribute;
            XmlAttribute hasProf_InvestigationAttribute;
            XmlAttribute hasProf_MedicineAttribute;
            XmlAttribute hasProf_NatureAttribute;
            XmlAttribute hasProf_PerceptionAttribute;
            XmlAttribute hasProf_PerformanceAttribute;
            XmlAttribute hasProf_PersuasionAttribute;
            XmlAttribute hasProf_ReligionAttribute;
            XmlAttribute hasProf_SleightOfHandAttribute;
            XmlAttribute hasProf_StealthAttribute;
            XmlAttribute hasProf_SurvivalAttribute;

            XmlAttribute hasExp_AcrobaticsAttribute;
            XmlAttribute hasExp_AnimalHandlingAttribute;
            XmlAttribute hasExp_ArcanaAttribute;
            XmlAttribute hasExp_AthleticsAttribute;
            XmlAttribute hasExp_DeceptionAttribute;
            XmlAttribute hasExp_HistoryAttribute;
            XmlAttribute hasExp_InsightAttribute;
            XmlAttribute hasExp_IntimidationAttribute;
            XmlAttribute hasExp_InvestigationAttribute;
            XmlAttribute hasExp_MedicineAttribute;
            XmlAttribute hasExp_NatureAttribute;
            XmlAttribute hasExp_PerceptionAttribute;
            XmlAttribute hasExp_PerformanceAttribute;
            XmlAttribute hasExp_PersuasionAttribute;
            XmlAttribute hasExp_ReligionAttribute;
            XmlAttribute hasExp_SleightOfHandAttribute;
            XmlAttribute hasExp_StealthAttribute;
            XmlAttribute hasExp_SurvivalAttribute;

            XmlAttribute addBonus_InitiativeAttribute;
            XmlAttribute addBonus_PassiveInsightAttribute;
            XmlAttribute addBonus_PassiveInvestigationAttribute;
            XmlAttribute addBonus_PassivePerceptionAttribute;

            XmlAttribute addBonus_StrengthSavingThrowAttribute;
            XmlAttribute addBonus_DexteritySavingThrowAttribute;
            XmlAttribute addBonus_ConstitutionSavingThrowAttribute;
            XmlAttribute addBonus_IntelligenceSavingThrowAttribute;
            XmlAttribute addBonus_WisdomSavingThrowAttribute;
            XmlAttribute addBonus_CharismaSavingThrowAttribute;

            XmlAttribute addBonus_AcrobaticsAttribute;
            XmlAttribute addBonus_AnimalHandlingAttribute;
            XmlAttribute addBonus_ArcanaAttribute;
            XmlAttribute addBonus_AthleticsAttribute;
            XmlAttribute addBonus_DeceptionAttribute;
            XmlAttribute addBonus_HistoryAttribute;
            XmlAttribute addBonus_InsightAttribute;
            XmlAttribute addBonus_IntimidationAttribute;
            XmlAttribute addBonus_InvestigationAttribute;
            XmlAttribute addBonus_MedicineAttribute;
            XmlAttribute addBonus_NatureAttribute;
            XmlAttribute addBonus_PerceptionAttribute;
            XmlAttribute addBonus_PerformanceAttribute;
            XmlAttribute addBonus_PersuasionAttribute;
            XmlAttribute addBonus_ReligionAttribute;
            XmlAttribute addBonus_SleightOfHandAttribute;
            XmlAttribute addBonus_StealthAttribute;
            XmlAttribute addBonus_SurvivalAttribute;

            XmlAttribute conditionsAttribute;
            XmlAttribute trackersAttribute;

            XmlAttribute imagePathAttribute;
            XmlAttribute primaryCharacterColorAttribute;
            XmlAttribute secondaryCharacterColorAttribute;
            XmlAttribute teriaryCharacterColorAttribute;

            foreach (Character character in party)
            {
                string characterTrackers = "";
                foreach (CharacterTracker tracker in character.CharacterTrackersList)
                {
                    characterTrackers = characterTrackers + tracker.TrackerName + "/" + tracker.TrackerAvailableUses + "/" + tracker.TrackerMaxUses + ";";
                }

                characterNode = doc.CreateElement("Character");
                nameAttribute = doc.CreateAttribute("Name");
                classAttribute = doc.CreateAttribute("Class");
                levelAttribute = doc.CreateAttribute("Level");
                maxHitpointsAttribute = doc.CreateAttribute("MaxHitpoints");
                currentHitpointsAttribute = doc.CreateAttribute("CurrentHitpoints");
                armorClassAttribute = doc.CreateAttribute("ArmorClass");
                strengthAttribute = doc.CreateAttribute("Strength");
                dexterityAttribute = doc.CreateAttribute("Dexterity");
                constitutionAttribute = doc.CreateAttribute("Constitution");
                intelligenceAttribute = doc.CreateAttribute("Intelligence");
                wisdomAttribute = doc.CreateAttribute("Wisdom");
                charismaAttribute = doc.CreateAttribute("Charisma");

                hasProf_StrengthSavingThrowAttribute = doc.CreateAttribute("hasProf_StrengthSavingThrow");
                hasProf_DexteritySavingThrowAttribute = doc.CreateAttribute("hasProf_DexteritySavingThrow");
                hasProf_ConstitutionSavingThrowAttribute = doc.CreateAttribute("hasProf_ConstitutionSavingThrow");
                hasProf_IntelligenceSavingThrowAttribute = doc.CreateAttribute("hasProf_IntelligenceSavingThrow");
                hasProf_WisdomSavingThrowAttribute = doc.CreateAttribute("hasProf_WisdomSavingThrow");
                hasProf_CharismaSavingThrowAttribute = doc.CreateAttribute("hasProf_CharismaSavingThrow");

                hasProf_AcrobaticsAttribute = doc.CreateAttribute("hasProf_Acrobatics");
                hasProf_AnimalHandlingAttribute = doc.CreateAttribute("hasProf_AnimalHandling");
                hasProf_ArcanaAttribute = doc.CreateAttribute("hasProf_Arcana");
                hasProf_AthleticsAttribute = doc.CreateAttribute("hasProf_Athletics");
                hasProf_DeceptionAttribute = doc.CreateAttribute("hasProf_Deception");
                hasProf_HistoryAttribute = doc.CreateAttribute("hasProf_History");
                hasProf_InsightAttribute = doc.CreateAttribute("hasProf_Insight");
                hasProf_IntimidationAttribute = doc.CreateAttribute("hasProf_Intimidation");
                hasProf_InvestigationAttribute = doc.CreateAttribute("hasProf_Investigation");
                hasProf_MedicineAttribute = doc.CreateAttribute("hasProf_Medicine");
                hasProf_NatureAttribute = doc.CreateAttribute("hasProf_Nature");
                hasProf_PerceptionAttribute = doc.CreateAttribute("hasProf_Perception");
                hasProf_PerformanceAttribute = doc.CreateAttribute("hasProf_Performance");
                hasProf_PersuasionAttribute = doc.CreateAttribute("hasProf_Persuasion");
                hasProf_ReligionAttribute = doc.CreateAttribute("hasProf_Religion");
                hasProf_SleightOfHandAttribute = doc.CreateAttribute("hasProf_SleightOfHand");
                hasProf_StealthAttribute = doc.CreateAttribute("hasProf_Stealth");
                hasProf_SurvivalAttribute = doc.CreateAttribute("hasProf_Survival");

                hasExp_AcrobaticsAttribute = doc.CreateAttribute("hasExp_Acrobatics");
                hasExp_AnimalHandlingAttribute = doc.CreateAttribute("hasExp_AnimalHandling");
                hasExp_ArcanaAttribute = doc.CreateAttribute("hasExp_AnimalHandling");
                hasExp_AthleticsAttribute = doc.CreateAttribute("hasExp_Athletics");
                hasExp_DeceptionAttribute = doc.CreateAttribute("hasExp_Deception");
                hasExp_HistoryAttribute = doc.CreateAttribute("hasExp_History");
                hasExp_InsightAttribute = doc.CreateAttribute("hasExp_Insight");
                hasExp_IntimidationAttribute = doc.CreateAttribute("hasExp_Intimidation");
                hasExp_InvestigationAttribute = doc.CreateAttribute("hasExp_Investigation");
                hasExp_MedicineAttribute = doc.CreateAttribute("hasExp_Medicine");
                hasExp_NatureAttribute = doc.CreateAttribute("hasExp_Nature");
                hasExp_PerceptionAttribute = doc.CreateAttribute("hasExp_Perception");
                hasExp_PerformanceAttribute = doc.CreateAttribute("hasExp_Performance");
                hasExp_PersuasionAttribute = doc.CreateAttribute("hasExp_Persuasion");
                hasExp_ReligionAttribute = doc.CreateAttribute("hasExp_Religion");
                hasExp_SleightOfHandAttribute = doc.CreateAttribute("hasExp_SleightOfHand");
                hasExp_StealthAttribute = doc.CreateAttribute("hasExp_Stealth");
                hasExp_SurvivalAttribute = doc.CreateAttribute("hasExp_Survival");

                addBonus_InitiativeAttribute = doc.CreateAttribute("addBonus_Initiative");
                addBonus_PassiveInsightAttribute = doc.CreateAttribute("addBonus_PassiveInsight");
                addBonus_PassiveInvestigationAttribute = doc.CreateAttribute("addBonus_PassiveInvestigation");
                addBonus_PassivePerceptionAttribute = doc.CreateAttribute("addBonus_PassivePerception");

                addBonus_StrengthSavingThrowAttribute = doc.CreateAttribute("addBonus_StrengthSavingThrow");
                addBonus_DexteritySavingThrowAttribute = doc.CreateAttribute("addBonus_DexteritySavingThrow");
                addBonus_ConstitutionSavingThrowAttribute = doc.CreateAttribute("addBonus_ConstitutionSavingThrow");
                addBonus_IntelligenceSavingThrowAttribute = doc.CreateAttribute("addBonus_IntelligenceSavingThrow");
                addBonus_WisdomSavingThrowAttribute = doc.CreateAttribute("addBonus_WisdomSavingThrow");
                addBonus_CharismaSavingThrowAttribute = doc.CreateAttribute("addBonus_CharismaSavingThrow");

                addBonus_AcrobaticsAttribute = doc.CreateAttribute("addBonus_Acrobatics");
                addBonus_AnimalHandlingAttribute = doc.CreateAttribute("addBonus_AnimalHandling");
                addBonus_ArcanaAttribute = doc.CreateAttribute("addBonus_Arcana");
                addBonus_AthleticsAttribute = doc.CreateAttribute("addBonus_Athletics");
                addBonus_DeceptionAttribute = doc.CreateAttribute("addBonus_Deception");
                addBonus_HistoryAttribute = doc.CreateAttribute("addBonus_History");
                addBonus_InsightAttribute = doc.CreateAttribute("addBonus_Insight");
                addBonus_IntimidationAttribute = doc.CreateAttribute("addBonus_Intimidation");
                addBonus_InvestigationAttribute = doc.CreateAttribute("addBonus_Investigation");
                addBonus_MedicineAttribute = doc.CreateAttribute("addBonus_Medicine");
                addBonus_NatureAttribute = doc.CreateAttribute("addBonus_Nature");
                addBonus_PerceptionAttribute = doc.CreateAttribute("addBonus_Perception");
                addBonus_PerformanceAttribute = doc.CreateAttribute("addBonus_Performance");
                addBonus_PersuasionAttribute = doc.CreateAttribute("addBonus_Persuasion");
                addBonus_ReligionAttribute = doc.CreateAttribute("addBonus_Religion");
                addBonus_SleightOfHandAttribute = doc.CreateAttribute("addBonus_SleightOfHand");
                addBonus_StealthAttribute = doc.CreateAttribute("addBonus_Stealth");
                addBonus_SurvivalAttribute = doc.CreateAttribute("addBonus_Survival");

                conditionsAttribute = doc.CreateAttribute("Conditions");
                trackersAttribute = doc.CreateAttribute("Trackers");

                imagePathAttribute = doc.CreateAttribute("ImagePath");
                primaryCharacterColorAttribute = doc.CreateAttribute("PrimaryCharacterColor");
                secondaryCharacterColorAttribute = doc.CreateAttribute("SecondaryCharacterColor");
                teriaryCharacterColorAttribute = doc.CreateAttribute("TertiaryCharacterColor");

                nameAttribute.Value = character.Name;
                classAttribute.Value = character.Class;
                levelAttribute.Value = character.Level.ToString();
                maxHitpointsAttribute.Value = character.MaxHitpoints.ToString();
                currentHitpointsAttribute.Value = character.CurrentHitpoints.ToString();
                armorClassAttribute.Value = character.ArmorClass.ToString();
                strengthAttribute.Value = character.Strength.ToString();
                dexterityAttribute.Value = character.Dexterity.ToString();
                constitutionAttribute.Value = character.Constitution.ToString();
                intelligenceAttribute.Value = character.Intelligence.ToString();
                wisdomAttribute.Value = character.Wisdom.ToString();
                charismaAttribute.Value = character.Charisma.ToString();

                hasProf_StrengthSavingThrowAttribute.Value = character.HasProficiency_Strength_Save.ToString();
                hasProf_DexteritySavingThrowAttribute.Value = character.HasProficiency_Dexterity_Save.ToString();
                hasProf_ConstitutionSavingThrowAttribute.Value = character.HasProficiency_Constitution_Save.ToString();
                hasProf_IntelligenceSavingThrowAttribute.Value = character.HasProficiency_Intelligence_Save.ToString();
                hasProf_WisdomSavingThrowAttribute.Value = character.HasProficiency_Wisdom_Save.ToString();
                hasProf_CharismaSavingThrowAttribute.Value = character.HasProficiency_Charisma_Save.ToString();

                hasProf_AcrobaticsAttribute.Value = character.HasProficiency_Acrobatics.ToString();
                hasProf_AnimalHandlingAttribute.Value = character.HasProficiency_Animal_Handling.ToString();
                hasProf_ArcanaAttribute.Value = character.HasProficiency_Arcana.ToString();
                hasProf_AthleticsAttribute.Value = character.HasProficiency_Athletics.ToString();
                hasProf_DeceptionAttribute.Value = character.HasProficiency_Deception.ToString();
                hasProf_HistoryAttribute.Value = character.HasProficiency_History.ToString();
                hasProf_InsightAttribute.Value = character.HasProficiency_Insight.ToString();
                hasProf_IntimidationAttribute.Value = character.HasProficiency_Intimidation.ToString();
                hasProf_InvestigationAttribute.Value = character.HasProficiency_Investigation.ToString();
                hasProf_MedicineAttribute.Value = character.HasProficiency_Medicine.ToString();
                hasProf_NatureAttribute.Value = character.HasProficiency_Nature.ToString();
                hasProf_PerceptionAttribute.Value = character.HasProficiency_Perception.ToString();
                hasProf_PerformanceAttribute.Value = character.HasProficiency_Performance.ToString();
                hasProf_PersuasionAttribute.Value = character.HasProficiency_Persuasion.ToString();
                hasProf_ReligionAttribute.Value = character.HasProficiency_Religion.ToString();
                hasProf_SleightOfHandAttribute.Value = character.HasProficiency_Sleight_Of_Hand.ToString();
                hasProf_StealthAttribute.Value = character.HasProficiency_Stealth.ToString();
                hasProf_SurvivalAttribute.Value = character.HasProficiency_Survival.ToString();

                hasExp_AcrobaticsAttribute.Value = character.HasExpertise_Acrobatics.ToString();
                hasExp_AnimalHandlingAttribute.Value = character.HasExpertise_Animal_Handling.ToString();
                hasExp_ArcanaAttribute.Value = character.HasExpertise_Arcana.ToString();
                hasExp_AthleticsAttribute.Value = character.HasExpertise_Athletics.ToString();
                hasExp_DeceptionAttribute.Value = character.HasExpertise_Deception.ToString();
                hasExp_HistoryAttribute.Value = character.HasExpertise_History.ToString();
                hasExp_InsightAttribute.Value = character.HasExpertise_Insight.ToString();
                hasExp_IntimidationAttribute.Value = character.HasExpertise_Intimidation.ToString();
                hasExp_InvestigationAttribute.Value = character.HasExpertise_Investigation.ToString();
                hasExp_MedicineAttribute.Value = character.HasExpertise_Medicine.ToString();
                hasExp_NatureAttribute.Value = character.HasExpertise_Nature.ToString();
                hasExp_PerceptionAttribute.Value = character.HasExpertise_Perception.ToString();
                hasExp_PerformanceAttribute.Value = character.HasExpertise_Performance.ToString();
                hasExp_PersuasionAttribute.Value = character.HasExpertise_Persuasion.ToString();
                hasExp_ReligionAttribute.Value = character.HasExpertise_Religion.ToString();
                hasExp_SleightOfHandAttribute.Value = character.HasExpertise_Sleight_Of_Hand.ToString();
                hasExp_StealthAttribute.Value = character.HasExpertise_Stealth.ToString();
                hasExp_SurvivalAttribute.Value = character.HasExpertise_Survival.ToString();

                addBonus_InitiativeAttribute.Value = character.AdditionalBonus_Initiative.ToString();
                addBonus_PassiveInsightAttribute.Value = character.AdditionalBonus_PassiveInsight.ToString();
                addBonus_PassiveInvestigationAttribute.Value = character.AdditionalBonus_PassiveInvestigation.ToString();
                addBonus_PassivePerceptionAttribute.Value = character.AdditionalBonus_PassivePerception.ToString();

                addBonus_StrengthSavingThrowAttribute.Value = character.AdditionalBonus_StrengthSavingThrow.ToString();
                addBonus_DexteritySavingThrowAttribute.Value = character.AdditionalBonus_DexteritySavingThrow.ToString();
                addBonus_ConstitutionSavingThrowAttribute.Value = character.AdditionalBonus_ConstitutionSavingThrow.ToString();
                addBonus_IntelligenceSavingThrowAttribute.Value = character.AdditionalBonus_IntelligenceSavingThrow.ToString();
                addBonus_WisdomSavingThrowAttribute.Value = character.AdditionalBonus_WisdomSavingThrow.ToString();
                addBonus_CharismaSavingThrowAttribute.Value = character.AdditionalBonus_CharismaSavingThrow.ToString();

                addBonus_AcrobaticsAttribute.Value = character.AdditionalBonus_Acrobatics.ToString();
                addBonus_AnimalHandlingAttribute.Value = character.AdditionalBonus_Animal_Handling.ToString();
                addBonus_ArcanaAttribute.Value = character.AdditionalBonus_Arcana.ToString();
                addBonus_AthleticsAttribute.Value = character.AdditionalBonus_Athletics.ToString();
                addBonus_DeceptionAttribute.Value = character.AdditionalBonus_Deception.ToString();
                addBonus_HistoryAttribute.Value = character.AdditionalBonus_History.ToString();
                addBonus_InsightAttribute.Value = character.AdditionalBonus_Insight.ToString();
                addBonus_IntimidationAttribute.Value = character.AdditionalBonus_Intimidation.ToString();
                addBonus_InvestigationAttribute.Value = character.AdditionalBonus_Investigation.ToString();
                addBonus_MedicineAttribute.Value = character.AdditionalBonus_Medicine.ToString();
                addBonus_NatureAttribute.Value = character.AdditionalBonus_Nature.ToString();
                addBonus_PerceptionAttribute.Value = character.AdditionalBonus_Perception.ToString();
                addBonus_PerformanceAttribute.Value = character.AdditionalBonus_Performance.ToString();
                addBonus_PersuasionAttribute.Value = character.AdditionalBonus_Performance.ToString();
                addBonus_ReligionAttribute.Value = character.AdditionalBonus_Religion.ToString();
                addBonus_SleightOfHandAttribute.Value = character.AdditionalBonus_Sleight_Of_Hand.ToString();
                addBonus_StealthAttribute.Value = character.AdditionalBonus_Stealth.ToString();
                addBonus_SurvivalAttribute.Value = character.AdditionalBonus_Survival.ToString();

                conditionsAttribute.Value = character.CharacterConditions.ToString();
                trackersAttribute.Value = characterTrackers;

                imagePathAttribute.Value = character.ImagePath.ToString();
                primaryCharacterColorAttribute.Value = character.PrimaryCharacterColor.ToString();
                secondaryCharacterColorAttribute.Value = character.SecondaryCharacterColor.ToString();
                teriaryCharacterColorAttribute.Value = character.TertiaryCharacterColor.ToString();

                characterNode.Attributes.Append(nameAttribute);
                characterNode.Attributes.Append(classAttribute);
                characterNode.Attributes.Append(levelAttribute);
                characterNode.Attributes.Append(maxHitpointsAttribute);
                characterNode.Attributes.Append(currentHitpointsAttribute);
                characterNode.Attributes.Append(armorClassAttribute);
                characterNode.Attributes.Append(strengthAttribute);
                characterNode.Attributes.Append(dexterityAttribute);
                characterNode.Attributes.Append(constitutionAttribute);
                characterNode.Attributes.Append(intelligenceAttribute);
                characterNode.Attributes.Append(wisdomAttribute);
                characterNode.Attributes.Append(charismaAttribute);

                characterNode.Attributes.Append(hasProf_StrengthSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_DexteritySavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_ConstitutionSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_IntelligenceSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_WisdomSavingThrowAttribute);
                characterNode.Attributes.Append(hasProf_CharismaSavingThrowAttribute);

                characterNode.Attributes.Append(hasProf_AcrobaticsAttribute);
                characterNode.Attributes.Append(hasProf_AnimalHandlingAttribute);
                characterNode.Attributes.Append(hasProf_ArcanaAttribute);
                characterNode.Attributes.Append(hasProf_AthleticsAttribute);
                characterNode.Attributes.Append(hasProf_DeceptionAttribute);
                characterNode.Attributes.Append(hasProf_HistoryAttribute);
                characterNode.Attributes.Append(hasProf_InsightAttribute);
                characterNode.Attributes.Append(hasProf_IntimidationAttribute);
                characterNode.Attributes.Append(hasProf_InvestigationAttribute);
                characterNode.Attributes.Append(hasProf_MedicineAttribute);
                characterNode.Attributes.Append(hasProf_NatureAttribute);
                characterNode.Attributes.Append(hasProf_PerceptionAttribute);
                characterNode.Attributes.Append(hasProf_PerformanceAttribute);
                characterNode.Attributes.Append(hasProf_PersuasionAttribute);
                characterNode.Attributes.Append(hasProf_ReligionAttribute);
                characterNode.Attributes.Append(hasProf_SleightOfHandAttribute);
                characterNode.Attributes.Append(hasProf_StealthAttribute);
                characterNode.Attributes.Append(hasProf_SurvivalAttribute);

                characterNode.Attributes.Append(hasExp_AcrobaticsAttribute);
                characterNode.Attributes.Append(hasExp_AnimalHandlingAttribute);
                characterNode.Attributes.Append(hasExp_ArcanaAttribute);
                characterNode.Attributes.Append(hasExp_AthleticsAttribute);
                characterNode.Attributes.Append(hasExp_DeceptionAttribute);
                characterNode.Attributes.Append(hasExp_HistoryAttribute);
                characterNode.Attributes.Append(hasExp_InsightAttribute);
                characterNode.Attributes.Append(hasExp_IntimidationAttribute);
                characterNode.Attributes.Append(hasExp_InvestigationAttribute);
                characterNode.Attributes.Append(hasExp_MedicineAttribute);
                characterNode.Attributes.Append(hasExp_NatureAttribute);
                characterNode.Attributes.Append(hasExp_PerceptionAttribute);
                characterNode.Attributes.Append(hasExp_PerformanceAttribute);
                characterNode.Attributes.Append(hasExp_PersuasionAttribute);
                characterNode.Attributes.Append(hasExp_ReligionAttribute);
                characterNode.Attributes.Append(hasExp_SleightOfHandAttribute);
                characterNode.Attributes.Append(hasExp_StealthAttribute);
                characterNode.Attributes.Append(hasExp_SurvivalAttribute);

                characterNode.Attributes.Append(addBonus_InitiativeAttribute);
                characterNode.Attributes.Append(addBonus_PassiveInsightAttribute);
                characterNode.Attributes.Append(addBonus_PassiveInvestigationAttribute);
                characterNode.Attributes.Append(addBonus_PassivePerceptionAttribute);

                characterNode.Attributes.Append(addBonus_StrengthSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_DexteritySavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_ConstitutionSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_IntelligenceSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_WisdomSavingThrowAttribute);
                characterNode.Attributes.Append(addBonus_CharismaSavingThrowAttribute);

                characterNode.Attributes.Append(addBonus_AcrobaticsAttribute);
                characterNode.Attributes.Append(addBonus_AnimalHandlingAttribute);
                characterNode.Attributes.Append(addBonus_ArcanaAttribute);
                characterNode.Attributes.Append(addBonus_AthleticsAttribute);
                characterNode.Attributes.Append(addBonus_DeceptionAttribute);
                characterNode.Attributes.Append(addBonus_HistoryAttribute);
                characterNode.Attributes.Append(addBonus_InsightAttribute);
                characterNode.Attributes.Append(addBonus_IntimidationAttribute);
                characterNode.Attributes.Append(addBonus_InvestigationAttribute);
                characterNode.Attributes.Append(addBonus_MedicineAttribute);
                characterNode.Attributes.Append(addBonus_NatureAttribute);
                characterNode.Attributes.Append(addBonus_PerceptionAttribute);
                characterNode.Attributes.Append(addBonus_PerformanceAttribute);
                characterNode.Attributes.Append(addBonus_PersuasionAttribute);
                characterNode.Attributes.Append(addBonus_ReligionAttribute);
                characterNode.Attributes.Append(addBonus_SleightOfHandAttribute);
                characterNode.Attributes.Append(addBonus_StealthAttribute);
                characterNode.Attributes.Append(addBonus_SurvivalAttribute);

                characterNode.Attributes.Append(conditionsAttribute);
                characterNode.Attributes.Append(trackersAttribute);

                characterNode.Attributes.Append(imagePathAttribute);
                characterNode.Attributes.Append(primaryCharacterColorAttribute);
                characterNode.Attributes.Append(secondaryCharacterColorAttribute);
                characterNode.Attributes.Append(teriaryCharacterColorAttribute);

                characterNode.InnerText = character.Name + "\n";

                rootNode.AppendChild(characterNode);
            }

            XmlWriterSettings xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace,
                NewLineOnAttributes = true
            };


            using (XmlWriter writer = XmlWriter.Create(savePath, xmlSettings))
            {
                doc.Save(writer);
            }

            MessageBox.Show("Party Data Saved!", "Battle Buddy");
        }

        public void LoadPartyFromFile()
        {
            string loadPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\TestParty.xml"));

            if (File.Exists(loadPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(loadPath);

                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Character");
                XmlAttribute partyNameAttribute = root.Attributes["PartyName"];

                XmlAttribute nameAttribute;
                XmlAttribute classAttribute;
                XmlAttribute levelAttribute;
                XmlAttribute maxHitpointsAttribute;
                XmlAttribute currentHitpointsAttribute;
                XmlAttribute armorClassAttribute;
                XmlAttribute strengthAttribute;
                XmlAttribute dexterityAttribute;
                XmlAttribute constitutionAttribute;
                XmlAttribute intelligenceAttribute;
                XmlAttribute wisdomAttribute;
                XmlAttribute charismaAttribute;

                XmlAttribute hasProf_StrengthSavingThrowAttribute;
                XmlAttribute hasProf_DexteritySavingThrowAttribute;
                XmlAttribute hasProf_ConstitutionSavingThrowAttribute;
                XmlAttribute hasProf_IntelligenceSavingThrowAttribute;
                XmlAttribute hasProf_WisdomSavingThrowAttribute;
                XmlAttribute hasProf_CharismaSavingThrowAttribute;

                XmlAttribute hasProf_AcrobaticsAttribute;
                XmlAttribute hasProf_AnimalHandlingAttribute;
                XmlAttribute hasProf_ArcanaAttribute;
                XmlAttribute hasProf_AthleticsAttribute;
                XmlAttribute hasProf_DeceptionAttribute;
                XmlAttribute hasProf_HistoryAttribute;
                XmlAttribute hasProf_InsightAttribute;
                XmlAttribute hasProf_IntimidationAttribute;
                XmlAttribute hasProf_InvestigationAttribute;
                XmlAttribute hasProf_MedicineAttribute;
                XmlAttribute hasProf_NatureAttribute;
                XmlAttribute hasProf_PerceptionAttribute;
                XmlAttribute hasProf_PerformanceAttribute;
                XmlAttribute hasProf_PersuasionAttribute;
                XmlAttribute hasProf_ReligionAttribute;
                XmlAttribute hasProf_SleightOfHandAttribute;
                XmlAttribute hasProf_StealthAttribute;
                XmlAttribute hasProf_SurvivalAttribute;

                XmlAttribute hasExp_AcrobaticsAttribute;
                XmlAttribute hasExp_AnimalHandlingAttribute;
                XmlAttribute hasExp_ArcanaAttribute;
                XmlAttribute hasExp_AthleticsAttribute;
                XmlAttribute hasExp_DeceptionAttribute;
                XmlAttribute hasExp_HistoryAttribute;
                XmlAttribute hasExp_InsightAttribute;
                XmlAttribute hasExp_IntimidationAttribute;
                XmlAttribute hasExp_InvestigationAttribute;
                XmlAttribute hasExp_MedicineAttribute;
                XmlAttribute hasExp_NatureAttribute;
                XmlAttribute hasExp_PerceptionAttribute;
                XmlAttribute hasExp_PerformanceAttribute;
                XmlAttribute hasExp_PersuasionAttribute;
                XmlAttribute hasExp_ReligionAttribute;
                XmlAttribute hasExp_SleightOfHandAttribute;
                XmlAttribute hasExp_StealthAttribute;
                XmlAttribute hasExp_SurvivalAttribute;

                XmlAttribute addBonus_InitiativeAttribute;
                XmlAttribute addBonus_PassiveInsightAttribute;
                XmlAttribute addBonus_PassiveInvestigationAttribute;
                XmlAttribute addBonus_PassivePerceptionAttribute;

                XmlAttribute addBonus_StrengthSavingThrowAttribute;
                XmlAttribute addBonus_DexteritySavingThrowAttribute;
                XmlAttribute addBonus_ConstitutionSavingThrowAttribute;
                XmlAttribute addBonus_IntelligenceSavingThrowAttribute;
                XmlAttribute addBonus_WisdomSavingThrowAttribute;
                XmlAttribute addBonus_CharismaSavingThrowAttribute;

                XmlAttribute addBonus_AcrobaticsAttribute;
                XmlAttribute addBonus_AnimalHandlingAttribute;
                XmlAttribute addBonus_ArcanaAttribute;
                XmlAttribute addBonus_AthleticsAttribute;
                XmlAttribute addBonus_DeceptionAttribute;
                XmlAttribute addBonus_HistoryAttribute;
                XmlAttribute addBonus_InsightAttribute;
                XmlAttribute addBonus_IntimidationAttribute;
                XmlAttribute addBonus_InvestigationAttribute;
                XmlAttribute addBonus_MedicineAttribute;
                XmlAttribute addBonus_NatureAttribute;
                XmlAttribute addBonus_PerceptionAttribute;
                XmlAttribute addBonus_PerformanceAttribute;
                XmlAttribute addBonus_PersuasionAttribute;
                XmlAttribute addBonus_ReligionAttribute;
                XmlAttribute addBonus_SleightOfHandAttribute;
                XmlAttribute addBonus_StealthAttribute;
                XmlAttribute addBonus_SurvivalAttribute;

                XmlAttribute conditionsAttribute;
                XmlAttribute trackersAttribute;

                XmlAttribute imagePathAttribute;
                XmlAttribute primaryCharacterColorAttribute;
                XmlAttribute secondaryCharacterColorAttribute;
                XmlAttribute teriaryCharacterColorAttribute;

                if (partyNameAttribute != null) { PartyName = partyNameAttribute.Value; }
                Character tempCharacter;

                foreach (XmlNode node in nodes)
                {
                    nameAttribute = node.Attributes["Name"];
                    classAttribute = node.Attributes["Class"];
                    levelAttribute = node.Attributes["Level"];
                    maxHitpointsAttribute = node.Attributes["MaxHitpoints"];
                    currentHitpointsAttribute = node.Attributes["CurrentHitpoints"];
                    armorClassAttribute = node.Attributes["ArmorClass"];
                    strengthAttribute = node.Attributes["Strength"];
                    dexterityAttribute = node.Attributes["Dexterity"];
                    constitutionAttribute = node.Attributes["Constitution"];
                    intelligenceAttribute = node.Attributes["Intelligence"];
                    wisdomAttribute = node.Attributes["Wisdom"];
                    charismaAttribute = node.Attributes["Charisma"];

                    hasProf_StrengthSavingThrowAttribute = node.Attributes["hasProf_StrengthSavingThrow"];
                    hasProf_DexteritySavingThrowAttribute = node.Attributes["hasProf_DexteritySavingThrow"];
                    hasProf_ConstitutionSavingThrowAttribute = node.Attributes["hasProf_ConstitutionSavingThrow"];
                    hasProf_IntelligenceSavingThrowAttribute = node.Attributes["hasProf_IntelligenceSavingThrow"];
                    hasProf_WisdomSavingThrowAttribute = node.Attributes["hasProf_WisdomSavingThrow"];
                    hasProf_CharismaSavingThrowAttribute = node.Attributes["hasProf_CharismaSavingThrow"];

                    hasProf_AcrobaticsAttribute = node.Attributes["hasProf_Acrobatics"];
                    hasProf_AnimalHandlingAttribute = node.Attributes["hasProf_AnimalHandling"];
                    hasProf_ArcanaAttribute = node.Attributes["hasProf_Arcana"];
                    hasProf_AthleticsAttribute = node.Attributes["hasProf_Athletics"];
                    hasProf_DeceptionAttribute = node.Attributes["hasProf_Deception"];
                    hasProf_HistoryAttribute = node.Attributes["hasProf_History"];
                    hasProf_InsightAttribute = node.Attributes["hasProf_Insight"];
                    hasProf_IntimidationAttribute = node.Attributes["hasProf_Intimidation"];
                    hasProf_InvestigationAttribute = node.Attributes["hasProf_Investigation"];
                    hasProf_MedicineAttribute = node.Attributes["hasProf_Medicine"];
                    hasProf_NatureAttribute = node.Attributes["hasProf_Nature"];
                    hasProf_PerceptionAttribute = node.Attributes["hasProf_Perception"];
                    hasProf_PerformanceAttribute = node.Attributes["hasProf_Performance"];
                    hasProf_PersuasionAttribute = node.Attributes["hasProf_Persuasion"];
                    hasProf_ReligionAttribute = node.Attributes["hasProf_Religion"];
                    hasProf_SleightOfHandAttribute = node.Attributes["hasProf_SleightOfHand"];
                    hasProf_StealthAttribute = node.Attributes["hasProf_Stealth"];
                    hasProf_SurvivalAttribute = node.Attributes["hasProf_Survival"];

                    hasExp_AcrobaticsAttribute = node.Attributes["hasExp_Acrobatics"];
                    hasExp_AnimalHandlingAttribute = node.Attributes["hasExp_AnimalHandling"];
                    hasExp_ArcanaAttribute = node.Attributes["hasExp_AnimalHandling"];
                    hasExp_AthleticsAttribute = node.Attributes["hasExp_Athletics"];
                    hasExp_DeceptionAttribute = node.Attributes["hasExp_Deception"];
                    hasExp_HistoryAttribute = node.Attributes["hasExp_History"];
                    hasExp_InsightAttribute = node.Attributes["hasExp_Insight"];
                    hasExp_IntimidationAttribute = node.Attributes["hasExp_Intimidation"];
                    hasExp_InvestigationAttribute = node.Attributes["hasExp_Investigation"];
                    hasExp_MedicineAttribute = node.Attributes["hasExp_Medicine"];
                    hasExp_NatureAttribute = node.Attributes["hasExp_Nature"];
                    hasExp_PerceptionAttribute = node.Attributes["hasExp_Perception"];
                    hasExp_PerformanceAttribute = node.Attributes["hasExp_Performance"];
                    hasExp_PersuasionAttribute = node.Attributes["hasExp_Persuasion"];
                    hasExp_ReligionAttribute = node.Attributes["hasExp_Religion"];
                    hasExp_SleightOfHandAttribute = node.Attributes["hasExp_SleightOfHand"];
                    hasExp_StealthAttribute = node.Attributes["hasExp_Stealth"];
                    hasExp_SurvivalAttribute = node.Attributes["hasExp_Survival"];

                    addBonus_InitiativeAttribute = node.Attributes["addBonus_Initiative"];
                    addBonus_PassiveInsightAttribute = node.Attributes["addBonus_PassiveInsight"];
                    addBonus_PassiveInvestigationAttribute = node.Attributes["addBonus_PassiveInvestigation"];
                    addBonus_PassivePerceptionAttribute = node.Attributes["addBonus_PassivePerception"];

                    addBonus_StrengthSavingThrowAttribute = node.Attributes["addBonus_StrengthSavingThrow"];
                    addBonus_DexteritySavingThrowAttribute = node.Attributes["addBonus_DexteritySavingThrow"];
                    addBonus_ConstitutionSavingThrowAttribute = node.Attributes["addBonus_ConstitutionSavingThrow"];
                    addBonus_IntelligenceSavingThrowAttribute = node.Attributes["addBonus_IntelligenceSavingThrow"];
                    addBonus_WisdomSavingThrowAttribute = node.Attributes["addBonus_WisdomSavingThrow"];
                    addBonus_CharismaSavingThrowAttribute = node.Attributes["addBonus_CharismaSavingThrow"];

                    addBonus_AcrobaticsAttribute = node.Attributes["addBonus_Acrobatics"];
                    addBonus_AnimalHandlingAttribute = node.Attributes["addBonus_AnimalHandling"];
                    addBonus_ArcanaAttribute = node.Attributes["addBonus_Arcana"];
                    addBonus_AthleticsAttribute = node.Attributes["addBonus_Athletics"];
                    addBonus_DeceptionAttribute = node.Attributes["addBonus_Deception"];
                    addBonus_HistoryAttribute = node.Attributes["addBonus_History"];
                    addBonus_InsightAttribute = node.Attributes["addBonus_Insight"];
                    addBonus_IntimidationAttribute = node.Attributes["addBonus_Intimidation"];
                    addBonus_InvestigationAttribute = node.Attributes["addBonus_Investigation"];
                    addBonus_MedicineAttribute = node.Attributes["addBonus_Medicine"];
                    addBonus_NatureAttribute = node.Attributes["addBonus_Nature"];
                    addBonus_PerceptionAttribute = node.Attributes["addBonus_Perception"];
                    addBonus_PerformanceAttribute = node.Attributes["addBonus_Performance"];
                    addBonus_PersuasionAttribute = node.Attributes["addBonus_Persuasion"];
                    addBonus_ReligionAttribute = node.Attributes["addBonus_Religion"];
                    addBonus_SleightOfHandAttribute = node.Attributes["addBonus_SleightOfHand"];
                    addBonus_StealthAttribute = node.Attributes["addBonus_Stealth"];
                    addBonus_SurvivalAttribute = node.Attributes["addBonus_Survival"];

                    conditionsAttribute = node.Attributes["Conditions"];
                    trackersAttribute = node.Attributes["Trackers"];

                    imagePathAttribute = node.Attributes["ImagePath"];
                    primaryCharacterColorAttribute = node.Attributes["PrimaryCharacterColor"];
                    secondaryCharacterColorAttribute = node.Attributes["SecondaryCharacterColor"];
                    teriaryCharacterColorAttribute = node.Attributes["TertiaryCharacterColor"];

                    tempCharacter = setCharacterTemplate();
                    if (nameAttribute != null) { tempCharacter.Name = nameAttribute.Value; }
                    if (classAttribute != null) { tempCharacter.Class = classAttribute.Value; }
                    if (levelAttribute != null) { tempCharacter.Level = Int32.Parse(levelAttribute.Value); }
                    if (maxHitpointsAttribute != null) { tempCharacter.MaxHitpoints = Int32.Parse(maxHitpointsAttribute.Value); }
                    if (currentHitpointsAttribute != null) { tempCharacter.CurrentHitpoints = Int32.Parse(currentHitpointsAttribute.Value); }
                    if (armorClassAttribute != null) { tempCharacter.ArmorClass = Int32.Parse(armorClassAttribute.Value); }
                    if (strengthAttribute != null) { tempCharacter.Strength = Int32.Parse(strengthAttribute.Value); }
                    if (dexterityAttribute != null) { tempCharacter.Dexterity = Int32.Parse(dexterityAttribute.Value); }
                    if (constitutionAttribute != null) { tempCharacter.Constitution = Int32.Parse(constitutionAttribute.Value); }
                    if (intelligenceAttribute != null) { tempCharacter.Intelligence = Int32.Parse(intelligenceAttribute.Value); }
                    if (wisdomAttribute != null) { tempCharacter.Wisdom = Int32.Parse(wisdomAttribute.Value); }
                    if (charismaAttribute != null) { tempCharacter.Charisma = Int32.Parse(charismaAttribute.Value); }

                    if (hasProf_StrengthSavingThrowAttribute != null) { tempCharacter.HasProficiency_Strength_Save = XmlConvert.ToBoolean(hasProf_StrengthSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_DexteritySavingThrowAttribute != null) { tempCharacter.HasProficiency_Dexterity_Save = XmlConvert.ToBoolean(hasProf_DexteritySavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_ConstitutionSavingThrowAttribute != null) { tempCharacter.HasProficiency_Constitution_Save = XmlConvert.ToBoolean(hasProf_ConstitutionSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_IntelligenceSavingThrowAttribute != null) { tempCharacter.HasProficiency_Intelligence_Save = XmlConvert.ToBoolean(hasProf_IntelligenceSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_WisdomSavingThrowAttribute != null) { tempCharacter.HasProficiency_Wisdom_Save = XmlConvert.ToBoolean(hasProf_WisdomSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_CharismaSavingThrowAttribute != null) { tempCharacter.HasProficiency_Charisma_Save = XmlConvert.ToBoolean(hasProf_CharismaSavingThrowAttribute.Value.ToLower()); }

                    if (hasProf_AcrobaticsAttribute != null) { tempCharacter.HasProficiency_Acrobatics = XmlConvert.ToBoolean(hasProf_AcrobaticsAttribute.Value.ToLower()); }
                    if (hasProf_AnimalHandlingAttribute != null) { tempCharacter.HasProficiency_Animal_Handling = XmlConvert.ToBoolean(hasProf_AnimalHandlingAttribute.Value.ToLower()); }
                    if (hasProf_ArcanaAttribute != null) { tempCharacter.HasProficiency_Arcana = XmlConvert.ToBoolean(hasProf_ArcanaAttribute.Value.ToLower()); }
                    if (hasProf_AthleticsAttribute != null) { tempCharacter.HasProficiency_Athletics = XmlConvert.ToBoolean(hasProf_AthleticsAttribute.Value.ToLower()); }
                    if (hasProf_DeceptionAttribute != null) { tempCharacter.HasProficiency_Deception = XmlConvert.ToBoolean(hasProf_DeceptionAttribute.Value.ToLower()); }
                    if (hasProf_HistoryAttribute != null) { tempCharacter.HasProficiency_History = XmlConvert.ToBoolean(hasProf_HistoryAttribute.Value.ToLower()); }
                    if (hasProf_InsightAttribute != null) { tempCharacter.HasProficiency_Insight = XmlConvert.ToBoolean(hasProf_InsightAttribute.Value.ToLower()); }
                    if (hasProf_IntimidationAttribute != null) { tempCharacter.HasProficiency_Intimidation = XmlConvert.ToBoolean(hasProf_IntimidationAttribute.Value.ToLower()); }
                    if (hasProf_InvestigationAttribute != null) { tempCharacter.HasProficiency_Investigation = XmlConvert.ToBoolean(hasProf_InvestigationAttribute.Value.ToLower()); }
                    if (hasProf_MedicineAttribute != null) { tempCharacter.HasProficiency_Medicine = XmlConvert.ToBoolean(hasProf_MedicineAttribute.Value.ToLower()); }
                    if (hasProf_NatureAttribute != null) { tempCharacter.HasProficiency_Nature = XmlConvert.ToBoolean(hasProf_NatureAttribute.Value.ToLower()); }
                    if (hasProf_PerceptionAttribute != null) { tempCharacter.HasProficiency_Perception = XmlConvert.ToBoolean(hasProf_PerceptionAttribute.Value.ToLower()); }
                    if (hasProf_PerformanceAttribute != null) { tempCharacter.HasProficiency_Performance = XmlConvert.ToBoolean(hasProf_PerformanceAttribute.Value.ToLower()); }
                    if (hasProf_PersuasionAttribute != null) { tempCharacter.HasProficiency_Persuasion = XmlConvert.ToBoolean(hasProf_PersuasionAttribute.Value.ToLower()); }
                    if (hasProf_ReligionAttribute != null) { tempCharacter.HasProficiency_Religion = XmlConvert.ToBoolean(hasProf_ReligionAttribute.Value.ToLower()); }
                    if (hasProf_SleightOfHandAttribute != null) { tempCharacter.HasProficiency_Sleight_Of_Hand = XmlConvert.ToBoolean(hasProf_SleightOfHandAttribute.Value.ToLower()); }
                    if (hasProf_StealthAttribute != null) { tempCharacter.HasProficiency_Stealth = XmlConvert.ToBoolean(hasProf_StealthAttribute.Value.ToLower()); }
                    if (hasProf_SurvivalAttribute != null) { tempCharacter.HasProficiency_Survival = XmlConvert.ToBoolean(hasProf_SurvivalAttribute.Value.ToLower()); }

                    if (hasExp_AcrobaticsAttribute != null) { tempCharacter.HasExpertise_Acrobatics = XmlConvert.ToBoolean(hasExp_AcrobaticsAttribute.Value.ToLower()); }
                    if (hasExp_AnimalHandlingAttribute != null) { tempCharacter.HasExpertise_Animal_Handling = XmlConvert.ToBoolean(hasExp_AnimalHandlingAttribute.Value.ToLower()); }
                    if (hasExp_ArcanaAttribute != null) { tempCharacter.HasExpertise_Arcana = XmlConvert.ToBoolean(hasExp_ArcanaAttribute.Value.ToLower()); }
                    if (hasExp_AthleticsAttribute != null) { tempCharacter.HasExpertise_Athletics = XmlConvert.ToBoolean(hasExp_AthleticsAttribute.Value.ToLower()); }
                    if (hasExp_DeceptionAttribute != null) { tempCharacter.HasExpertise_Deception = XmlConvert.ToBoolean(hasExp_DeceptionAttribute.Value.ToLower()); }
                    if (hasExp_HistoryAttribute != null) { tempCharacter.HasExpertise_History = XmlConvert.ToBoolean(hasExp_HistoryAttribute.Value.ToLower()); }
                    if (hasExp_InsightAttribute != null) { tempCharacter.HasExpertise_Insight = XmlConvert.ToBoolean(hasExp_InsightAttribute.Value.ToLower()); }
                    if (hasExp_IntimidationAttribute != null) { tempCharacter.HasExpertise_Intimidation = XmlConvert.ToBoolean(hasExp_IntimidationAttribute.Value.ToLower()); }
                    if (hasExp_InvestigationAttribute != null) { tempCharacter.HasExpertise_Investigation = XmlConvert.ToBoolean(hasExp_InvestigationAttribute.Value.ToLower()); }
                    if (hasExp_MedicineAttribute != null) { tempCharacter.HasExpertise_Medicine = XmlConvert.ToBoolean(hasExp_MedicineAttribute.Value.ToLower()); }
                    if (hasExp_NatureAttribute != null) { tempCharacter.HasExpertise_Nature = XmlConvert.ToBoolean(hasExp_NatureAttribute.Value.ToLower()); }
                    if (hasExp_PerceptionAttribute != null) { tempCharacter.HasExpertise_Perception = XmlConvert.ToBoolean(hasExp_PerceptionAttribute.Value.ToLower()); }
                    if (hasExp_PerformanceAttribute != null) { tempCharacter.HasExpertise_Performance = XmlConvert.ToBoolean(hasExp_PerformanceAttribute.Value.ToLower()); }
                    if (hasExp_PersuasionAttribute != null) { tempCharacter.HasExpertise_Persuasion = XmlConvert.ToBoolean(hasExp_PersuasionAttribute.Value.ToLower()); }
                    if (hasExp_ReligionAttribute != null) { tempCharacter.HasExpertise_Religion = XmlConvert.ToBoolean(hasExp_ReligionAttribute.Value.ToLower()); }
                    if (hasExp_SleightOfHandAttribute != null) { tempCharacter.HasExpertise_Sleight_Of_Hand = XmlConvert.ToBoolean(hasExp_SleightOfHandAttribute.Value.ToLower()); }
                    if (hasExp_StealthAttribute != null) { tempCharacter.HasExpertise_Stealth = XmlConvert.ToBoolean(hasExp_StealthAttribute.Value.ToLower()); }
                    if (hasExp_SurvivalAttribute != null) { tempCharacter.HasExpertise_Survival = XmlConvert.ToBoolean(hasExp_SurvivalAttribute.Value.ToLower()); }

                    if (addBonus_InitiativeAttribute != null) { tempCharacter.AdditionalBonus_Initiative = Int32.Parse(addBonus_InitiativeAttribute.Value); }
                    if (addBonus_PassiveInsightAttribute != null) { tempCharacter.AdditionalBonus_PassiveInsight = Int32.Parse(addBonus_PassiveInsightAttribute.Value); }
                    if (addBonus_PassiveInvestigationAttribute != null) { tempCharacter.AdditionalBonus_PassiveInvestigation = Int32.Parse(addBonus_PassiveInvestigationAttribute.Value); }
                    if (addBonus_PassivePerceptionAttribute != null) { tempCharacter.AdditionalBonus_PassivePerception = Int32.Parse(addBonus_PassivePerceptionAttribute.Value); }

                    if (addBonus_StrengthSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_StrengthSavingThrow = Int32.Parse(addBonus_StrengthSavingThrowAttribute.Value); }
                    if (addBonus_DexteritySavingThrowAttribute != null) { tempCharacter.AdditionalBonus_DexteritySavingThrow = Int32.Parse(addBonus_DexteritySavingThrowAttribute.Value); }
                    if (addBonus_ConstitutionSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_ConstitutionSavingThrow = Int32.Parse(addBonus_ConstitutionSavingThrowAttribute.Value); }
                    if (addBonus_IntelligenceSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_IntelligenceSavingThrow = Int32.Parse(addBonus_IntelligenceSavingThrowAttribute.Value); }
                    if (addBonus_WisdomSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_WisdomSavingThrow = Int32.Parse(addBonus_WisdomSavingThrowAttribute.Value); }
                    if (addBonus_CharismaSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_CharismaSavingThrow = Int32.Parse(addBonus_CharismaSavingThrowAttribute.Value); }

                    if (addBonus_AcrobaticsAttribute != null) { tempCharacter.AdditionalBonus_Acrobatics = Int32.Parse(addBonus_AcrobaticsAttribute.Value); }
                    if (addBonus_AnimalHandlingAttribute != null) { tempCharacter.AdditionalBonus_Animal_Handling = Int32.Parse(addBonus_AnimalHandlingAttribute.Value); }
                    if (addBonus_ArcanaAttribute != null) { tempCharacter.AdditionalBonus_Arcana = Int32.Parse(addBonus_ArcanaAttribute.Value); }
                    if (addBonus_AthleticsAttribute != null) { tempCharacter.AdditionalBonus_Athletics = Int32.Parse(addBonus_AthleticsAttribute.Value); }
                    if (addBonus_DeceptionAttribute != null) { tempCharacter.AdditionalBonus_Deception = Int32.Parse(addBonus_DeceptionAttribute.Value); }
                    if (addBonus_HistoryAttribute != null) { tempCharacter.AdditionalBonus_History = Int32.Parse(addBonus_HistoryAttribute.Value); }
                    if (addBonus_InsightAttribute != null) { tempCharacter.AdditionalBonus_Insight = Int32.Parse(addBonus_InsightAttribute.Value); }
                    if (addBonus_IntimidationAttribute != null) { tempCharacter.AdditionalBonus_Intimidation = Int32.Parse(addBonus_IntimidationAttribute.Value); }
                    if (addBonus_InvestigationAttribute != null) { tempCharacter.AdditionalBonus_Investigation = Int32.Parse(addBonus_InvestigationAttribute.Value); }
                    if (addBonus_MedicineAttribute != null) { tempCharacter.AdditionalBonus_Medicine = Int32.Parse(addBonus_MedicineAttribute.Value); }
                    if (addBonus_NatureAttribute != null) { tempCharacter.AdditionalBonus_Nature = Int32.Parse(addBonus_NatureAttribute.Value); }
                    if (addBonus_PerceptionAttribute != null) { tempCharacter.AdditionalBonus_Perception = Int32.Parse(addBonus_PerceptionAttribute.Value); }
                    if (addBonus_PerformanceAttribute != null) { tempCharacter.AdditionalBonus_Performance = Int32.Parse(addBonus_PerformanceAttribute.Value); }
                    if (addBonus_PersuasionAttribute != null) { tempCharacter.AdditionalBonus_Persuasion = Int32.Parse(addBonus_PersuasionAttribute.Value); }
                    if (addBonus_ReligionAttribute != null) { tempCharacter.AdditionalBonus_Religion = Int32.Parse(addBonus_ReligionAttribute.Value); }
                    if (addBonus_SleightOfHandAttribute != null) { tempCharacter.AdditionalBonus_Sleight_Of_Hand = Int32.Parse(addBonus_SleightOfHandAttribute.Value); }
                    if (addBonus_StealthAttribute != null) { tempCharacter.AdditionalBonus_Stealth = Int32.Parse(addBonus_StealthAttribute.Value); }
                    if (addBonus_SurvivalAttribute != null) { tempCharacter.AdditionalBonus_Survival = Int32.Parse(addBonus_SurvivalAttribute.Value); }

                    if (conditionsAttribute != null) { tempCharacter.CharacterConditions = conditionsAttribute.Value; }
                    if (trackersAttribute != null) { tempCharacter.CharacterTrackers = trackersAttribute.Value; }

                    if (imagePathAttribute != null) { tempCharacter.ImagePath = imagePathAttribute.Value; }
                    if (primaryCharacterColorAttribute != null) { tempCharacter.PrimaryCharacterColor = (Color)ColorConverter.ConvertFromString(primaryCharacterColorAttribute.Value); }
                    if (secondaryCharacterColorAttribute != null) { tempCharacter.SecondaryCharacterColor = (Color)ColorConverter.ConvertFromString(secondaryCharacterColorAttribute.Value); }
                    if (teriaryCharacterColorAttribute != null) { tempCharacter.TertiaryCharacterColor = (Color)ColorConverter.ConvertFromString(teriaryCharacterColorAttribute.Value); }

                    CharacterCollection.Add(tempCharacter);
                }
            }
            else
            {
                //Throw error message saying file cant be found
            }
            

            
        }

        public void LoadPartyFromFile(string loadPath)
        {
            //string loadPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\TestParty.xml"));

            if (File.Exists(loadPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(loadPath);

                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Character");
                XmlAttribute partyNameAttribute = root.Attributes["PartyName"];

                XmlAttribute nameAttribute;
                XmlAttribute classAttribute;
                XmlAttribute levelAttribute;
                XmlAttribute maxHitpointsAttribute;
                XmlAttribute currentHitpointsAttribute;
                XmlAttribute armorClassAttribute;
                XmlAttribute strengthAttribute;
                XmlAttribute dexterityAttribute;
                XmlAttribute constitutionAttribute;
                XmlAttribute intelligenceAttribute;
                XmlAttribute wisdomAttribute;
                XmlAttribute charismaAttribute;

                XmlAttribute hasProf_StrengthSavingThrowAttribute;
                XmlAttribute hasProf_DexteritySavingThrowAttribute;
                XmlAttribute hasProf_ConstitutionSavingThrowAttribute;
                XmlAttribute hasProf_IntelligenceSavingThrowAttribute;
                XmlAttribute hasProf_WisdomSavingThrowAttribute;
                XmlAttribute hasProf_CharismaSavingThrowAttribute;

                XmlAttribute hasProf_AcrobaticsAttribute;
                XmlAttribute hasProf_AnimalHandlingAttribute;
                XmlAttribute hasProf_ArcanaAttribute;
                XmlAttribute hasProf_AthleticsAttribute;
                XmlAttribute hasProf_DeceptionAttribute;
                XmlAttribute hasProf_HistoryAttribute;
                XmlAttribute hasProf_InsightAttribute;
                XmlAttribute hasProf_IntimidationAttribute;
                XmlAttribute hasProf_InvestigationAttribute;
                XmlAttribute hasProf_MedicineAttribute;
                XmlAttribute hasProf_NatureAttribute;
                XmlAttribute hasProf_PerceptionAttribute;
                XmlAttribute hasProf_PerformanceAttribute;
                XmlAttribute hasProf_PersuasionAttribute;
                XmlAttribute hasProf_ReligionAttribute;
                XmlAttribute hasProf_SleightOfHandAttribute;
                XmlAttribute hasProf_StealthAttribute;
                XmlAttribute hasProf_SurvivalAttribute;

                XmlAttribute hasExp_AcrobaticsAttribute;
                XmlAttribute hasExp_AnimalHandlingAttribute;
                XmlAttribute hasExp_ArcanaAttribute;
                XmlAttribute hasExp_AthleticsAttribute;
                XmlAttribute hasExp_DeceptionAttribute;
                XmlAttribute hasExp_HistoryAttribute;
                XmlAttribute hasExp_InsightAttribute;
                XmlAttribute hasExp_IntimidationAttribute;
                XmlAttribute hasExp_InvestigationAttribute;
                XmlAttribute hasExp_MedicineAttribute;
                XmlAttribute hasExp_NatureAttribute;
                XmlAttribute hasExp_PerceptionAttribute;
                XmlAttribute hasExp_PerformanceAttribute;
                XmlAttribute hasExp_PersuasionAttribute;
                XmlAttribute hasExp_ReligionAttribute;
                XmlAttribute hasExp_SleightOfHandAttribute;
                XmlAttribute hasExp_StealthAttribute;
                XmlAttribute hasExp_SurvivalAttribute;

                XmlAttribute addBonus_InitiativeAttribute;
                XmlAttribute addBonus_PassiveInsightAttribute;
                XmlAttribute addBonus_PassiveInvestigationAttribute;
                XmlAttribute addBonus_PassivePerceptionAttribute;

                XmlAttribute addBonus_StrengthSavingThrowAttribute;
                XmlAttribute addBonus_DexteritySavingThrowAttribute;
                XmlAttribute addBonus_ConstitutionSavingThrowAttribute;
                XmlAttribute addBonus_IntelligenceSavingThrowAttribute;
                XmlAttribute addBonus_WisdomSavingThrowAttribute;
                XmlAttribute addBonus_CharismaSavingThrowAttribute;

                XmlAttribute addBonus_AcrobaticsAttribute;
                XmlAttribute addBonus_AnimalHandlingAttribute;
                XmlAttribute addBonus_ArcanaAttribute;
                XmlAttribute addBonus_AthleticsAttribute;
                XmlAttribute addBonus_DeceptionAttribute;
                XmlAttribute addBonus_HistoryAttribute;
                XmlAttribute addBonus_InsightAttribute;
                XmlAttribute addBonus_IntimidationAttribute;
                XmlAttribute addBonus_InvestigationAttribute;
                XmlAttribute addBonus_MedicineAttribute;
                XmlAttribute addBonus_NatureAttribute;
                XmlAttribute addBonus_PerceptionAttribute;
                XmlAttribute addBonus_PerformanceAttribute;
                XmlAttribute addBonus_PersuasionAttribute;
                XmlAttribute addBonus_ReligionAttribute;
                XmlAttribute addBonus_SleightOfHandAttribute;
                XmlAttribute addBonus_StealthAttribute;
                XmlAttribute addBonus_SurvivalAttribute;

                XmlAttribute conditionsAttribute;
                XmlAttribute trackersAttribute;

                XmlAttribute imagePathAttribute;
                XmlAttribute primaryCharacterColorAttribute;
                XmlAttribute secondaryCharacterColorAttribute;
                XmlAttribute teriaryCharacterColorAttribute;

                if (partyNameAttribute != null) { PartyName = partyNameAttribute.Value; }
                Character tempCharacter;

                foreach (XmlNode node in nodes)
                {
                    nameAttribute = node.Attributes["Name"];
                    classAttribute = node.Attributes["Class"];
                    levelAttribute = node.Attributes["Level"];
                    maxHitpointsAttribute = node.Attributes["MaxHitpoints"];
                    currentHitpointsAttribute = node.Attributes["CurrentHitpoints"];
                    armorClassAttribute = node.Attributes["ArmorClass"];
                    strengthAttribute = node.Attributes["Strength"];
                    dexterityAttribute = node.Attributes["Dexterity"];
                    constitutionAttribute = node.Attributes["Constitution"];
                    intelligenceAttribute = node.Attributes["Intelligence"];
                    wisdomAttribute = node.Attributes["Wisdom"];
                    charismaAttribute = node.Attributes["Charisma"];

                    hasProf_StrengthSavingThrowAttribute = node.Attributes["hasProf_StrengthSavingThrow"];
                    hasProf_DexteritySavingThrowAttribute = node.Attributes["hasProf_DexteritySavingThrow"];
                    hasProf_ConstitutionSavingThrowAttribute = node.Attributes["hasProf_ConstitutionSavingThrow"];
                    hasProf_IntelligenceSavingThrowAttribute = node.Attributes["hasProf_IntelligenceSavingThrow"];
                    hasProf_WisdomSavingThrowAttribute = node.Attributes["hasProf_WisdomSavingThrow"];
                    hasProf_CharismaSavingThrowAttribute = node.Attributes["hasProf_CharismaSavingThrow"];

                    hasProf_AcrobaticsAttribute = node.Attributes["hasProf_Acrobatics"];
                    hasProf_AnimalHandlingAttribute = node.Attributes["hasProf_AnimalHandling"];
                    hasProf_ArcanaAttribute = node.Attributes["hasProf_Arcana"];
                    hasProf_AthleticsAttribute = node.Attributes["hasProf_Athletics"];
                    hasProf_DeceptionAttribute = node.Attributes["hasProf_Deception"];
                    hasProf_HistoryAttribute = node.Attributes["hasProf_History"];
                    hasProf_InsightAttribute = node.Attributes["hasProf_Insight"];
                    hasProf_IntimidationAttribute = node.Attributes["hasProf_Intimidation"];
                    hasProf_InvestigationAttribute = node.Attributes["hasProf_Investigation"];
                    hasProf_MedicineAttribute = node.Attributes["hasProf_Medicine"];
                    hasProf_NatureAttribute = node.Attributes["hasProf_Nature"];
                    hasProf_PerceptionAttribute = node.Attributes["hasProf_Perception"];
                    hasProf_PerformanceAttribute = node.Attributes["hasProf_Performance"];
                    hasProf_PersuasionAttribute = node.Attributes["hasProf_Persuasion"];
                    hasProf_ReligionAttribute = node.Attributes["hasProf_Religion"];
                    hasProf_SleightOfHandAttribute = node.Attributes["hasProf_SleightOfHand"];
                    hasProf_StealthAttribute = node.Attributes["hasProf_Stealth"];
                    hasProf_SurvivalAttribute = node.Attributes["hasProf_Survival"];

                    hasExp_AcrobaticsAttribute = node.Attributes["hasExp_Acrobatics"];
                    hasExp_AnimalHandlingAttribute = node.Attributes["hasExp_AnimalHandling"];
                    hasExp_ArcanaAttribute = node.Attributes["hasExp_AnimalHandling"];
                    hasExp_AthleticsAttribute = node.Attributes["hasExp_Athletics"];
                    hasExp_DeceptionAttribute = node.Attributes["hasExp_Deception"];
                    hasExp_HistoryAttribute = node.Attributes["hasExp_History"];
                    hasExp_InsightAttribute = node.Attributes["hasExp_Insight"];
                    hasExp_IntimidationAttribute = node.Attributes["hasExp_Intimidation"];
                    hasExp_InvestigationAttribute = node.Attributes["hasExp_Investigation"];
                    hasExp_MedicineAttribute = node.Attributes["hasExp_Medicine"];
                    hasExp_NatureAttribute = node.Attributes["hasExp_Nature"];
                    hasExp_PerceptionAttribute = node.Attributes["hasExp_Perception"];
                    hasExp_PerformanceAttribute = node.Attributes["hasExp_Performance"];
                    hasExp_PersuasionAttribute = node.Attributes["hasExp_Persuasion"];
                    hasExp_ReligionAttribute = node.Attributes["hasExp_Religion"];
                    hasExp_SleightOfHandAttribute = node.Attributes["hasExp_SleightOfHand"];
                    hasExp_StealthAttribute = node.Attributes["hasExp_Stealth"];
                    hasExp_SurvivalAttribute = node.Attributes["hasExp_Survival"];

                    addBonus_InitiativeAttribute = node.Attributes["addBonus_Initiative"];
                    addBonus_PassiveInsightAttribute = node.Attributes["addBonus_PassiveInsight"];
                    addBonus_PassiveInvestigationAttribute = node.Attributes["addBonus_PassiveInvestigation"];
                    addBonus_PassivePerceptionAttribute = node.Attributes["addBonus_PassivePerception"];

                    addBonus_StrengthSavingThrowAttribute = node.Attributes["addBonus_StrengthSavingThrow"];
                    addBonus_DexteritySavingThrowAttribute = node.Attributes["addBonus_DexteritySavingThrow"];
                    addBonus_ConstitutionSavingThrowAttribute = node.Attributes["addBonus_ConstitutionSavingThrow"];
                    addBonus_IntelligenceSavingThrowAttribute = node.Attributes["addBonus_IntelligenceSavingThrow"];
                    addBonus_WisdomSavingThrowAttribute = node.Attributes["addBonus_WisdomSavingThrow"];
                    addBonus_CharismaSavingThrowAttribute = node.Attributes["addBonus_CharismaSavingThrow"];

                    addBonus_AcrobaticsAttribute = node.Attributes["addBonus_Acrobatics"];
                    addBonus_AnimalHandlingAttribute = node.Attributes["addBonus_AnimalHandling"];
                    addBonus_ArcanaAttribute = node.Attributes["addBonus_Arcana"];
                    addBonus_AthleticsAttribute = node.Attributes["addBonus_Athletics"];
                    addBonus_DeceptionAttribute = node.Attributes["addBonus_Deception"];
                    addBonus_HistoryAttribute = node.Attributes["addBonus_History"];
                    addBonus_InsightAttribute = node.Attributes["addBonus_Insight"];
                    addBonus_IntimidationAttribute = node.Attributes["addBonus_Intimidation"];
                    addBonus_InvestigationAttribute = node.Attributes["addBonus_Investigation"];
                    addBonus_MedicineAttribute = node.Attributes["addBonus_Medicine"];
                    addBonus_NatureAttribute = node.Attributes["addBonus_Nature"];
                    addBonus_PerceptionAttribute = node.Attributes["addBonus_Perception"];
                    addBonus_PerformanceAttribute = node.Attributes["addBonus_Performance"];
                    addBonus_PersuasionAttribute = node.Attributes["addBonus_Persuasion"];
                    addBonus_ReligionAttribute = node.Attributes["addBonus_Religion"];
                    addBonus_SleightOfHandAttribute = node.Attributes["addBonus_SleightOfHand"];
                    addBonus_StealthAttribute = node.Attributes["addBonus_Stealth"];
                    addBonus_SurvivalAttribute = node.Attributes["addBonus_Survival"];

                    conditionsAttribute = node.Attributes["Conditons"];
                    trackersAttribute = node.Attributes["Trackers"];

                    imagePathAttribute = node.Attributes["ImagePath"];
                    primaryCharacterColorAttribute = node.Attributes["PrimaryCharacterColor"];
                    secondaryCharacterColorAttribute = node.Attributes["SecondaryCharacterColor"];
                    teriaryCharacterColorAttribute = node.Attributes["TertiaryCharacterColor"];

                    tempCharacter = setCharacterTemplate();
                    if (nameAttribute != null) { tempCharacter.Name = nameAttribute.Value; }
                    if (classAttribute != null) { tempCharacter.Class = classAttribute.Value; }
                    if (levelAttribute != null) { tempCharacter.Level = Int32.Parse(levelAttribute.Value); }
                    if (maxHitpointsAttribute != null) { tempCharacter.MaxHitpoints = Int32.Parse(maxHitpointsAttribute.Value); }
                    if (currentHitpointsAttribute != null) { tempCharacter.CurrentHitpoints = Int32.Parse(currentHitpointsAttribute.Value); }
                    if (armorClassAttribute != null) { tempCharacter.ArmorClass = Int32.Parse(armorClassAttribute.Value); }
                    if (strengthAttribute != null) { tempCharacter.Strength = Int32.Parse(strengthAttribute.Value); }
                    if (dexterityAttribute != null) { tempCharacter.Dexterity = Int32.Parse(dexterityAttribute.Value); }
                    if (constitutionAttribute != null) { tempCharacter.Constitution = Int32.Parse(constitutionAttribute.Value); }
                    if (intelligenceAttribute != null) { tempCharacter.Intelligence = Int32.Parse(intelligenceAttribute.Value); }
                    if (wisdomAttribute != null) { tempCharacter.Wisdom = Int32.Parse(wisdomAttribute.Value); }
                    if (charismaAttribute != null) { tempCharacter.Charisma = Int32.Parse(charismaAttribute.Value); }

                    if (hasProf_StrengthSavingThrowAttribute != null) { tempCharacter.HasProficiency_Strength_Save = XmlConvert.ToBoolean(hasProf_StrengthSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_DexteritySavingThrowAttribute != null) { tempCharacter.HasProficiency_Dexterity_Save = XmlConvert.ToBoolean(hasProf_DexteritySavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_ConstitutionSavingThrowAttribute != null) { tempCharacter.HasProficiency_Constitution_Save = XmlConvert.ToBoolean(hasProf_ConstitutionSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_IntelligenceSavingThrowAttribute != null) { tempCharacter.HasProficiency_Intelligence_Save = XmlConvert.ToBoolean(hasProf_IntelligenceSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_WisdomSavingThrowAttribute != null) { tempCharacter.HasProficiency_Wisdom_Save = XmlConvert.ToBoolean(hasProf_WisdomSavingThrowAttribute.Value.ToLower()); }
                    if (hasProf_CharismaSavingThrowAttribute != null) { tempCharacter.HasProficiency_Charisma_Save = XmlConvert.ToBoolean(hasProf_CharismaSavingThrowAttribute.Value.ToLower()); }

                    if (hasProf_AcrobaticsAttribute != null) { tempCharacter.HasProficiency_Acrobatics = XmlConvert.ToBoolean(hasProf_AcrobaticsAttribute.Value.ToLower()); }
                    if (hasProf_AnimalHandlingAttribute != null) { tempCharacter.HasProficiency_Animal_Handling = XmlConvert.ToBoolean(hasProf_AnimalHandlingAttribute.Value.ToLower()); }
                    if (hasProf_ArcanaAttribute != null) { tempCharacter.HasProficiency_Arcana = XmlConvert.ToBoolean(hasProf_ArcanaAttribute.Value.ToLower()); }
                    if (hasProf_AthleticsAttribute != null) { tempCharacter.HasProficiency_Athletics = XmlConvert.ToBoolean(hasProf_AthleticsAttribute.Value.ToLower()); }
                    if (hasProf_DeceptionAttribute != null) { tempCharacter.HasProficiency_Deception = XmlConvert.ToBoolean(hasProf_DeceptionAttribute.Value.ToLower()); }
                    if (hasProf_HistoryAttribute != null) { tempCharacter.HasProficiency_History = XmlConvert.ToBoolean(hasProf_HistoryAttribute.Value.ToLower()); }
                    if (hasProf_InsightAttribute != null) { tempCharacter.HasProficiency_Insight = XmlConvert.ToBoolean(hasProf_InsightAttribute.Value.ToLower()); }
                    if (hasProf_IntimidationAttribute != null) { tempCharacter.HasProficiency_Intimidation = XmlConvert.ToBoolean(hasProf_IntimidationAttribute.Value.ToLower()); }
                    if (hasProf_InvestigationAttribute != null) { tempCharacter.HasProficiency_Investigation = XmlConvert.ToBoolean(hasProf_InvestigationAttribute.Value.ToLower()); }
                    if (hasProf_MedicineAttribute != null) { tempCharacter.HasProficiency_Medicine = XmlConvert.ToBoolean(hasProf_MedicineAttribute.Value.ToLower()); }
                    if (hasProf_NatureAttribute != null) { tempCharacter.HasProficiency_Nature = XmlConvert.ToBoolean(hasProf_NatureAttribute.Value.ToLower()); }
                    if (hasProf_PerceptionAttribute != null) { tempCharacter.HasProficiency_Perception = XmlConvert.ToBoolean(hasProf_PerceptionAttribute.Value.ToLower()); }
                    if (hasProf_PerformanceAttribute != null) { tempCharacter.HasProficiency_Performance = XmlConvert.ToBoolean(hasProf_PerformanceAttribute.Value.ToLower()); }
                    if (hasProf_PersuasionAttribute != null) { tempCharacter.HasProficiency_Persuasion = XmlConvert.ToBoolean(hasProf_PersuasionAttribute.Value.ToLower()); }
                    if (hasProf_ReligionAttribute != null) { tempCharacter.HasProficiency_Religion = XmlConvert.ToBoolean(hasProf_ReligionAttribute.Value.ToLower()); }
                    if (hasProf_SleightOfHandAttribute != null) { tempCharacter.HasProficiency_Sleight_Of_Hand = XmlConvert.ToBoolean(hasProf_SleightOfHandAttribute.Value.ToLower()); }
                    if (hasProf_StealthAttribute != null) { tempCharacter.HasProficiency_Stealth = XmlConvert.ToBoolean(hasProf_StealthAttribute.Value.ToLower()); }
                    if (hasProf_SurvivalAttribute != null) { tempCharacter.HasProficiency_Survival = XmlConvert.ToBoolean(hasProf_SurvivalAttribute.Value.ToLower()); }

                    if (hasExp_AcrobaticsAttribute != null) { tempCharacter.HasExpertise_Acrobatics = XmlConvert.ToBoolean(hasExp_AcrobaticsAttribute.Value.ToLower()); }
                    if (hasExp_AnimalHandlingAttribute != null) { tempCharacter.HasExpertise_Animal_Handling = XmlConvert.ToBoolean(hasExp_AnimalHandlingAttribute.Value.ToLower()); }
                    if (hasExp_ArcanaAttribute != null) { tempCharacter.HasExpertise_Arcana = XmlConvert.ToBoolean(hasExp_ArcanaAttribute.Value.ToLower()); }
                    if (hasExp_AthleticsAttribute != null) { tempCharacter.HasExpertise_Athletics = XmlConvert.ToBoolean(hasExp_AthleticsAttribute.Value.ToLower()); }
                    if (hasExp_DeceptionAttribute != null) { tempCharacter.HasExpertise_Deception = XmlConvert.ToBoolean(hasExp_DeceptionAttribute.Value.ToLower()); }
                    if (hasExp_HistoryAttribute != null) { tempCharacter.HasExpertise_History = XmlConvert.ToBoolean(hasExp_HistoryAttribute.Value.ToLower()); }
                    if (hasExp_InsightAttribute != null) { tempCharacter.HasExpertise_Insight = XmlConvert.ToBoolean(hasExp_InsightAttribute.Value.ToLower()); }
                    if (hasExp_IntimidationAttribute != null) { tempCharacter.HasExpertise_Intimidation = XmlConvert.ToBoolean(hasExp_IntimidationAttribute.Value.ToLower()); }
                    if (hasExp_InvestigationAttribute != null) { tempCharacter.HasExpertise_Investigation = XmlConvert.ToBoolean(hasExp_InvestigationAttribute.Value.ToLower()); }
                    if (hasExp_MedicineAttribute != null) { tempCharacter.HasExpertise_Medicine = XmlConvert.ToBoolean(hasExp_MedicineAttribute.Value.ToLower()); }
                    if (hasExp_NatureAttribute != null) { tempCharacter.HasExpertise_Nature = XmlConvert.ToBoolean(hasExp_NatureAttribute.Value.ToLower()); }
                    if (hasExp_PerceptionAttribute != null) { tempCharacter.HasExpertise_Perception = XmlConvert.ToBoolean(hasExp_PerceptionAttribute.Value.ToLower()); }
                    if (hasExp_PerformanceAttribute != null) { tempCharacter.HasExpertise_Performance = XmlConvert.ToBoolean(hasExp_PerformanceAttribute.Value.ToLower()); }
                    if (hasExp_PersuasionAttribute != null) { tempCharacter.HasExpertise_Persuasion = XmlConvert.ToBoolean(hasExp_PersuasionAttribute.Value.ToLower()); }
                    if (hasExp_ReligionAttribute != null) { tempCharacter.HasExpertise_Religion = XmlConvert.ToBoolean(hasExp_ReligionAttribute.Value.ToLower()); }
                    if (hasExp_SleightOfHandAttribute != null) { tempCharacter.HasExpertise_Sleight_Of_Hand = XmlConvert.ToBoolean(hasExp_SleightOfHandAttribute.Value.ToLower()); }
                    if (hasExp_StealthAttribute != null) { tempCharacter.HasExpertise_Stealth = XmlConvert.ToBoolean(hasExp_StealthAttribute.Value.ToLower()); }
                    if (hasExp_SurvivalAttribute != null) { tempCharacter.HasExpertise_Survival = XmlConvert.ToBoolean(hasExp_SurvivalAttribute.Value.ToLower()); }

                    if (addBonus_InitiativeAttribute != null) { tempCharacter.AdditionalBonus_Initiative = Int32.Parse(addBonus_InitiativeAttribute.Value); }
                    if (addBonus_PassiveInsightAttribute != null) { tempCharacter.AdditionalBonus_PassiveInsight = Int32.Parse(addBonus_PassiveInsightAttribute.Value); }
                    if (addBonus_PassiveInvestigationAttribute != null) { tempCharacter.AdditionalBonus_PassiveInvestigation = Int32.Parse(addBonus_PassiveInvestigationAttribute.Value); }
                    if (addBonus_PassivePerceptionAttribute != null) { tempCharacter.AdditionalBonus_PassivePerception = Int32.Parse(addBonus_PassivePerceptionAttribute.Value); }

                    if (addBonus_StrengthSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_StrengthSavingThrow = Int32.Parse(addBonus_StrengthSavingThrowAttribute.Value); }
                    if (addBonus_DexteritySavingThrowAttribute != null) { tempCharacter.AdditionalBonus_DexteritySavingThrow = Int32.Parse(addBonus_DexteritySavingThrowAttribute.Value); }
                    if (addBonus_ConstitutionSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_ConstitutionSavingThrow = Int32.Parse(addBonus_ConstitutionSavingThrowAttribute.Value); }
                    if (addBonus_IntelligenceSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_IntelligenceSavingThrow = Int32.Parse(addBonus_IntelligenceSavingThrowAttribute.Value); }
                    if (addBonus_WisdomSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_WisdomSavingThrow = Int32.Parse(addBonus_WisdomSavingThrowAttribute.Value); }
                    if (addBonus_CharismaSavingThrowAttribute != null) { tempCharacter.AdditionalBonus_CharismaSavingThrow = Int32.Parse(addBonus_CharismaSavingThrowAttribute.Value); }

                    if (addBonus_AcrobaticsAttribute != null) { tempCharacter.AdditionalBonus_Acrobatics = Int32.Parse(addBonus_AcrobaticsAttribute.Value); }
                    if (addBonus_AnimalHandlingAttribute != null) { tempCharacter.AdditionalBonus_Animal_Handling = Int32.Parse(addBonus_AnimalHandlingAttribute.Value); }
                    if (addBonus_ArcanaAttribute != null) { tempCharacter.AdditionalBonus_Arcana = Int32.Parse(addBonus_ArcanaAttribute.Value); }
                    if (addBonus_AthleticsAttribute != null) { tempCharacter.AdditionalBonus_Athletics = Int32.Parse(addBonus_AthleticsAttribute.Value); }
                    if (addBonus_DeceptionAttribute != null) { tempCharacter.AdditionalBonus_Deception = Int32.Parse(addBonus_DeceptionAttribute.Value); }
                    if (addBonus_HistoryAttribute != null) { tempCharacter.AdditionalBonus_History = Int32.Parse(addBonus_HistoryAttribute.Value); }
                    if (addBonus_InsightAttribute != null) { tempCharacter.AdditionalBonus_Insight = Int32.Parse(addBonus_InsightAttribute.Value); }
                    if (addBonus_IntimidationAttribute != null) { tempCharacter.AdditionalBonus_Intimidation = Int32.Parse(addBonus_IntimidationAttribute.Value); }
                    if (addBonus_InvestigationAttribute != null) { tempCharacter.AdditionalBonus_Investigation = Int32.Parse(addBonus_InvestigationAttribute.Value); }
                    if (addBonus_MedicineAttribute != null) { tempCharacter.AdditionalBonus_Medicine = Int32.Parse(addBonus_MedicineAttribute.Value); }
                    if (addBonus_NatureAttribute != null) { tempCharacter.AdditionalBonus_Nature = Int32.Parse(addBonus_NatureAttribute.Value); }
                    if (addBonus_PerceptionAttribute != null) { tempCharacter.AdditionalBonus_Perception = Int32.Parse(addBonus_PerceptionAttribute.Value); }
                    if (addBonus_PerformanceAttribute != null) { tempCharacter.AdditionalBonus_Performance = Int32.Parse(addBonus_PerformanceAttribute.Value); }
                    if (addBonus_PersuasionAttribute != null) { tempCharacter.AdditionalBonus_Persuasion = Int32.Parse(addBonus_PersuasionAttribute.Value); }
                    if (addBonus_ReligionAttribute != null) { tempCharacter.AdditionalBonus_Religion = Int32.Parse(addBonus_ReligionAttribute.Value); }
                    if (addBonus_SleightOfHandAttribute != null) { tempCharacter.AdditionalBonus_Sleight_Of_Hand = Int32.Parse(addBonus_SleightOfHandAttribute.Value); }
                    if (addBonus_StealthAttribute != null) { tempCharacter.AdditionalBonus_Stealth = Int32.Parse(addBonus_StealthAttribute.Value); }
                    if (addBonus_SurvivalAttribute != null) { tempCharacter.AdditionalBonus_Survival = Int32.Parse(addBonus_SurvivalAttribute.Value); }

                    if (conditionsAttribute != null) { tempCharacter.CharacterConditions = conditionsAttribute.Value; }
                    if (trackersAttribute != null) { tempCharacter.CharacterTrackers = trackersAttribute.Value; }

                    if (imagePathAttribute != null) { tempCharacter.ImagePath = imagePathAttribute.Value; }
                    if (primaryCharacterColorAttribute != null) { tempCharacter.PrimaryCharacterColor = (Color)ColorConverter.ConvertFromString(primaryCharacterColorAttribute.Value); }
                    if (secondaryCharacterColorAttribute != null) { tempCharacter.SecondaryCharacterColor = (Color)ColorConverter.ConvertFromString(secondaryCharacterColorAttribute.Value); }
                    if (teriaryCharacterColorAttribute != null) { tempCharacter.TertiaryCharacterColor = (Color)ColorConverter.ConvertFromString(teriaryCharacterColorAttribute.Value); }

                    CharacterCollection.Add(tempCharacter);
                }
            }
            else
            {
                //Throw error message saying file cant be found
            }



        }


        public void LoadUserSettingsFromFile()
        {
            string loadPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\UserSettings.xml"));

            if (File.Exists(loadPath))
            {
                UserSettings tempSettings = new UserSettings();

                XmlDocument doc = new XmlDocument();
                doc.Load(loadPath);

                XmlElement root = doc.DocumentElement;
                
                XmlAttribute defaultPartyFilePathAttribute = root.Attributes["DefaultPartyFilePath"];
                XmlAttribute BackgroundImageFilePathAttribute = root.Attributes["BackgroundImageFilePath"];
                XmlAttribute UseBackgroundImageAttribute = root.Attributes["UseBackgroundImage"];
                XmlAttribute ApplicationThemeAttribute = root.Attributes["ApplicationTheme"];
                XmlAttribute UseCharacterUniqueColorsInDetailViewAttribute = root.Attributes["UseCharacterUniqueColorsInDetailView"];
                XmlAttribute UseCharacterUniqueColorsInSummaryViewAttribute = root.Attributes["UseCharacterUniqueColorsInSummaryView"];

                XmlAttribute Custom_TitleColorAttribute = root.Attributes["Custom_TitleColor"];
                XmlAttribute Custom_BackgroundColorAttribute = root.Attributes["Custom_BackgroundColor"];
                XmlAttribute Custom_BorderColorAttribute = root.Attributes["Custom_BorderColor"];
                XmlAttribute Custom_ButtonColorAttribute = root.Attributes["Custom_ButtonColor"];
                XmlAttribute Custom_ButtonHoverColorAttribute = root.Attributes["Custom_ButtonHoverColor"];
                XmlAttribute Custom_IconColorAttribute = root.Attributes["Custom_IconColor"];
                XmlAttribute Custom_IconHoverColorAttribute = root.Attributes["Custom_IconHoverColor"];
                XmlAttribute Custom_DefaultCharacterColor1Attribute = root.Attributes["Custom_DefaultCharacterColor1"];
                XmlAttribute Custom_DefaultCharacterColor2Attribute = root.Attributes["Custom_DefaultCharacterColor2"];
                XmlAttribute Custom_DefaultCharacterColor3Attribute = root.Attributes["Custom_DefaultCharacterColor3"];

                XmlAttribute InTouchScreenModeAttribute = root.Attributes["InTouchScreenMode"];
                XmlAttribute InHexModeCharacterListAttribute = root.Attributes["InHexModeCharacterList"];

                if (defaultPartyFilePathAttribute != null) { tempSettings.DefaultPartyFilePath = defaultPartyFilePathAttribute.Value; }
                if (BackgroundImageFilePathAttribute != null) { tempSettings.BackgroundImageFilePath = BackgroundImageFilePathAttribute.Value; }
                if (UseBackgroundImageAttribute != null) { tempSettings.UseBackgroundImage = Convert.ToBoolean(UseBackgroundImageAttribute.Value); }
                if (ApplicationThemeAttribute != null) { tempSettings.ApplicationTheme = Int32.Parse(ApplicationThemeAttribute.Value); }
                if (UseCharacterUniqueColorsInDetailViewAttribute != null) { tempSettings.UseCharacterUniqueColorsInDetailView = Convert.ToBoolean(UseCharacterUniqueColorsInDetailViewAttribute.Value); }
                if (UseCharacterUniqueColorsInSummaryViewAttribute != null) { tempSettings.UseCharacterUniqueColorsInSummaryView = Convert.ToBoolean(UseCharacterUniqueColorsInSummaryViewAttribute.Value); }

                if (Custom_TitleColorAttribute != null) { tempSettings.Custom_TitleColor = (Color)ColorConverter.ConvertFromString(Custom_TitleColorAttribute.Value); }
                if (Custom_BackgroundColorAttribute != null) { tempSettings.Custom_BackgroundColor = (Color)ColorConverter.ConvertFromString(Custom_BackgroundColorAttribute.Value); }
                if (Custom_BorderColorAttribute != null) { tempSettings.Custom_BorderColor = (Color)ColorConverter.ConvertFromString(Custom_BorderColorAttribute.Value); }
                if (Custom_ButtonColorAttribute != null) { tempSettings.Custom_ButtonColor = (Color)ColorConverter.ConvertFromString(Custom_ButtonColorAttribute.Value); }
                if (Custom_ButtonHoverColorAttribute != null) { tempSettings.Custom_ButtonHoverColor = (Color)ColorConverter.ConvertFromString(Custom_ButtonHoverColorAttribute.Value); }
                if (Custom_IconColorAttribute != null) { tempSettings.Custom_IconColor = (Color)ColorConverter.ConvertFromString(Custom_IconColorAttribute.Value); }
                if (Custom_IconHoverColorAttribute != null) { tempSettings.Custom_IconHoverColor = (Color)ColorConverter.ConvertFromString(Custom_IconHoverColorAttribute.Value); }
                if (Custom_DefaultCharacterColor1Attribute != null) { tempSettings.Custom_DefaultCharacterColor1 = (Color)ColorConverter.ConvertFromString(Custom_DefaultCharacterColor1Attribute.Value); }
                if (Custom_DefaultCharacterColor2Attribute != null) { tempSettings.Custom_DefaultCharacterColor2 = (Color)ColorConverter.ConvertFromString(Custom_DefaultCharacterColor2Attribute.Value); }
                if (Custom_DefaultCharacterColor3Attribute != null) { tempSettings.Custom_DefaultCharacterColor3 = (Color)ColorConverter.ConvertFromString(Custom_DefaultCharacterColor3Attribute.Value); }

                if (InTouchScreenModeAttribute != null) { tempSettings.InTouchScreenMode = Convert.ToBoolean(InTouchScreenModeAttribute.Value); }
                if (InHexModeCharacterListAttribute != null) { tempSettings.InHexModeCharacterList = Convert.ToBoolean(InHexModeCharacterListAttribute.Value); }

                XmlNodeList conditionNodes = root.SelectNodes("Condition");
                foreach (XmlNode node in conditionNodes)
                {
                    ConditionCollection.Add(new CharacterCondition()
                    {
                        ConditionName = node["ConditionName"].InnerText,
                        ConditionDescription = node["ConditionDescription"].InnerText
                    });
                }
                
                XmlStoredUserSettings = tempSettings;
            }
            else
            {
                //Throw error message saying file cant be found
            }
        }

        public void SaveUserSettingsToFile(UserSettings newSettings, ObservableCollection<CharacterCondition> conditionCollection)
        {
            string savePath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\XML\UserSettings.xml"));

            //delete this line later:
            //XmlStoredUserSettings = temporaryDefaultSettings();

            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Settings");

            XmlAttribute defaultPartyFilePathAttribute = doc.CreateAttribute("DefaultPartyFilePath");
            XmlAttribute BackgroundImageFilePathAttribute = doc.CreateAttribute("BackgroundImageFilePath");
            XmlAttribute UseBackgroundImageAttribute = doc.CreateAttribute("UseBackgroundImage");
            XmlAttribute ApplicationThemeAttribute = doc.CreateAttribute("ApplicationTheme");
            XmlAttribute UseCharacterUniqueColorsInDetailViewAttribute = doc.CreateAttribute("UseCharacterUniqueColorsInDetailView");
            XmlAttribute UseCharacterUniqueColorsInSummaryViewAttribute = doc.CreateAttribute("UseCharacterUniqueColorsInSummaryView");

            XmlAttribute Custom_TitleColorAttribute = doc.CreateAttribute("Custom_TitleColor");
            XmlAttribute Custom_BackgroundColorAttribute = doc.CreateAttribute("Custom_BackgroundColor");
            XmlAttribute Custom_BorderColorAttribute = doc.CreateAttribute("Custom_BorderColor");
            XmlAttribute Custom_ButtonColorAttribute = doc.CreateAttribute("Custom_ButtonColor");
            XmlAttribute Custom_ButtonHoverColorAttribute = doc.CreateAttribute("Custom_ButtonHoverColor");
            XmlAttribute Custom_IconColorAttribute = doc.CreateAttribute("Custom_IconColor");
            XmlAttribute Custom_IconHoverColorAttribute = doc.CreateAttribute("Custom_IconHoverColor");
            XmlAttribute Custom_DefaultCharacterColor1Attribute = doc.CreateAttribute("Custom_DefaultCharacterColor1");
            XmlAttribute Custom_DefaultCharacterColor2Attribute = doc.CreateAttribute("Custom_DefaultCharacterColor2");
            XmlAttribute Custom_DefaultCharacterColor3Attribute = doc.CreateAttribute("Custom_DefaultCharacterColor3");

            XmlAttribute InTouchScreenModeAttribute = doc.CreateAttribute("InTouchScreenMode");
            XmlAttribute InHexModeCharacterListAttribute = doc.CreateAttribute("InHexModeCharacterList");

            if (newSettings.DefaultPartyFilePath != null) 
                { defaultPartyFilePathAttribute.Value = newSettings.DefaultPartyFilePath; }
            
            if (newSettings.BackgroundImageFilePath != null) 
                { BackgroundImageFilePathAttribute.Value = newSettings.BackgroundImageFilePath; }
            
            if (newSettings.UseBackgroundImage.ToString() != null)
                { UseBackgroundImageAttribute.Value = newSettings.UseBackgroundImage.ToString(); }
            
            if (newSettings.ApplicationTheme.ToString() != null)
                { ApplicationThemeAttribute.Value = newSettings.ApplicationTheme.ToString(); }
            
            if (newSettings.UseCharacterUniqueColorsInDetailView.ToString() != null)
                { UseCharacterUniqueColorsInDetailViewAttribute.Value = newSettings.UseCharacterUniqueColorsInDetailView.ToString(); }
            
            if (newSettings.UseCharacterUniqueColorsInSummaryView.ToString() != null)
                { UseCharacterUniqueColorsInSummaryViewAttribute.Value = newSettings.UseCharacterUniqueColorsInSummaryView.ToString(); }

            if (newSettings.Custom_TitleColor.ToString() != null) { Custom_TitleColorAttribute.Value = newSettings.Custom_TitleColor.ToString(); }
            if (newSettings.Custom_BackgroundColor.ToString() != null) { Custom_BackgroundColorAttribute.Value = newSettings.Custom_BackgroundColor.ToString(); }
            if (newSettings.Custom_BorderColor.ToString() != null) { Custom_BorderColorAttribute.Value = newSettings.Custom_BorderColor.ToString(); }
            if (newSettings.Custom_ButtonColor.ToString() != null) { Custom_ButtonColorAttribute.Value = newSettings.Custom_ButtonColor.ToString(); }
            if (newSettings.Custom_ButtonHoverColor.ToString() != null) { Custom_ButtonHoverColorAttribute.Value = newSettings.Custom_ButtonHoverColor.ToString(); }
            if (newSettings.Custom_IconColor.ToString() != null) { Custom_IconColorAttribute.Value = newSettings.Custom_IconColor.ToString(); }
            if (newSettings.Custom_IconHoverColor.ToString() != null) { Custom_IconHoverColorAttribute.Value = newSettings.Custom_IconHoverColor.ToString(); }
            if (newSettings.Custom_DefaultCharacterColor1.ToString() != null) { Custom_DefaultCharacterColor1Attribute.Value = newSettings.Custom_DefaultCharacterColor1.ToString(); }
            if (newSettings.Custom_DefaultCharacterColor2.ToString() != null) { Custom_DefaultCharacterColor2Attribute.Value = newSettings.Custom_DefaultCharacterColor2.ToString(); }
            if (newSettings.Custom_DefaultCharacterColor3.ToString() != null) { Custom_DefaultCharacterColor3Attribute.Value = newSettings.Custom_DefaultCharacterColor3.ToString(); }

            if (newSettings.InTouchScreenMode.ToString() != null)
                { InTouchScreenModeAttribute.Value = newSettings.InTouchScreenMode.ToString(); }
            
            if (newSettings.InHexModeCharacterList.ToString() != null)
                { InHexModeCharacterListAttribute.Value = newSettings.InHexModeCharacterList.ToString(); }
            

            rootNode.Attributes.Append(defaultPartyFilePathAttribute);
            rootNode.Attributes.Append(BackgroundImageFilePathAttribute);
            rootNode.Attributes.Append(UseBackgroundImageAttribute);
            rootNode.Attributes.Append(ApplicationThemeAttribute);
            rootNode.Attributes.Append(UseCharacterUniqueColorsInDetailViewAttribute);
            rootNode.Attributes.Append(UseCharacterUniqueColorsInSummaryViewAttribute);

            rootNode.Attributes.Append(Custom_TitleColorAttribute);
            rootNode.Attributes.Append(Custom_BackgroundColorAttribute);
            rootNode.Attributes.Append(Custom_BorderColorAttribute);
            rootNode.Attributes.Append(Custom_ButtonColorAttribute);
            rootNode.Attributes.Append(Custom_ButtonHoverColorAttribute);
            rootNode.Attributes.Append(Custom_IconColorAttribute);
            rootNode.Attributes.Append(Custom_IconHoverColorAttribute);
            rootNode.Attributes.Append(Custom_DefaultCharacterColor1Attribute);
            rootNode.Attributes.Append(Custom_DefaultCharacterColor2Attribute);
            rootNode.Attributes.Append(Custom_DefaultCharacterColor3Attribute);

            rootNode.Attributes.Append(InTouchScreenModeAttribute);
            rootNode.Attributes.Append(InHexModeCharacterListAttribute);

            //rootNode.AppendChild();
            foreach (CharacterCondition characterCondition in conditionCollection)
            {

                XmlNode conditionNode = doc.CreateElement("Condition");
                XmlNode conditionNodeName = doc.CreateElement("ConditionName");
                XmlNode conditionNodeDescription = doc.CreateElement("ConditionDescription");

                conditionNodeName.InnerText = characterCondition.ConditionName;
                conditionNodeDescription.InnerText = characterCondition.ConditionDescription;

                conditionNode.AppendChild(conditionNodeName);
                conditionNode.AppendChild(conditionNodeDescription);
                rootNode.AppendChild(conditionNode);

            }

            doc.AppendChild(rootNode);



            XmlWriterSettings xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace,
                NewLineOnAttributes = true
            };


            using (XmlWriter writer = XmlWriter.Create(savePath, xmlSettings))
            {
                doc.Save(writer);
            }

            MessageBox.Show("User Settings Saved!", "Battle Buddy");
        }


        private Character setCharacterTemplate()
        {
            Character characterTemplate = new Character()
            {
                Name = "",
                Class = "",
                Level = 0,
                MaxHitpoints = 0,
                CurrentHitpoints = 0,
                ArmorClass = 0,
                Strength = 0,
                Dexterity = 0,
                Constitution = 0,
                Intelligence = 0,
                Wisdom = 0,
                Charisma = 0,
                CharacterConditions = "",
                CharacterTrackers = "",
                ImagePath = ""
            };
            return characterTemplate;
        }

        //delete or rename to be specific on purpose
        private UserSettings temporaryDefaultSettings()
        {
            UserSettings tempUserSettings = new UserSettings()
            {
                DefaultPartyFilePath = "FakePartyFilePath",
                BackgroundImageFilePath = "FakeBackgroundImageFilePath",
                UseBackgroundImage = false,
                ApplicationTheme = 1,
                UseCharacterUniqueColorsInDetailView = false,
                UseCharacterUniqueColorsInSummaryView = false,
                InTouchScreenMode = false,
                InHexModeCharacterList = false
            };
            return tempUserSettings;
        }
    }
}
