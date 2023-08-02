using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RxBlazorApp.Client.Pages.DocumentList.Models;

namespace RxBlazorApp.Client.Pages.DocumentList.Components;

public partial class DocumentTable : IDisposable
{
    [CascadingParameter(Name = "DocumentListStateContainer")]
    private DocumentListStateContainer State { get; set; } = null!;

    private ICollection<Document>? _documents;
    private IDisposable? _documentsSubscription;

    protected override void OnInitialized()
    {
        _documentsSubscription = State.Documents.Subscribe(OnLoad);
        State.LoadDocuments();
    }

    private void OnLoad(ICollection<Document> documents)
    {
        _documents = documents;
        StateHasChanged();
    }

    public void Dispose()
    {
        _documentsSubscription?.Dispose();
    }
}