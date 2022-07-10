using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Enums;

namespace TaskTracker.Data.Filters
{
    public class ProjectQuery : ISortable
    {
        #region Filtering

        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus? Status { get; set; }
        public int? Priority { get; set; }

        #endregion

        #region Sorting

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }

        #endregion

    }
}
