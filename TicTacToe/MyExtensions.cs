using System;
using System.Collections.Generic;

public static class MyExtensions
{
    public static void Print(this string strValue)
    {
        Console.WriteLine(strValue);
    }
}