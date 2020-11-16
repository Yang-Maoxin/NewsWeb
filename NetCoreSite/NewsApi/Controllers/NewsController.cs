using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Common;
using NewsApi.Dapper.Entities;
using NewsApi.Dapper.IRepository;

namespace NewsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NewsController : Controller
    {
        private readonly IChannelsRepository channelsRepository;
        private readonly INewsRepository newssRepository;
        public NewsController(IChannelsRepository _channelsRepository, INewsRepository _newssRepository)
        {
            channelsRepository = _channelsRepository;
            newssRepository = _newssRepository;
        }
        [HttpGet]
        public async Task<HttpActionResult<List<Channels>>> GetChannels()
        {
            List<Channels> list = await channelsRepository.GetChannels();
            return HttpActionResult<List<Channels>>.Successful(list);
        }
        [HttpGet]
        public ActionResult<HttpActionResult<PageData<News>>> GetNewsList(int channelId = -1, int pageIndex = 1, int pageSize = 10)
        {
            var list = newssRepository.GetNewsList(channelId, pageIndex, pageSize);
            return HttpActionResult<PageData<News>>.Successful(list);
        }

    }
}