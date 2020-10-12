using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Utility
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId, string role, string name);
    }

}
