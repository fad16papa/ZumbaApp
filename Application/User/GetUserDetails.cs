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
    public class GetUserDetails
    {
        public class Query : IRequest<UserDetials>
        {
            public string Email { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserDetials>
        {
            private readonly UserManager<UserDetials> _userManager;
            public Handler(UserManager<UserDetials> userManager)
            {
                _userManager = userManager;
            }

            public async Task<UserDetials> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic goes here
                var user = await _userManager.FindByIdAsync(request.Email);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, string.Format($"The user cannot be found."));

                return new UserDetials()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    City = user.City,
                    Country = user.Country,
                    BirthDate = user.BirthDate,
                    MobileNumber = user.MobileNumber,
                    DisplayName = user.DisplayName
                };
            }
        }
    }
}