using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;


namespace AssistPurchaseCaseStudy.Repository
{

    public class AlertRepository : IAlertRepository
    {
        readonly List<AlertDataModel> _alertsdb = new List<AlertDataModel>();
        public AlertRepository()
        {
            _alertsdb.Add(new AlertDataModel
            {
                CustomerName = "Tom",
                CustomerContactNo = "8765432019",
                CustomerRegion = "north",
                CustomerEmailId = "tom@gmail.com",
                ProductIdConfirmed = "P101",
                AlertSent = false,
                OrderId = 1

            });
            _alertsdb.Add(new AlertDataModel
            {
                CustomerName = "Harry",
                CustomerContactNo = "1234567898",
                CustomerRegion = "east",
                CustomerEmailId = "harry@gmail.com",
                ProductIdConfirmed = "P109",
                AlertSent = false,
                OrderId = 2

            });
        }

        public void Add(AlertDataModel dataModel)
        {
            _alertsdb.Add(dataModel);
        }
        public IEnumerable<AlertDataModel> GetCustomers()
        {
            return _alertsdb;
        }

        public IEnumerable<AlertDataModel> GetRegionSpecificCustomers(string region)
        {
            List<AlertDataModel> dataModels = new List<AlertDataModel>();

            foreach (AlertDataModel customer in _alertsdb)
            {
                if (customer.CustomerRegion == region)
                {
                    dataModels.Add(customer);
                }
            }
            return dataModels;
        }

        public IEnumerable<AlertDataModel> GetNewCustomers()
        {
            List<AlertDataModel> dataModels = new List<AlertDataModel>();

            foreach (AlertDataModel customer in _alertsdb)
            {
                if (customer.AlertSent == false)
                {
                    dataModels.Add(customer);
                }
            }
            return dataModels;
        }

        public bool UpdateConsumerAlert(int orderId)
        {
            bool flag = false;
            foreach(AlertDataModel alertData in _alertsdb)
            {
                if (alertData.OrderId == orderId)
                {
                    alertData.AlertSent = true;
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool CheckConsumerExist(int orderId)
        {
            bool flag = false;
            foreach (AlertDataModel alertData in _alertsdb)
            {
                if (alertData.OrderId == orderId)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
