﻿namespace WebUI.Helpers;

public class Pagination
{
    public Pagination(
        int totalItems,
        int currentPage = 1,
        int pageSize = 15,
        int maxPages = 6,
        int lastMaxPages=3)
    {
        // calculate total pages
        var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);

        // ensure current page isn't out of range
        if (currentPage < 1)
        {
            currentPage = 1;
        }
        else if (currentPage > totalPages)
        {
            currentPage = totalPages;
        }

        int startPage, endPage;
        if (totalPages <= maxPages)
        {
            // total pages less than max so show all pages
            startPage = 1;
            endPage = totalPages;
        }
        else
        {
            // total pages more than max so calculate start and end pages
            var maxPagesBeforeCurrentPage = (int)Math.Floor(maxPages / (decimal)2);
            var maxPagesAfterCurrentPage = (int)Math.Ceiling(maxPages / (decimal)2) - 1;
            if (currentPage <= maxPagesBeforeCurrentPage)
            {
                // current page near the start
                startPage = 1;
                endPage = maxPages;
            }
            else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
            {
                // current page near the end
                startPage = totalPages - maxPages + 1;
                endPage = totalPages;
            }
            else
            {
                // current page somewhere in the middle
                startPage = currentPage - maxPagesBeforeCurrentPage;
                endPage = currentPage + maxPagesAfterCurrentPage;
            }
        }

        // calculate start and end item indexes
        var startIndex = (currentPage - 1) * pageSize;
        var endIndex = Math.Min(startIndex + pageSize - 1, totalItems - 1);

        // create an array of pages that can be looped over
        var pages = Enumerable.Range(startPage, endPage + 1 - startPage);
        if (totalPages > endPage)
        {
            pages=pages.Append(-1);
            if(totalPages-endPage>lastMaxPages)
                pages=pages.Concat(Enumerable.Range((totalPages- lastMaxPages)+1, lastMaxPages));
            else
                pages= pages.Concat(Enumerable.Range(endPage + 1, totalPages - endPage));

        }
        // update object instance with all pager properties required by the view
        TotalItems = totalItems;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalPages = totalPages;
        StartPage = startPage;
        EndPage = endPage;
        StartIndex = startIndex;
        EndIndex = endIndex;
        Pages = pages;

    }

    public int TotalItems { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }

    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
    public int StartIndex { get; private set; }
    public int EndIndex { get; private set; }
    public IEnumerable<int> Pages { get; private set; }
}
