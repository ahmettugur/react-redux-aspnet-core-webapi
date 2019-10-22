using System;

namespace ATCommon.Logging.Contracts
{
    public interface ICommonLogger
    {
        void Log(LogMethodParameter logMethodParameter);
    }
}
