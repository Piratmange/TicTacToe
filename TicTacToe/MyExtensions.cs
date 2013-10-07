using System;
using System.Collections.Generic;

public static class MyExtensions
{
    public static void Echo(this string strValue)
    {
        Console.WriteLine(strValue);
    }
}