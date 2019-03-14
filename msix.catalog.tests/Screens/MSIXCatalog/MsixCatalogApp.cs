using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msix.catalog.tests.Screens.MSIXCatalog
{
    public class MsixCatalogApp
    {
        private WindowsDriver<WindowsElement> _msixCatalogApp;


        public MsixCatalogApp LaunchApp(string sourcePath)
        {
            var msixCatalogAppPath = sourcePath + @"\msix.catalog.package.net\bin\x86\Release\msix.catalog.app.net\msix.catalog.app.exe";

            //var msixCatalogAppPath = @"C:\Users\abel\Source\github\AbelSquidHead\msix-catalog\msix.catalog.package.net\bin\AnyCPU\Debug\msix.catalog.app.net\msix.catalog.app.exe";
            
            // launch windows store app
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", msixCatalogAppPath);
            _msixCatalogApp = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            return this;
        }

        
        public MsixCatalogApp KillApp()
        {
            var buttonList = _msixCatalogApp.FindElementsByClassName("Button");

            var closeButton = buttonList[4];
            closeButton.Click();

            return this;

        }

        public AboutScreen ClickAbout()
        {
            var listBoxItemList = _msixCatalogApp.FindElementsByClassName("ListBoxItem");
            var about = listBoxItemList[6];
            about.Click();

            return new AboutScreen(_msixCatalogApp);
        }

        public void SetTopLevelWindow(WindowsDriver<WindowsElement> driver)
        {
            _msixCatalogApp = driver;
        }

        public WindowsDriver<WindowsElement> GetTopLevelWindow()
        {
            return _msixCatalogApp;
        }

    }
}
