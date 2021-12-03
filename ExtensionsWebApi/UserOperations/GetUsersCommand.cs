using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionsWebApi.Database;
using ExtensionsWebApi.CustomExtensions;

namespace ExtensionsWebApi.UserOperations
{
    public class GetUsersCommand
    {
        private readonly UsersDbContext _dbContext;

        public GetUsersCommand(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<UsersViewModel> Handle()
        {
            var userList = _dbContext.Users.OrderBy(x => x.Id).ToList<User>();
            List<UsersViewModel> vm = new List<UsersViewModel>();
            foreach (var user in userList)
            {
                vm.Add(new UsersViewModel()
                {
                    //shortName için oluşturduğum extensionlar
                    shortName = user.Name.GetShortName() + user.Surname.GetShortName(),
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber

                });
            }
            return vm;
        }

    }

    public class UsersViewModel//Bilgiyi istediğimiz şekilde dönüyoruz
    {
        public string shortName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }

}