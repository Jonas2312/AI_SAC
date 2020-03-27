using System;
using System.Windows;

namespace AI_SAC.AutoCompletion.View
{
	/// <summary>
	/// Interaction logic for AddItemDialog.xaml
	/// </summary>
	public partial class AddItemDialog : Window
    {
        public AddItemDialog(string question, string defaultAnswer)
        {
            InitializeComponent();
			lblQuestion.Content = question;
			txtAnswer.Text = defaultAnswer;
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

	}
}
