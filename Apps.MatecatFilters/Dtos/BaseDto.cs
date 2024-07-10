using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.MatecatFilters.Dtos
{
    public class BaseDto
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Log { get; set; }
        public string ErrorMessage { get; set; }
    }
}
