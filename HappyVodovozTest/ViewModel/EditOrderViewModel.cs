using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.ViewModel
{
    public class EditOrderViewModel
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        private int _numberOrder;
        private string _productName;

        public EditOrderViewModel(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
        }
    }
}
