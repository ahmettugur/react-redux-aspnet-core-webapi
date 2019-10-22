using System;
using System.Collections.Generic;
using System.Text;

namespace ATCommon.Utilities
{
    public class ColumnMapperAttribute : Attribute
    {
        public ColumnMapperAttribute(string headerName)
        {
            HeaderName = headerName;
        }
        public string HeaderName { get; set; }
    }

}

