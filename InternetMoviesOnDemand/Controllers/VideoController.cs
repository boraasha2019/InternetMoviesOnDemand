using InternetMoviesOnDemand.BusinessAccessLayer.BAL;
using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetMoviesOnDemand.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoController : Controller
    {
        private IVideoBAL _videoBAL;

        public VideoController(IVideoBAL videoBAL)
        {
            _videoBAL = videoBAL;
        }

        /// <summary>
        /// To get all the videos
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Viewer")]
        [HttpGet]
        public IActionResult Get()
        {
            var videos = _videoBAL.GetAllVideos();
            if (videos.Count > 0)
                return Ok(videos);

            return NotFound();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var video = _videoBAL.GetVideoById(id);

            if (video != null)
                return Ok(video);
            return NotFound();
        }

        /// <summary>
        /// Add a new Video
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        // POST api/values
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Add(VideoVM video)
        {
            if (ModelState.IsValid)
            {
                if (_videoBAL.GetVideoByName(video.VideoName) != null)
                {
                    _videoBAL.AddVideo(video);

                    return Ok("Video Successfully Added!!");
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Update the Desccription and other detail
        /// </summary>
        /// <param name="videoVM"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public IActionResult Update(VideoVM videoVM)
        {
            if (ModelState.IsValid)
            {
                var movie = _videoBAL.GetVideoById(videoVM.VideoId);
                if (movie != null)
                {
                    movie.VideoDescription = videoVM.VideoDescription;

                    return Ok("Video Description updated successfully!!");
                }
                return NotFound("Video Description Cannot be updated as, Not Found!");
            }
            return BadRequest("Video cannot be updated!!");
        }

    }
}
