using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for CreateCharacterTracker.xaml
    /// </summary>
    public partial class CreateCharacterTrackerWindow : Window
    {
        public CreateCharacterTrackerWindow()
        {
			InitializeComponent();
			txtTrackerName.Focus();
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtTrackerName.SelectAll();
			txtTrackerName.Focus();
		}

		public string TrackerName
		{
			get { return txtTrackerName.Text; }
		}

		public int TrackerAvailableUses
		{
			get
			{
				try
				{
					int available_uses = Convert.ToInt32(txtTrackerAvailableUses.Text.ToString());
					return available_uses;
				}
				catch (Exception ex)
				{
					MessageBox.Show("\nOnly integer numbers can be entered for this field.", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
					return 0;
				}
			}
		}

		public int TrackerMaxUses
		{
			get
			{
				try
				{
					int max_uses = Convert.ToInt32(txtTrackerMaxUses.Text.ToString());
					return max_uses;
				}
				catch (Exception ex)
				{
					MessageBox.Show("\nOnly integer numbers can be entered for this field.", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
					return 0;
				}
			}
		}
	}
}
