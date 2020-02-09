using MyPanda.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPanda.Services.Interfaces
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);
    }


}
