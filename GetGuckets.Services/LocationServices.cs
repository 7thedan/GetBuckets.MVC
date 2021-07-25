using GetBuckets.Data;
using GetBuckets.Models.LocationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGuckets.Services
{
    public class LocationServices
    {
        private readonly Guid _userID;
        private LocationServices(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    LocationName = model.LocationName,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Open = model.Open,
                    Closed = model.Closed,
                    HoursOfOperation = model.HoursOfOperation,
                    Membership = model.Memembership,
                    Indoor = model.Indoor,
                    Outdoor = model.Outdoor
                }; 
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1; 
            }
        }
        public IEnumerable<LocationListItems> GetLocations()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                  ctx
                      .Players
                      .Where(e => e.OwnerID == _userID)
                      .Select(e => new LocationListItems
                      {
                         



                      }
                      );
            }
        }
    }
}
