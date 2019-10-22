using ATCommon.Logging.Contracts;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ATCommon.Logging
{
    public class JsonFileLogger : ICommonLogger
    {
        public void Log(LogMethodParameter logMethodParameter)
        {
            var mainPath = AppDomain.CurrentDomain.BaseDirectory + "/Log";
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string logName = $"{year}{month}{day}";

            if (logMethodParameter == null)
            {
                throw new Exception("Log method parameter cannot be null");
            }
            if (!string.IsNullOrWhiteSpace(logMethodParameter.LogName))
            {
                logName = logMethodParameter.LogName;
            }
            if (string.IsNullOrWhiteSpace(logMethodParameter.Message))
            {
                logMethodParameter.Message = JsonConvert.SerializeObject(logMethodParameter.LogDetail, Formatting.Indented);
            }

            try
            {

                string fullPath = $"{mainPath}/{year}/{month}/{day}";
                if (!string.IsNullOrWhiteSpace(logMethodParameter.Path))
                {
                    fullPath = logMethodParameter.Path;
                }
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }

                string filePath = $"{fullPath}/{logName}_{hour}.json";
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("/*------------------ START " + DateTime.Now.ToString() + "------------------*/");
                sw.WriteLine(logMethodParameter.Message);
                sw.WriteLine("/*------------------ END " + DateTime.Now.ToString() + "------------------*/");
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch
            {

            }
        }
    }
}
