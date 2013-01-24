using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class ModelUser:IModelUser
    {
       

        public string GetUserName()
        {
            return "Nicholaspei";
        }
    }
}