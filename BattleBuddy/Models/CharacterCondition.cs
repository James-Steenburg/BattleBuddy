using BattleBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Models 
{
    class CharacterCondition : ChangeNotifier
    {
        private string _conditionName;
        public string ConditionName
        {
            get { return _conditionName; }
            set { _conditionName = value; OnPropertyChanged(nameof(ConditionName)); }
        }

        private string _conditionDescription;
        public string ConditionDescription
        {
            get { return _conditionDescription; }
            set { _conditionDescription = value; OnPropertyChanged(nameof(ConditionDescription)); }
        }
    }
}
