using CodelineAirlines.Shared.Models.DTOs.ReviewDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.ClientServices
{
    public interface IReviewService
    {
        void AddReview(Review review);
        ReviewInputDTO UpdateReview(ReviewInputDTO updatedReview);
        List<Review> GetAllReview();
        void DeleteReview(int reviewId);
        IEnumerable<ReviewInputDTO> GetAllReviewsByUser(int userId);
    }
}