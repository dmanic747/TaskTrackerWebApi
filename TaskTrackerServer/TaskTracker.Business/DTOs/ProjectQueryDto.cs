using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Enums;
using TaskTracker.Data.Filters;

namespace TaskTracker.Business.DTOs
{
    public class ProjectQueryDto
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

        public ProjectQuery ToProjectQuery()
        {
            return new ProjectQuery
            {
                Name = Name,
                StartDate = StartDate,
                CompletionDate = CompletionDate,
                Status = Status,
                Priority = Priority,
                SortBy = SortBy,
                IsSortAscending = IsSortAscending
            };
        }


    }
}
