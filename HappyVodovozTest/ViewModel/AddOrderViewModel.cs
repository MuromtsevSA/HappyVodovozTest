using HappyVodovozTest.Commands;
using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HappyVodovozTest.ViewModel
{
    public class AddOrderViewModel: ViewModelBase
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        private int _numberOrder;
        private string _productName;
        private int _selectedNamePersonIndex;

        private ICommand _addOrderCommand;

        public ICommand AddOrderCommand => _addOrderCommand ?? (_addOrderCommand = new RelayCommand(AddOrders));

        private ObservableCollection<Person> _persons;

        public int NumberOrder
        {
            get { return _numberOrder; }
            set
            {
                _numberOrder = value;
                OnPropertyChanged("OrderNumber");
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public int SelectedNamePerson
        {
            get { return _selectedNamePersonIndex; }
            set
            {
                _selectedNamePersonIndex = value;
                OnPropertyChanged("SelectedName");
            }
        }
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public AddOrderViewModel(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow= closeWindow;
            _db.Persons.Load();
            Persons = _db.Persons.Local.ToObservableCollection();
        }

        public void AddOrders()
        {
            if (_db != null)
            {
                if (_numberOrder != 0 && _productName != string.Empty)
                {
                    var person = _db.Persons.FirstOrDefault(x => x.Id == _selectedNamePersonIndex + 1).Id;
                    if (person != null)
                    {
                        var order = new Order { Name = _productName, Number = _numberOrder, PersonId = person };
                        if (order != null)
                        {
                            _db.Orders.Add(order);
                            ((Context)_db).SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
