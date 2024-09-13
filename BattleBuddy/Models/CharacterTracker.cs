using BattleBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Models
{
    internal class CharacterTracker : ChangeNotifier
    {
        private string _trackerName;
        public string TrackerName
        {
            get { return _trackerName; }
            set { _trackerName = value; OnPropertyChanged(nameof(TrackerName)); }
        }

        private int _trackerAvailableUses;
        public int TrackerAvailableUses
        {
            get { return _trackerAvailableUses; }
            set { _trackerAvailableUses = value; OnPropertyChanged(nameof(TrackerAvailableUses)); }
        }

        private int _trackerMaxUses;
        public int TrackerMaxUses
        {
            get { return _trackerMaxUses; }
            set { _trackerMaxUses = value; OnPropertyChanged(nameof(TrackerMaxUses)); }
        }
    }
}
