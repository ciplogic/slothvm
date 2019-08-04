using SlothVm.JvmData.Members;

namespace SlothVm.JvmData
{
    public class ClassSectionReader
    {
        public static BaseDeclaration ReadSection(ClassMemberSection memberSection)
        {
            BaseDeclaration result = null; 
            if (IsField(memberSection.FirstRow))
            {
                var resultField = new FieldDeclaration(memberSection.ParentClass);
                result = resultField;
            }
            else
            {
                var resultMethod = new MethodDeclaration(memberSection.ParentClass);
                resultMethod.ParseCode(memberSection.Items);
                result = resultMethod;
            }

            result.MemberAccessMode = Preparse(memberSection);

            return result;
        }

        public static AccessMode Preparse(ClassMemberSection section)
        {
            AccessMode result;
            var firstRow = section.FirstRow.Trim();
            if (firstRow.StartsWith("public"))
                result = AccessMode.Public;
            else 
            if (firstRow.StartsWith("private"))
                result= AccessMode.Private;
            else 
            if (firstRow.StartsWith("protected"))
                result= AccessMode.Protected;
            else
            {
                result= AccessMode.Package;
            }

            return result;
        }
        public static bool IsField(string firstRow)
        {
            return !firstRow.Contains('(');
        }
    }
}