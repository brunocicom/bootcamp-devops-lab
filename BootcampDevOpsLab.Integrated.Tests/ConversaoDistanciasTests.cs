using Moq;
using Xunit;
using System.IO;
using Selenium.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using BootcampDevOpsLab.Services.Interfaces;
using BootcampDevOpsLab.Integrated.Tests.POM;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampDevOpsLab.Integrated.Tests
{
    public class ConversaoDistanciasTests
    {
        public ConversaoDistanciasTests()
        {
            var directory = Directory.GetCurrentDirectory();
            directory = Regex.Replace(directory, @"\\BootcampDevOpsLab\.Integrated\.Tests\\bin\\Debug\\netcoreapp3\.1", "");
            directory += "\\BootcampDevOpsLab\\wwwroot\\";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .UseIISIntegration()
                .UseWebRoot(directory)
                .UseStartup<Startup>()
                .ConfigureTestServices((services) => 
                {
                    services.AddScoped(sp =>
                    {
                        var mock = new Mock<IMathService>();
                        mock.Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(160);
                        return mock.Object;
                    });
                })
            .Build();

            host.RunAsync();

            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        private readonly IConfiguration _configuration;

        [Theory]
        //[InlineData(Browser.Firefox, 100, 160)]
        [InlineData(Browser.Chrome, 100, 161)]
        public void TestarConversaoDistancia(Browser browser, double valorMilhas, double valorKm)
        {
            TelaConversaoDistancias tela = new TelaConversaoDistancias(_configuration, browser);

            tela.CarregarPagina();
            tela.PreencherDistanciaMilhas(valorMilhas);
            tela.ProcessarConversao();
            double resultado = tela.ObterDistanciaKm();
            tela.Fechar();

            Assert.Equal(valorKm, resultado);
        }
    }
}