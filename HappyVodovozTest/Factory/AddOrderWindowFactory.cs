using HappyVodovozTest.Model;
using HappyVodovozTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyVodovozTest.Factory
{
    public class AddOrderWindowFactory: IAddOrderWindowFactory
    {
        private readonly IContext _db;
        private ICloseWindow _closeWindow;
        public AddOrderWindowFactory(IContext db, ICloseWindow closeWindow)
        {
            _db = db;
            _closeWindow = closeWindow;
        }

        public AddOrderWindow Create()
        {
            return new AddOrderWindow(_db, _closeWindow);
        }
    }
}
