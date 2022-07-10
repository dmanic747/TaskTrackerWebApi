using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Data.Filters
{
    public interface IRangeFilter
    {
        DateTime? StartAt { get; set; }
        DateTime? EndAt { get; set; }
    }
}
