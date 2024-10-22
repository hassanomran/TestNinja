using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IDownloadFileRepository
    { void DownloadFile(string address, string fileName); }
    public class DownloadFileRepository : IDownloadFileRepository
    {
        public void DownloadFile(string address, string fileName)
        {
            var client = new WebClient();
            client.DownloadFile(address, fileName);


        }

    }
}
