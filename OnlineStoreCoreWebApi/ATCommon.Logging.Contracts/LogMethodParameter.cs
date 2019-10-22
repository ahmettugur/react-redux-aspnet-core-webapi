using System;
using System.Collections.Generic;
using System.Text;

namespace ATCommon.Logging.Contracts
{
    public class LogMethodParameter
    {
        public string LogName { get; set; }
        public string Message { get; set; } = "";
        public string Path { get; set; } = "";
        public LogDetail LogDetail { get; set; }
    }
}
