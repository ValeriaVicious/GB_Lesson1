using FileHosting.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FileServiceClient serviceClient = new FileServiceClient(new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8080/FileService"));

            FileInfo[] files = serviceClient.GetFiles(@"c:\123");

            foreach(FileInfo file in files)
            {
                Console.WriteLine(file.FullName);
            }

            serviceClient.StartProcess("calc", "");
            Console.ReadLine();
        }
    }

    class FileServiceClient : ClientBase<IFileService>, IFileService
    {
        public FileServiceClient(Binding binding, EndpointAddress endpoint)
            : base(binding, endpoint) {}

        public DirectoryInfo[] GetDirectories(string Path) => Channel.GetDirectories(Path);


        public DriveInfo[] GetDrives() => Channel.GetDrives();


        public FileInfo[] GetFiles(string Path) => Channel.GetFiles(Path);


        public DateTime GetServiceTime() => Channel.GetServiceTime();


        public int StartProcess(string Path, string Args) => Channel.StartProcess(Path, Args);

    }
}
