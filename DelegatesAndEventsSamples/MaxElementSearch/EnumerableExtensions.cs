using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndEventsSamples.MaxElementSearch;

public static class EnumerableExtensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));
    
        if (!collection.Any())
            throw new ArgumentException("Collection can't be empty", nameof(collection));
        
        T maxValue = null;
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

        return maxValue!;
    }
}