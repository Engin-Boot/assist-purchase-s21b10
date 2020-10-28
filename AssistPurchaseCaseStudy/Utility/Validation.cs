using System;
using AssistPurchaseCaseStudy.Repository;


namespace AssistPurchaseCaseStudy.Utility
{
    public class Validation
    {
        public bool CheckValidity(Models.AlertDataModel dataModel)
        {
            ProductRepository repository = new ProductRepository();
            bool productIdResponse = repository.CheckProductId(dataModel.ProductIdConfirmed);
            bool detailsresponse = CheckContactNoAndName(dataModel.CustomerContactNo, dataModel.CustomerName, dataModel.CustomerEmailId);
            if (productIdResponse == false || detailsresponse == false)
            {
                return false;
            }
            return true;

        }
        private bool CheckContactNoAndName(string contactno, string customername, string email)
        {
            if (ContactNocheck(contactno,email) || String.IsNullOrEmpty(customername))
            {
                return false;
            }
            return true;
        }
        private bool ContactNocheck(string contactno, string email)
        {
            if (String.IsNullOrEmpty(email) || contactno.Length != 10)
                return true;
            else
                return false;
        }
    }
}
