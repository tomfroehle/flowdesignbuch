namespace csvviewer;

public static class CommandLine
{
    public static string GetFilename(string[] args)
    {
        return args[0];
    }

    public static int GetPageLength(string[] args)
    {
        return args.Length > 1 ? int.Parse(args[1]) : 10;
    }
}