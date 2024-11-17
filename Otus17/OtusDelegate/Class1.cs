using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusDelegate
{
    public static class Class1 
    {
        public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class 
        {
            T maxElement = null;
            float maxValue = float.MinValue;

            foreach (var item in collection)
            {
                float value = convertToNumber(item as T);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxElement = item as T;
                }
            }
            return maxElement;
        }
    }
}
