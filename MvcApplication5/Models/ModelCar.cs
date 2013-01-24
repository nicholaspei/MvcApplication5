using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class ModelCar:IModelCar
    {
       
        public string GetCarName()
        {
            return "Benz S350";
        }
    }
}