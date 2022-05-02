using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestClient.VVG.RestClient
{
    public class RnClient<T> : RestClient<T>
    {
        public RnClient(string inEndpoint) : base(inEndpoint)
        {
        }

        public void serviceByworkOrderId(int workOrderId)
        {
            Task<HttpResponseMessage> responseTask = base.client.GetAsync("Service/WorkOrder/" + workOrderId);

            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                var responseContent = responseTask.Result.Content.ReadAsStringAsync();

                DataSource = JsonSerializer.Deserialize<IList<T>>(responseContent.Result);
            }
        }
    }
}
