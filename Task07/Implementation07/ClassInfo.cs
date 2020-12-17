using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Implementation07
{
    public class ClassInfo
    {
        public Type Type { get; set; }

        public ConstructorInfo[] Constructors { get; set; }

        public MethodInfo[] Methods { get; set; }

        public ClassInfo(Type type, ConstructorInfo[] constructors, MethodInfo[] methods)
        {
            Type = type;
            Constructors = constructors;
            Methods = methods;
        }

        public string GetClassName()
        {
            return Type.Name;
        }

        public string[] GetMethodNames()
        {
            string[] methods = new string[Constructors.Length + Methods.Length];
            for (int i = 0; i < Constructors.Length; i++)
            {
                methods[i] = Constructors[i].Name;
            }
            for (int i = Constructors.Length; i < methods.Length; i++)
            {
                methods[i] = Methods[i - Constructors.Length].Name;
            }
            return methods;
        }

        public string GetMethodParameters(int index)
        {
            ParameterInfo[] parameters = IsConstructor(index) ?
                Constructors[index].GetParameters() :
                Methods[index - Constructors.Length].GetParameters();
            if (parameters.Length == 0)
            {
                return "null; ";
            }
            StringBuilder builder = new StringBuilder();
            foreach (ParameterInfo parameter in parameters)
            {
                builder.Append($"{parameter.Name}; ");
            }
            return builder.ToString();
        }

        public bool IsConstructor(int index)
        {
            return index < Constructors.Length;
        }
    }

}
