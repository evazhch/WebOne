using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.Models;
using Apps.IDAL;
using System.Data;
using System.Data.Entity;

namespace Apps.DAL
{
    class SysModuleRepository : IDisposable, ISysModuleRepository
    {
        public int Create(SysModule entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                //db.SysModule.AddObject(entity);
                db.SysModule.Add(entity);
                return db.SaveChanges();
            }

        }

        public void Delete(AppsDBEntities db, string id)
        {
            SysModule entity = db.SysModule.SingleOrDefault(a => a.Id == id);
            if (entity != null)
            {

                //删除SysRight表数据
                var sr = db.SysRight.AsQueryable().Where(a => a.ModuleId == id);
                foreach (var o in sr)
                {
                    //删除SysRightOperate表数据
                    var sro = db.SysRightOperate.AsQueryable().Where(a => a.RightId == o.Id);
                    foreach (var o2 in sro)
                    {
                        db.SysRightOperate.Remove(o2);
                        //db.SysRightOperate.DeleteObject(o2);
                    }
                    //db.SysRight.DeleteObject(o);
                    db.SysRight.Remove(o);
                }
                //删除SysModuleOperate数据
                var smo = db.SysModuleOperate.AsQueryable().Where(a => a.ModuleId == id);
                foreach (var o3 in smo)
                {
                    db.SysModuleOperate.Remove(o3);
                }
                db.SysModule.Remove(entity);
            }

        }

        public int Edit(SysModule entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysModule.Attach(entity);
                //db.SysModule.m
                db.Entry<SysModule>(entity).State = EntityState.Modified;   
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                //db.sta
                return db.SaveChanges();
            }

        }

        public SysModule GetById(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                return db.SysModule.SingleOrDefault(a => a.Id == id);
            }

        }

        public IQueryable<SysModule> GetList(AppsDBEntities db)
        {
            IQueryable<SysModule> list = db.SysModule.AsQueryable();
            return list;

        }

        public IQueryable<SysModule> GetModuleBySystem(AppsDBEntities db, string parentId)
        {
            return db.SysModule.Where(a => a.ParentId == parentId).AsQueryable();
        }

        public bool IsExist(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                SysModule entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~SysModuleRepository() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
