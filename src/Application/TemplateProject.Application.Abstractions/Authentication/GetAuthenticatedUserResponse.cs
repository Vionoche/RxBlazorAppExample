using TemplateProject.Application.Abstractions.Authentication.Models;

namespace TemplateProject.Application.Abstractions.Authentication;

public record GetAuthenticatedUserResponse(
    AuthenticatedUserModel User);