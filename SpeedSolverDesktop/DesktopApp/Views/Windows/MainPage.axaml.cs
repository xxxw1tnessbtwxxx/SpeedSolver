using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;

namespace DesktopApp.Views.Windows;

public partial class MainPage : Window
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void InterractPane_OnClick(object? sender, RoutedEventArgs e)
    {
        LeftSideMenuBar.IsPaneOpen = !LeftSideMenuBar.IsPaneOpen;
    }

    private void LeftSideMenuBar_OnPaneOpening(object? sender, CancelRoutedEventArgs e)
    {
        InterractPane.Content = "<";
        InterractPane.HorizontalAlignment = HorizontalAlignment.Right;
    }

    private void LeftSideMenuBar_OnPaneClosing(object? sender, CancelRoutedEventArgs e)
    {
        InterractPane.Content = ">";
        InterractPane.HorizontalAlignment = HorizontalAlignment.Left;
    }
}