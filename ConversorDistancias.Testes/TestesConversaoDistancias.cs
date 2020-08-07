using Xunit;
using System.IO;
using Selenium.Utils;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using BootcampDevOpsLab;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;

namespace ConversorDistancias.Testes
{
    public class TestesConversaoDistancias
    {

        public TestesConversaoDistancias()
        {
            var directory = Directory.GetCurrentDirectory();
            directory = Regex.Replace(directory, @"\.Tests\\bin\\Debug\\netcoreapp3\.1", "");
            directory = directory + "\\wwwroot\\";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("https://localhost:5001")
                .UseIISIntegration()
                .UseWebRoot(directory)
                .UseStartup<Startup>()
            .Build();

            host.RunAsync();

            //_driver.Navigate().GoToUrl("https://localhost:5001/");

            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

        }

        private readonly IConfiguration _configuration;

        [Theory]
        //[InlineData(Browser.Firefox, 100, 160.9)]
        //[InlineData(Browser.Firefox, 230.05, 370.1505)]
        //[InlineData(Browser.Firefox, 250.5, 403.0545)]
        //[InlineData(Browser.Chrome, 100, 160.9)]
        //[InlineData(Browser.Chrome, 230.05, 370.1505)]
        [InlineData(Browser.Chrome, 250.5, 403.0545)]
        public async Task TestarConversaoDistancia(Browser browser, double valorMilhas, double valorKm)
        {
            //WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();
            //TelaConversaoDistancias tela = new TelaConversaoDistancias(_configuration, browser);
            //var client = factory.CreateClient();


            //await client.GetAsync("Home");
            //tela.CarregarPagina();
            //tela.PreencherDistanciaMilhas(valorMilhas);
            //tela.ProcessarConversao();
            //double resultado = tela.ObterDistanciaKm();
            //tela.Fechar();

            //Assert.Equal(valorKm, resultado);

            IWebDriver webDriver = new ChromeDriver("C:\\Selenium\\ChromeDriver");

            webDriver.LoadPage(TimeSpan.FromSeconds(5), "https://localhost:5001/");
        }
    }
}