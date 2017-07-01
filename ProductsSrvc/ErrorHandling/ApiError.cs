using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSrvc.ErrorHandling
{
    public class ApiError
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }
        //public ValidationErrorCollection errors { get; set; }

        public ApiError(string message)
        {
            this.message = message;
            isError = true;
        }
    }
}
