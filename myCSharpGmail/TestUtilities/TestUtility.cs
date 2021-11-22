using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using myCSharpGmail.BaseClass;
using System.Collections.ObjectModel;

namespace myCSharpGmail.TestUtilities
{
    public class TestUtility : BaseTest

    {

        public static void WaitForElementVisible(WebDriver driver, By element, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(ExpectedConditions.ElementIsVisible(element));
			}
		}



		//Visiblity of Element
		public static bool IsElementVisible(IWebElement element)
		{
			return element.Displayed && element.Enabled;
		}

    

	//Explicit Wait to Click on WebElement.
	public static void ClickOn(WebDriver driver, IWebElement element, int timeout)
	{
		new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(element));
		element.Click();
	}

		//Explicit Wait to Send Data to WebElement.
		public static void SendKeys(WebDriver rdriver, string element, int timeout, String value)
	{
			WebDriver driver;
			driver = rdriver;
			new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
			IWebElement ele = (IWebElement)driver.FindElement(By.XPath(element));
			ele.SendKeys(value);
	}

	//Explicit Wait for Element To Be Visible.
	public static void WaitForElementToBeVisible(WebDriver driver, By locator, int timeout)
	{
		new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).
		Until(ExpectedConditions.ElementExists(locator));
	}


	//To Check Element is Displayed or No.
	public static bool isElementDisplayed(IWebElement element)
	{
		bool elementDisplayed = element.Displayed;
		if (elementDisplayed)
		{
				return true;
		}
		else
		{
				return false;
		}
	}



	//To Check Element is Enabled or No.
	public static void isElementEnabled(IWebElement element)
	{
		bool elementEnabled = element.Enabled;
		if (elementEnabled)
		{
			Console.WriteLine("Element is Enabled");
		}
		else
		{
			Console.WriteLine("Element is not Enabled");
		}

	}
    }
}

