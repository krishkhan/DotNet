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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ViewList : Window
    {
        private ViewListModel _vlm;
        
        public ViewList()
        {
            InitializeComponent();
            _vlm = ModelManager.GetInstance();
            this.DataContext = _vlm;
            this.CommandBindings.Add(new CommandBinding(ViewListCommands.LaunchAddItem,ExecuteLaunchAddItem,CanExecuteItem));
            this.CommandBindings.Add(new CommandBinding(ViewListCommands.EditItem, ExecuteEditItem, CanExecuteItem));
            this.CommandBindings.Add(new CommandBinding(ViewListCommands.UpdateItem, ExecuteUpdateItem, CanExecuteItem));
                
        }


        private void ExecuteEditItem(object sender, ExecutedRoutedEventArgs e)
        {
            _vlm.EditItem();
        }
        
        private void ExecuteAddItem(object sender, ExecutedRoutedEventArgs e)
        {
            _vlm.AddItem();
        }

        private void ExecuteLaunchAddItem(object sender,ExecutedRoutedEventArgs e)
        {
            _vlm.LaunchAddItem();
        }


        private void CanExecuteItem(Object sender, CanExecuteRoutedEventArgs e)
        {
            
            e.CanExecute = _vlm.CanExecute();
        }

        private void ExecuteUpdateItem(object sender, ExecutedRoutedEventArgs e)
        {
            _vlm.UpdateItem();
        }

        
    }
}
