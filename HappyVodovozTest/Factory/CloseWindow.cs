using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HappyVodovozTest.Factory
{
    public interface ICloseWindow
    {
        void Close();
    }
    public class CloseWindow : ICloseWindow
    {
        public void Close()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }
    }
}
