using BattleBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Models
{
    internal class CharacterAbilityBonus : ChangeNotifier
    {
        private string _targetAbilityName;
        public string AbilityName
        {
            get { return _targetAbilityName; }
            set { _targetAbilityName = value; }
        }

        private bool _isTargetAbilityProficient;
        public bool IsAbilityProficient
        {
            get { return _isTargetAbilityProficient; }
            set { _isTargetAbilityProficient = value; }
        }

        private bool _isTargetAbilityExpert;
        public bool IsAbilityExpert
        {
            get { return _isTargetAbilityExpert; }
            set { _isTargetAbilityExpert = value; }
        }

        private int _targetAbilityAdditionalBonus;
        public int AbilityAdditionalBonus
        {
            get { return _targetAbilityAdditionalBonus; }
            set { _targetAbilityAdditionalBonus = value; }
        }

        public string TargetAbilityBonusDescription
        {
            get
            {
                if (IsAbilityExpert) return "Expert";
                else if (IsAbilityProficient) return "Proficient";
                else return "None";
            }
        }
    }
}
