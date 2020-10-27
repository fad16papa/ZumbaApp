using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.User
{
    public class Edit
    {
        public class Command : IRequest
        {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public DateTime BirthDate { get; set; }
            public string DisplayName { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly UserManager<AppUser> _userManager;
            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //logic goes here
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, string.Format($"The userName {0} cannot be found", request.UserName));

                user.FirstName = request.FirstName ?? user.FirstName;
                user.LastName = request.LastName ?? user.LastName;
                user.Email = request.Email ?? user.Email;
                user.BirthDate = request.BirthDate;
                user.City = request.City ?? user.City;
                user.Country = request.Country ?? user.Country;
                user.UserName = request.UserName ?? user.UserName;
                user.DisplayName = request.DisplayName ?? user.DisplayName;

                var success = await _userManager.UpdateAsync(user);

                if (success.Succeeded)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Problem saving changes");
                }
            }
        }
    }
}