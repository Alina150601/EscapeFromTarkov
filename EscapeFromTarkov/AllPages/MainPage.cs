using EscapeFromTarkov.Extensions;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages;

public class MainPage
{
    private IWebDriver _driver;

    private By videoIcon = By.Id("banner_39_youtube");
    private By firstPlayButton = By.XPath("//*[@id='movie_player']/div[4]/button");
    private By currentVideoTime = By.XPath("//a[contains(text(),'Escape from Tarkov - Battle for Concordia')]//div[@id='player']");
    private By merchButton = By.XPath("//a[contains(text(),'Мерч')]");
    private By ratingButton = By.XPath("//a[contains(text(),'Рейтинг')]");
    private By supportButton = By.XPath("//a[contains(text(),'Поддержка')]");
    private By wikiButton = By.XPath("//*[contains(text(),'Вики')]");
    private By preorder = By.XPath("//*[@class='preorder_button']");

    public MainPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void VideoIconClick()
    {
        _driver.ElementClick(videoIcon);
    }

    public void FirstPlayButtonClick()
    {
        _driver.ElementClick(firstPlayButton);
    }
    
    public string textOfVideoCurrentTime()
    {
        return _driver.ElementText(currentVideoTime);
    }

    public void MerchButtonClick()
    {
        _driver.ElementClick(merchButton);
    }

    public void RatingButtonClick()
    {
        _driver.ElementClick(ratingButton);
    }

    public void SupportButtonClick()
    {
        _driver.ElementClick(supportButton);
    }

    public void WikiButtonClick()
    {
        _driver.ElementClick(wikiButton);
    }

    public void PreorderButtonClickOnMainMainPage()
    {
        _driver.ElementClick(preorder);
    }
}