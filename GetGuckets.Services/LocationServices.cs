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
                    OwnerID = _userID,

                }
        }
    }
}
