namespace SlothVm.JvmData
{
    public class TypeName
    {
        public string Name;
        public bool IsByValue;

        public static TypeName FromName(string typeName)
        {
            var isByValue = false;
            switch (typeName)
            {
                case "int":
                case "char":
                case "float":
                case "double":
                    isByValue = true;
                    break;
            }

            var result = new TypeName {Name = typeName, IsByValue = isByValue};
            return result;
        }

        public override string ToString() 
            => Name;
    }
}