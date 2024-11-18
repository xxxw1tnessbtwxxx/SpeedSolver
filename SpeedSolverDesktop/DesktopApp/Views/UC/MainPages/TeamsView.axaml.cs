using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using DesktopApp.DTO;
using MsBox.Avalonia;

namespace DesktopApp.Views.UC.MainPages;

public partial class TeamsView : UserControl
{

    public ObservableCollection<TeamView> teams = new()
    {
        new TeamView
        {
            TeamName = "Корги",
            MemberCount = 5
        },
        new TeamView
        {
            TeamName = "Чихуахуа",
            MemberCount = 10
        },
        new TeamView
        {
            TeamName = "Шпицы",
            MemberCount = 15
        },
    };
    
    public TeamsView()
    {
        InitializeComponent();
        TeamsList.ItemsSource = teams;
    }

    private void TeamsList_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        MessageBoxManager.GetMessageBoxStandard("selected", ((TeamsList.SelectedItem) as TeamView).TeamName)
            .ShowAsync();
    }
}