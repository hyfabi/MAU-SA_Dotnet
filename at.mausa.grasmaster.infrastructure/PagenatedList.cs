using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace At.Mausa.Grasmaster.Infrastructure; 
public class PagenatedList<T> : List<T> {
    public int PageIndex { get; private set; } // !!NICHT!! Zero-Based (1, 2, 3, 4, ...)

    public int TotalPages { get; private set; }

    public PagenatedList(List<T> items, int count, int pageIndex, int pageSize) {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public bool HasPreviousPage
        => PageIndex > 1;

    public bool HasNextPage
        => PageIndex < TotalPages;

    public static PagenatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize) {
        var count = source.Count();
        var items = source
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToList();
        return new PagenatedList<T>(items, count, pageIndex, pageSize);
    }

    public static PagenatedList<T> CreateNoPaging(IQueryable<T> source) {
        var count = source.Count();

        return new PagenatedList<T>(source.ToList(), count, 1, count);
    }
}
