namespace LoxySharp
{
    internal class Program
    {
        /// <summary>
        /// Indicates whether an error occurred during execution.
        /// </summary>
        public static bool HadError { get; private set; }

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: LoxySharp.exe [script]");
                Environment.Exit(64);
            }
            else if (args.Length == 1)
            {
                RunFile(args[0]);

                if (HadError)
                {
                    Environment.Exit(65);
                }
            }
            else
            {
                RunPrompt();
            }
        }

        /// <summary>
        /// Loads and runs a file of Lox source code.
        /// </summary>
        private static void RunFile(string path)
        {
            string source = File.ReadAllText(path);
            Run(source);
        }

        /// <summary>
        /// Prompts for and runs a line of Lox source code as a REPL.
        /// </summary>
        private static void RunPrompt()
        {
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();

                if (line == null)
                {
                    break;
                }

                Run(line);

                HadError = false;
            }
        }

        /// <summary>
        /// Runs Lox source code.
        /// </summary>
        private static void Run(string source)
        {
            var scanner = new Scanner(source);

            var tokens = scanner.ScanTokens();

            // For now, just print the tokens.
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
        }

        /// <summary>
        /// Reports an error at a specific line.
        /// </summary>
        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }

        /// <summary>
        /// Outputs the details of an error at a specific line and location to the console.
        /// </summary>
        private static void Report(int line, string where, string message)
        {
            Console.Error.WriteLine($"[line {line}] Error{where}: {message}");

            HadError = true;
        }
    }
}
