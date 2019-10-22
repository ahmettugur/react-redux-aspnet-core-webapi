using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ATCommon.Logging.Contracts
{
    [DataContract]
    public class LogDetail
    {
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string MethodName { get; set; }
        [DataMember]
        public List<LogDetailParameter> Parameters { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string InnerException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string StackStrace { get; set; }
    }
}
