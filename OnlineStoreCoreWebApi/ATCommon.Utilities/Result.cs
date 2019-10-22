using System;
using System.Collections.Generic;
using System.Text;

namespace ATCommon.Utilities
{
    public class Result<T> where T : class
    {
        public bool ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public T ResultData { get; set; }
    }
}
