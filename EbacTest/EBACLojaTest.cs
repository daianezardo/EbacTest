using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace EbacTest
{
    [TestClass]
    public class EBACLojaTest
    {
        [TestMethod]
        public async Task shouldAccessHome()
        {
            const string lojaUrl = "http://lojaebac.ebaconline.art.br/";
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel="chrome", Headless=false
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync(lojaUrl);
            Assert.AreEqual(await page.TitleAsync(), "EBAC – Shop – Página de teste");
        }
    }
}