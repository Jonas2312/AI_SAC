using AI_SAC.Model.XML;
using AI_SAC.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AI_SAC.View
{
    /// <summary>
    /// Interaction logic for ExcelTableView.xaml
    /// </summary>
    public partial class ExcelTableView : UserControl
    {
        public bool textChanged;
        string oldValue;
        public ExcelTableView()
        {
            InitializeComponent();
            Loaded += Init;
        }

        public void Init(object sender, RoutedEventArgs e)
        {
            textChanged = false;
            oldValue = string.Empty;
        }

        public void ChangeText(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            {
                if (vis is DataGridRow)
                {
                    DataGridRow row = (DataGridRow)vis;
                    EditorView.instance.remove((row.Item as DataItemViewModel).ID);
                    break;
                }
            }
        }


        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            textChanged = true;
        }

        private void TextBoxGainFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox))
                return;
            TextBox tb = (TextBox)sender;
            oldValue = tb.Text;
        }
        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {

            if (!(sender is TextBox))
                return;

            if (textChanged)
            {
                TextBox tb = (TextBox)sender;
                if (Validation.GetHasError(tb))
                {
                    tb.Text = oldValue;
                    Validation.ClearInvalid(tb.BindingGroup.BindingExpressions[0]);
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("ERROR: A trigger can not contain another trigger and must be at least 3 characters (Triggers are case insensitive).", "Removal Confirmation", System.Windows.MessageBoxButton.OK);
                }
                else
                    oldValue = tb.Text;

                // Reset changed flag
                textChanged = false;
            }
        }

    }
}
