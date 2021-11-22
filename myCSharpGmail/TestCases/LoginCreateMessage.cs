using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myCSharpGmail.PageObjects;
using myCSharpGmail.BaseClass;
using NUnit.Framework;
using StackExchange.Redis;

namespace myCSharpGmail.TestCases
{
	[TestFixture]
	public class LoginCreateMessage : BaseTest
	{
		[Test, Order(1)]
		public void LoginGmail()
		{

			LoginPage lp = new LoginPage(driver);
			bool result = lp.gmailHomePage();
			Assert.True(result);
	}


		[Test, Order(2)]
		public void composeTest()
		{

			HomePage hp = new HomePage(driver);
			bool result = hp.composeTest();
			Assert.True(result);
		}


		[Test, Order(3)]
		public void verifyMail()
		{

		HomePage hp = new HomePage(driver);
		bool result = hp.verifyMail();
		Assert.True(result);
		}
	 
    }
}
