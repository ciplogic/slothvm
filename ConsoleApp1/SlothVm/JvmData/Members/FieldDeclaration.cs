using SlothVm.JvmData.Jvm;

namespace SlothVm.JvmData.Members
{
    public class FieldDeclaration : BaseDeclaration
    {
        public FieldDeclaration(ClassData parentClass) : base(DeclarationType.Field, parentClass)
        {
        }
    }
}