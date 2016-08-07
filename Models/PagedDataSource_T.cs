using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Models

{
    public class PagedDataSource<T> : IPagedDataSource
    {
        public string SearchPattern
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        public int PageCount
        {
            get
            {
                if (TotalCount == 0)
                    return 0;

                return (int)Math.Ceiling((double)TotalCount / (double)PageSize);
            }
        }

        public int PageSize
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }

        public IList<T> Items
        {
            get;
            set;
        }

        public bool IsNextAvailable
        {
            get
            {
                return PageCount > 0 && PageIndex != PageCount - 1;
            }
        }

        public bool IsPreviousAvailable
        {
            get
            {
                return PageIndex != 0;
            }
        }
    }
}
