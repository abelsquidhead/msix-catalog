using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msix.catalog.tests.Screens.MSIXCatalog
{
    public class AboutScreen : MsixCatalogApp
    {
        public AboutScreen(WindowsDriver<WindowsElement> driver)
        {
            this.SetTopLevelWindow(driver);
        }

        public AboutScreen AssertTitle(string title)
        {
            var textBlocks = this.GetTopLevelWindow().FindElementsByClassName("TextBlock");
            var titleTextBlock = textBlocks[0];

            Assert.AreEqual(title, titleTextBlock.Text);

            return this;
        }
    }
}
