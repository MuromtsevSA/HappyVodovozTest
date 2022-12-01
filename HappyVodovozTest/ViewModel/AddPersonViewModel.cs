using HappyVodovozTest.Commands;
using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HappyVodovozTest.ViewModel
{
    public class AddPersonViewModel : ViewModelBase
    {
        private readonly IContext _db;
        private string _personName;
        private string _personSurname;
        private DateTime _personDateBirth;
        private string _personPatronymic;
        private int _selectedGender;
        private int _selectedDepartment;
        private ICloseWindow _closeWindow;
        private ICommand _addPersonCommand;

        public ICommand AddPersonCommand => _addPersonCommand ?? (_addPersonCommand = new RelayCommand(AddPerson));

        private ObservableCollection<Person> _persons;
        private ObservableCollection<Department> _departments;
        private ObservableCollection<String> _gender;

        public string PersonPatronymic
        {
            get { return _personPatronymic; }
            set
            {
                _personPatronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        public int SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged("selectedGender");
            }
        }

        public int SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                _selectedGender = value;
                OnPropertyChanged("selectedGender");
            }
        }

        public string PersonName
        {
            get { return _personName; }
            set
            {
                _personName = value;
                OnPropertyChanged("PersonName");
            }
        }

        public DateTime PersonDateBirth
        {
            get { return _personDateBirth; }
            set
            {
                _personDateBirth = value;
                OnPropertyChanged("DateBirth");
            }
        }

        public string PersonSurName
        {
            get { return _personSurname; }
            set
            {
                _personSurname = value;
                OnPropertyChanged("PersonSurName");
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

        public ObservableCollection<String> Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged("Persons");
            }
        }

        public AddPersonViewModel(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
            _db.Departments.Load();
            _db.Persons.Load();
            Persons = _db.Persons.Local.ToObservableCollection();
            Departments = db.Departments.Local.ToObservableCollection();
            Gender = new ObservableCollection<string> { "Male", "Female" };
        }

        public void AddPerson()
        {
            if (_db != null)
            {
                if (_personName != string.Empty && _personSurname != string.Empty)
                {
                    var person = new Person { Name = _personName, Patromynic = _personPatronymic, Surname = _personSurname, DateOfBirth = _personDateBirth.ToUniversalTime().AddDays(1), Gender = (Model.Gender)_selectedGender, DepartmentId = _selectedDepartment + 1 };
                    if (person != null)
                    {
                        _db.Persons.Add(person);
                        ((Context)_db).SaveChanges();
                    }
                }
            }
        }
    }
}
