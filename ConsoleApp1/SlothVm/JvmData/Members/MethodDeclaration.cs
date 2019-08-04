using SlothVm.JvmData.Jvm;

namespace SlothVm.JvmData.Members
{
    public class MethodDeclaration : BaseDeclaration
    {
        public MethodDeclaration(ClassData parentClass) : base(DeclarationType.Method, parentClass)
        {
        }

        public void ParseCode(string[] sectionItems)
        {
            var codeSection = sectionItems.Trim().RowsInRange("Code:", "LineNumberTable:");

            
        }
    }
}