

using System;
using System.IO;

public static class PathHelper
{
    public static string GetSolutionDirectory()
    {
        var dir = Directory.GetCurrentDirectory();
        while (dir != null && !File.Exists(Path.Combine(dir, "DoctorAppointmentDemo.sln")))
        {
            dir = Directory.GetParent(dir)?.FullName;
        }

        if (dir == null)
        {
            throw new Exception("Solution directory not found.");
        }

        return dir;
    }

    public static string GetDatabaseFilePath(string relativePath)
    {
        var solutionDir = GetSolutionDirectory();
        var fullPath = Path.Combine(solutionDir, relativePath);
        return Path.GetFullPath(fullPath);
    }
}


