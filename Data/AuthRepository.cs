using AuthDomain;
using AuthDomain.Querys.Object;
using Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Connection _connection;
        public AuthRepository(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection, nameof(connection));
            _connection = connection;
        }

        public User? Authentication(string login, string password)
        {
            var client = _connection.Clients
                                    .Include(row => row.Roles)
                                    .FirstOrDefault(row => row.Login.ToLower()==login.ToLower() 
                                                    && row.Password == password);
            if (client != null)
            {
                User user = new User();
                user.Login = login;
                user.Rules = client.Roles.Select(row => row.Value).ToList();
                return user;
            }
            return null;
        }

        public User? Registration(string login, string password)
        {
            bool any = _connection.Clients.Any(user => user.Login.ToLower() == login.ToLower());
            if (!any)
            {
                Client row = new Client();
                row.Login = login.ToLower();
                row.Password = password;
                var role = _connection.Roles.FirstOrDefault(row => row.Value == "User");
                row.Roles = new List<Role>() { role };
                _connection.Add(row);
                if (_connection.SaveChanges() > 0)
                {
                    User user = new User();
                    user.Login = login.ToLower();
                    user.Rules = new List<string>() { role.Value };
                    return user;
                }
            }
            return null;
        }
    }
}
