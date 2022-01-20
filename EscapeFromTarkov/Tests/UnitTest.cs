using System;
using System.Linq;
using System.Threading;
using EscapeFromTarkov.Extensions;
using EscapeFromTarkov.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EscapeFromTarkov.Tests;

public class Tests : BaseTest
{
    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void MediaPlayTest()
    {
        var mainPage = new MainPage(_driver);
        mainPage.VideoIconClick();
        _driver.SwitchTo().Frame("VideoPlayer_39");
        mainPage.FirstPlayButtonClick();
        //mainPage.SecondPlayButtonClick();
        Assert.AreNotEqual("0:00", mainPage.textOfVideoCurrentTime);
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void BookPriceTest()
    {
        var mainPage = new MainPage(_driver);
        mainPage.MerchButtonClick();
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        var merchPage = new MerchPage(_driver);
        merchPage.BooksButtonClick();
        Assert.AreEqual("260₽", merchPage.BookPrice());
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void SortingRating()
    {
        var mainPage = new MainPage(_driver);
        mainPage.RatingButtonClick();
        var ratingPage = new RatingPage(_driver);
        ratingPage.dropdownTop100Click();
        ratingPage.OptionTimeInGameClick();
        Assert.AreEqual(100, ratingPage.CountNumberOfPlayers());
        var listOfPrices = ratingPage.GetPlayersLevels().Select(level => level.Text).ToList();
        var isLevelValid = listOfPrices.All(levelText => int.Parse(levelText) > 0 && int.Parse(levelText) < 65);
        Assert.IsTrue(isLevelValid);
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void ValidArticle()
    {
        var mainPage = new MainPage(_driver);
        mainPage.SupportButtonClick();
        var suppotPage = new SupportPage(_driver);
        suppotPage.EnterSearchRequest("ошибка 208");
        suppotPage.SearchResultClick();
        Assert.AreEqual("Error 208 - bad region", suppotPage.PageText());
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void CartridgeSize()
    {
        var mainPage = new MainPage(_driver);
        mainPage.WikiButtonClick();
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        var wikiPage= new WikiPage(_driver);
        wikiPage.WeaponsAndModsButtonClick();
        wikiPage.WeaponsButtonClick();
        Assert.AreEqual("5.45x39 мм", wikiPage.GetBulletSize());
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void OrderWithoutRegistration()
    {
        var mainPage = new MainPage(_driver);
        mainPage.PreorderButtonClickOnMainMainPage();
        var preorderPage = new PreorderPage(_driver);
        preorderPage.preorderButtonClickOnPreorderPage();
        Assert.AreEqual("СНАЧАЛА ВАМ НУЖНО ЗАРЕГИСТРИРОВАТЬСЯ, И АВТОРИЗОВАТЬСЯ.", preorderPage.GetTextOnThePage());
    }
}
