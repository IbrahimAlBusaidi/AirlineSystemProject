﻿using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User user);

        User GetById(int id);
        User GetUserForLogin(string email, string password);
        void UpdateUser(User user);
        public void DeactivateUser(int userId);
        public void ReactivateUser(int userId);
    }
}