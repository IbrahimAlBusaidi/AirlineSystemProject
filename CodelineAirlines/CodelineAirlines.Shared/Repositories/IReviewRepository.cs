using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Shared.Repositories
{
    public interface IReviewRepository
    {
        string AddReview(Review review);
        Review GetReviewById(int id);
        void UpdateReview(Review updatedReview);
        List<Review> GetAllReview();
        void DeleteReview(int id);
        IEnumerable<Review> GetReviewsByUserId(int userId);
    }
}