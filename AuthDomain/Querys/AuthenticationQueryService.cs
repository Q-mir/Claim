using AuthDomain.Querys.Object;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Querys
{
    public class AuthenticationQueryService : IQueryService<EntryDTO, User?>
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticationQueryService(IAuthRepository authRepository)
        {
            ArgumentNullException.ThrowIfNull(authRepository, nameof(authRepository));
            _authRepository = authRepository;
        }

        public User? Execute(EntryDTO obj)
        {
            if (obj == null) return null;

            return _authRepository.Authentication(obj.Login, obj.Password);
        }
    }
}
