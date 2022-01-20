using EscapeFromTarkov.Extensions;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages;

public class SupportPage
{
    private IWebDriver _driver;

    private By inputSearch = By.Id("main_search");
    private By searchResult = By.Id("knowledge_results");
    private By pageText = By.XPath("//*[contains(text(),'Error 208 - bad region')]");
    
    public SupportPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void EnterSearchRequest(string text)
    {
        _driver.GetElement(inputSearch).SendKeys(text);
    }
    
    public void SearchResultClick()
    {
        _driver.ElementClick(searchResult);
    }
    
    public string PageText()
    {
        return _driver.ElementText(pageText);
    }
}