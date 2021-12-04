using Chatroom.Model.Entities;
using Chatroom.Model.Entities.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatroom.Service
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetUserById(int id);

    }
}
