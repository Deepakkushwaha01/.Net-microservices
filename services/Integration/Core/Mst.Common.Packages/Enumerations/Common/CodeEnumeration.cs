using System.Reflection;

namespace Mst.Common.Packages.Enumerations
{
    public class CodeEnumeration : IComparable
    {
        public string Code { get; } = string.Empty;

        public CodeEnumeration() { }

        public CodeEnumeration(string code)
        {
            Code = code;
        }

        public int CompareTo(object? obj)
        {
            if (obj is CodeEnumeration other)
            {
                return string.Compare(this.Code, other.Code, StringComparison.Ordinal);
            }
            throw new ArgumentException("Object is not a CodeEnumeration");
        }

        protected static IEnumerable<T> GetAll<T>()
      where T : CodeEnumeration
        {
            Type type = typeof(T);

            FieldInfo[] fields = type.GetTypeInfo().GetFields(BindingFlags.Public
                                                    | BindingFlags.Static
                                                    | BindingFlags.DeclaredOnly);

            foreach (FieldInfo info in fields)
            {
                object? instance = Activator.CreateInstance(type, nonPublic: true);
                T? locatedValue = info.GetValue(instance) as T;

                if (!(locatedValue is null))
                {
                    yield return locatedValue;
                }
            }
        }
        public override string ToString()
        {
            return Code;
        }

        public static T? GetByCode<T>(string? code) where T : CodeEnumeration
        {
            return GetAll<T>().FirstOrDefault(x => x.Code == code?.Trim()?.ToUpperInvariant());
        }
    }
}