using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Models


{
    public interface IPagedDataSource
    {
        int PageCount
        {
            get;
        }

        int PageIndex
        {
            get;
            set;
        }

        bool IsNextAvailable
        {
            get;
        }

        bool IsPreviousAvailable
        {
            get;
        }
    }
}
