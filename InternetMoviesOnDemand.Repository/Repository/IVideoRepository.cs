using InternetMoviesOnDemand.Repository.Model;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public interface IVideoRepository
    {
        List<Video> GetAllVideos();

        Video GetVideoByCategory(string categoryName);

        Video GetVideoById(int id);

        Video GetVideoByName(string videoName);

        void AddVideo(Video video);

        void DeleteVideo(int id);

        void UpdateVideoDetails(Video video);
    }
}
