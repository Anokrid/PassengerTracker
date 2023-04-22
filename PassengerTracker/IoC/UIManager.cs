using Microsoft.Win32;
using PassengerTracker.ViewModel;
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
