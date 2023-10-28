using System.Collections.Generic;

namespace TemplateProject.Application.Abstractions;

public record PagedCollection<TItem>(
    IReadOnlyCollection<TItem> Items,
    int PageIndex,
    int PageSize,
    int TotalCount);