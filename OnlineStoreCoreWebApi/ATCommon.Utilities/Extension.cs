using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ATCommon.Utilities
{
    public static class Extension
    {
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T XmlToObject<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        /// <summary>
        /// DataTable'ı List'e çevirir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTableToList<T>(this object dataTable) where T : class, new()
        {
            DataTable dt = dataTable as DataTable;
            List<T> arr = new List<T>();
            Type entityType = typeof(T);

            PropertyInfo[] properties = entityType.GetProperties();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T obj = new T();
                foreach (PropertyInfo property in properties)
                {
                    ColumnMapperAttribute mapperAttribute = property.GetCustomAttributes(typeof(ColumnMapperAttribute), true).Select((o) => o as ColumnMapperAttribute).FirstOrDefault();
                    string propertyName = mapperAttribute == null ? property.Name : mapperAttribute.HeaderName;

                    dynamic value = dt.Rows[i][propertyName].ToString();

                    //var converter = TypeDescriptor.GetConverter(property.PropertyType);
                    //var result = converter.ConvertFrom(value);
                    if (dt.Rows[i][propertyName].ToString() != "")
                    {
                        var converter = TypeDescriptor.GetConverter(property.PropertyType);
                        var result = converter.ConvertFrom(value);
                        //var result = Convert.ChangeType(value, property.PropertyType);
                        obj.GetType().GetProperty(property.Name).SetValue(obj, result, null);
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        obj.GetType().GetProperty(property.Name).SetValue(obj, "", null);
                    }


                }
                arr.Add(obj);
            }
            return arr;
        }

        /// <summary>
        /// DataTable'ı ObjectEe çevirir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static T ConvertDataTableToSingle<T>(this object dataTable) where T : class, new()
        {
            DataTable dt = dataTable as DataTable;
            Type entityType = typeof(T);

            PropertyInfo[] properties = entityType.GetProperties();
            T obj = new T();

            foreach (PropertyInfo property in properties)
            {
                ColumnMapperAttribute mapperAttribute = property.GetCustomAttributes(typeof(ColumnMapperAttribute), true).Select((x) => x as ColumnMapperAttribute).FirstOrDefault();
                string propertyName = mapperAttribute == null ? property.Name : mapperAttribute.HeaderName;
                dynamic value = dt.Rows[0][propertyName].ToString();

                var converter = TypeDescriptor.GetConverter(property.PropertyType);
                var result = converter.ConvertFrom(value);

                obj.GetType().GetProperty(property.Name).SetValue(obj, result, null);
            }
            return obj;
        }

        /// <summary>
        ///   Boş değeri Db yazdırmak için kullanıyoruz
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static object ToDbNull(this object objValue)
        {
            if (objValue == null)
            {
                return DBNull.Value;
            }
            else if (string.IsNullOrWhiteSpace(objValue.ToString()))
            {
                return DBNull.Value;
            }
            else
            {
                return objValue;
            }
        }
        /// <summary>
        /// Gelen Boş değeri ekrana yazdırmak için kullanıyoruz
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static object ToEmpty(this object strValue)
        {
            string vl = strValue.GetType().ToString();
            if (object.ReferenceEquals(strValue, DBNull.Value))
            {
                return null;
            }
            else
            {
                return strValue;
            }
        }

        /// <summary>
        /// Cümledeki Kelimelerin ilk harflerini büyük hale getirir
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FirstUpperAllLower(this string text)
        {
            text = text.TrimEnd();
            text = text.TrimStart();
            text = text.Replace("_", " ");
            string newString = string.Empty;

            if (text != "")
            {
                string[] textArr = text.Split(' ');
                List<string> clearTextArr = new List<string>();

                if (textArr.Length > 1)
                {
                    foreach (var item in textArr)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                            clearTextArr.Add(item);
                    }

                    for (int i = 0; i < clearTextArr.Count; i++)
                    {
                        string tempString = string.Empty;
                        tempString = clearTextArr[i].ToLower();
                        tempString = char.ToUpper(tempString[0]) + tempString.Substring(1);
                        if (newString == string.Empty)
                        {
                            newString = tempString;
                        }
                        else
                        {
                            newString = newString + " " + tempString;
                        }
                    }
                }
                else
                {
                    text = text.ToLower();
                    text = char.ToUpper(text[0]) + text.Substring(1);
                    newString = text;
                }
            }
            return newString;

        }

        /// <summary>
        /// Gönderilen text içerisindeki _ karakterini temizler ve baş harfleri büyük yapar
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceColumnName(this string text)
        {
            text = text.TrimEnd();
            text = text.TrimStart();
            text = text.Replace("_", " ");
            text = text.Replace(".", " ");
            string newString = string.Empty;

            if (text != "")
            {
                string[] textArr = text.Split(' ');
                List<string> clearTextArr = new List<string>();

                if (textArr.Length > 1)
                {
                    foreach (var item in textArr)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                            clearTextArr.Add(item);
                    }

                    for (int i = 0; i < clearTextArr.Count; i++)
                    {
                        string tempString = string.Empty;
                        tempString = clearTextArr[i].ToLower();
                        tempString = char.ToUpper(tempString[0]) + tempString.Substring(1);
                        if (newString == string.Empty)
                        {
                            newString = tempString;
                        }
                        else
                        {
                            newString = newString + " " + tempString;
                        }
                    }
                }
                else
                {
                    text = text.ToLower();
                    text = char.ToUpper(text[0]) + text.Substring(1);
                    newString = text;
                }
            }
            newString = newString.Replace(" ", string.Empty);
            newString = ToEnglishCharacter(newString);
            return newString;

        }


        /// <summary>
        /// Türkçe karakterleri ingilizce karakterlere çevirir.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string ToEnglishCharacter(this string word)
        {
            char[] Wordin = word.ToCharArray();
            string result = string.Empty;
            for (int i = 0; i < Wordin.Length; i++)
            {
                switch (Wordin[i])
                {
                    case 'ç': Wordin[i] = 'c'; break;
                    case 'ğ': Wordin[i] = 'g'; break;
                    case 'ı': Wordin[i] = 'i'; break;
                    case 'ö': Wordin[i] = 'o'; break;
                    case 'ş': Wordin[i] = 's'; break;
                    case 'ü': Wordin[i] = 'u'; break;
                    case 'Ç': Wordin[i] = 'C'; break;
                    case 'Ğ': Wordin[i] = 'G'; break;
                    case 'İ': Wordin[i] = 'I'; break;
                    case 'Ö': Wordin[i] = 'O'; break;
                    case 'Ş': Wordin[i] = 'S'; break;
                    case 'Ü': Wordin[i] = 'U'; break;
                    default: Wordin[i] = Wordin[i]; break;
                }
                result += Wordin[i].ToString();
            }
            return result;
        }

        /// <summary>
        /// Html taglarını siler
        /// </summary>
        /// <param name="Html"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string Html)
        {
            var value = System.Text.RegularExpressions.Regex.Replace(Html, "<[^>]*>", string.Empty);
            return value;

        }

        /// <summary>
        /// verilen string değerin belirli bir kısmını alır.
        /// </summary>
        /// <param name="stringToShorten"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public static string ShortenString(this string stringToShorten, int newLength)
        {
            if (newLength > stringToShorten.Length) return stringToShorten;

            int cutOffPoint = stringToShorten.IndexOf(" ", newLength - 1);

            if (cutOffPoint <= 0)
                cutOffPoint = stringToShorten.Length;

            return stringToShorten.Substring(0, cutOffPoint);
        }

        public static byte[] ObjectToByteArray<T>(this List<T> obj) where T : class, new()
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static List<T> ByteArrayToObject<T>(this byte[] _ByteArray) where T : class, new()
        {
            MemoryStream _MemoryStream = new MemoryStream(_ByteArray);
            BinaryFormatter _BinaryFormatter = new BinaryFormatter();
            _MemoryStream.Position = 0;
            return _BinaryFormatter.Deserialize(_MemoryStream) as List<T>;
        }

        public static string GetDataType(string dataType)
        {
            if (dataType == "VARCHAR2")
            {
                return "string";
            }
            else if (dataType == "NUMBER")
            {
                return "decimal";
            }
            else if (dataType == "DATE")
            {
                return "DateTime";
            }
            else if (dataType == "RAW")
            {
                return "string";
            }
            return "string";
        }

        public static string Base64Encode(string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }

        public static string Base64Decode(string text)
        {
            var decodedText = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(decodedText);
        }

        public static void WriteTextFile(FileMode fileMode,string message, string folder, string fileName)
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + "/"+ folder;
            string filePath = folderPath + "/" + fileName;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            FileStream fs = new FileStream(filePath, fileMode, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static string ReadTextFile(string folder, string fileName)
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + "/" + folder;
            string filePath = folderPath + "/" + fileName;
            if (!File.Exists(filePath))
            {
                return "";
            }
            StreamReader sr = new StreamReader(filePath);
            string text = sr.ReadToEnd();
            if (string.IsNullOrWhiteSpace(text.Trim()))
            {
                return "";
            }

            text = text.Trim();
            sr.Close();
            return text;
        }

        public static bool IsIn(object value, params object[] parameters)
        {
            foreach (var item in parameters)
            {
                if (string.Equals(item.ToString(), value.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false; ;
        }
    }
}
