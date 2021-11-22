using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace myCSharpGmail.BaseClass
{
    public class BaseTest
    {

        public WebDriver driver = new ChromeDriver();


        [OneTimeSetUp]
        public void setUp()
        {
            driver.Url = "https://mail.google.com/";
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            driver.Quit();
        }


    }
}
