using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GridSample
{
    /// <summary>
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddView : Window
    {
        private ViewListModel _vlm;
        public AddView()
        {
            InitializeComponent();
            _vlm = ModelManager.GetInstance();
            this.DataContext = _vlm;

            this.CommandBindings.Add(new CommandBinding(ViewListCommands.AddItem, ExecuteAddItem, CanExecuteItem));
        }

        private void ExecuteAddItem(object sender, ExecutedRoutedEventArgs e)
        {
            _vlm.AddItem();
        }

        private void CanExecuteItem(Object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = _vlm.CanExecute();
        }
    }
}
