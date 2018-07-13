﻿using Apps.IDAL;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public class SysExceptionRepository : IDisposable, ISysExceptionRepository
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<SysException> GetList(AppsDBEntities db)
        {
            IQueryable<SysException> list = db.SysException.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(SysException entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysException.Add(entity);
                return db.SaveChanges();
            }

        }


        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysException GetById(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                return db.SysException.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }

}
