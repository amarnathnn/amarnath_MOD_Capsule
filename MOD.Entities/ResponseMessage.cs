using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Entities
{
    public class ResponseMessage
    {
        public bool HasErrors { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public bool IsSuccess { get; set; }

        public void SetSuccessMessage(string value)
        {
            IsSuccess = true;
            SuccessMessage = value;
        }

        public void SetErrorMessage(string value)
        {
            HasErrors = true;
            ErrorMessage = value;
        }
    }
}
