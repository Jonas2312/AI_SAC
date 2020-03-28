using AI_SAC.AutoCompletion.Model.Analyzer;
using AI_SAC.AutoCompletion.Model.HookFeed;
using AI_SAC.AutoCompletion.Model.XML;
using AI_SAC.AutoCompletion.Others;
using AI_SAC.AutoCompletion.ViewModel;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AI_SAC.AutoCompletion.View
{ 
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView : System.Windows.Controls.UserControl
    {
        public Window currentPopup;
        public static EditorView instance;
        public EditorViewModel editorViewModel;
        public string filePath;
        public EditorView()
        {
            instance = this;
            Setup();
            InitializeComponent();
            Loaded += Init;
        }

        public void Setup()
        {
            filePath = Utils.getXMLFilePath();
        }
        public void Init(object sender, RoutedEventArgs e)
        {            
            foreach(var item in Grid.Children)
            {
                if(item is UIElement)
                    (item as UIElement).Visibility = Visibility.Hidden;
            }
            NewDatabase.Visibility = Visibility.Visible;
            LoadDatabase.Visibility = Visibility.Visible;
        }

        private void OnSearchTextChanged(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            foreach(DataItemViewModel divm in editorViewModel.ExcelTableViewModel.XMLData)
            {
                string searched = tb.Text;
                if (string.IsNullOrWhiteSpace(searched))
                {
                    divm.ItemVisibility = Visibility.Visible;
                    continue;
                }
                else if(divm.Trigger.ToLower().Contains(searched.ToLower()) || divm.Completion.ToLower().Contains(searched.ToLower()))
                {
                    divm.ItemVisibility = Visibility.Visible;
                    continue;
                }
                divm.ItemVisibility = Visibility.Collapsed;
            }
        }
        private void StartProgramButton_Click(object sender, RoutedEventArgs e)
        {
            ProgramRunningText.Visibility = Visibility.Visible;
            ProgramNotRunningText.Visibility = Visibility.Hidden;
            StopProgramButton.Visibility = Visibility.Visible;
            StartProgramButton.Visibility = Visibility.Hidden;
            editorViewModel.hookFeedController.isActive = true;
        }


        public void StopProgramButton_Click(object sender, RoutedEventArgs e)
        {
            ProgramRunningText.Visibility = Visibility.Hidden;
            ProgramNotRunningText.Visibility = Visibility.Visible;
            StopProgramButton.Visibility = Visibility.Hidden;
            StartProgramButton.Visibility = Visibility.Visible;
            editorViewModel.hookFeedController.isActive = false;
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            DataCollectionViewModel dcvm = editorViewModel.ExcelTableViewModel.XMLData;
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(r => ((char)r).ToString())
                .Concat(Enumerable.Range(97, 26).Select(r => ((char)r).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(r => r.ToString()))
                .OrderBy(r => Guid.NewGuid())
                .Take(15)
                .ToList().ForEach(r => builder.Append(r));
            string id = builder.ToString();

            dcvm.Add(new DataItemViewModel(new DataItem(id, "", "", false)));
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {

            DataCollectionViewModel dcvm = editorViewModel.ExcelTableViewModel.XMLData;
           
            AddItemDialog aid = new AddItemDialog("Remove row with id", "Item ID");
            if (aid.ShowDialog() == false)
                return;

            string answer = aid.Answer;
            remove(answer);
        }




        public void remove(string id)
        {

            DataCollectionViewModel dcvm = editorViewModel.ExcelTableViewModel.XMLData;

            DataItemViewModel divm = dcvm.Where(i => i.ID == id).FirstOrDefault();            

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure? Removal can not be undone.", "Removal Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                dcvm.Remove(divm);
            }
        }

        private void NewDataBaseButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = filePath,
                Title = "New Database",

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataCollection xmlData = XMLLoad.Load(saveFileDialog.FileName);
                HookFeedController hfc = new HookFeedController(xmlData);
                editorViewModel = new EditorViewModel(hfc);
                HasValidEditorViewModel();
            }
        }

        public void LoadDataBaseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = filePath,
                Title = "Load Database",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataCollection xmlData = XMLLoad.Load(openFileDialog1.FileName);
                HookFeedController hfc = new HookFeedController(xmlData);
                editorViewModel = new EditorViewModel(hfc);
                HasValidEditorViewModel();
            }
        }

        public void HasValidEditorViewModel()
        {
            foreach (var item in Grid.Children)
            {
                if (item is UIElement)
                    (item as UIElement).Visibility = Visibility.Visible;
            }
            StopProgramButton.Visibility = Visibility.Hidden;
            ProgramRunningText.Visibility = Visibility.Hidden;

            DataContext = editorViewModel;
        }


        public async void ShowSuggestionDialog()
        {
            DataCollectionViewModel dcvm = new DataCollectionViewModel(new DataCollection(null));
            KeyAnalyzer analyzer = editorViewModel.hookFeedController.keyAnalyzer;
            string searchFor = analyzer.currentString;
            foreach(var item in editorViewModel.ExcelTableViewModel.XMLData)
            {
                if(item.Trigger.ToLower().Contains(searchFor.ToLower()))
                    dcvm.Add(item);
            }

            Suggestions aid = new Suggestions(dcvm);

            if (aid.ShowDialog() == false)
                return;

            DataItemViewModel divm = (DataItemViewModel)aid.selected_item;
            analyzer.FeedDataItem(divm.ToModel());
        }
    }
}
