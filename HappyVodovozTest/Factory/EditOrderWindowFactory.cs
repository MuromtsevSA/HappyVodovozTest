using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class EditOrderWindowFactory : IEditOrderWindowFactory
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public EditOrderWindowFactory(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
        }
        public EditOrderWindow Create()
        {
           return new EditOrderWindow(_db, _closeWindow);
        }
    }
}
