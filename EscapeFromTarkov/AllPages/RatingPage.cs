using System.Collections.Generic;
using EscapeFromTarkov.Extensions;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages;

public class RatingPage
{
    private IWebDriver _driver;

    private By dropdownTop100 = By.XPath("//*[@id='ratingFiltersForm']//div[@class='category switcher inlinetop']");
    private By optionTimeInGame = By.XPath("//*[contains(text(),'время в игре')]");
    private By numberOfPlayers = By.XPath("//tbody/tr");
    private By playersLevels = By.XPath("//*[@data-col-name='ур']");
    
    public RatingPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void dropdownTop100Click()
    {
        _driver.ScrollElementToCenter(dropdownTop100);
        _driver.ElementClick(dropdownTop100);
    }
    
    public void OptionTimeInGameClick()
    {
        _driver.ElementClick(optionTimeInGame);
    }
    
    public int CountNumberOfPlayers()
    {
        return _driver.CountElements(numberOfPlayers);
    }

    public IEnumerable<IWebElement> GetPlayersLevels()
    {
        return _driver.GetElements(playersLevels);
    }
}