using MFT.Abstractions;

namespace MFT.Logic.Services
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

        public int CopyFiles(IReadOnlyCollection<FileInfo> files, string directory, string? postfixFileName, bool overwrite)
        {
            var directoryInfo = new DirectoryInfo(directory);
            var countFiles = 0;

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            foreach (var file in files)
            {
                var fileName = $"{Path.GetFileNameWithoutExtension(file.Name)}{postfixFileName ?? string.Empty}{file.Extension}";

                file.CopyTo(
                    Path.Combine(
                        directoryInfo.FullName,
                        fileName),
                    overwrite);
                countFiles++;
            }

            return countFiles;
        }
    }
}
