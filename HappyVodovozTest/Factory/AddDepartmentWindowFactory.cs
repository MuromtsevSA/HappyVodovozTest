using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class AddDepartmentWindowFactory: IAddDepartmentWindow
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public AddDepartmentWindowFactory(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
        }

        public AddDepartmentWindow Create()
        {
            return new AddDepartmentWindow(_db, _closeWindow);
        }
    }
}
