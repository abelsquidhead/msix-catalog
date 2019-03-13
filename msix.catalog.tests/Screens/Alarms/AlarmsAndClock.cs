using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msix.catalog.tests.Screens.Alarms
{
    public class AlarmsAndClock
    {
        private WindowsDriver<WindowsElement> _alarmAndClockApp;

        public AlarmsAndClock LaunchApp()
        {


            // launch windows store app
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
            _alarmAndClockApp = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            return this;
        }

        public AlarmScreen ClickAlarmMenuItem()
        {
            var alarmMenuItem = _alarmAndClockApp.FindElementByName("Alarm");
            alarmMenuItem.Click();

            try
            {
                var alarmScreen = _alarmAndClockApp.FindElementByAccessibilityId("AlarmListView");
                return new AlarmScreen(alarmScreen, _alarmAndClockApp);
            }
            catch (Exception)
            {
                return new AlarmScreen(null, _alarmAndClockApp);
            }

        }

        public WindowsDriver<WindowsElement> GetTopLevelWindow()
        {
            return _alarmAndClockApp;
        }

        public void SetTopLevelWindow(WindowsDriver<WindowsElement> driver)
        {
            _alarmAndClockApp = driver;
        }

    }
}
