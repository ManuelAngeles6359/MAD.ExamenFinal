using MAD.Chinook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IUserRepository: IRepository<User>
    {


        User ValidaterUser(string email, string password);
    }
}
