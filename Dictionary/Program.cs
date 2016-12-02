using System;
using SimpleInjector;
using Dictionary.Views;
using Dictionary.DataAccess;
using Dictionary.ViewModels;
using Moq;
using System.Collections.Generic;

namespace Dictionary
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = Bootstrap();
            try
            {
                var app = new App();
                var window = container.GetInstance<MainWindow>();
                app.Run(window);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Container Bootstrap()
        {
            var container = new Container();
            container.Register<IGlossaryRepository, GlossaryRepository>(Lifestyle.Transient);
            container.Register<GlossaryViewModel>();
            container.Register<MainWindow>();
            //Mock<IGlossaryRepository> mock = new Mock<IGlossaryRepository>();
            //mock.Setup(o => o.Items).Returns(new List<Glossary>()
            //{
            //    new Glossary() { Definition = "test1", Term = "Test1" },
            //    new Glossary() { Definition = "test2", Term = "Test2" },
            //    new Glossary() { Definition = "test3", Term = "Test3" },
            //    new Glossary() { Definition = "test4", Term = "Test4" },
            //    new Glossary() { Definition = "test5", Term = "Test5" },
            //    new Glossary() { Definition = "test6", Term = "Test6" },
            //});
            //container.Register<IGlossaryRepository>(() => mock.Object, Lifestyle.Transient);
            container.Verify();
            return container;
        }
    }
}