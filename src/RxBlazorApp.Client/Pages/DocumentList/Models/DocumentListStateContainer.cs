using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;

namespace RxBlazorApp.Client.Pages.DocumentList.Models;

public class DocumentListStateContainer
{
    public IObservable<ICollection<Document>> Documents => _documentListSubject;

    public void LoadDocuments()
    {
        _documentListSubject.OnNext(_documents);
    }

    public void ApplyFilter(string number, string name)
    {
        var filteredDocuments = _documentFilter
            .ApplyFilter(_documents, number, name)
            .ToList();
            
        _documentListSubject.OnNext(filteredDocuments);
    }

    public void ClearFilter()
    {
        _documentFilter.ClearFilter();
        _documentListSubject.OnNext(_documents);
    }

    public void AddDocument(string number, string name)
    {
        _documents.Add(new Document(Guid.NewGuid(), number, name, DateTime.Today));

        var filteredDocuments = _documentFilter
            .ApplyFilter(_documents)
            .ToList();
        
        _documentListSubject.OnNext(filteredDocuments);
    }

    private readonly DocumentFilter _documentFilter = new();
    
    private readonly Subject<ICollection<Document>> _documentListSubject = new();
        
    private readonly ICollection<Document> _documents = new List<Document>
    {
        new Document(Guid.NewGuid(), "1001", "First", new DateTime(2019, 4, 5)),
        new Document(Guid.NewGuid(), "1002", "Test", new DateTime(2020, 6, 20)),
        new Document(Guid.NewGuid(), "1011", "Deploy", new DateTime(2021, 8, 15)),
        new Document(Guid.NewGuid(), "1012", "Playing", new DateTime(2022, 4, 25)),
        new Document(Guid.NewGuid(), "1013", "Release", new DateTime(2023, 5, 26))
    };
}