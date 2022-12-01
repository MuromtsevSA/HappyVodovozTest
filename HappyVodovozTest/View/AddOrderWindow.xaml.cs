using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
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
using System.Windows.Shapes;

namespace HappyVodovozTest.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public AddOrderWindow(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
            DataContext = new AddOrderViewModel(_db, _closeWindow);
            InitializeComponent();
        }
    }
}
