using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using InternetMoviesOnDemand.Repository.Model;
using InternetMoviesOnDemand.Repository.Repository;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public class VideoBAL : IVideoBAL
    {
        private IVideoRepository _videoRepository;
        private ICategoryBAL _categoryBAL;

        public VideoBAL(IVideoRepository videoRepository, ICategoryBAL categoryBAL)
        {
            _videoRepository = videoRepository;
            _categoryBAL = categoryBAL;
        }
        /// <summary>
        /// To add a new Video
        /// </summary>
        /// <param name="video"></param>
        public void AddVideo(VideoVM video)
        {
            var movie = new Video { VideoDescription = video.VideoDescription, VideoName = video.VideoName, CategoryId = video.CategoryId, VideoPath = video.VideoPath, VideoSize = video.VideoSize };

            _videoRepository.AddVideo(movie);
        }

        /// <summary>
        /// Delete Video by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteVideo(int id)
        {
            _videoRepository.DeleteVideo(id);
        }

        /// <summary>
        /// Getall list of Videso
        /// </summary>
        /// <returns></returns>
        public List<VideoVM> GetAllVideos()
        {
            var videoVMList = new List<VideoVM>();
            var videoList = _videoRepository.GetAllVideos();
            if (videoList.Count != 0)
            {
                foreach (var video in videoList)
                {
                    videoVMList.Add(new VideoVM
                    {
                        VideoDescription = video.VideoDescription,
                        VideoName = video.VideoName,
                        VideoPath = video.VideoPath,
                        VideoSize = video.VideoSize,
                        VideoId = video.Id,
                        CategoryId = video.CategoryId,
                        CategoryName = _categoryBAL.GetCategoryById(video.CategoryId).CategoryName
                    });
                }
            }
            return videoVMList;
        }

        /// <summary>
        /// Get the Videos by Category
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public VideoVM GetVideoByCategory(string categoryName)
        {
            var video = _videoRepository.GetVideoByCategory(categoryName);
            var videoVM = new VideoVM();
            if (video != null)
            {
                videoVM.VideoName = video.VideoName;
                videoVM.VideoId = video.Id;
                videoVM.VideoPath = video.VideoPath;
                videoVM.VideoSize = video.VideoSize;
                videoVM.CategoryId = video.CategoryId;
                videoVM.VideoDescription = video.VideoDescription;
                videoVM.CategoryName = _categoryBAL.GetCategoryById(video.CategoryId).CategoryName;
            }

            return videoVM;
        }

        /// <summary>
        /// Get Video By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VideoVM GetVideoById(int id)
        {
            var video = _videoRepository.GetVideoById(id);
            var videoVM = new VideoVM();
            if (video != null)
            {
                videoVM.VideoName = video.VideoName;
                videoVM.VideoId = video.Id;
                videoVM.VideoPath = video.VideoPath;
                videoVM.VideoSize = video.VideoSize;
                videoVM.CategoryId = video.CategoryId;
                videoVM.VideoDescription = video.VideoDescription;
                videoVM.CategoryName = _categoryBAL.GetCategoryById(video.CategoryId).CategoryName;
            }

            return videoVM;
        }

        /// <summary>
        /// Get Video Details by name
        /// </summary>
        /// <param name="videoName"></param>
        /// <returns></returns>
        public VideoVM GetVideoByName(string videoName)
        {
            var video = _videoRepository.GetVideoByName(videoName);
            var videoVM = new VideoVM();
            if (video != null)
            {
                videoVM.VideoName = video.VideoName;
                videoVM.VideoId = video.Id;
                videoVM.VideoPath = video.VideoPath;
                videoVM.VideoSize = video.VideoSize;
                videoVM.CategoryId = video.CategoryId;
                videoVM.VideoDescription = video.VideoDescription;
                videoVM.CategoryName = _categoryBAL.GetCategoryById(video.CategoryId).CategoryName;
            }

            return videoVM;
        }

        /// <summary>
        /// Update Video Details
        /// </summary>
        /// <param name="video"></param>
        public void UpdateVideoDetails(VideoVM videoVM)
        {
            var video = new Video();
            if (video != null)
            {
                video.VideoName = videoVM.VideoName;
                video.Id = videoVM.VideoId;
                video.VideoDescription = videoVM.VideoDescription;
                video.VideoPath = videoVM.VideoPath;
                video.VideoSize = videoVM.VideoSize;
                video.CategoryId = videoVM.CategoryId;
            }
            _videoRepository.UpdateVideoDetails(video);

        }
    }
}
