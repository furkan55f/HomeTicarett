using HomeTicaretCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeTicaret
{
    public class AppControllerBase : Controller
    {
        //Kullanıcı Login Kontrolü
        public bool IsLogin { get; private set; }
        //Giriş yapmış kişinin ID'si
        public int LoginUserID { get; private set; }
        //Login User Entity
        public User LoginUserEntity { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            //Session["LoginUseID"]
            //Session["LoginUser"] 
            if (requestContext.HttpContext.Session["LoginUseID"] != null)
            {
                //Kullanıcı giriş yapmışsa
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUseID"];
                LoginUserEntity = (HomeTicaretCore.Entity.User)requestContext.HttpContext.Session["LoginUser"];

            }
            base.Initialize(requestContext);
        }
    }
}