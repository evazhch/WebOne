using Apps.BLL.Core;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Models.sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL
{
    public class SysUserBLL : BaseBLL, ISysUserBLL
    {
        [Dependency]
        public ISysRightRepository sysRightRepository { get; set; }
        public List<permModel> GetPermission(string accountid, string controller)
        {
            return sysRightRepository.GetPermission(accountid, controller);
        }


    }

}
