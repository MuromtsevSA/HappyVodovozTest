using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using HappyVodovozTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace HappyVodovozTest.View
{
    /// <summary>
    /// Логика взаимодействия для EditPersonWindow.xaml
    /// </summary>
    public partial class EditPersonWindow : Window
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public EditPersonWindow(IContext db, ICloseWindow closeWindow)
        {
            _db= db;
            _closeWindow= closeWindow;
            DataContext = new EditPersonViewModel(_db, _closeWindow);
            InitializeComponent();
        }
    }
}
