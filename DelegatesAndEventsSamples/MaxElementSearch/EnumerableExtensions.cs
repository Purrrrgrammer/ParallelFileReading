using System.Collections;
using System.Collections.Generic;

namespace DelegatesAndEventsSamples.MaxElementSearch;

public static class EnumerableExtensions
{
    public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        T? maxValue = null;
        var maxNumber = float.MinValue;
        
        foreach (var element in collection)
        {
            var number = convertToNumber(element);
            if (number >= maxNumber)
            {
                maxNumber = number;
                maxValue = element;
            }
        }

        return maxValue;
    }
}