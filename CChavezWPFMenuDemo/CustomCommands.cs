using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CChavezWPFMenuDemo
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand // Exit commannd Alt+F4 implemetation
        (
            "Exit",
            "Exit",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                        new KeyGesture(Key.F4, ModifierKeys.Alt)
            }

        );
    }
}
