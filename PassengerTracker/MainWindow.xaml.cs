using PassengerTracker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassengerTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
            DataContext = new MainFormViewModel();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            WindowState ^= WindowState.Maximized;
        }

        private void ButtonMinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonMaximizeClick(object sender, RoutedEventArgs e)
        {
            WindowState ^= WindowState.Maximized;
        }

        private void ButtonCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
