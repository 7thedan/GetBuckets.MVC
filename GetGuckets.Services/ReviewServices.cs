using GetBuckets.Data;
using GetBuckets.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGuckets.Services
{
    public class ReviewServices
    {
        private readonly Guid _userID;

        public ReviewServices(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    OwnerID = _userID,
                    
                    PlayerID = model.PlayerID,
                    LocationID = model.LocationID,
                    Comment = model.Comment,
                    IsRecommended = model.IsRecommended,
                    LocationRating = model.LocationRating,
                    DateCreated = DateTimeOffset.Now //upon creation it will populate it with date and time! Decoration on the fields and date time to display! 
                   


                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItems> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
             {
                 var query =
                   ctx
                        .Reviews
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                           new ReviewListItems
                            {
                              ReviewID = e.ReviewID,
                              UserName = e.Player.UserName,
                              LocationName = e.Location.LocationName,
                              Comment = e.Comment,
                              IsRecommended = e.IsRecommended,
                              LocationRating = e.LocationRating,
                              DateCreated = e.DateCreated,
                              DateModified = e.DateModified
                            });
                    return query.ToArray();
                }
            }
        public ReviewDetail GetReviewByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.OwnerID == _userID);

                return new ReviewDetail
            {
                ReviewID = entity.ReviewID,
                UserName = entity.Player.UserName,
                LocationName = entity.Location.LocationName,
                Address = entity.Location.Address,
                Comment = entity.Comment,
                IsRecommended = entity.IsRecommended,
                LocationRating = entity.LocationRating,
                DateCreated = entity.DateCreated,
                DateModified = entity.DateModified
            };

            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewID == model.ReviewID && e.OwnerID == _userID);

                entity.Player.UserName = model.UserName;
                entity.Location.LocationName = model.LocationName;
                entity.Comment = model.Comment;
                entity.IsRecommended = model.IsRecommended;
                entity.LocationRating = model.LocationRating;
                entity.DateCreated = model.DateCreated;
                entity.DateModified = model.DateModified;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewID == reviewID && e.OwnerID == _userID);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
