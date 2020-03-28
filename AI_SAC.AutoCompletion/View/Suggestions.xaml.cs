using AI_SAC.AutoCompletion.ViewModel;
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

namespace AI_SAC.AutoCompletion.View
{
    /// <summary>
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Window
    {
        public Suggestions(DataCollectionViewModel items)
        {
            items = items;
            InitializeComponent();
        }
    }

    public DataCollectionViewModel Items { get; set; }
}
