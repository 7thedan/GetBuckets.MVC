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
        private readonly Guid _userId;

        public PlayerServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Player()
                {
                    OwnerID = _userId,
                    PlayerEmail = model.PlayerEmail,
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
        public IEnumerable<PlayerListItems> GetPlayer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e =>
                            new PlayerListItems
                            {
                                PlayerEmail = e.PlayerEmail,
                                UserName = e.UserName,
                                Height = e.Height,
                                Skill = e.Skill,
                                Position = e.Position,
                                Location = e.Location,
                                Indoor = e.Indoor,
                                Outdoor = e.Outdoor,
                                TeamID = e.TeamID

                            }
                            );
                return query.ToArray();
            }
        }
        public bool UpdatePlayer(PlayerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerID == model.PlayerID && e.OwnerID == _userId);

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
                        .Single(e => e.PlayerID == playerID && e.OwnerID == _userId);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
