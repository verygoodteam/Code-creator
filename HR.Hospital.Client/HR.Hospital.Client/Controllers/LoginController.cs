﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        //public ActionResult LoginDo(Models.Ooperationuser ooperationuser, string returnUrl = null)
        //{
        //    //验证用户是否登录
        //    const string errorMessage = "用户名或密码错误！";
        //    if (ooperationuser == null)
        //    {
        //        return BadRequest(errorMessage);
        //    }
        //    var tmpUser = new UserInfo().GetUserList().FirstOrDefault(m => m.UserName == ooperationuser.OoperationUserName && m.Password == ooperationuser.Pwd);
        //    if (tmpUser?.Password != user.Password)
        //    {
        //        return BadRequest(errorMessage);
        //    }
        //}






















        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
    }
}