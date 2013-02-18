using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioRecorderTests
{
    [TestClass]
    public class MPTests : SilverlightTest
    {
        [TestMethod]
        public void AlwaysPass()
        {
            Assert.IsTrue(true, "Method always passes.");
        }

        [TestMethod]
        [Description("Tests to see if MainPage gets created successfully.")]
        public void CheckMainPageNotNull()
        {
            AudioRecorder.MainPage testPage = new AudioRecorder.MainPage();
            Assert.IsNotNull(testPage);
        }

        [TestMethod]
        [Description("Checks to see if the SavedItem list is populated properly.")]
        [Tag("debug")]
        public void CheckSavedItemListNotNull()
        {
            AudioRecorder.MainPage testPage = new AudioRecorder.MainPage();
            Assert.IsNotNull(testPage.savedItemsList);
        }

        [TestMethod]
        [Description("Checks to see if the first item in SavedItemsList is a SavedAudio.")]
        public void CheckIfItemIsSavedAudio()
        {
            AudioRecorder.ViewModels.MainPageViewModel testPage = new AudioRecorder.ViewModels.MainPageViewModel();
            Assert.IsTrue(testPage.ListItemsSource[0] is AudioRecorder.SavedAudio);
        }
    }
}
