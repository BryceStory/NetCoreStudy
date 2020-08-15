using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload
{
    public class FileProvider
    {
        public static void Run()
        {
            var provider = new ServiceCollection()
                .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"D:\Study\NetCoreStudy\FileUpload\other"))
                .AddSingleton<FileManager>().BuildServiceProvider();

            var fileManage = provider.GetService<FileManager>();

            var content = fileManage.ReadAsync("test.txt").Result;
            Console.WriteLine(content);

            Console.ReadLine();
        }


        public class FileManager
        {
            private readonly IFileProvider _fileProvider;

            public FileManager(IFileProvider iFileProvider)
            {
                _fileProvider = iFileProvider;
            }


            public async Task<string> ReadAsync(string path)
            {
                await using (var stream=_fileProvider.GetFileInfo(path).CreateReadStream())
                {
                    var buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, buffer.Length);
                    return Encoding.Default.GetString(buffer);
                }
            }
        }
    }
}
