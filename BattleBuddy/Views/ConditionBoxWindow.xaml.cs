using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ConditionBoxWindow.xaml
    /// </summary>
    public partial class ConditionBoxWindow : Window
    {
        private string _selectedCondition;
        public string SelectedCondition
        {
            get { return _selectedCondition; }
            set { _selectedCondition = value; }
        }


        public ObservableCollection<string> filteredConditionList;
        public ObservableCollection<string> origConditionList;
        public ConditionBoxWindow(ObservableCollection<string> conditionList)
        {
            InitializeComponent();
            txtFilter.Focus();

            filteredConditionList = new ObservableCollection<string>();
            origConditionList = new ObservableCollection<string>();

            origConditionList = conditionList;
            conditionFilter(origConditionList);

            lvConditions.ItemsSource = filteredConditionList;
        }

        private void conditionFilter(ObservableCollection<string> list)
        {
            if(filteredConditionList.Count > 0) { filteredConditionList.Clear(); }
            
            foreach (string s in list)
            {
                if(s.ToLower().Contains(txtFilter.Text.ToLower()) || txtFilter.Text == "")
                {
                    filteredConditionList.Add(s);
                }
            }
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            conditionFilter(origConditionList);
            CollectionViewSource.GetDefaultView(lvConditions.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lvConditions.SelectedItem != null)
            {
                SelectedCondition = lvConditions.SelectedItem.ToString();
                this.DialogResult = true;
            }
            
        }
    }
}
