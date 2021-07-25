using GetBuckets.Data;
using GetBuckets.Models.LocationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GetGuckets.Services
{
    public class LocationServices
    {
        private readonly Guid _userID;
        public LocationServices(Guid userID)
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
                      .Locations
                      .Select(e => new LocationListItems
                      {
                         LocationID = e.LocationID,
                         LocationName = e.LocationName,
                         Street = e.Street,
                         City = e.City,
                         State = e.State,
                         ZipCode = e.ZipCode,
                         Open = e.Open,
                         Closed = e.Closed,
                         HoursOfOperation = e.HoursOfOperation,
                         Memembership = e.Membership,
                         Indoor = e.Indoor,
                         Outdoor = e.Outdoor
                      }
                      );
                return query.ToArray();
            }
        }

        public LocationDetail GetLocationByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == e.LocationID);

                return
                new LocationDetail
                {
                    LocationID = entity.LocationID,
                    LocationName = entity.LocationName,
                    Street = entity.Street,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode,
                    Open = entity.Open,
                    Closed = entity.Closed,
                    HoursOfOperation = entity.HoursOfOperation,
                    Memembership = entity.Membership,
                    Indoor = entity.Indoor,
                    Outdoor = entity.Outdoor
                };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == e.LocationID);

                entity.LocationName = model.LocationName;
                entity.Street = model.Street;
                entity.City = model.City;
                entity.ZipCode = model.ZipCode;
                entity.Open = model.Open;
                entity.Closed = model.Closed;
                entity.HoursOfOperation = model.HoursOfOperation;
                entity.Membership = model.Memembership;
                entity.Indoor = model.Indoor;
                entity.Outdoor = model.Outdoor;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == e.LocationID);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
