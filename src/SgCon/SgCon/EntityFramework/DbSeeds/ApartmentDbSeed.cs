using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class ApartmentDbSeed : DbSeedBase
    {
        public ApartmentDbSeed(SgConContext context) : base(context)
        {
            if (!context.Apartments.Any())
            {
                List<Apartment> apartments = new List<Apartment>();

                Apartment apartmentOne = new Apartment
                {
                    Number = "10",
                    Floor = "1",
                    TowerId = 1,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                apartments.Add(apartmentOne);

                Apartment apartmentTwo = new Apartment
                {
                    Number = "11",
                    Floor = "1",
                    TowerId = 1,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                apartments.Add(apartmentTwo);

                Apartment apartmentThree = new Apartment
                {
                    Number = "20",
                    Floor = "2",
                    TowerId = 1,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                apartments.Add(apartmentThree);

                Apartment apartmentFour = new Apartment
                {
                    Number = "21",
                    Floor = "2",
                    TowerId = 1,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                apartments.Add(apartmentFour);

                context.AddRange(apartments);
                context.SaveChanges();
            }
        }

    }
}
