﻿using Apps.BLL;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.Common;
using Apps.IBLL;
using Microsoft.Practices.Unity;
using Apps.Models.sys;
using WebOne.Core;

namespace WebOne.Controllers
{
    public class SysSampleController : BaseController
    {
        //
        // GET: /SysSample/
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }
        ValidationErrors errors = new ValidationErrors();


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager,string queryStr)
        {
            List<SysSampleModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysSampleModel()
                        {

                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,

                        }).ToArray()

            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(1, "插入成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "插入失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 修改

        public ActionResult Edit(string id)
        {

            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]

        public JsonResult Edit(SysSampleModel model)
        {


            if (m_BLL.Edit(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 详细
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(id))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion
        

    }
}
    