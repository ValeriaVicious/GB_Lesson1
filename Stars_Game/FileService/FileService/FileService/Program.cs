using FileHosting.Interface;
using FileHosting.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileHosting
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(FileService),
                new Uri("https://localhost:8080/FileService"));

            host.AddServiceEndpoint(typeof(IFileService),
                new BasicHttpsBinding(),
                "https://localhost:8080/FileService");

            host.Description.Behaviors.Add(new ServiceMetadataBehavior{
                HttpsGetEnabled = true
            });
            
            host.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");
           
            host.Open();

            
            Console.WriteLine("Хост запущен успешно!");
            Console.ReadLine();

        }

    }
}
