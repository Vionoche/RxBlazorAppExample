using System;

namespace RxBlazorApp.Client.Pages.DocumentList.Models;

public record Document(
    Guid DocumentId,
    string Number,
    string Name,
    DateTime CreationDate);