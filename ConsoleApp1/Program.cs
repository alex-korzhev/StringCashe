using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public static class Program
{
    static void Main()
    {
        stringCache sc = new stringCache();
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(sc.ProcessInput(line));
            }
    }
}

public class stringCache
{
    List<String> cache;

    public stringCache()
    {
        cache = new List<string>();
    }

    public String ProcessInput(String input)
    {
        String command = input.Split('|')[0];
        String value = "";
        if (!command.Equals("Reset")) { value = input.Split('|')[1]; }
        String result = "NULL";
        switch (command)
        {
            case "Add":
                result = cacheAdd(value);
                break;
            case "Get":
                result = cacheGet(value);
                break;
            case "Has":
                result = cacheHas(value);
                break;
            case "Remove":
                result = cacheRemove(value);
                break;
            case "Reset":
                result = cacheReset();
                break;       
        }
        return result;
    }

    String cacheGet(String value)
    {
        if (cache.Contains(value)) { return value; } else { return "NULL"; }
    }
    
    String cacheHas(String value)
    {
        if (cache.Contains(value)) { return "True"; } else { return "False"; }
    }

    String cacheRemove(String value)
    {
        if (cache.Contains(value))
        {
            cache.Remove(value);
            return "True";
        } else
        {
            return "False";
        }

    }

    String cacheReset()
    {
        String res = cache.Count.ToString();
        cache = new List<string>();
        return res;
    }

    String cacheAdd(String value)
    {
        if (cache.Contains(value))
        {
            return "False";
        }
        else
        {
            cache.Add(value);
            return "True";
        }
    }

}
