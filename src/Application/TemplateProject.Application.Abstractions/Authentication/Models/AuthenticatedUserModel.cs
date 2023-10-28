using System;
using System.Collections.Generic;

namespace TemplateProject.Application.Abstractions.Authentication.Models;

public record AuthenticatedUserModel(
    string UserLogin,
    bool IsAuthenticated,
    IReadOnlyCollection<string> Roles)
{
    public static readonly AuthenticatedUserModel Anonymous = new AuthenticatedUserModel(
        UserLogin: string.Empty,
        IsAuthenticated: false,
        Roles: Array.Empty<string>());
}