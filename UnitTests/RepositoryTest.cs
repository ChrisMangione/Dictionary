using System;
using SimpleInjector;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dictionary.DataAccess;
using Dictionary.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void GlossaryRepository_AddGlossaryItem()
        {
            Mock<IGlossaryRepository> mock = new Mock<IGlossaryRepository>();
            mock.Setup(o => o.Items).Returns(new List<Glossary>()
            {
                new Glossary() { Definition = "test1", Term = "Test1" },
                new Glossary() { Definition = "test2", Term = "Test2" }
            });
            GlossaryRepository gr = new GlossaryRepository();
            gr.Items = mock.Object.Items;
            gr.Add(new Glossary() { Definition = "test3", Term = "Test3" });

            Assert.IsTrue(gr.Items.Count == 3);
        }

        [TestMethod]
        public void GlossaryRepository_DeleteGlossaryItem()
        {
            Mock<IGlossaryRepository> mock = new Mock<IGlossaryRepository>();
            var item = new Glossary() { Definition = "test3", Term = "Test3" };
            mock.Setup(o => o.Items).Returns(new List<Glossary>()
            {
                new Glossary() { Definition = "test1", Term = "Test1" },
                item
            });
            GlossaryRepository gr = new GlossaryRepository();
            gr.Items = mock.Object.Items;
            Assert.IsTrue(gr.Items.Count == 2);
            gr.Delete(item);
            Assert.IsTrue(gr.Items.Count == 1);
        }

        [TestMethod]
        public void GlossaryRepository_SortGlossaryItems()
        {
            Mock<IGlossaryRepository> mock = new Mock<IGlossaryRepository>();
            mock.Setup(o => o.Items).Returns(new List<Glossary>()
            {
                new Glossary() { Definition = "test1", Term = "Test1" },
                new Glossary() { Definition = "test2", Term = "Test2" },
                new Glossary() { Definition = "x", Term = "a" }
            });
            GlossaryRepository gr = new GlossaryRepository();
            gr.Items = mock.Object.Items;
            gr.SortList();
            Assert.IsTrue(gr.Items.Count == 3);
            Assert.IsTrue(gr.Items[0].Term == "a");
        }
    }
}
