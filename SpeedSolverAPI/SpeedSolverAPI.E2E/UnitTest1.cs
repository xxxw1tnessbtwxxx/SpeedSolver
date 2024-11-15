using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Options;
using SpeedSolverDatabase;
using System.Net.Http.Json;
using Testcontainers.PostgreSql;
namespace SpeedSolverAPI.E2E
{
    public class DatabaseSchemaMigrationShould: WebApplicationFactory<Program>
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithName("postgres")
            .WithPassword("123")
            .WithDatabase("speedsolver")
            .WithExposedPort("5555")
            .Build();

        [Fact]
        public async Task MakeLocalRegister()
        {

            using var client = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, ssl) => true
            });

            var result = client.PostAsJsonAsync("https://localhost:5006/api/v1/users/register", new
            {
                login = "string",
                password = "string"
            }).Result.Content.ReadAsStringAsync().Result;
            Assert.True(result is string);
        }

        [Fact]
        public async Task MakeRemoteSshAuth()
        {
            using var client = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, ssl) => true
            });

            var result = client.PostAsJsonAsync("https://147.45.254.226:5006/api/v1/users/authorize", new
            {
                login = "string",
                password = "string"
            }).Result.Content.ReadAsStringAsync().Result;

            Assert.True(result is string);
        }
   

        
    }
}