using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetPlayMobile.Services
{
    public class RemoteService : ApiService
    {
        private readonly string _Url;
        public RemoteService()
        {
            _Url += URL + "remote/";
        }

        public async Task SetState(LedQueryInfo model)
        {
            var client = GetClient();
            var content = GetHttpContent(model);

            var response = await client.PostAsync(_Url + "set-state", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception();
            }
        }
    }

    public class LedQueryInfo
    {
        public int Led { get; set; }
        public int State { get; set; }
    }
}
