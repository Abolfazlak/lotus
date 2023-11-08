using System;
using lotus.Models.UserManagement;

namespace lotus.Repositories.UserManagement
{
	public interface IUserManagerRepo
	{
        public Task<List<UsersDto>> GetUsersFromDb();
    }
}

