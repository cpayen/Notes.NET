﻿using System.Globalization;
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
                return await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        public static async Task<byte[]> GetFileStreamAsync(string filePath)
        {
            byte[] result;

            using (var fileStream = File.OpenRead(filePath))
            {
                result = new byte[fileStream.Length];
                await fileStream.ReadAsync(result, 0, (int)fileStream.Length).ConfigureAwait(false);
            }

            return result;
        }
    }
}
