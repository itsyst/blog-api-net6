using AutoMapper;
using Blog.Application.Features.Posts.Commands.Create;
using Blog.Application.Features.Posts.Commands.Delete;
using Blog.Application.Features.Posts.Commands.Update;
using Blog.Application.Features.Posts.Queries.GetPostDetail;
using Blog.Application.Features.Posts.Queries.GetPosts;
using Blog.Application.Mapping.Dtos;
using Blog.Domain;

namespace Blog.Application.Mapping.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto and Dto to Domain
            CreateMap<Post, GetPostsViewModel>().ReverseMap();
            CreateMap<Post, GetPostViewModel>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();


            //Domain to Dto.
            CreateMap<Category, CategoryDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Tag, TagDto>();

            //Dto to Domain or use ReverseMap().     
            CreateMap<CategoryDto, Category>()
                .ForMember(p => p.Id, opt => opt.Ignore());            
            CreateMap<CommentDto, Comment>()
                .ForMember(p => p.Id, opt => opt.Ignore());            
            CreateMap<PostDto, Post>()
                .ForMember(p => p.Id, opt => opt.Ignore());           
            CreateMap<TagDto, Tag>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}
