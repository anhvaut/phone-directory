using System;
using System.Windows;
using System.Windows.Input;

namespace PhoneDirectory
{
    public class TrayBarCommand : ICommand
    {
        public void Execute(object parameter)
        {
            QuickSearch _QuickSearch = new QuickSearch();
            _QuickSearch.Show();

            _QuickSearch.Top = System.Windows.SystemParameters.PrimaryScreenHeight - _QuickSearch.Height - 50;
            _QuickSearch.Left = System.Windows.SystemParameters.PrimaryScreenWidth - _QuickSearch.Width;
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
