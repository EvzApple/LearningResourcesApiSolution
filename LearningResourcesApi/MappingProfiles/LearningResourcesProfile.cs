using AutoMapper;
using LearningResourcesApi.Data;
using LearningResourcesApi.Models;

namespace LearningResourcesApi.MappingProfiles;

public class LearningResourcesProfile : Profile
{
    public LearningResourcesProfile()
    {
        CreateMap<LearningResource, ResourceItem>();

        CreateMap<PostResourceRequest, LearningResource>();
    }
}
