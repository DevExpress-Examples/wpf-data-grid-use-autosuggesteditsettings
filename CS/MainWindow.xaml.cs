using DevExpress.Mvvm;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DXSample {
    public partial class MainWindow : Window {
        public ObservableCollection<Item> Items { get; set; }
        public MainWindow() {
            Items = new ObservableCollection<Item>();
            DataContext = this;
            InitializeComponent();
        }
        AutoSuggestEdit ActiveEditor;
        void ShownEditor(object sender, EditorEventArgs e) {
            ActiveEditor = e.Editor as AutoSuggestEdit;
            if (ActiveEditor != null)
                ActiveEditor.QuerySubmitted += QuerySubmitted;
        }
        void HiddenEditor(object sender, EditorEventArgs e) {
            if (ActiveEditor != null) {
                ActiveEditor.QuerySubmitted += QuerySubmitted;
                ActiveEditor.ItemsSource = null;
                ActiveEditor = null;
            }
        }
        void QuerySubmitted(object sender, AutoSuggestEditQuerySubmittedEventArgs e) {
            ActiveEditor.ItemsSource = new List<string>(Enumerable.Range(0, 10).Select(c => e.Text + " item #" + c));
        }
    }
    public class Item : BindableBase {
        string _Value;
        public string Value {
            get { return _Value; }
            set { SetProperty(ref _Value, value, "Value"); }
        }
    }
}