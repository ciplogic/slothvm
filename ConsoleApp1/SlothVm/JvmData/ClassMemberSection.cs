using System.Collections.Generic;
using System.Linq;
using SlothVm.JvmData.Jvm;

namespace SlothVm.JvmData
{
    public class ClassMemberSection
    {
        public ClassData ParentClass { get; }
        public string[] Items { get; }

        public ClassMemberSection(IEnumerable<string> items, ClassData parentClass)
        {
            ParentClass = parentClass;
            Items = items.ToArray();

        }

        public string FirstRow => Items[0];
        public bool IsField => !FirstRow.Contains('(');
        public bool IsCtor => !IsField && FirstRow.StartsWith(ParentClass.Name + "(");

        public string Name
        {
            get
            {
                if (IsCtor)
                    return ParentClass.Name;
                return FirstRow.Substring(FirstRow.IndexOf(' ')+1);
            }
        }


        public override string ToString() 
            => Items.Length == 0 ? "(Empty)" : FirstRow.Trim();
    }
}