using System;
using System.Linq;
using ExtensionsWebApi.Database;

namespace ExtensionsWebApi.UserOperations
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; } //Modeli oluşturuyoruz.

        private readonly UsersDbContext _dbContext;//Database contexti aldık.
        public CreateUserCommand(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()//Bu metod asıl işi yapıyor
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user is not null)
            {
                throw new InvalidOperationException("User already exists.");
            }
            user = new User();

            user.Email = Model.Email;
            user.Name = Model.Name;
            user.Surname = Model.Name;
            user.PhoneNumber = Model.PhoneNumber;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges(); //context içinde değişiklikleri kaydetmek önemli --<
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }

}