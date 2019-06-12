using System.Net.Http;
using Newtonsoft.Json;

namespace HR.Hospital.Client.Common
{
    public static class HttpClientApi
    {
        /// <summary>
        /// 执行Get操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetAsync<T>(string url)
        {
            var clarinet = new HttpClient();
            var mess = clarinet.GetAsync(url).Result;
            if (mess.IsSuccessStatusCode)
            {
                var result = mess.Content.ReadAsStringAsync().Result;//返回结果
                var model = JsonConvert.DeserializeObject<T>(result);//把json反序列化成对象
                return model;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 执行Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="model"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static U PostAsync<T, U>(T model, string url)
        {
            var client = new HttpClient();//声明一个操作http对象
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//数据返回格式是json
            var json = JsonConvert.SerializeObject(model);//序列成json字符串
            HttpContent context = new StringContent(json);
            context.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");//传递到服务器的数据格式
            var mess = client.PostAsync(url, context).Result;
            if (mess.IsSuccessStatusCode)
            {
                var Result = mess.Content.ReadAsStringAsync().Result;//返回结果
                U i = JsonConvert.DeserializeObject<U>(Result);
                return i;
            }
            else
            {
                return default(U);
            }
        }

        /// <summary>
        /// 执行Put操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TU"></typeparam>
        /// <param name="model"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static TU PutAsync<T, TU>(T model, string url)
        {
            var client = new HttpClient();//声明一个操作http对象
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//数据返回格式是json
            var json = JsonConvert.SerializeObject(model);//序列成json字符串
            HttpContent context = new StringContent(json);
            context.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");//传递到服务器的数据格式
            var mess = client.PutAsync(url, context).Result;
            if (mess.IsSuccessStatusCode)
            {
                var result = mess.Content.ReadAsStringAsync().Result;//返回结果
                TU i =JsonConvert.DeserializeObject<TU>(result);
                return i;
            }
            else
            {
                return default(TU);
            }
        }

        /// <summary>
        /// 执行删除操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T DeleteAsync<T>(string url)
        {
            var clarinet = new HttpClient();
            var mess = clarinet.DeleteAsync(url).Result;
            if (mess.IsSuccessStatusCode)
            {
                var result = mess.Content.ReadAsStringAsync().Result;//返回结果
                var model = JsonConvert.DeserializeObject<T>(result);//把json反序列化成对象
                return model;
            }
            else
            {
                return default(T);
            }
        }
    }
}

