using System;
using lotus.Models.UserManagement;
using lotus.Repositories.UserManagement;


namespace lotus.Services.UserManagement
{
	public class UserManagerService : IUserManagerService
	{
		private readonly IUserManagerRepo _userRepo;

		public UserManagerService(IUserManagerRepo userRepo)
		{
			_userRepo = userRepo;
		}

		public async Task<List<UsersDto>> GetUsersFromService()
		{
			var users = await _userRepo.GetUsersFromDb();
			return users;
		}

        
    }
}

