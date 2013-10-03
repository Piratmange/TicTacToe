using System;
using System.Linq;
using System.Collections.Generic;

public static class MyExtensions
{

    public static void Echo(this string strValue)
    {
        Console.WriteLine(strValue);
    }
    public static string Join<T>(this List<T> list)
    {
        return string.Join(", ", list);
    }
}