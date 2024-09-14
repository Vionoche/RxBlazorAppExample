using ApplicationHandlers;

namespace TemplateProject.Application.Abstractions.Authentication;

public record GetAuthenticatedUserQuery : IRequest<GetAuthenticatedUserResponse>;