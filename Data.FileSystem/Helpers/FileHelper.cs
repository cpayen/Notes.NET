using System.IO;
using System.Threading.Tasks;

namespace Data.FileSystem.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> ReadAllTextAsync(string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
