using System.Collections.Generic;
using SimpleInjector.Diagnostics;

namespace Dictionary.DataAccess
{
    public interface IGlossaryRepository
    {
        IList<Glossary> Items { get; set; }

        void Add(Glossary item);

        void Add(Glossary item, int index);

        void Delete(Glossary item);

        IList<Glossary> SortList();

        IList<Glossary> Update();
    }
}
