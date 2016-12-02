using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Dictionary.DataAccess;

namespace Dictionary.ViewModels
{
    public sealed class GlossaryViewModel : BaseViewModel
    {
        public readonly IGlossaryRepository GlossaryRepository;
        private ObservableCollection<Glossary> _items;
        private int? _listIndex = null;


        public GlossaryViewModel(IGlossaryRepository glossaryRepository)
        {
            if (glossaryRepository.Items == null)
                glossaryRepository.Items = new List<Glossary>();
            GlossaryRepository = glossaryRepository;
            _items = new ObservableCollection<Glossary>(GlossaryRepository.Items);
            Items = _items;
            GenerateCommands();
        }

        #region Properties

        public IList<Glossary> Items
        {
            get { return _items; }
            set
            {
                if (value != _items)
                {
                    _items = new ObservableCollection<Glossary>(value);
                    OnPropertyChanged("Items");
                }
            }
        }

        private Glossary _selectedItem;

        public Glossary SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    if (value != null)
                    {
                        Definition = value.Definition;
                        Term = value.Term;
                    }
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        private string _term;

        public string Term
        {
            get { return _term; }
            set
            {
                if (value != _term)
                {
                    _term = value;
                    SelectedItem.Term = value;
                    OnPropertyChanged("Term");
                }
            }
        }

        private string _definition;

        public string Definition
        {
            get { return _definition; }
            set
            {
                if (value != _definition)
                {
                    _definition = value;
                    SelectedItem.Definition = value;
                    OnPropertyChanged("Definition");
                }
            }
        }

        private bool _editing = false;

        public bool Editing
        {
            get { return _editing; }
            set
            {
                if (value != _editing)
                {
                    _editing = value;
                    OnPropertyChanged("Editing");
                }
            }
        }

        #endregion Properties

        public void GenerateCommands()
        {
            DeleteCommand = new RouteCommand(o => Delete());
            EditCommand = new RouteCommand(o => Edit());
            NewCommand = new RouteCommand(o => New());
            AddCommand = new RouteCommand(o => Add());
        }

        public void Sort()
        {
            Items = GlossaryRepository.SortList();
        }

        private bool NotEmpty(string term, string definition)
        {
            return term != null && definition != null;
        }

        private void New()
        {
            Editing = true;
            SelectedItem = new Glossary();
        }

        public void Add()
        {
            if (NotEmpty(_selectedItem.Term, _selectedItem.Definition))
            {
                if (_listIndex == null)
                {
                    GlossaryRepository.Add(SelectedItem);
                }
                else
                {
                    GlossaryRepository.Add(SelectedItem, (int)_listIndex);
                    _listIndex = null;
                }
                Items = GlossaryRepository.Items;
                Editing = false;
            }
            else
            {
                MessageBox.Show("Field is empty", "Notice");
            }
            Sort();
        }

        public void Edit()
        {
            if (SelectedItem != null)
            {
                Editing = true;
                _listIndex = _items.IndexOf(SelectedItem);
            }
            else
            {
                MessageBox.Show("No item selected", "Notice");
            }
        }

        public void Delete()
        {
            if (_selectedItem != null)
            {
                GlossaryRepository.Delete(SelectedItem);
                Items = GlossaryRepository.Items;
            }
            else
            {
                MessageBox.Show("No item selected", "Notice");
            }
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand NewCommand { get; set; }
    }
}
