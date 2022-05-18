using System.Collections.Generic;
using System.Linq;

namespace csvviewer;

public class Paging<T>
{
    private readonly int _pageLength;
    private readonly IEnumerable<T> _records;
    private int _currentPageNumber;

    public Paging(IEnumerable<T> records, int pageLength)
    {
        _records = records;
        _pageLength = pageLength;
    }

    public IEnumerable<T> ExtractFirstPage()
    {
        _currentPageNumber = 1;
        return ExtractCurrentPage();
    }

    public IEnumerable<T> ExtractPrevPage()
    {
        DecrementPageNo();
        return ExtractCurrentPage();
    }

    public IEnumerable<T> ExtractNextPage()
    {
        IncrementPageNo();
        return ExtractCurrentPage();
    }

    public IEnumerable<T> ExtractLastPage()
    {
        _currentPageNumber = CalculateLastPageNo();
        return ExtractCurrentPage();
    }

    private int CalculateLastPageNo()
    {
        return _records.Count() / _pageLength + 1;
    }

    private void IncrementPageNo()
    {
        var numberOfLines = _records.Count();
        if (_currentPageNumber * _pageLength + 1 < numberOfLines) _currentPageNumber++;
    }

    private void DecrementPageNo()
    {
        if ((_currentPageNumber - 1) * _pageLength + 1 > 1) _currentPageNumber--;
    }

    private IEnumerable<T> ExtractCurrentPage()
    {
        var recordsToSkip = (_currentPageNumber - 1) * _pageLength + 1;
        return _records
            .Take(1)
            .Union(_records.Skip(recordsToSkip)
                .Take(_pageLength));
    }
}