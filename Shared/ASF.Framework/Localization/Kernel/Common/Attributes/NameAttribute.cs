using System;

namespace Kuntur.Framework.Kernel.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NameAttribute : Attribute
    {
        public string Name { get; set; }

        public NameAttribute(string name)
        {
            Name = name;
        }
    }
}
