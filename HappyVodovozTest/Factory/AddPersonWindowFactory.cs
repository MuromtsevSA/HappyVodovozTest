using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class AddPersonWindowFactory : IAddPersonWindowFactory
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public AddPersonWindowFactory(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
        }

        public AddPersonWindow Create()
        {
            return new AddPersonWindow(_db, _closeWindow);
        }
    }
}
