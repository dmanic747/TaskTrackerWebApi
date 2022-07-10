using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Enums;

namespace TaskTracker.Data.Filters
{
    public class ProjectQuery : ISortable, IRangeFilter, IExactValueFilter
    {
        #region Filtering

        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Name { get; set; }
        public int? Priority { get; set; }
        public byte? Status { get; set; }

        #endregion

        #region Sorting

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }

        #endregion

    }
}
