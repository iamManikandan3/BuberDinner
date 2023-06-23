using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Models;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
        {
            this._jwtTokenGenerator = jwtTokenGenerator;
            this._userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // validate the user exists
            if (_userRepository.GetUserById(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // validate the password
            if (user.Password != request.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
