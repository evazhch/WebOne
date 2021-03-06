﻿using Apps.IDAL;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        public SysUser Login(string username, string pwd)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                SysUser user = db.SysUser.SingleOrDefault(a => a.UserName == username && a.Password == pwd);
                return user;
            }
        }
        public void Dispose()
        {

        }
    }

}
