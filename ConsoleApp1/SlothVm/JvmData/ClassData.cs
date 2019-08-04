using System.Collections.Generic;
using SlothVm.JvmData.Members;

namespace SlothVm.JvmData
{
    namespace Jvm
    {
        public class ClassData
        {
            public TypeName TypeName { get; set; }
            public string Name
            {
                set { TypeName = TypeName.FromName(value); }
                get { return TypeName.Name; }
            }

            public int InterfacesCount { get; set; }
            public int FieldCount { get; set; }
            public int MethodCount { get; set; }
            public int AttributeCount { get; set; }
            public List<string> ConstantPoolRaw { get; } = new List<string>();
            public List<ClassMemberSection> ClassMemberSections { get; set; }
            
            public List<BaseDeclaration> Declarations { get; } = new List<BaseDeclaration>();
        }    
}
    
}