using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Apps.IBLL;
using Apps.Models;
using Apps.IDAL;

namespace Apps.BLL
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        public List<SysModule> GetMenuByPersonId(string personId, string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(personId, moduleId);
        }
    }

}
