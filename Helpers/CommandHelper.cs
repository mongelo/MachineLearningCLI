﻿using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Helpers;

public static class CommandHelper
{
    public static Command ProcessCommand(string userInput)
    {
        string[] parts = userInput.Split(' ');
        string[] arguments = new string[parts.Length - 1];
        Array.Copy(parts, 1, arguments, 0, arguments.Length);

        var argumentsList = arguments.ToList();
        var subCommandName = parts.Length == 1 ? "" : parts[1];
        //var subCommandName = argumentsList.Where(arg => arg.StartsWith("--")).SingleOrDefault() ?? "";
        argumentsList.Remove(subCommandName);

        return new Command
        {
            CommandText = userInput,
            CommandName = parts[0],
            SubCommandName = subCommandName,
            Arguments = argumentsList
        };
    }

    public static string? GetParameterValueFromArguments(this IEnumerable<string> arguments, string parameterName)
    {
        parameterName += "=";
        return arguments.Where(arg => arg.StartsWith(parameterName)).SingleOrDefault()?.GetParameterValue();
    }

    private static string? GetParameterValue(this string str)
    {
        return str.Split('=')[1];
    }
}
