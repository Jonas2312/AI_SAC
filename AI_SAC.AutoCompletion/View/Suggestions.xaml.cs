using AI_SAC.AutoCompletion.Model.Analyzer;
using AI_SAC.AutoCompletion.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AI_SAC.AutoCompletion.View
{
    /// <summary>
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Window
    {
        public DataItemViewModel selected_item;
        KeyAnalyzer analyzer;
        public DataCollectionViewModel Items { get; set; }
        public string CurrentString { get; set; }

        public Suggestions(DataCollectionViewModel items, string currentString, KeyAnalyzer analyzer)
        {
            Items = items;
            if (string.IsNullOrWhiteSpace(currentString))
                CurrentString = "No (or an empty) input was registered.";
            else
                CurrentString = currentString;
            this.analyzer = analyzer;
            InitializeComponent();
            this.Topmost = true;
            this.Activate();
            this.Focus();
        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selected_item = (DataItemViewModel)button.Tag;
            DialogResult = true;
        }

        public void ClearInputClick(object sender, RoutedEventArgs e)
        {
            analyzer.CurrentString = string.Empty;
            DialogResult = true;
        }

        public void ClearInputRemoveClick(object sender, RoutedEventArgs e)
        {
            string s = string.Empty;
            for (int i = 0; i < analyzer.CurrentString.Length; i++)
            {
                s += "{BACKSPACE}";
            }
            analyzer.CurrentString = string.Empty;
            analyzer.stringsToFeed.Add(s);
            DialogResult = true;
        }
    }

}
