using Dictionary.DataAccess;
using Dictionary.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    class ViewModelTest
    {
        [TestMethod]
        public void GlossaryViewModel_ItemsUpdated()
        {
            Mock<IGlossaryRepository> mock = new Mock<IGlossaryRepository>();
            mock.Setup(o => o.Items).Returns(new List<Glossary>()
            {
                new Glossary() { Definition = "test1", Term = "Test1" },
                new Glossary() { Definition = "test2", Term = "Test2" }
            });
            GlossaryViewModel gvm = new GlossaryViewModel(mock.Object);
            Assert.IsTrue(gvm.Items.Count == 2);
        }
    }
}
