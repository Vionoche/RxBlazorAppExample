using ApplicationHandlers;
using TemplateProject.Application.Abstractions.Authentication.Models;

namespace TemplateProject.Application.Abstractions.Authentication;

public interface IGetAuthenticatedUserHandler : IQueryHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse>
{
}

public record GetAuthenticatedUserQuery();

public record GetAuthenticatedUserResponse(
    AuthenticatedUserModel User);