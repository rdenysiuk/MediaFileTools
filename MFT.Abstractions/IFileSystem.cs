
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
        public IReadOnlyCollection<FileInfo> GetFiles(string directory, params string[] extensions);
    }
}
