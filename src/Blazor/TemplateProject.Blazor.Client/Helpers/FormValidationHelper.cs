using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TemplateProject.Blazor.Client.Helpers;

public class FormValidationHelper
{
    public static async Task<IEnumerable<string>> ValidateModel<TModel, TValidator>(TModel model, string propertyName, TValidator validator)
        where TValidator : IValidator
    {
        var validationContext = ValidationContext<TModel>.CreateWithOptions(model, x => x.IncludeProperties(propertyName));

        var result = await validator.ValidateAsync(validationContext);

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }

        return result.Errors.Select(e => e.ErrorMessage);
    }
}