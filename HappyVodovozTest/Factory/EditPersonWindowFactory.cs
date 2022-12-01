using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class EditPersonWindowFactory : IEditPersonWindowFactory
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public EditPersonWindowFactory(IContext db, ICloseWindow closeWindow) 
        {
            _db = db;
            _closeWindow = closeWindow;
        }
        public EditPersonWindow Create()
        {
            return new EditPersonWindow(_db, _closeWindow);
        }
    }
}
