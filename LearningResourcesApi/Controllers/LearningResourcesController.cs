using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearningResourcesApi.Data;
using LearningResourcesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningResourcesApi.Controllers
{
    public class LearningResourcesController : ControllerBase
    {
        private readonly LearningResourcesDataContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public LearningResourcesController(LearningResourcesDataContext context, IMapper mapper, MapperConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("/resources")]
        public async Task<ActionResult> AddOne([FromBody] PostResourceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                //1. Add to Db
                //     - then must Map from PostResourceRequest -> LearningResource
                var resource = _mapper.Map<LearningResource>(request);
                //     - Add it to the collection 
                _context.LearningResources.Add(resource);
                //     - Save the Changes
                await _context.SaveChangesAsync(); //will changed the entities it saved to match the Db 
                //Location: http://localhost:5001/resources/13
                //2. Return:
                //     - 201 Status Code (Created)
                //     - Add a Location header with the URL of the new resource (this is good for caches)
                //     - Send them a "courtesy" copy of whatever they would get if they followed the location URL
                var response = _mapper.Map<ResourceItem>(resource);
                return CreatedAtRoute("get-resource", new { id = response.Id }, response);//Ok(request);
            }
        }

        [HttpGet("/resources/{id:int}", Name ="get-resource")]
        public async Task<ActionResult<ResourceItem>> Get(int id)
        {
            var response = await _context.LearningResources
                .Where(r => r.Id == id)
                .ProjectTo<ResourceItem>(_config)
                .SingleOrDefaultAsync();

            if(response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("/resources")]
        public async Task<ActionResult<GetResourcesResponse>> GetAll()
        {
            //var response = new GetResourcesResponse()
            //{
            //    Data = new List<ResourceItem>
            //    {
            //        new ResourceItem { Id= 1, Title = "Guitar 101", Author="Duane Eddy", Format="Youtube",SuggestedBy="Scott"},
            //        new ResourceItem { Id= 2, Title = "Building Bridges", Author="Sue", Format ="Pluralsight", SuggestedBy="Anne", WatchedOn= DateTime.Now.AddDays(-2)}
            //    }
            //};
            //var response = await _context.LearningResources.ToListAsync();
            //mapping here means a --> b, LINQ uses Select method 
            await Task.Delay(2000);
            var response = new GetResourcesResponse
            {
                Data = await _context.LearningResources.ProjectTo<ResourceItem>(_config).ToListAsync()
            };
            return Ok(response);
        }
    }
}


