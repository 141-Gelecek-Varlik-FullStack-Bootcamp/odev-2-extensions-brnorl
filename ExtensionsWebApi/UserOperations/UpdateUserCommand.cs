using System;
using System.Linq;
using ExtensionsWebApi.Database;

namespace ExtensionsWebApi.UserOperations
{
    public class UpdateUserCommand
    {
        private readonly UsersDbContext _context;
        public int UserId { get; set; }

        public UpdateUserModel Model { get; set; }
        public UpdateUserCommand(UsersDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == UserId);//Id kontrolü
            if (user is null)
            {
                throw new InvalidOperationException("user is not exists.");//Hata mesajı
            }
            user.Name = Model.Name != default ? Model.Name : user.Name;
            user.Surname = Model.Surname != default ? Model.Surname : user.Surname;
            user.PhoneNumber = Model.PhoneNumber != default ? Model.PhoneNumber : user.PhoneNumber;
            _context.SaveChanges();
        }


    }
    public class UpdateUserModel //Emaili değiştirilebilir olmaktan çıkarmak için view modele eklemedim.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}