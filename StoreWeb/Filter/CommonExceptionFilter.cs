﻿using StoreWeb.Core;
using StoreWeb.Core.Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StoreWeb
{
    public class CommonExceptionFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }
            StringBuilder error = new StringBuilder();
            var enter = Environment.NewLine;
            error.Append(enter);
            error.Append("发生时间:" + DateTime.Now);
            error.Append(enter);
            error.Append("用户IP:" + WebHelper.GetClientIP());
            error.Append(enter);
            error.Append("发生异常页: " + filterContext.HttpContext.Request.Url);
            error.Append(enter);

            error.Append("控制器: " + filterContext.RouteData.Values["controller"]);
            error.Append(enter);

            error.Append("Action: " + filterContext.RouteData.Values["action"]);
            error.Append(enter);

            Logger.Log(error.ToString(), filterContext.Exception);
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var data = new
                {
                    flag = false,
                    data = string.Empty,
                    msg = filterContext.Exception.Message
                };
                filterContext.Result = new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                var errorMsg = typeof(SqlException) == ExceptionType ? "数据库异常" : filterContext.Exception.Message;

                var view = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = { ["Error"] = errorMsg }
                };
                filterContext.Result = view;
            }

            filterContext.ExceptionHandled = true;
        }
    }
}