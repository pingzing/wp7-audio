using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Shell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Phone.Testing;


namespace AudioRecorderUnitTests
{
    [TestClass]
    public class MainPageTest : WorkItemTest
    {
        [TestMethod]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true, "This method will always pass.");
        }

        [TestMethod]
        [Description("Should always have this. Check if MainPage is created without problems.")]
        public void CheckMainPageNotNull()
        {
            AudioRecorder.MainPage recorder = new AudioRecorder.MainPage();
            Assert.IsNotNull(recorder);
        }

    }
}
