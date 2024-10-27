using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using DesktopApp.DTO;
using System.Configuration;
using DesktopApp.Helpers;

namespace DesktopApp.Views.UC;

public partial class AuthozationWindow : UserControl
{
    public AuthozationWindow()
    {
        InitializeComponent();
    }

    private async void AuthorizeBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
        {
            await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Поле логин или пароль пустые.").ShowAsync();
            return;
        }
        
        var service = APIService.APIService
            .BuildService()
            .WithUrl();
        
        AuthorizeRequest request = new()
        {
            Login = LoginBox.Text,
            Password = PasswordBox.Text
        };
        
        var tokenCreation = await service.UserAuthorize(request);
        if (tokenCreation.IsFailure)
        {
            await MessageBoxManager.GetMessageBoxStandard("Ошибка", tokenCreation.Error).ShowAsync();
            return;
        }

        await MessageBoxManager.GetMessageBoxStandard("Успешно", "Вы успешно авторизовались в сервисе. Срок сессии: 24 часа.").ShowAsync();
        SessionProperties.Token = tokenCreation.Value;
        await MessageBoxManager.GetMessageBoxStandard("asd", SessionProperties.Token).ShowAsync();

    }
}