using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
  public  interface IVideoBAL
    {
        List<VideoVM> GetAllVideos();

        VideoVM GetVideoByCategory(string categoryName);

       VideoVM GetVideoById(int id);

        VideoVM GetVideoByName(string videoName);

        void AddVideo(VideoVM video);

        void DeleteVideo(int id);

        void UpdateVideoDetails(VideoVM video);
    }
}
