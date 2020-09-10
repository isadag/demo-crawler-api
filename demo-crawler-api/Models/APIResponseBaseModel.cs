using System;
namespace demo_crawler_api.Models
{
    public class APIResponseBaseModel
    {
        public bool Success { get; set; }
        public object Result { get; set; }
    }
}
