using System;
using System.Linq;
using ExtensionsWebApi.Database;

namespace ExtensionsWebApi.UserOperations
{
    public class DeleteUserCommand
    {
        private readonly UsersDbContext _dbContext;

        public int userId { get; set; }//Silme işlemi için ID alımı

        public DeleteUserCommand(UsersDbContext dbContext)//database contexti alma
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == userId);//ID kontrolü
            if (user is null)
            {
                throw new InvalidOperationException("User is not exists.");
            }

            _dbContext.Users.Remove(user);//Silme işlemi
            _dbContext.SaveChanges();//Değişikliklerin kaydedilmesi
        }
    }
}