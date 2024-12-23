﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IDownloadFileRepository _downloadFileRepository;
        private string _setupDestinationFile;
        public InstallerHelper(IDownloadFileRepository downloadFileRepository)
        {
            _downloadFileRepository = downloadFileRepository;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _downloadFileRepository.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}