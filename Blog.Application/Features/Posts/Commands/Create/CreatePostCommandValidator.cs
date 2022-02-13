using FluentValidation;

namespace Blog.Application.Features.Posts.Commands.Create
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(155);

            RuleFor(p => p.Excerpt)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull();
        }
    }
}
