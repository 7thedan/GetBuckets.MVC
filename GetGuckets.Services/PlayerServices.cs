using GetBuckets.Data;
using GetBuckets.Models.PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGuckets.Services
{
    public class PlayerServices
    {
        private readonly Guid _userID;

        public PlayerServices(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Player()
                {
                    OwnerID = _userID,
                    PlayerEmail = model.PlayerEmail,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    UserName = model.UserName,
                    Height = model.Height,
                    Skill = model.Skill,
                    Position = model.Position,
                    Location = model.Location,
                    Indoor = model.Indoor,
                    Outdoor = model.Outdoor,
                    TeamID = model.TeamID

                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlayerListItems> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(e => e.OwnerID == _userID)
                        .Select(e => new PlayerListItems
                            {
                            PlayerID = e.PlayerID,
                            PlayerEmail = e.PlayerEmail,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Age = e.Age,
                            UserName = e.UserName,
                            Height = e.Height,
                            Skill = e.Skill,
                            Position = e.Position,
                            Location = e.Location,
                            Indoor = e.Indoor,
                            Outdoor = e.Outdoor,
                            TeamName = e.Team.TeamName

                        }
                        );
                return query.ToArray();
            }
        }
        public PlayerDetails GetPlayerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerID == id && e.OwnerID == _userID);
                        return
                    new PlayerDetails
                    {
                        PlayerEmail = entity.PlayerEmail,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Age = entity.Age,
                        UserName = entity.UserName,
                        Height = entity.Height,
                        Skill = entity.Skill,
                        Position = entity.Position,
                        Location = entity.Location,
                        Indoor = entity.Indoor,
                        Outdoor = entity.Outdoor,
                        TeamID = entity.Team.TeamID
                       /* TeamID = (int)entity.TeamID *///a way to cast. 

                    };
            }
        }
        public bool UpdatePlayer(PlayerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerID == model.PlayerID && e.OwnerID == _userID);

                entity.PlayerEmail = model.PlayerEmail;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.UserName = model.UserName;
                entity.Age = model.Age;
                entity.Height = model.Height;
                entity.Skill = model.Skill;
                entity.Position = model.Position;
                entity.Location = model.Location;
                entity.Indoor = model.Indoor;
                entity.Outdoor = model.Outdoor;
                entity.TeamID = model.TeamID;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeletePlayer(int playerID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerID == playerID && e.OwnerID == _userID);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
