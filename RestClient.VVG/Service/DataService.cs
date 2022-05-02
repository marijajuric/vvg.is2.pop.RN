using Model.VVG.model;
using RestClient.VVG.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.VVG.Service
{
    public sealed class DataService
    {
        // *??
        public static string baseUrl { get; set; } = "https://localhost:7109";

        private static readonly DataService instance = new DataService();
        public static RestClient<WorkOrderService> serviceRestClient { get; set; }
        public static RnClient<Equipment> warehouseRestClient { get; set; }
        public static RestClient<Equipment> equipmentRestClient { get; set; }


        private DataService()
        {
            Initialize();
        }

        public static DataService Instance
        {

            get { return instance; }
        }

        public static void Initialize()
        {
            serviceRestClient = new RestClient<WorkOrderService>("Service");
            warehouseRestClient = new RnClient<Equipment>("Equipment");
            equipmentRestClient = new RestClient<Equipment>("Equipment");
        }

    }
}
