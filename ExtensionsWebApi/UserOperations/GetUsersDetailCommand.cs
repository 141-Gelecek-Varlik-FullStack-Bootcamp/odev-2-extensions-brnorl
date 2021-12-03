using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionsWebApi.Database;
using ExtensionsWebApi.CustomExtensions;

namespace ExtensionsWebApi.UserOperations
{
    public class GetUsersDetailCommand
    {
        private readonly UsersDbContext _dbContext;
        public int UserId { get; set; }
        public GetUsersDetailCommand(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UsersDetailViewModel Handle()
        {
            var user = _dbContext.Users.Where(user => user.Id == UserId).SingleOrDefault();
            if (user is null)
            {
                throw new InvalidOperationException("User is not exists.");
            }

            UsersDetailViewModel vm = new UsersDetailViewModel();

            vm.shortName = user.Name + " " + user.Surname;
            vm.Email = user.Email.getProtectedEmail();
            vm.PhoneNumber = user.PhoneNumber.getProtectedPhoneNumber();

            return vm;

        }
    }
    public class UsersDetailViewModel
    {
        public string shortName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}