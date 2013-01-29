using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class NewModelCar:IModelCar
    {
        public string GetCarName()
        {
            return "new car name";
        }
    }
}