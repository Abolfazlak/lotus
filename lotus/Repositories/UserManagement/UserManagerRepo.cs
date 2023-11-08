using System;
using lotus.DataProvide;
using lotus.Models.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace lotus.Repositories.UserManagement
{
	public class UserManagerRepo : IUserManagerRepo
	{
        private readonly UserDbContext _userContext;


        public UserManagerRepo(UserDbContext userContext)
		{
            _userContext = userContext;
		}

		public async Task<List<UsersDto>> GetUsersFromDb()
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
	}
}

