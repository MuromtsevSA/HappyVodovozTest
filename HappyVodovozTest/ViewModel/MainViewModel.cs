using HappyVodovozTest.Commands;
using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HappyVodovozTest.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private readonly IContext _db;
        private readonly IAddDepartmentWindow _department;
        private readonly IAddPersonWindowFactory _person;
        private readonly IAddOrderWindowFactory _order;
        private readonly IEditDepartmentWindowFactory _editDepartment;
        private readonly IEditOrderWindowFactory _editOrder;
        private readonly IEditPersonWindowFactory _editPerson;
        private ICloseWindow _closeWindow;

        private ICommand _openWindowAddDepartmentCommand;
        private ICommand _openWindowAddOrderCommand;
        private ICommand _openWindowAddPersonCommand;
        private ICommand _openWindowEditDepartmentCommand;
        private ICommand _openWindowEditOrderCommand;
        private ICommand _openWindowEditPersonCommand;

        public ICommand OpenWindowAddDepartmentCommand => _openWindowAddDepartmentCommand ?? (_openWindowAddDepartmentCommand = new RelayCommand(OpenWindowAddDepartment));
        public ICommand OpenWindowAddOrderCommand => _openWindowAddOrderCommand ?? (_openWindowAddOrderCommand = new RelayCommand(OpenWindowAddOrder));
        public ICommand OpenWindowAddPersonCommand => _openWindowAddPersonCommand ?? (_openWindowAddPersonCommand = new RelayCommand(OpenWindowAddPerson));
        public ICommand OpenWindowEditDepartmentCommand => _openWindowEditDepartmentCommand ?? (_openWindowEditDepartmentCommand = new RelayCommand(OpenWidndowEditDepartment));
        public ICommand OpenWindowEditOrderCommand => _openWindowEditOrderCommand ?? (_openWindowEditOrderCommand = new RelayCommand(OpenWidndowEditOrder));
        public ICommand OpenWindowEditPersonCommand => _openWindowEditPersonCommand ?? (_openWindowEditPersonCommand = new RelayCommand(OpenWidndowEditPerson));

        private ObservableCollection<Person> _persons;
        private ObservableCollection<Department> _departments;
        private ObservableCollection<Order> _orders;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public ObservableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged("Departments");
            }
        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public MainViewModel(IContext db,
            IAddDepartmentWindow department,
            IAddPersonWindowFactory person,
            IAddOrderWindowFactory order,
            IEditDepartmentWindowFactory editDepartment,
            IEditOrderWindowFactory editOrder,
            IEditPersonWindowFactory editPerson,
            ICloseWindow closeWindow)
        {
            _db = db;
            _db.Persons.Load();
            _db.Departments.Load();
            _db.Orders.Load();
            Orders = _db.Orders.Local.ToObservableCollection();
            Departments = _db.Departments.Local.ToObservableCollection();
            Persons = _db.Persons.Local.ToObservableCollection();
            _department = department;
            _person = person;
            _order = order;
            _editDepartment = editDepartment;
            _editOrder = editOrder;
            _editPerson = editPerson;
            _closeWindow = closeWindow;
        }

        public void OpenWindowAddDepartment()
        {
            _department.Create().Show();
        }

        public void OpenWindowAddPerson()
        {
            _person.Create().Show();
        }

        public void OpenWindowAddOrder()
        {
            _order.Create().Show();
        }

        public void OpenWidndowEditDepartment()
        {
            _editDepartment.Create().Show();
        }
        public void OpenWidndowEditOrder()
        {
            _editOrder.Create().Show();
        }
        public void OpenWidndowEditPerson()
        {
            _editPerson.Create().Show();
        }
    }
}
