using InternetMoviesOnDemand.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
