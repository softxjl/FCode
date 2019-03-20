using FCode.Entity;
using FCode.Utility;
using FCode.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCode.Api
{
    public class IndexController : ApiBaseController
    {
        [HttpGet]
        public ReturnResult GetHome()
        {
            var result = new ReturnResult();
            var token = this.GetToken();
            if (token == null) result.msg = "身份无效！";
            var db = new FCodeDbContext();
            //db.Database.CreateIfNotExists();
            db.Users.Add(new User { Name = "Jace夏将龙", Age = 30, Sex = true });
            result.data = db.SaveChanges();
            return result;
        }
    }
}
