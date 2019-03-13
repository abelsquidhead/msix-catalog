using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msix.catalog.tests.Screens.Alarms
{
    public class Alarm : AlarmsAndClock
    {
        private AppiumWebElement _alarm;

        public Alarm(AppiumWebElement alarm, WindowsDriver<WindowsElement> driver)
        {
            _alarm = alarm;
            this.SetTopLevelWindow(driver);
        }

        public EditAlarmScreen SelectAlarm()
        {
            _alarm.Click();
            var editAlarmScreen = GetTopLevelWindow().FindElementByAccessibilityId("ScrollContainer");
            return new EditAlarmScreen(editAlarmScreen, this.GetTopLevelWindow());
        }

        public bool IsToggleOn()
        {
            var toggle = _alarm.FindElementByAccessibilityId("AlarmToggleSwitch");


            return toggle.Selected;
        }
    }
}
