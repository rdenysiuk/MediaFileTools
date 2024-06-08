using System.Diagnostics.CodeAnalysis;

namespace MFT.Logic
{
    public class FileInfoSizeComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo replica, FileInfo original)
        {
            if (replica != null && original != null)
            {
                return 
                    replica.Name.Equals(original.Name, StringComparison.CurrentCultureIgnoreCase) && 
                    replica.Length == original.Length;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] FileInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
