
namespace Exline.Notifier.Data.Collections
{
    public class ApplicationApiKeyCollection:BaseCollection
    {
        public ApplicationApiKeyCollection()
            :base()
        {

        }
        public string ApiKey{get;set;}

        public int TotalRequestCount{get;set;}
        
    }
}