using System;
using System.Collections.Generic;
using System.Text;
using InternetMoviesOnDemand.Repository.Model;
using InternetMoviesOnDemand.Data;
using System.Linq;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private InMemoryDataContext _context;
        public VideoRepository(InMemoryDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// To add a new Video
        /// </summary>
        /// <param name="video"></param>
        public void AddVideo(Video video)
        {
            try
            {
                _context.Videos.Add(new Video { CategoryId = video.CategoryId, VideoDescription = video.VideoDescription, VideoName = video.VideoName, VideoPath = video.VideoPath, VideoSize = video.VideoSize });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To delete a Video
        /// </summary>
        /// <param name="id"></param>
        public void DeleteVideo(int id)
        {
            var video = _context.Videos.Where(x => x.Id == id).SingleOrDefault();
            if (video != null)
                _context.Videos.Remove(video);
        }

        /// <summary>
        /// To Get All the videos
        /// </summary>
        /// <returns></returns>
        public List<Video> GetAllVideos()
        {
            return _context.Videos;
        }

        /// <summary>
        /// To get Video by CategoryName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public Video GetVideoByCategory(string categoryName)
        {
            var category = _context.Categories.Where(x => x.CategoryName == categoryName).SingleOrDefault();
            if (category != null)
                return _context.Videos.Where(x => x.CategoryId == category.Id).SingleOrDefault();
            return null;
        }

        /// <summary>
        /// Get Video By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetVideoById(int id)
        {
            var video = _context.Videos.Where(x => x.Id == id).SingleOrDefault();
            if (video != null)
                return video;
            return null;
        }

        public Video GetVideoByName(string videoName)
        {
            var video = _context.Videos.Where(x => x.VideoName == videoName).SingleOrDefault();
            if (video != null)
                return video;
            return null;
        }

        /// <summary>
        /// Update Video Description
        /// </summary>
        /// <param name="video"></param>
        public void UpdateVideoDetails(Video video)
        {
            var movie = _context.Videos.Where(x => x.CategoryId == video.CategoryId && x.Id == video.Id && x.VideoName == video.VideoName).FirstOrDefault();
            if (movie != null)
                movie.VideoDescription = video.VideoDescription;
        }
    }
}
