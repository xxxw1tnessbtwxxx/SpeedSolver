using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DesktopApp.DTO;
using DesktopApp.Settings;
using DesktopApp.Settings.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using SpeedSolverCore.DTO.User;

namespace DesktopApp.APIService;

public class APIService
{
    private readonly string _apiVersion = "v1";
    private HttpClient? _requester = null;
    private MainConfiguration? _config = null;
    private APIService()
    {
        this._config = SettingsReader.ReadSettings(); 
        _requester = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });
    }
    
    public static APIService BuildService()
    {
        return new APIService();
    }

    public APIService WithUrl(BaseUrl baseUrl)
    {
        if (baseUrl == BaseUrl.Local)
        {
            _requester.BaseAddress = new Uri($"https://localhost:5006/api/{this._apiVersion}/");
        }
        else if (baseUrl == BaseUrl.Remote)
        {
            _requester.BaseAddress = new Uri($"https://{_config.Machine.Address}:5006/api/{this._apiVersion}/");

        }

        return this;
    }

    public async Task<Result<UserDto>> Register(RegisterRequest request)
    {

        HttpResponseMessage response = null;
        try
        {
            response = _requester.PostAsJsonAsync("users/register", request).Result;
        }
        catch (Exception ex)
        {
            return Result.Failure<UserDto>(ex.Message);
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return Result.Failure<UserDto>(response.Content.ReadAsStringAsync().Result);
        }
        

        return Result.Success<UserDto>(JsonConvert.DeserializeObject<UserDto>(response.Content.ReadAsStringAsync().Result));
    }
}