using Apps.Models.sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IDAL
{
    public interface ISysRightRepository
    {
        List<permModel> GetPermission(string accountid, string controller);
    }
}
