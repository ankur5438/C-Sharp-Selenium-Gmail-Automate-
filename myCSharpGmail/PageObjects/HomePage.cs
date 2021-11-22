using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using myCSharpGmail.BaseClass;
using SeleniumExtras;
using myCSharpGmail.TestUtilities;
using myCSharpGmail.Constants;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace myCSharpGmail.PageObjects
{
    public class HomePage 
    {
        //Compose Button to compose a message
        [FindsBy(How = How.XPath, Using = "//div[text() =\"Compose\"]")]
		private IWebElement composeButton { get; set; }


		//Recipient Box while composing mail

		string recipientB = "//textarea[@name='to']";
        [FindsBy(How = How.XPath, Using = "//textarea[@name='to']")]
		private
		IWebElement recipientBox { get; }

		//Subject Input Box while composing mail
		[FindsBy(How = How.XPath, Using = "//input[@name=\"subjectbox\"]")]
		private
		IWebElement subjectInput { get; set; }

		//Body Text while composing mail
		[FindsBy(How = How.XPath, Using = "//div[@aria-label=\"Message Body\"]")]
		private
		IWebElement bodyText { get; set; }

		//Compose Send Button while composing mail

		[FindsBy(How = How.XPath, Using = "//div[text() =\"Send\"]")]
		private
		IWebElement sendButton { get; set; }



		//Sent Message Text
		string sentMsg = "//*[contains(text(),'Message sent')]";
		[FindsBy(How = How.XPath, Using = "//*[contains(text(),'Message sent')]")]
		private
		IWebElement sentMessage { get; set; }

		

		//All Inbox Emails List

		[FindsBy(How = How.XPath, Using = "//div[@class=\"Cp\"]/div/table/tbody/tr")]
		public
		IList <IWebElement> allEmails { get; set; }

		//Subject of Email after opening a mail
		string subjectHead = "//div[@class=\"ha\"]/h2";

		[FindsBy(How = How.XPath, Using = "//div[@class=\"ha\"]/h2")]
		private
		IWebElement subjectHeading { get; set; }



		//All Emails on First page

		[FindsBy(How = How.XPath, Using = "//div[@class=\"J-J5-Ji amH J-JN-I\"]/span/span[2]")]
		private
		IWebElement numberOfEmails { get; set; }


		//Check Star Icon for Opened Mail	

		[FindsBy(How = How.XPath, Using = "//tbody/tr[@class=\"acZ\"]//div/div")]
		private
		IWebElement starIconCheck { get; set; }

		//Move to Button in a EMail

		[FindsBy(How = How.XPath, Using = "//div[@class=\"iH bzn\"]//div[@class=\"T-I J-J5-Ji T-I-Js-IF mA ns T-I-ax7 L3\"]")]
		private
		IWebElement moveToBtn { get; set; }

		//More Button in SideNavbar
		[FindsBy(How = How.XPath, Using = "//span[@class=\"CJ\" and  text()=\"More\"]")]
		private
		IWebElement moreBtn { get; set; }


        WebDriver driver;
        WebDriverWait wait;
		String totalEmails;
		public int random;
		String composeSubject = "HELLO I AM AUTOMATED SUBJECT 766877";





        public HomePage(WebDriver rdriver)

        {

			driver = rdriver;
			PageFactory.InitElements(rdriver, this);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

		}


		public bool composeTest()
		{

			totalEmails = numberOfEmails.GetAttribute("innerHTML");
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class=\"Cp\"]/div/table/tbody/tr")));
			TestUtility.ClickOn(driver, composeButton, Constants.Constants.EXPLICIT_WAIT);
			
			Thread.Sleep(1000);
			TestUtility.SendKeys(driver, recipientB, Constants.Constants.EXPLICIT_WAIT, "ankur.huria2@gmail.com");
		
			subjectInput.SendKeys(composeSubject);
	
			bodyText.SendKeys(Constants.Constants.COMPOSE_BODY);
		
			sendButton.Click();
		
			wait.Until(ExpectedConditions.ElementExists(By.XPath(sentMsg)));
			
			return sentMessage.Text.Contains("Message sent");

	}



	public bool verifyMail()
	{
		bool result = false;
			Thread.Sleep(4000);
		foreach (IWebElement email in allEmails)
		{
			if (email.Displayed && email.Text.Contains(composeSubject))
			{
				email.Click();
			
				wait.Until(ExpectedConditions.ElementExists(By.XPath(subjectHead)));
				result = subjectHeading.Text.Equals(composeSubject);
				break;

			}
		}

		return result;
	}


    }
}
