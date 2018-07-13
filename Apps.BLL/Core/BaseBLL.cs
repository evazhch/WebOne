using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL.Core
{
    public class BaseBLL : IDisposable
    {
        //用base类去做统一的实例化
        private AppsDBEntities _entity = new AppsDBEntities();

        public AppsDBEntities entity
        {
            get { return _entity; }
        }

        public void Dispose()
        {
            ((IDisposable)_entity).Dispose();
        }
    }
}
