using LearningResourcesApi.Data;
using LearningResourcesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningResourcesApi.Controllers
{
    public class LearningResourcesController : ControllerBase
    {
        private readonly LearningResourcesDataContext _context;
        public LearningResourcesController(LearningResourcesDataContext context)
        {
            _context = context;
        }

        [HttpGet("/resources")]
        public ActionResult<GetResourcesResponse> GetAll()
        {
            //var response = new GetResourcesResponse()
            //{
            //    Data = new List<ResourceItem>
            //    {
            //        new ResourceItem { Id= 1, Title = "Guitar 101", Author="Duane Eddy", Format="Youtube",SuggestedBy="Scott"},
            //        new ResourceItem { Id= 2, Title = "Building Bridges", Author="Sue", Format ="Pluralsight", SuggestedBy="Anne", WatchedOn= DateTime.Now.AddDays(-2)}
            //    }
            //};
            var response = _context.LearningResources.ToList();
            return Ok(response);
        }
    }
}

//export interface ResourceModel
//{
//    id: string;
//  title: string;
//  author: string;
//  suggestedBy?: string;
//  format: string;
//  link?: string;
//  watchedOn?: string;
//}
