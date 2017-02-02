﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteSolution.Core.Entities.SearchResult
{
    public interface IPagedList<T>
    {
        int TotalCount { get; }
        int PageCount { get; }
        int Page { get; }
        int PageSize { get; }
        List<T> Results { get; }
    }

    public class PagedList<T> : IPagedList<T>
    {
        public int TotalCount { get; private set; }
        public int PageCount { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public List<T> Results { get; }

        public PagedList(IQueryable<T> source, int page, int pageSize)
        {
            TotalCount = source.Count();
            PageCount = GetPageCount(pageSize, TotalCount);
            Page = page < 1 ? 0 : page - 1;
            PageSize = pageSize;

            Results = new List<T>();
            Results.AddRange(source.Skip(Page * PageSize).Take(PageSize).ToList());
        }

        private int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }
    }
}
