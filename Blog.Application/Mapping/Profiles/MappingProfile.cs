using AutoMapper;
using Blog.Application.Features.Posts.Queries.GetPosts;
using Blog.Application.Mapping.Dtos;
using Blog.Domain;

namespace Blog.Application.Mapping.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto.
            CreateMap <Post, GetPostsViewModel> ();

            CreateMap <Category, CategoryDto> ();

            //Dto to Domain or use ReverseMap().
            CreateMap<GetPostsViewModel, Post>()
                .ForMember(p => p.Id, opt => opt.Ignore());  
            
            CreateMap<CategoryDto, Category>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}
