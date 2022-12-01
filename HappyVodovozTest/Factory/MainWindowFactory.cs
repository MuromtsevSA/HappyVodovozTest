using HappyVodovozTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class MainWindowFactory: IMainWindowFactory
    {
        private readonly IContext _db;
        private IAddDepartmentWindow _addDepartment;
        private IAddPersonWindowFactory _addPerson;
        private IAddOrderWindowFactory _addOrder;
        private IEditDepartmentWindowFactory _editDepartment;
        private IEditOrderWindowFactory _editOrder;
        private IEditPersonWindowFactory _editPerson;
        private ICloseWindow _closeWindow;


        public MainWindowFactory(IContext db, 
            IAddDepartmentWindow addDepartment, 
            IAddPersonWindowFactory addPerson,
            IAddOrderWindowFactory addOrder,
            IEditDepartmentWindowFactory editDepartment,
            IEditOrderWindowFactory editOrder,
            IEditPersonWindowFactory editPerson,
            ICloseWindow closeWindow
            )
        {
            _db = db;
            _addDepartment = addDepartment;
            _addOrder = addOrder;
            _addPerson = addPerson;
            _editDepartment = editDepartment;
            _editOrder = editOrder;
            _editPerson = editPerson;
            _closeWindow = closeWindow;
        }

        public MainWindow Create()
        {
            return new MainWindow(_db,_addDepartment, _addPerson, _addOrder, _editDepartment, _editOrder, _editPerson, _closeWindow);
        }
    }
}
