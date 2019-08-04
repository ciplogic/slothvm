using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SlothVm.JvmData;
using SlothVm.JvmData.Jvm;

namespace SlothVm
{
    class DotClassReaderUsingJavaP
    {
        public static string[] ReadClassContents(string fullPathToClassFile)
        {
            var proc = new Process 
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "javap",
                    Arguments = "-p -c -verbose " + fullPathToClassFile,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            var resultList = new List<string>();
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                resultList.Add(line);
            }
            return resultList.ToArray();
        }

        public ClassData ReadClassFile(string fullPathToClassFile)
        {
            var rows = ReadClassContents(fullPathToClassFile);
            File.WriteAllLines("debug.txt", rows);
            var result = new ClassData();

            ParseClassName(result, rows);
            ParseConstantPool(result, rows);
            GetClassMembers(rows, result);
            foreach (var section in result.ClassMemberSections)
            {
                var declaration = ClassSectionReader.ReadSection(section);
                result.Declarations.Add(declaration);
            }

            return result;
        }

        private void GetClassMembers(string[] rows, ClassData parentClass)
        {
            var startClassIndex = ArrayStringExtensions.StartsWith(rows, "{");

            var currentIndex = startClassIndex + 1;
            var endClassIndex = ArrayStringExtensions.StartsWith(rows, "}");
            var result = new List<ClassMemberSection>();
            do
            {
                var endSection = ArrayStringExtensions.EqualsWith(rows, "", currentIndex);
                var subSection = ArrayStringExtensions.SubRange(rows, currentIndex, endSection == -1? endClassIndex : endSection);
                result.Add(new ClassMemberSection(subSection, parentClass));
                if (endSection == -1)
                {
                    parentClass.ClassMemberSections = result;
                    return;
                }

                currentIndex = endSection + 1;
            } while (true);
        }

        private static void ParseConstantPool(ClassData result, string[] rows)
        {
            var rowsRange = ArrayStringExtensions.RowsInRange(rows, "Constant pool:", "{");
            result.ConstantPoolRaw.AddRange(rowsRange);
        }

        private static void ParseClassName(ClassData result, string[] rows)
        {
            var indexClassDesc = ArrayStringExtensions.Contains(rows, "class ");
            var items = rows[indexClassDesc].Split(' ');
            var className =items.SkipWhile(it => it != "class").Skip(1).First();
            result.Name = className;
        }

    }
}