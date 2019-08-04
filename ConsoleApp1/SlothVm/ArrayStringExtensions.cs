using System;
using System.Collections.Generic;
using System.Linq;

namespace SlothVm
{
    public static class ArrayStringExtensions
    {
        public static string[] Trim(this string[] rows)
        {
            return rows.Select(it => it.Trim()).ToArray();
        }
        
        public static string[] SubRange(this string[] rows, int startIndex, int endIndex)
        {
            var result = new List<string>();
            for (var i = startIndex; i < endIndex; i++)
            {
                result.Add(rows[i]);
            }
            return result.ToArray();
        }
        public  static string[] RowsInRange(this string[] rows, string startString, string endString)
        {
            var indexConstantPool = StartsWith(rows, startString);
            var indexEndConstantPool = StartsWith(rows, endString, indexConstantPool);
            return SubRange(rows, indexConstantPool + 1, indexEndConstantPool);
        }

        public  static int EqualsWith(string[] items, string prefix, int startIndex = 0, bool validate = false)
        {
            for(var i = startIndex; i<items.Length; i++)
                if (items[i] == prefix)
                    return i;
            if (validate)
            {
                throw new Exception("Text '" + prefix + "' should be here");
            }

            return -1;
        }

        public  static int StartsWith(string[] items, string prefix, int startIndex = 0, bool validate = false)
        {
            for(var i = startIndex; i<items.Length; i++)
                if (items[i].StartsWith(prefix))
                    return i;
            if (validate)
            {
                throw new Exception("Text '" + prefix + "' should be here");
            }

            return -1;
        }
        public  static int Contains(string[] items, string prefix, int startIndex = 0, bool validate = false)
        {
            for(var i = startIndex; i<items.Length; i++)
                if (items[i].Contains(prefix))
                    return i;
            if (validate)
            {
                throw new Exception("Text '" + prefix + "' should be here");
            }

            return -1;
        }
    }
}