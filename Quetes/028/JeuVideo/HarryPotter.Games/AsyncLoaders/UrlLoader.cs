using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLoaders
{
    internal class UrlLoader
    {

        public async Task<int> Load(string url)
        {
            var client = new HttpClient();

            string content = await client.GetStringAsync(url);

            return content.Length;
        }
    }
}
