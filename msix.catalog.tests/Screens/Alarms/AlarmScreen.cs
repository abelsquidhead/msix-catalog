using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msix.catalog.tests.Screens.Alarms
{
    public class AlarmScreen : AlarmsAndClock
    {
        private WindowsElement _alarmScreen;

        public AlarmScreen(WindowsElement alarmScreen, WindowsDriver<WindowsElement> driver)
        {
            _alarmScreen = alarmScreen;
            this.SetTopLevelWindow(driver);
        }

        public bool IsListOfAlarmsPresent()
        {
            return !(_alarmScreen == null);
        }

        public EditAlarmScreen AddNewAlarm()
        {
            var addNewAlarmButton = this.GetTopLevelWindow().FindElementByAccessibilityId("AddAlarmButton");
            addNewAlarmButton.Click();

            var editAlarmScreen = GetTopLevelWindow().FindElementByAccessibilityId("ScrollContainer");

            return new EditAlarmScreen(editAlarmScreen, this.GetTopLevelWindow());

        }

        public Alarm GetAlarm(string alarmName)
        {
            if (!this.IsListOfAlarmsPresent())
            {
                throw new Exception("Could not find list of alarms");
            }

            var alarm = _alarmScreen.FindElementByName(alarmName);

            return new Alarm(alarm, this.GetTopLevelWindow());
        }
    }
}
