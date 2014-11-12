
namespace Contract
{
    public class Rating
    {
        public Rating() { }

        public Rating(int predictedStarRating, int actualStarRating, int averageStarRating)
        {
            PredictedStarRating = predictedStarRating;
            ActualStarRating = actualStarRating;
            AverageStarRating = averageStarRating;
        }

        public int PredictedStarRating { get; private set; }
        public int ActualStarRating { get; private set; }
        public int AverageStarRating { get; private set; }
    }
}