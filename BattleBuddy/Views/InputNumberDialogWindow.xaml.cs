using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for InputNumberDialogWindow.xaml
    /// </summary>
    public partial class InputNumberDialogWindow : Window
    {
		public InputNumberDialogWindow(string question, string defaultAnswer = "")
		{
			InitializeComponent();
			lblQuestion.Content = question;
			txtAnswer.Text = defaultAnswer;
			txtAnswer.Focus();
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtAnswer.SelectAll();
			txtAnswer.Focus();
		}

		public string Answer
		{
			get { return txtAnswer.Text; }
		}

		public int IntAnswer
        {
			get
            {
				try
                {
					DataTable dt = new DataTable();
					var v = dt.Compute(txtAnswer.Text, "");
					int v_int = Convert.ToInt32(Math.Floor(Convert.ToDouble(v)));
					return v_int;
				}
				catch (Exception ex)
                {
					MessageBox.Show("\nOnly numbers and basic mathematics symbols (.+-/*) can be entered.", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
					return 0;
                }
            }
        }
	}
}
