using System;
using System.Collections.Generic;
using System.Text;

namespace Chatroom.Model.Entities.JWT
{
    public class AuthenticateResponse: AEntity<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {

            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;

        }

    }
}
