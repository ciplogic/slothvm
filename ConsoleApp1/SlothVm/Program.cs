using System;

namespace SlothVm
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new DotClassReaderUsingJavaP();
            var contents = reader.ReadClassFile(@"D:\Oss\SlothVm\production\HelloProgram\com\company\Primes.class");
            
            //var contents2 = reader.ReadClassFile(@"java.lang.String");
            Console.WriteLine("Processed successfully!");
        }
    }
}