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
    public class EditPersonViewModel: ViewModelBase
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        private string _personName;
        private string _personSurname;
        private DateTime _personDateBirth;
        private string _personPatronymic;
        private int _selectedGender;
        private int _selectedDepartment;
        private int _selectedSurName;
        private ICommand _editPersonCommand;
        private ObservableCollection<Person> _persons;
        private ObservableCollection<Department> _departments;


        public ICommand EditPersonCommand => _editPersonCommand ?? (_editPersonCommand = new RelayCommand(EditPerson));

        public int SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged("selectedGender");
            }
        }


        public int SelectedSurName
        {
            get { return _selectedSurName; }
            set
            {
                _selectedSurName = value;
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

        public string PersonSurName
        {
            get { return _personSurname; }
            set
            {
                _personSurname = value;
                OnPropertyChanged("PersonSurName");
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

        public string PersonPatronymic
        {
            get { return _personPatronymic; }
            set
            {
                _personPatronymic = value;
                OnPropertyChanged("Patronymic");
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

        public ObservableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged("Department");
            }
        }

        public EditPersonViewModel(IContext db, ICloseWindow closeWindow)
        {
            _db= db;
            _db.Persons.Load();
            _db.Departments.Load();
            Departments = _db.Departments.Local.ToObservableCollection();
            Persons = _db.Persons.Local.ToObservableCollection();
            _closeWindow= closeWindow;
        }

        public void EditPerson()
        {
            if (_db != null)
            {
                var person = _db.Persons.FirstOrDefault(x => x.Id == _selectedSurName + 1);
                if (person != null)
                {
                    person.Surname = _personSurname == null ? person.Surname : _personSurname;
                    person.Name = _personName == null ? person.Name : _personName;
                    person.Patromynic = _personPatronymic == null ? person.Patromynic : _personPatronymic;
                    person.Gender = (Gender)_selectedGender < 0  ? person.Gender : (Gender)_selectedGender;
                    person.DateOfBirth = _personDateBirth < 0 ? person.DateOfBirth : _personDateBirth.ToUniversalTime().AddDays(1);
                    person.DepartmentId = _selectedDepartment < 0 ? person.DepartmentId : _selectedDepartment + 1;
                }
                ((Context)_db).SaveChangesAsync();
            }
        }
    }
}
