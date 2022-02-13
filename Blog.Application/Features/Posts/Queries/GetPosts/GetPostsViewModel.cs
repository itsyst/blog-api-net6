using Blog.Application.Mapping.Dtos;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        [Required]
        public string Excerpt { get; set; } = string.Empty;

        public ICollection<Tag> Tags { get; } = new List<Tag>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();

    }
}
