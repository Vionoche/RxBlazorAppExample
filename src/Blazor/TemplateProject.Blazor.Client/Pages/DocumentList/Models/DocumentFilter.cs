using System.Collections.Generic;
using System.Linq;

namespace TemplateProject.Blazor.Client.Pages.DocumentList.Models;

public class DocumentFilter
{
    public IEnumerable<Document> ApplyFilter(IEnumerable<Document> documents, string? number, string? name)
    {
        _number = number;
        _name = name;
        
        return ApplyFilter(documents);
    }
    
    public IEnumerable<Document> ApplyFilter(IEnumerable<Document> documents)
    {
        if (!string.IsNullOrEmpty(_number))
        {
            documents = documents.Where(x => x.Number == _number);
        }
        if (!string.IsNullOrEmpty(_name))
        {
            documents = documents.Where(x => x.Name == _name);
        }

        return documents;
    }

    public void ClearFilter()
    {
        _number = null;
        _name = null;
    }
    
    private string? _number;
    private string? _name;
}