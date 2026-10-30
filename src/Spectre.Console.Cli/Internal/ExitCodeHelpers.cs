namespace Spectre.Console.Cli;

internal static class ExitCodeHelpers
{
    public static IReadOnlyDictionary<int, string> Merge(
        IReadOnlyDictionary<int, string>? global,
        IReadOnlyDictionary<int, string>? command)
    {
        // Command-scoped descriptions win over global ones.
        var result = new SortedDictionary<int, string>();
        Add(result, global);
        Add(result, command);
        return result;
    }

    private static void Add(SortedDictionary<int, string> target, IReadOnlyDictionary<int, string>? source)
    {
        if (source == null)
        {
            return;
        }

        foreach (var pair in source)
        {
            target[pair.Key] = pair.Value;
        }
    }
}
