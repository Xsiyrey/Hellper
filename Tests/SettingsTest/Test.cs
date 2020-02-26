using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hellper.Models;
using Hellper.Attributes;

namespace Tests.SettingsTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            CSettings settings = new CSettings();
            bool stringChangeResult = settings.ChangeProperty("Slava", nameof(settings.Name));
            bool intChangeResult = settings.ChangeProperty(20, nameof(settings.Age));
            int a = 5;
            Assert.IsTrue(stringChangeResult && intChangeResult);
        }
    }

    public class CSettings : BaseSettingParams
    {
        [SettingsPropertyAttribute]
        public string Name { get; set; }
        [SettingsPropertyAttribute]
        public int Age { get; set; }
        public string TestNotSetting {get;set;}
    }
}
