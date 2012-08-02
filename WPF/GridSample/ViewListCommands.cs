using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GridSample
{
    public static class ViewListCommands
    {
        public static RoutedCommand LaunchAddItem = new RoutedCommand();
        public static RoutedCommand AddItem = new RoutedCommand();
        public static RoutedCommand EditItem = new RoutedCommand();
        public static RoutedCommand UpdateItem = new RoutedCommand();
    }
}
