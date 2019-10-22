using System;
using System.Collections.Generic;
using System.Text;

namespace ATCommon.Logging.Contracts
{
    public class LogDetailParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }
}
