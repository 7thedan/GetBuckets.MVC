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
                    Address = model.Address,
                    Comment = model.Comment,
                    IsRecommended = model.IsRecommended,
                    LocationRating = model.LocationRating,
                    DateCreated = model.DateCreated,


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
                              PlayerID = e.PlayerID,
                              LocationID = e.LocationID,
                              Address = e.Address,
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

                return
            new ReviewDetail
            {
                ReviewID = entity.ReviewID,
                PlayerID = entity.PlayerID,
                LocationID = entity.LocationID,
                Address = entity.Address,
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

                entity.Address = model.Address;
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
