using Apps.IDAL;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public class SysLogRepository : IDisposable, ISysLogRepository
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<SysLog> GetList(AppsDBEntities db)
        {
            IQueryable<SysLog> list = db.SysLog.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(SysLog entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysLog.Add(entity);
                return db.SaveChanges();
            }

        }

        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="deleteCollection">集合</param>
        public void Delete(AppsDBEntities db, string[] deleteCollection)
        {
            IQueryable<SysLog> collection = from f in db.SysLog
                                            where deleteCollection.Contains(f.Id)
                                            select f;
            foreach (var deleteItem in collection)
            {
                db.SysLog.Remove(deleteItem);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysLog GetById(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                return db.SysLog.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }

}
