using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using msix.catalog.tests.Screens.Alarms;

namespace msix.catalog.tests.Behaviors
{
    [TestClass]
    public class AlarmsAndClockTests
    {
        private static TestContext _context;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _context = context;

            // start appium windows app driver
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // kill appim windows app driver
            var processes = Process.GetProcesses();

            foreach (var process in Process.GetProcessesByName("WinAppDriver"))
            {
                process.Kill();
            }
        }


        [TestMethod]
        public void AddAlarmMakeSureEnabledTest()
        {
            var alarmsAndClock = new AlarmsAndClock();

            var goodMorningAlarm = alarmsAndClock.LaunchApp()
                .ClickAlarmMenuItem()
                .AddNewAlarm()
                .SetHour(10)
                .SetMinute("00")
                .SetAmPm("PM")
                .SetAlarmName("Good morning!!!")
                .ClickSaveAlarm()
                .GetAlarm("Good morning!!!, ‎10‎:‎00‎ ‎PM, Only once, On");

            Assert.IsTrue(goodMorningAlarm.IsToggleOn(), "alarm toggle should be selected");


        }

        [TestMethod]
        public void TestMethod2()
        {
            System.Console.WriteLine("Ok");
        }

    }
}
