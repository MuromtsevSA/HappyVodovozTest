using HappyVodovozTest.Commands;
using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HappyVodovozTest.ViewModel
{
    public class AddDepartmentViewModel: ViewModelBase
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        private string _departmentName;
        private ICommand _addDepartmentCommand;
        private ICommand _closeCommand;

        public ICommand AddDepartmentCommand => _addDepartmentCommand ?? (_addDepartmentCommand = new RelayCommand(AddDepartment));
        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(CloseWindow));
        public string DepartmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
                OnPropertyChanged("Name");
            }
        }

        public AddDepartmentViewModel(IContext db, ICloseWindow closeWindow)
        {
            _closeWindow = closeWindow;
            _db = db;
        }

        public void AddDepartment()
        {
            if (_db != null)
            {
                if (_departmentName != string.Empty)
                {
                    var department = new Department { Name = _departmentName };
                    if (department != null)
                    {
                        _db.Departments.Add(department);
                        ((Context)_db).SaveChanges();
                        _closeWindow.Close();
                    }
                }
            }
        }

        public void CloseWindow()
        {
            _closeWindow.Close();
        }
    }
}
