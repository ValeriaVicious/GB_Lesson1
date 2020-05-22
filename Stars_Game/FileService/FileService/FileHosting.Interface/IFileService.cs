using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace FileHosting.Interface
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        DateTime GetServiceTime();

        [OperationContract]
        DriveInfo[] GetDrives();

        [OperationContract]
        FileInfo[] GetFiles(string Path);

        [OperationContract]
        DirectoryInfo[] GetDirectories(string Path);

        [OperationContract]
        int StartProcess(string Path, string Args);
    }
}
