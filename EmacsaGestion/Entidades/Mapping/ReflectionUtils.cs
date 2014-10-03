using System;
using System.Reflection;

namespace Entidades.Mapping
{
    internal static class ReflectionUtils
    {
        public static object Invoke(MethodInfo method, object obj, object[] parameters)
        {
            try
            {
                return method.Invoke(obj, parameters);
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        public static bool IsGenericType(Type t, Type genericType)
        {
            if (t != null)
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == genericType)
                    {
                        return true;
                    }
                else
                    {
                        return IsGenericType(t.BaseType, genericType);
                    }
            }

            return false;
        }
    }
}
