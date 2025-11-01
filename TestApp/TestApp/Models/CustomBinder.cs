using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Models
{
    public class CustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string Id = controllerContext.HttpContext.Request.Form["id"];
            string Name = controllerContext.HttpContext.Request.Form["Name"];
            string Address1 = controllerContext.HttpContext.Request.Form["Address1"];
            string Address2 = controllerContext.HttpContext.Request.Form["Address2"];
            string City = controllerContext.HttpContext.Request.Form["City"];

            return new Student()
            {
                 Id=int.Parse(Id),
                 Name=Name,
                 Address = Address1 + ", " + Address2 + ", " + City,
            };
        }
    }
}