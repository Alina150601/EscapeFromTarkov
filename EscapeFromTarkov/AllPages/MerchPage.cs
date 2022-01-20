using EscapeFromTarkov.Extensions;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages;

public class MerchPage
{
    private IWebDriver _driver;
    
    private By booksButtonClick = By.XPath("//*[contains(text(),'Книги')]");
    private By bookPrice = By.XPath("//*[contains(text(),'Хозяин Ночи') and contains(text(),'Русская версия')]/../../span");

    public MerchPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void BooksButtonClick()
    {
        _driver.ElementClick(booksButtonClick);
    }
    
    public string BookPrice()
    {
       return _driver.ElementText(bookPrice);
    }
}