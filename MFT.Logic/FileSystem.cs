using MFT.Abstractions;

namespace MFT.Logic
{
    public class FileSystem : IFileSystem
    {
        public IReadOnlyCollection<FileInfo> GetFiles(string directory, params string[] extensions)
        {
            var directoryInfo = new DirectoryInfo(directory);

            var files = directoryInfo.EnumerateFiles("*.*", enumerationOptions:
                new EnumerationOptions
                {
                    IgnoreInaccessible = true,
                    RecurseSubdirectories = true,
                });


            return files.Where(f => extensions.Length == 0 || extensions.Contains(f.Extension)).ToArray();
        }
    }
}
