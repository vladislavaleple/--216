using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context travelContext = new Context())
            {
                travelContext.Roles.Add(new Role() { NameRole = "Адміністратор" });
                travelContext.Roles.Add(new Role() { NameRole = "Менеджер" });
                travelContext.Roles.Add(new Role() { NameRole = "Зареєстрований" });
                travelContext.Roles.Add(new Role() { NameRole = "Незареєстрований" });
                travelContext.SaveChanges();

                travelContext.Users.Add(new User() { Name = "Admin", Pass = "Admin", RoleId = 1, Surname = "Admin", Login = "Admin" });
                travelContext.Users.Add(new User() { Name = "Manager", Pass = "Manager", RoleId = 2, Surname = "Manager", Login = "Manager" });
                travelContext.Users.Add(new User() { Name = "Registred1", Pass = "Registred1", RoleId = 3, Surname = "Registred1", Login = "Registred1" });
                travelContext.Users.Add(new User() { Name = "Registred2", Pass = "Registred2", RoleId = 3, Surname = "Registred2", Login = "Registred2" });
                travelContext.Users.Add(new User() { Name = "Registred3", Pass = "Registred3", RoleId = 3, Surname = "Registred3", Login = "Registred3" });
                travelContext.Users.Add(new User() { Name = "UnRegistred", Pass = "UnRegistred", RoleId = 4, Surname = "UnRegistred", Login = "UnRegistred" });
                travelContext.SaveChanges();

                travelContext.Tours.Add(new Tour()
                {
                    Cost = 5000,
                    DataEnd = new DateTime(2019, 8, 25),
                    DataStart = new DateTime(2019, 7, 25),
                    DepartureCity = "Kiev",
                    Description = "*",
                    MovingTime = 5,
                    Transport = "Plane",
                    TypeFood = "AllIn",
                    NameTour = "Georgia"
                });

                travelContext.Tours.Add(new Tour()
                {
                    Cost = 6000,
                    DataEnd = new DateTime(2010, 8, 25),
                    DataStart = new DateTime(2010, 7, 25),
                    DepartureCity = "Kiev",
                    Description = "*",
                    MovingTime = 5,
                    Transport = "Plane",
                    TypeFood = "AllIn",
                    NameTour = "Europe"
                });

                travelContext.Tours.Add(new Tour()
                {
                    Cost = 2000,
                    DataEnd = new DateTime(2020, 8, 25),
                    DataStart = new DateTime(2020, 7, 25),
                    DepartureCity = "Kiev",
                    Description = "*",
                    MovingTime = 5,
                    Transport = "Plane",
                    TypeFood = "AllIn",
                    NameTour = "Russia"
                });

                travelContext.SaveChanges();

                travelContext.Cities.Add(new City() { NameCity = "Kiev", NameCountry = "Ukraine", TourId = 1 });
                travelContext.Cities.Add(new City() { NameCity = "Tbilisi", NameCountry = "Georgia", TourId = 1 });
                travelContext.SaveChanges();

            }

        }
    }
}
