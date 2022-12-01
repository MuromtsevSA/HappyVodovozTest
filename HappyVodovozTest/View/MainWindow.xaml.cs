using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using HappyVodovozTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HappyVodovozTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContext _db;
        private IAddDepartmentWindow _addDepartment;
        private IAddPersonWindowFactory _addPerson;
        private IAddOrderWindowFactory _addOrder;
        private IEditDepartmentWindowFactory _editDepartment;
        private IEditOrderWindowFactory _editOrder;
        private IEditPersonWindowFactory _editPerson;
        private ICloseWindow _closeWindow;
        public MainWindow(IContext db,
            IAddDepartmentWindow addDepartment, 
            IAddPersonWindowFactory addPerson,
            IAddOrderWindowFactory addOrder,
            IEditDepartmentWindowFactory editDepartment,
            IEditOrderWindowFactory editOrder,
            IEditPersonWindowFactory editPerson,
            ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
            _addDepartment = addDepartment;
            _addOrder = addOrder;
            _addPerson = addPerson;
            _editDepartment = editDepartment;
            _editOrder = editOrder;
            _editPerson = editPerson;
            DataContext = new MainViewModel(_db, _addDepartment, _addPerson, _addOrder, _editDepartment, _editOrder, _editPerson, _closeWindow);
            InitializeComponent();
            
        }
    }
}
