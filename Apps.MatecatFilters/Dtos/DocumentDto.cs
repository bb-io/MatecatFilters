using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.MatecatFilters.Dtos
{
    public class DocumentDto : BaseDto
    {
        public string Filename { get; set; }
        public string DocumentContent { get; set; }
    }
}
