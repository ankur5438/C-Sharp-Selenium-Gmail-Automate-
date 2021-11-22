using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using myCSharpGmail.Constants;
using myCSharpGmail.TestUtilities;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace myCSharpGmail.PageObjects
{
    internal class LoginPage
    {
		[FindsBy(How = How.Id, Using = "identifierId")]
			private
			IWebElement emailInput { get; set; }

		//Email Next Button

		[FindsBy(How = How.XPath, Using = "//div[@id=\"identifierNext\"]/div/button")]
			private
			IWebElement emailNextButton { get; set; }


		//Password Input Box
		string passwordI = "//input[@name=\"password\"]";
		[FindsBy(How = How.XPath, Using = "//input[@name=\"password\"]")]
			private
			IWebElement passwordInput { get; set; }

		//Next button for password

		[FindsBy(How=How.XPath,Using = "//div[@id=\"passwordNext\"]/div/button")]
			private
			IWebElement passwordNextButton { get; set; }




		//composeButton

		[FindsBy(How= How.XPath, Using = "//div[@id=\":32\"]/div/div")]
			private	
			IWebElement composeButton { get; set; }



		WebDriver driver;
		WebDriverWait wait;
        readonly int timeOut = Constants.Constants.EXPLICIT_WAIT;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public LoginPage(WebDriver rdriver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

			driver = rdriver;
			PageFactory.InitElements(rdriver, this);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));


		}


		public void login()
		{

			
			emailInput.SendKeys("ankur.huria2@gmail.com");
			
			TestUtility.ClickOn(driver, emailNextButton, timeOut);
		
			TestUtility.SendKeys(driver, passwordI, timeOut, "9988995249#");
			
			TestUtility.ClickOn(driver, passwordNextButton, timeOut);
		
			wait.Until(ExpectedConditions.TitleContains(Constants.Constants.HOME_PAGE_TITLE));

		}


		public bool gmailHomePage()
		{

			login();
			String title = driver.Title;
			bool isloginTitle = title.Contains(Constants.Constants.HOME_PAGE_TITLE);
			return isloginTitle;

		}

}
}
