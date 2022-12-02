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
    public class EditDepartmentViewModel: ViewModelBase
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        private int _selectedIndexDepartmen;
        private string _departmentName;
        private ICommand _editDepartmentCommand;
        private ObservableCollection<Department> _departments;

        public ICommand EditDepartmentCommand => _editDepartmentCommand ?? (_editDepartmentCommand = new RelayCommand(EditDepartment));

        public string DepartmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
                OnPropertyChanged("DepartmentName");
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

        public int SelectedIndexDepartmen
        {
            get { return _selectedIndexDepartmen; }
            set
            {
                _selectedIndexDepartmen = value;
                OnPropertyChanged("DepartmentIndex");
            }
        }



        public EditDepartmentViewModel(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _db.Departments.Load();
            Departments = _db.Departments.Local.ToObservableCollection();
            _closeWindow = closeWindow;
        }


        public void EditDepartment()
        {
            if (_db != null)
            {
                var department = _db.Departments.FirstOrDefault(x => x.Id == _selectedIndexDepartmen);
                if (department != null)
                {
                    department.Name = _departmentName;
                }
                ((Context)_db).SaveChangesAsync();
            }
        }
    }
}
