using Lazy_Loading_API.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lazy_Loading_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LargeJSONController : ControllerBase
	{
		private readonly ILogger<LargeJSON> _logger;
		private readonly IHostEnvironment _hostEnvironment;

		public LargeJSONController(ILogger<LargeJSON> logger, IHostEnvironment hostEnvironment)
		{
			_logger = logger;
			_hostEnvironment = hostEnvironment;
		}

		[HttpGet("GetJsonFile")]
		public string GetJSON()
		{
			var path = Path.Combine(_hostEnvironment.ContentRootPath, "DB", "largefile.json");
			var jsonStr = System.IO.File.ReadAllText(path);
			List<LargeJSON.Rootobject> items = JsonConvert.DeserializeObject<List<LargeJSON.Rootobject>>(jsonStr);
			string limitedItem = JsonConvert.SerializeObject(items.Take(100));
			return limitedItem;
		}

		[HttpGet("GetChunkData")]
		public IActionResult GetChunkData(int start = 0, int count = 20)
		{
			var path = Path.Combine(_hostEnvironment.ContentRootPath, "DB", "largefile.json");
			var jsonStr = System.IO.File.ReadAllText(path);
			List<LargeJSON.Rootobject> items = JsonConvert.DeserializeObject<List<LargeJSON.Rootobject>>(jsonStr);

			var paginatedItems = items.Skip(start).Take(count).ToList();

			var totalCount = items.Count;
			var response = new
			{
				Start = start,
				Count = paginatedItems.Count,
				Total = totalCount,
				Items = paginatedItems
			};

			return Ok(response);
		}
	}
}

