using EscapeFromTarkov.Extensions;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages;

public class WikiPage
{
    private IWebDriver _driver;

    private By weaponsAndModsButton = By.XPath("//*[@class='fandom-community-header']//span[contains(text(),'Оружие и моды')]");
    private By weaponsButton = By.XPath("//*[@class='fandom-community-header']//span[text()='Оружие']");
    private By bulletSize =By.XPath("//*[@class='wikitable sortable jquery-tablesorter']//*[contains(text(),'АК-74М')]/../following-sibling::*[2]/a");

    public WikiPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void WeaponsAndModsButtonClick()
    {
        _driver.ElementClick(weaponsAndModsButton);
    }
    
    public void WeaponsButtonClick()
    {
        _driver.ElementClick(weaponsButton);
    }
    
    public string GetBulletSize()
    {
        return _driver.ElementText(bulletSize);
    }
}