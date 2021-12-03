using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExtensionsWebApi.Database
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UsersDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<UsersDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Name = "Baransel",
                        Surname = "Oral",
                        Email = "brnorl47@gmail.com",
                        PhoneNumber = "123567893"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Umut",
                        Surname = "bozbek",
                        Email = "umud@gmail.com",
                        PhoneNumber = "123567893"
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Efe",
                        Surname = "Karahanlı",
                        Email = "efe13@gmail.com",
                        PhoneNumber = "123567893"
                    },
                    new User
                    {
                        Id = 4,
                        Name = "Üstün",
                        Surname = "Kısa",
                        Email = "kısa123@gmail.com",
                        PhoneNumber = "123567893"
                    },
                    new User
                    {
                        Id = 5,
                        Name = "Fethi",
                        Surname = "Güngördü",
                        Email = "brnorl47@gmail.com",
                        PhoneNumber = "123567893"
                    },
                    new User
                    {
                        Id = 6,
                        Name = "Arda",
                        Surname = "Turan",
                        Email = "arda123@gmail.com",
                        PhoneNumber = "123567893"
                    }
                        );
                //Database içerisindeki context'e kayıt işlemi --önemli,kalıcı olmasını sağlar--
                context.SaveChanges();
            }
        }
    }
}