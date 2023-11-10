using System;
using lotus.DataProvide;
using lotus.Models.UserManagement;
using lotus.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace lotus.Repositories.UserManagement
{
	public class UserManagerRepo : IUserManagerRepo
	{
        private readonly UserDbContext _userContext;
        private readonly ILogger<UserManagerRepo> _logger;


        public UserManagerRepo(UserDbContext userContext, ILogger<UserManagerRepo> logger)
		{
            _userContext = userContext;
			_logger = logger;
		}

		public async Task<List<UsersDto>> GetUsersFromDb()
		{
			try
			{
				var users = await (from user in _userContext.Users
								   select new UsersDto
								   {
									   Id = user.Id,
									   FirstName = user.FirstName,
									   LastName = user.LastName,
									   Email = user.Email,
									   Mobile = user.Mobile
								   }).ToListAsync();

				if (users != null)
				{
					return users;
				}
				return new List<UsersDto>();
			}
			catch (Exception ex)
			{
                _logger.LogError($"exception occured in GetUsersFromDb: {ex.Message}");

                return new List<UsersDto>();
            }
        }
	}
}

