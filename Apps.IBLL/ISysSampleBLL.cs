using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;
using Apps.Common;
using Apps.Models.sys;

namespace Apps.IBLL
{
    public interface ISysSampleBLL
    {
        List<SysSampleModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysSampleModel model);
        bool Delete(string id);
        bool Edit(SysSampleModel entity);
        bool IsExists(string id);
        SysSampleModel GetById(string id);
        bool IsExist(string id);
    }
}
