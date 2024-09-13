using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BattleBuddy.Views
{
    /// <summary>
    /// Interaction logic for AbilityBonusBoxWindow.xaml
    /// </summary>
    public partial class AbilityBonusBoxWindow : Window
    {
        private string _targetAbilityName;
        public string TargetAbilityName
        {
            get { return _targetAbilityName; }
            set { _targetAbilityName = value; }
        }

        private bool _isTargetAbilityProficient;
        public bool IsTargetAbilityProficient
        {
            get { return _isTargetAbilityProficient; }
            set { _isTargetAbilityProficient = value; }
        }

        private bool _isTargetAbilityExpert;
        public bool IsTargetAbilityExpert
        {
            get { return _isTargetAbilityExpert; }
            set { _isTargetAbilityExpert = value; }
        }

        private int _targetAbilityAdditionalBonus;
        public int TargetAbilityAdditionalBonus
        {
            get { return _targetAbilityAdditionalBonus; }
            set { _targetAbilityAdditionalBonus = value; }
        }

        public AbilityBonusBoxWindow()
        {
            InitializeComponent();
        }

        
        private void btnAddBonus_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBonus.SelectedItem != null)
            {
                //TargetAbilityName = cmbBonus.SelectedItem.ToString();

                TargetAbilityName = ((ComboBoxItem)cmbBonus.SelectedItem).Content.ToString();

                //Double check IsOn property is working as expected
                //IsTargetAbilityProficient = toggleSwitchProficient.IsOn;
                //IsTargetAbilityExpert = toggleSwitchExpertise.IsOn;

                if (txtAdditionalBonus.Text != null)
                {
                    try
                    {
                        int additionalBonus = Convert.ToInt32(txtAdditionalBonus.Text.ToString());
                        TargetAbilityAdditionalBonus = additionalBonus;
                    }
                    catch (Exception ex)
                    {
                        TargetAbilityAdditionalBonus = 0;
                        //MessageBox.Show("\nOnly integer numbers can be entered for this field.", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                this.DialogResult = true;
            }
        }
    }
}
