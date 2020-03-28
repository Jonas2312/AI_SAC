using AI_SAC.AutoCompletion.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AI_SAC.AutoCompletion.View
{
    /// <summary>
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Window
    {
        public object selected_item;
        public Suggestions(DataCollectionViewModel items)
        {
            Items = items;
            InitializeComponent();
            this.Topmost =this true;
            this.Activate();
            this.Focus();
        }

        public DataCollectionViewModel Items { get; set; }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selected_item = button.Tag;
        }
    }

}
