using System.Net;

namespace OtusHomework
{
    internal class ImageDownloader
    {
        public event Action DownloadStarted;

        public event Action DownloadCompleted;

        private readonly string _remoteUri;

        private readonly string _fileName;

        public ImageDownloader()
        {
            _remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
            _fileName = "bigimage.jpg";
        }

        public async Task DownloadAsync()
        {
            var myWebClient = new WebClient();

            if (DownloadStarted is not null)
            {
                DownloadStarted();
            }

            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", _fileName, _remoteUri);
            await myWebClient.DownloadFileTaskAsync(_remoteUri, _fileName);
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", _fileName, _remoteUri);

            if (DownloadCompleted is not null)
            {
                DownloadCompleted();
            }
        }
    }
}
