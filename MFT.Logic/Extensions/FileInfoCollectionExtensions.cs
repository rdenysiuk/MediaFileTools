using System.Security.Cryptography;

namespace MFT.Logic.Extensions
{
    public static class FileInfoCollectionExtensions
    {
        public static string[] GetUniqueFileExtenssions(this IReadOnlyCollection<FileInfo> fileCollection)
        {
            return fileCollection.Select(f => f.Extension).Distinct().ToArray();
        }

        /// <summary>
        /// Compare source file with specified and choose file with bigger size
        /// </summary>
        /// <param name="replicaCollection"></param>
        /// <param name="originalCollection"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<FileInfo> ChooseBiggerFiles(
            this IReadOnlyCollection<FileInfo> replicaCollection,
            IReadOnlyCollection<FileInfo> originalCollection)
        {
            return
                (from replica in replicaCollection
                 join original in originalCollection
                     on replica.Name equals original.Name into nameGroup
                 from g in nameGroup.DefaultIfEmpty()
                 select
                     g?.Length > replica.Length ? g : replica).ToArray();
        }

        /// <summary>
        /// Get files with bigger size
        /// </summary>
        /// <param name="replicaCollection"></param>
        /// <param name="originalCollection"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<FileInfo> GetBiggerFiles(
            this IReadOnlyCollection<FileInfo> replicaCollection,
            IReadOnlyCollection<FileInfo> originalCollection)
        {
            return
                (from replica in replicaCollection
                 join original in originalCollection
                     on replica.Name equals original.Name into nameGroup
                 from g in nameGroup.DefaultIfEmpty()
                 where g != null && g.Length > replica.Length
                 select g).ToArray();
        }
    }
}
