using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridSample
{
    public class ModelManager 
    {
        private static ViewListModel _vlm;
        private ModelManager()
        {
            _vlm = new ViewListModel(); 
        }

        public static ViewListModel GetInstance()
        {
            if (null == _vlm)
            {
                return (_vlm = new ViewListModel());
            }
            return _vlm;
        }
    }
}
