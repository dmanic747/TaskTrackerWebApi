using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Data.Filters
{
    public interface ISortable
    {
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
    }
}
