namespace InternetMoviesOnDemand.Repository.Model
{
    public class Video
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string VideoName { get; set; }

        public string VideoDescription { get; set; }

        public string VideoSize { get; set; }

        public string VideoPath { get; set; }

    }
}
