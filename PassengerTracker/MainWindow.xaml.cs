using PassengerTracker.ViewModel;
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
            IUIManager uiManager = new UIManager();
            DataContext = new MainFormViewModel(uiManager);
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
