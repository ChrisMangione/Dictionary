using System.Collections.Generic;
using System.Linq;

namespace Dictionary.DataAccess
{
    //This class will implement the data store. Will require editing of the methods
    public class GlossaryRepository : IGlossaryRepository
    {
        public IList<Glossary> Items { get; set; }

        public void Add(Glossary item)
        {
            Items.Add(item);
        }

        public void Add(Glossary item, int index)
        {
            Items.Insert(index, item);
            Items.RemoveAt(index + 1);
        }

        public void Delete(Glossary item)
        {
            Items.Remove(item);
        }

        public IList<Glossary> SortList()
        {
            Items = Items.OrderBy(o => o.Term).ToList();
            return Items;
        }

        public IList<Glossary> Update()
        {
            return Items;
        }
    }
}
