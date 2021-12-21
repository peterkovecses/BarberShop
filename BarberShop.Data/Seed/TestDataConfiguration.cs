using BarberShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BarberShop.Data.Seed
{
    public class TestDataConfiguration
    {
        public static void ConfigureSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceType>().HasData(
                WithAudit(new ServiceType { Id = 1, Name = "Hajvágás", Price = 5000}),
                WithAudit(new ServiceType { Id = 2, Name = "Gyermek hajvágás", Price = 4000 }),
                WithAudit(new ServiceType { Id = 3, Name = "Borbély élmény", Price = 7000 }),
                WithAudit(new ServiceType { Id = 4, Name = "Borotválás", Price = 3000 }),
                WithAudit(new ServiceType { Id = 5, Name = "Szakállvágás", Price = 3000 })
                );

            modelBuilder.Entity<Barber>().HasData(
                WithAudit(new Barber { Id = 1, Name = "Kobak Károly", PhotoPath = "barberImages/1.jpg", PublicDescription = "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." }),
                WithAudit(new Barber { Id = 2, Name = "Bajusz Béla", PhotoPath = "barberImages/2.jpg", PublicDescription = "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." }),
                WithAudit(new Barber { Id = 3, Name = "Szakáll Sándor", PhotoPath = "barberImages/3.jpg", PublicDescription = "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." }),
                WithAudit(new Barber { Id = 4, Name = "Borbély Bertalan", PhotoPath = "barberImages/4.jpg", PublicDescription = "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." })
                );

            var date = DateTime.Now;
            var ts = new TimeSpan(08, 00, 0);
            date = date.Date + ts;
            var id = 1;

            var appointments = new List<Appointment>();
            var time = date;

            for (int i = 1; i <= 120; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    appointments.Add(new Appointment { Id = id++, Date = time, BarberId = j });
                }

                if (i % 20 != 0)
                    time = time.AddMinutes(30);
                else
                {
                    date = date.AddDays(1);
                    time = date;
                }
            }

            foreach (var appointment in appointments)
            {
                modelBuilder.Entity<Appointment>().HasData(
                WithAudit(appointment)
                );
            }

            T WithAudit<T>(T entity) where T : EntityBase
            {
                entity.DateOfCreation = entity.DateOfUpdate = new (2020, 01, 01);
                return entity;
            }
        }
    }
}
