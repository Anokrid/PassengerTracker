using Microsoft.Win32;
using PassengerTracker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassengerTracker
{
    public class UIManager : IUIManager
    {
        public void ShowWarningMessage(string message, string title = "")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public string ShowOpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            
            if (result == true)
            {
                return openFileDialog.FileName;
            }
            return "";
        }
    }
}
