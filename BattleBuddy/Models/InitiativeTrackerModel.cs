using BattleBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Models
{
    internal class InitiativeTrackerModel : ChangeNotifier
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set { _initiative = value; OnPropertyChanged(nameof(Initiative)); }
        }

        public InitiativeTrackerModel() { }
    }
}
