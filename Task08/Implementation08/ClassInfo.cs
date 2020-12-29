using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Implementation08
{
    public class ClassInfo
    {
        private Assembly Assembly { get; }

        public ClassInfo(string path)
        {
            Assembly = Assembly.LoadFrom(path);
        }

        public List<Type> ChildrensAndImpls(Type type)
        {
            if (!type.IsInterface && !type.IsAbstract)
                return new List<Type>();

            return new List<Type>(Assembly.GetTypes().Where(t => ClassChecker(t, type)));
        }

        private bool ClassChecker(Type type, Type baseType)
        {
            if (!type.IsClass || type.IsAbstract || type is null)
                return false;

            if (baseType == null)
                return type.IsInterface || type == typeof(object);

            if (baseType.IsInterface)
                return type.GetInterfaces().Contains(baseType);

            Type tmp = type;
            while (tmp != null)
            {
                if (tmp.BaseType == baseType)
                    return true;
                tmp = tmp.BaseType;
            }
            return false;
        }
    }
}
