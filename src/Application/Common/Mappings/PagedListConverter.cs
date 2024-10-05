using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using X.PagedList;

namespace FlexBook.Application.Common.Mappings;

public class PagedListConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>>
{
    public IPagedList<TDestination> Convert(IPagedList<TSource> source, IPagedList<TDestination> destination, ResolutionContext context)
    {
        // Map each item in the paged list from TSource to TDestination
        var mappedList = source.Select(item => context.Mapper.Map<TDestination>(item)).ToList();

        // Return a new IPagedList using the mapped data, keeping the pagination info intact
        return new StaticPagedList<TDestination>(mappedList, source.PageNumber, source.PageSize, source.TotalItemCount);
    }
}