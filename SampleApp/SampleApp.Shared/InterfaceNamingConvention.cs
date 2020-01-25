using System;
using System.Reflection;
using EasyRpc.DynamicClient;

namespace SampleApp
{
    internal class InterfaceNamingConvention : INamingConventionService
    {
        public string GetNameForType(Type type)
        {
            return type.Name.Substring(1);
        }

        public string GetMethodName(MethodInfo method)
        {
            return method.Name;
        }
    }
}