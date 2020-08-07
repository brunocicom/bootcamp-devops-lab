using System;
using Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;

namespace ConversorDistancias.Testes
{
    public class TelaConversaoDistancias
    {


        public TelaConversaoDistancias(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver = _configuration.GetSection("Selenium:CaminhoDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver = _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(browser, caminhoDriver);
        }

        private readonly IConfiguration _configuration;
        private IWebDriver _driver;

        public void CarregarPagina() => _driver.LoadPage(TimeSpan.FromSeconds(15), _configuration.GetSection("Selenium:UrlTelaConversaoDistancias").Value);

        public void PreencherDistanciaMilhas(double valor) => _driver.SetText(By.Name("milhas"), valor.ToString());

        public void ProcessarConversao()
        {
            _driver.Submit(By.Id("btnConverter"));

            WebDriverWait wait = new WebDriverWait( _driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("DistanciaKm")) != null);
        }

        public double ObterDistanciaKm()
        {
            return Convert.ToDouble(
                _driver.GetText(By.Id("DistanciaKm")));
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
