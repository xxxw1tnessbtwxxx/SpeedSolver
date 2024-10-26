using System;
using System.IO;
using DesktopApp.Settings.Models;
using Microsoft.Extensions.Configuration;

namespace DesktopApp.Settings;

public class SettingsReader
{
    public static MainConfiguration? ReadSettings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        var configModel = new MainConfiguration();
        configuration.Bind(configModel);

        return 
    }
}