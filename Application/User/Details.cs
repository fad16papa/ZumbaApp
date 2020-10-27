using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class Details
    {
        public class Query : IRequest<AppUser>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppUser>
        {
            private readonly UserManager<AppUser> _userManager;
            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<AppUser> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic goes here
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, string.Format($"The user cannot be found"));

                return new AppUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Country = user.Country,
                    City = user.City,
                    BirthDate = user.BirthDate,
                    UserName = user.UserName,
                    DisplayName = user.DisplayName
                };
            }

        }
    }
}