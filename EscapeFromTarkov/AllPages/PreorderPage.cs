using EscapeFromTarkov.Extensions;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages;

public class PreorderPage
{
    private IWebDriver _driver;
    private By preorderButtonOnPreorderPage = By.XPath("//div[text()='Предзаказ' and @data-selected='standard']");
    private By textOnThePage = By.XPath("//h4");

    public PreorderPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void preorderButtonClickOnPreorderPage()
    {
        _driver.ElementClick(preorderButtonOnPreorderPage);
    }

    public string GetTextOnThePage()
    {
        return _driver.ElementText(textOnThePage);
    }
    
    
}