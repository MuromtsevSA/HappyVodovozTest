using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class EditDepartmentWindowFactory : IEditDepartmentWindowFactory
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public EditDepartmentWindowFactory(IContext db, ICloseWindow closeWindow) 
        {
            _closeWindow = closeWindow;
            _db = db;
        }
        public EditDepartmentWindow Create()
        {
            return new EditDepartmentWindow(_db, _closeWindow);
        }
    }
}
