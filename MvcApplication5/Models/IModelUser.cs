using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication5.Models
{
    public interface IModelUser:IDependency
    {
        string GetUserName();
    }
}
