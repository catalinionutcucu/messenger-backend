using System.Collections.Immutable;

namespace Messenger.Models;

public sealed class Page<TItem>
{
    public ImmutableList<TItem> Items { get; }

    public int PageNumber { get; }

    public int PageSize { get; }

    public int TotalItems { get; }

    public int TotalPages { get; }

    public Page(IEnumerable<TItem> items, int pageNumber, int pageSize, int totalItems)
    {
        Items = [ ..items ];
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
    }
}
