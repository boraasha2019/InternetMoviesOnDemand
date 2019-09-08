using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
  public  interface IVideoBAL
    {
        /// <summary>
        /// Get all the videos
        /// </summary>
        /// <returns></returns>
        List<VideoVM> GetAllVideos();

        /// <summary>
        /// Get video by Category name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        VideoVM GetVideoByCategory(string categoryName);

        /// <summary>
        /// Get video by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       VideoVM GetVideoById(int id);

        /// <summary>
        /// Get video by name
        /// </summary>
        /// <param name="videoName"></param>
        /// <returns></returns>
        VideoVM GetVideoByName(string videoName);

        /// <summary>
        /// Add a video
        /// </summary>
        /// <param name="video"></param>
        void AddVideo(VideoVM video);

        /// <summary>
        /// Delete a video
        /// </summary>
        /// <param name="id"></param>
        void DeleteVideo(int id);

        /// <summary>
        /// To update the video description
        /// </summary>
        /// <param name="video"></param>
        void UpdateVideoDetails(VideoVM video);
    }
}
