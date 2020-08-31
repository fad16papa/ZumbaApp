using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZumbaAPI.Repository.Interface
{
    public interface IUserAccessorRepository
    {
        string GetCurrentUser();
    }
}
