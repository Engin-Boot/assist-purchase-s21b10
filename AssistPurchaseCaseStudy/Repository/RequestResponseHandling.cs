using AssistPurchaseCaseStudy.Models;

namespace AssistPurchaseCaseStudy.Repository
{
    public class RequestResponseHandling : IRequestResponseHandling
    {

        public RequestResponse GetSampleResponse()
        {
            RequestResponse sendResponse = new RequestResponse();
            return sendResponse;
        }
    }
}
