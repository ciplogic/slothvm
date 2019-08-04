using SlothVm.JvmData.Jvm;

namespace SlothVm.JvmData.Members
{
    public class BaseDeclaration
    {
        public DeclarationType Type;
        public AccessMode MemberAccessMode;
        public ClassData ParentClass;

        public BaseDeclaration(DeclarationType type, ClassData parentClass)
        {
            Type = type;
            ParentClass = parentClass;
        }


    }
}