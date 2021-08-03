using GetBuckets.Data;
using GetBuckets.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGuckets.Services
{
    public class TeamServices
    {
        private readonly Guid _userID;

        public TeamServices(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    OwnerID = _userID,
                    TeamName = model.TeamName,
                    LocationID = model.LocationID

                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeamListItems> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new TeamListItems
                                {
                                    TeamID = e.TeamID,
                                    TeamName = e.TeamName,
                                    LocationName = e.Location.LocationName

                                }
                        );
                return query.ToArray();
            }
        }
        public TeamDetail GetTeamByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamID == id && e.OwnerID == _userID);

                    return
                    new TeamDetail
                    {
                        TeamID = entity.TeamID,
                        TeamName = entity.TeamName,
                        LocationName = entity.Location.LocationName,
                        ListOfPlayers = entity.ListOfPlayers
                    };
            }
        }
        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamID == model.TeamID && e.OwnerID == _userID);

                entity.TeamName = model.TeamName;
                entity.Location.LocationName = model.LocationName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTeam(int teamID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamID == teamID && e.OwnerID == _userID);

                        ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
