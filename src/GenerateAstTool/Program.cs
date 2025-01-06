namespace GenerateAstTool
{
    internal class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: GenerateAstTool.exe [output directory]");
                Environment.Exit(64);
            }

            var outputDir = args[0];

            DefineAst(
                outputDir,
                "Expr",
                new List<string>
                {
                    "Binary   : Expr Left, Token Operator, Expr Right",
                    "Grouping : Expr Expression",
                    "Literal  : object Value",
                    "Unary    : Token Operator, Expr Right",
                }
            );
        }

        private static void DefineAst(string outputDir, string baseName, List<string> types)
        {
            var path = $"{outputDir}/{baseName}.cs";
            using var writer = new StreamWriter(path);

            writer.WriteLine("namespace LoxySharp");
            writer.WriteLine("{");
            writer.WriteLine($"    public abstract class {baseName}");
            writer.WriteLine("    {");

            // The AST classes.
            foreach (string type in types)
            {
                string className = type.Split(":")[0].Trim();
                string fields = type.Split(":")[1].Trim();
                DefineType(writer, baseName, className, fields);
            }

            writer.WriteLine("    }");
            writer.WriteLine("}");
        }

        private static void DefineType(
            StreamWriter writer,
            string baseName,
            string className,
            string fieldList
        )
        {
            writer.WriteLine($"        public class {className} : {baseName}");
            writer.WriteLine("        {");

            // Constructor.
            writer.WriteLine($"            public {className}({fieldList})");
            writer.WriteLine("            {");

            // Store parameters in fields.
            string[] fields = fieldList.Split(", ");
            foreach (string field in fields)
            {
                string name = field.Split(" ")[1];
                writer.WriteLine($"                this.{name} = {name};");
            }

            writer.WriteLine("            }");

            // Fields.
            writer.WriteLine();
            foreach (string field in fields)
            {
                writer.WriteLine($"            public {field};");
            }

            writer.WriteLine("        }");
        }
    }
}
