using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msix.catalog.tests.Screens.Alarms
{
    public class EditAlarmScreen : AlarmsAndClock
    {
        private WindowsElement _editAlarmScreen;

        public EditAlarmScreen(WindowsElement editAlarmScreen, WindowsDriver<WindowsElement> driver)
        {
            _editAlarmScreen = editAlarmScreen;
            this.SetTopLevelWindow(driver);
        }

        public EditAlarmScreen SetHour(int hour)
        {
            var hourSelector = _editAlarmScreen.FindElementByAccessibilityId("HourLoopingSelector");
            hourSelector.FindElementByName(hour.ToString()).Click();

            return this;
        }

        public EditAlarmScreen SetMinute(string minute)
        {
            var minuteSelector = _editAlarmScreen.FindElementByAccessibilityId("MinuteLoopingSelector");
            minuteSelector.FindElementByName(minute).Click();

            return this;
        }

        public EditAlarmScreen SetAmPm(string amPm)
        {
            var periodSelector = _editAlarmScreen.FindElementByAccessibilityId("PeriodLoopingSelector");
            periodSelector.FindElementByName(amPm).Click();

            return this;
        }

        public EditAlarmScreen SetAlarmName(string name)
        {
            var alarmNameTextBox = _editAlarmScreen.FindElementByAccessibilityId("AlarmNameTextBox");
            alarmNameTextBox.Clear();
            alarmNameTextBox.SendKeys(name);
            return this;
        }

        public AlarmScreen ClickSaveAlarm()
        {
            this.GetTopLevelWindow().FindElementByName("Save").Click();
            var alarmScreen = this.GetTopLevelWindow().FindElementByAccessibilityId("AlarmListView");
            return new AlarmScreen(alarmScreen, this.GetTopLevelWindow());
        }
    }
}
