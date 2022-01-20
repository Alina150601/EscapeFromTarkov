using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EscapeFromTarkov.Extensions;

public static class WebDriverExtension
{
    public static IWebDriver GoToUrl(this IWebDriver driver, string url)
    {
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
        return driver;
    }

    public static IWebElement GetElement(this IWebDriver driver, By by) =>
        GetElement(driver, by, TimeSpan.FromSeconds(25));

    public static IWebElement GetElement(this IWebDriver driver, By by, TimeSpan timeout)
    {
        var wait = new WebDriverWait(driver, timeout);
        wait.Until(ExpectedConditions.ElementToBeClickable(by));
        return wait.Until(d => d.FindElement(by));
    }
    public static ReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, By by, TimeSpan timeout)
    {
        var wait = new WebDriverWait(driver, timeout);
        wait.Until(ExpectedConditions.ElementToBeClickable(by));
        wait.IgnoreExceptionTypes(new[] {typeof(StaleElementReferenceException),typeof(StaleElementReferenceException)});
        return wait.Until(d => d.FindElements(by));
    }

    public static IEnumerable<IWebElement> GetElements(this IWebDriver driver, By by) =>
        GetElements(driver, by, TimeSpan.FromSeconds(15));

    public static int CountElements(this IWebDriver driver, By by) =>
        GetElements(driver, by, TimeSpan.FromSeconds(15)).Count;

    public static string ElementText(this IWebDriver driver, By by) =>
        GetElement(driver, by, TimeSpan.FromSeconds(15)).Text;

    public static void ElementClick(this IWebDriver driver, By by) =>
        GetElement(driver, by, TimeSpan.FromSeconds(15)).Click();

    public static void ScrollElementToCenter(this IWebDriver driver, By by) =>
        ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView({inline:\"center\"});",
            GetElement(driver, by));
}
