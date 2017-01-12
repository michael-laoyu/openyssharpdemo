using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace ys000
{
    public class camera
    {
        //
        public class json
        {
            public int resultCode { get; set; }
            public int count { get; set; }
            public List<cameraList> carameList { get; set; }
        }

        public class cameraList
        {
            public string cameraId { get; set; }
            public string cameraName { get; set; }
            public int cameraNo { get; set; }
            public int defence { get; set; }
            public string deviceId { get; set; }
            public string deviceName { get; set; }
            public int deviceSerial { get; set; }
            public int isEncrypt { get; set; }
            public int isShared { get; set; }
            public string picUrl { get; set; }
            public int status { get; set; }
            public int videoLevel { get; set; }
        }


        //处理json的方法
        public static string jsonHandle(string str)
        {
            string devid = string.Empty;
            string jsonStr = str;
            JObject jsonObj = JObject.Parse(jsonStr);
            JArray jar = JArray.Parse(jsonObj["cameraList"].ToString());
            JObject j = JObject.Parse(jar[1].ToString());
            devid=j["deviceId"].ToString();
            return devid;
                       
        }

    }   
}
