namespace Exline.Notifier
{
    public class APNSServiceConfig : ServiceConfig
    {
        public APNSServiceConfig(string certificateFilePath)
            : base()
        {
            CertificateFilePath=certificateFilePath;
        }
        public string CertificateFilePath { get; set; }
    }
}