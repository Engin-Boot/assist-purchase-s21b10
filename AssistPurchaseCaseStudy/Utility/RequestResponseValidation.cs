using AssistPurchaseCaseStudy.Models;
using AssistPurchaseCaseStudy.Repository;

namespace AssistPurchaseCaseStudy.Utility
{
    public class RequestResponseValidation
    {
        public bool IsRequestResponseCorrect(RequestResponse requestResponse)
        {
            var suggestionPathObj = new SuggestionPaths();
            if(suggestionPathObj.ListOfLayers.Contains(requestResponse.Layer))
            {
                foreach(var layermember in requestResponse.LayerMembers)
                {
                    if (!suggestionPathObj.ValidLayerMembers[requestResponse.Layer].Contains(layermember))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool IsChoicesMade(string[] choices)
        {
            if((string.Join("",choices) == ""))
            {
                return false;
            }
            return true;
        }

        public bool IsGetProductRequestCorrect(RequestResponse requestResponse)
        {
            if(requestResponse.ChoiceDictionary.Count!=0)
            {
                return true;
            }
            return false;
        }
    }
}
