using System;
using System.Linq;
using System.Threading;
using EscapeFromTarkov.Extensions;
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
        _driver.ElementClick(By.Id("banner_39_youtube"));
        _driver.SwitchTo().Frame("VideoPlayer_39");
        _driver.ElementClick(By.XPath("//*[@id='movie_player']/div[4]/button"));
        _driver.ElementClick(By.XPath(
            "//a[contains(text(),'Escape from Tarkov - Battle for Concordia')]/../../../../../../div[@id='player']"));
        Thread.Sleep(5000);
        var currentTime = _driver.ElementText(By.XPath(
            "//a[contains(text(),'Escape from Tarkov - Battle for Concordia')]/../../../../../../div[@id='player']//*[@class='ytp-time-current']"));
        Assert.AreNotEqual("0:00", currentTime);
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void BookPriceTest()
    {
        _driver.ElementClick(By.XPath("//a[contains(text(),'Мерч')]"));
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        _driver.ElementClick(By.XPath("//*[contains(text(),'Книги')]"));
        var bookPrice = _driver
            .ElementText(
                By.XPath("//*[contains(text(),'Хозяин Ночи') and contains(text(),'Русская версия')]/../../span"));
        Assert.AreEqual("260₽", bookPrice);
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void SortingRating()
    {
        _driver.ElementClick(By.XPath("//a[contains(text(),'Рейтинг')]"));
        var js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("scrollBy(0, 400)");
        Thread.Sleep(3000);
        _driver.ElementClick(By.XPath("//*[@id='ratingFiltersForm']//div[@class='category switcher inlinetop']"));
        Thread.Sleep(3000);
        _driver.ElementClick(By.XPath("//*[contains(text(),'время в игре')]"));
        Assert.AreEqual(100, _driver.CountElements(By.XPath("//tbody/tr")));
        Thread.Sleep(3000);
        var levels = _driver.GetElements(By.XPath("//*[@data-col-name='ур']"));
        var listOfPrices = levels.Select(level => level.Text).ToList();
        var validLevel = true;
        foreach (var levelText in
                 listOfPrices.Where(levelText => int.Parse(levelText) < 0 && int.Parse(levelText) > 58))
        {
            validLevel = false;
        }

        Assert.IsTrue(validLevel);
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void ValidArticle()
    {
        _driver.ElementClick(By.XPath("//a[contains(text(),'Поддержка')]"));
        _driver.GetElement(By.Id("main_search"), new TimeSpan(10)).SendKeys("ошибка 208");
        var builder = new Actions(_driver);
        builder.MoveToElement(_driver.FindElement(By.Id("knowledge_results"))).Build().Perform();
        _driver.ElementClick(By.Id("knowledge_results"));
        Assert.AreEqual("Error 208 - bad region",
            _driver.ElementText(By.XPath("//*[contains(text(),'Error 208 - bad region')]")));
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void CartridgeSize()
    {
        _driver.ElementClick(By.XPath("//*[contains(text(),'Вики')]"));
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        _driver.ElementClick(By.XPath("//*[@class='fandom-community-header']//span[contains(text(),'Оружие и моды')]"));
        _driver.ElementClick(By.XPath("/html/body/div[4]/div[3]/div[1]/header/nav/ul/li[4]/div[2]/ul/li[1]/a"));
        var bulletSize = _driver.ElementText(By.XPath(
            "//*[@class='wikitable sortable jquery-tablesorter']//*[contains(text(),'АК-74М')]/../following-sibling::*[2]/a"));
        Assert.AreEqual("5.45x39 мм", bulletSize);
    }

    [Parallelizable(ParallelScope.Self)]
    [Test]
    public void OrderWithoutRegistration()
    {
        _driver.ElementClick(By.XPath("//*[@class='preorder_button']"));
        _driver.ElementClick(By.XPath("//div[text()='Предзаказ' and @data-selected='standard']"));
        Assert.AreEqual("СНАЧАЛА ВАМ НУЖНО ЗАРЕГИСТРИРОВАТЬСЯ, И АВТОРИЗОВАТЬСЯ.",
            _driver.ElementText(By.XPath("//h4")));
    }
}
