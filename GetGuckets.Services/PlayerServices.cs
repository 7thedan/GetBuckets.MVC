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
                    Outdoor = model.Outdoor

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
                                UserName = e.UserName,
                                Height = e.Height,
                                Skill = e.Skill,
                                Position = e.Position,
                                Location = e.Location,
                                Indoor = e.Indoor,
                                Outdoor = e.Outdoor,
                                TeamID = (int)e.TeamID

                            }
                        );
                return query.ToArray();
            }
        }
        public PlayerDetail GetPlayerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerID == id && e.OwnerID == _userID);
                        return
                    new PlayerDetail
                    {
                        PlayerID = entity.PlayerID,
                        PlayerEmail = entity.PlayerEmail,
                        UserName = entity.UserName,
                        Height = entity.Height,
                        Skill = entity.Skill,
                        Position = entity.Position,
                        Location = entity.Location,
                        Indoor = entity.Indoor,
                        Outdoor = entity.Outdoor,
                        TeamID = (int)entity.TeamID //a way to cast. 

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
                entity.UserName = entity.UserName;
                entity.Height = entity.Height;
                entity.Skill = entity.Skill;
                entity.Position = entity.Position;
                entity.Location = entity.Location;
                entity.Indoor = entity.Indoor;
                entity.Outdoor = entity.Outdoor;

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
