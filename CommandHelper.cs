using MachineLearningCLI.Entities;

namespace MachineLearningCLI
{
    public static class CommandHelper
    {
        public static Command ProcessCommand(string userInput)
        {
            string[] parts = userInput.Split(' ');
            string command = parts[0];
            string[] arguments = new string[parts.Length - 1];
            Array.Copy(parts, 1, arguments, 0, arguments.Length);

            return new Command
            {
                CommandText = command,
                CommandName = parts[0],
                Arguments = arguments.ToList()
            };
        }
    }
}
