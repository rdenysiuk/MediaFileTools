
namespace MFT.Abstractions
{
    public interface IFileSystem
    {
        /// <summary>
        /// Get file list from the specified <paramref name="directory"/> and <paramref name="extensions"/>
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        IReadOnlyCollection<FileInfo> GetFiles(string directory, params string[] extensions);

        /// <summary>
        /// Copies an existing files to a new files, allowing the overwriting of an existing file.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="directory">The name of the new file to copy to.</param>
        /// <param name="postfixFileName"></param>
        /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false.</param>
        /// <returns></returns>
        int CopyFiles(IReadOnlyCollection<FileInfo> files,
                      string directory,
                      string? postfixFileName = null,
                      bool overwrite = false);
    }
}
