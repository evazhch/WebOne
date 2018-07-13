using Apps.Models.sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IBLL
{
    public interface ISysUserBLL
    {
        List<permModel> GetPermission(string accountid, string controller);

    }
}
