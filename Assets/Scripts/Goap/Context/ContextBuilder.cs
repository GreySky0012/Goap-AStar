using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Security;
using System.Collections;
using System;

public class ContextBuilder {

    private static Dictionary<string, Type> _contextTypes;

    public static Type GetType(string typeName)
    {
        if (_contextTypes.ContainsKey(typeName))
            return _contextTypes[typeName];
        return null;
    }

    public static void Regist(string typeName,Type type)
    {
        _contextTypes[typeName] = type;
    }

    public static Context Build(string type,Type[] paramTypes,Object[] param)
    {
        try
        {
            return (Context)(type.GetConstructor(paramTypes).Invoke(param));
        }
        catch (Exception e)
        {
            Console.WriteLine("Message: " + e.Message);
        }
        return null;
    }

    public static Context Build(string type)
    {
        try
        {
            Type[] param = new Type[0];
            return (Context)(type.GetConstructor(param).Invoke());
        }
        catch (Exception e)
        {
            Console.WriteLine("Message: " + e.Message);
        }
        return null;
    }
}
