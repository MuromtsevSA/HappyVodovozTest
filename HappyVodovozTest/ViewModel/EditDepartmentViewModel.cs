using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.ViewModel
{
    public class EditDepartmentViewModel
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;

        public EditDepartmentViewModel(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
        }
    }
}
