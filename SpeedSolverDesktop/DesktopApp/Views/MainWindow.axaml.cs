using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DesktopApp.Views.UC;

namespace DesktopApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.UserActionControl.Content = new DefaultTextView();
        }

        private void CloseAppBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void HideAppBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ImFirstTimeBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            this.UserActionControl.Content = new RegisterWindow(this);
        }

        private void ImRegisteredBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            UserActionControl.Content = new AuthozationWindow(this);
        }
    }
}