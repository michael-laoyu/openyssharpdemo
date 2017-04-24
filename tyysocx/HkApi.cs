using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace tyysocx
{
    public class HkApi
    {


        private static string _SafeKey = "ABCDEF";
        //访问令牌，通过接口调用获得
        private static string AccessToken=string.Empty;
        private static int AccessTokenLength= 0;
        private static string ApiUrl = "https://open.ys7.com/api/method";
        //private static string AppKey = "5c8abc7e11c94606b199fb771088c4db";//盘锦大洼；//ConfigurationManager.AppSettings["AppKey"].ToString();//
        private static string AppKey = "5c8abc7e11c94606b199fb771088c4db";//盘锦移动

        private static string AuthAddr = "https://auth.ys7.com";
        //private static string PhoneNumber = "13384271168";//盘锦大洼；//ConfigurationManager.AppSettings["PhoneNumber"].ToString();//
        private static string PhoneNumber = "18969185796";//盘锦移动
        private static string PlatformAddr = "https://open.ys7.com";
        //private static string SecretKey = "d8289da6bec56abc8c7dce10d49af7e7"; //盘锦大洼 ConfigurationManager.AppSettings["SecretKey"].ToString();//
        private static string SecretKey = "dda8fd0c33eda787877dc709dcb3d948";//盘锦移动

        private static int videoQualityLevel = 0;//清晰度，0流畅，1标清，2高清
        private static string userId = "1b14cf56-b61d-43f5-a2c8-62b9626cbaaf";//自定义用户名，用guid防止重复
        //分配会话后，调用方法之后执行的回调函数
        static HkSDK.MsgHandler msgHandler = new HkSDK.MsgHandler(HkApi.MsgHandler);

        //初始化库
        public static bool Init()
        {
            return (HkSDK.OpenSDK_InitLib(AuthAddr, PlatformAddr, AppKey) == 0);
        }
        //反初始化库
        public static bool Close()
        {
            return (HkSDK.OpenSDK_FiniLib() == 0);
        }

        //获取accesstoken
        public static bool LoginImmediately()
        {
            IntPtr pBuf;
            int iLength;
            string header = BuildHeaderParas("token");
            int ret = HkSDK.OpenSDK_HttpSendWithWait(ApiUrl, header, "", out pBuf, out iLength);

            string returnstr = Marshal.PtrToStringAnsi(pBuf, iLength);
            //string accessToken = string.Empty;
            if (ret == 0)
            {
                JObject result = (JObject)JsonConvert.DeserializeObject(returnstr);
                if (result["result"]["code"].ToString() == "200")
                {
                    HkApi.AccessToken = result["result"]["data"]["accessToken"].ToString();
                    Debug.WriteLine(HkApi.AccessToken);
                }
                else
                {
                    Debug.WriteLine(result["result"]["code"].ToString());
                }
            }
            return ret == 0;
        }

        //处理json获取token
        private  static string BuildHeaderParas(string action)
        {
            string str = string.Empty;
            action = action.ToLower();
            if (action != null)
            {
                if (!(action == "token"))
                {
                    if (action == "msg")
                    {
                        str = "msg/get";
                    }
                    else
                    {
                        str = "msg/get";
                    }
                }
                else
                {
                    str = "token/getAccessToken";
                }
            }
            TimeSpan span = (TimeSpan)(DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x7b2, 1, 1, 0, 0, 0)));
            string str2 = Math.Round(span.TotalSeconds, 0).ToString();
            string str3 = MD5Encrypt("phone:" + PhoneNumber + ",method:" + str + ",time:" + str2 + ",secret:" + SecretKey, 0x20).ToLower();
            return ("{\"id\":\"100\",\"system\":{\"key\":\"" + AppKey + "\",\"sign\":\"" + str3 + "\",\"time\":\"" + str2 + "\",\"ver\":\"1.0\"},\"method\":\"" + str + "\",\"params\":{\"phone\":\"" + PhoneNumber + "\"}}");
        }

        //MD5加密
        private static string MD5Encrypt(string str, int code)
        {
            MD5 md = new MD5CryptoServiceProvider();
            Encoding encoding = Encoding.UTF8;
            byte[] buffer = md.ComputeHash(encoding.GetBytes(str));
            StringBuilder builder = new StringBuilder(code);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }

        //第三方登录
        public unsafe static bool Login()
        {
            int ret = -1;
            try
            {
                string token = string.Empty;
                char* pToken = (char*)Marshal.StringToBSTR(token);
                int pLen = 0;
                ret = HkSDK.OpenSDK_Mid_Login(&pToken, &pLen);
                if (ret == 0)
                {
                    AccessToken = Marshal.PtrToStringAnsi((IntPtr)pToken, pLen);
                    AccessTokenLength = pLen;
                }
            }
            catch (Exception)
            {
            }
            return (ret == 0);
        }

        //申请会话
        public static IntPtr AllocSession()
        {
            IntPtr userID = Marshal.StringToHGlobalAnsi(userId);
            IntPtr sessionId = IntPtr.Zero;
            int sidLength = -1;
            bool flag = HkSDK.OpenSDK_AllocSession(msgHandler, userID, ref sessionId, ref sidLength, false, uint.MaxValue) == 0;
            //SessionIdstr = Marshal.PtrToStringAnsi(sessionId, sidLength);
            return sessionId;
        }

        //结束会话
        public static bool CloseAllocion(IntPtr sid)
        {
            string sid1 = sid.ToString();
            return (HkSDK.OpenSDK_FreeSession(sid1) == 0);
        }


        //获取设备列表 返回jsonstr
        public static GetDevListResult GetCameraList()
        {
            IntPtr pBuf;
            int iLength;
            int ret = HkSDK.OpenSDK_Data_GetDevList(AccessToken, 0, 50, out pBuf, out iLength);
            string returnJsonStr = Marshal.PtrToStringAnsi(pBuf);
            GetDevListResult result = null;
            if (ret == 0)
            {
                result = (GetDevListResult)JsonConvert.DeserializeObject(returnJsonStr, typeof(GetDevListResult));
            }
            //Marshal.FreeHGlobal(pBuf); 
            return result;
        }

        public static string GetCameraList4Json()
        {
            IntPtr pBuf;
            int iLength;
            int ret = HkSDK.OpenSDK_Data_GetDevList(AccessToken, 0, 50, out pBuf, out iLength);
            string returnJsonStr = Marshal.PtrToStringAnsi(pBuf);
            //GetDevListResult result = null;
            if (ret == 0)
            {
                //result = (GetDevListResult)JsonConvert.DeserializeObject(returnJsonStr, typeof(GetDevListResult));
                return returnJsonStr;
            }
            //Marshal.FreeHGlobal(pBuf); 
            return string.Empty;
        }

        //播放视频（预览）
        public static bool StartPlay(IntPtr hWnd, string cameraId, IntPtr sessionId)
        {
            return (HkSDK.OpenSDK_StartRealPlay(sessionId, hWnd, cameraId, AccessToken, videoQualityLevel, _SafeKey, AppKey, 0) == 0);
        }

        //停止播放（预览）
        public static bool StopPlay(IntPtr SessionId)
        {
            CloseAllocion(SessionId);//每次播放结束会话            
            return HkSDK.OpenSDK_StopRealPlay(SessionId, 0) == 0;
        }

       
        //截图
        public static bool CapturePicture(IntPtr sessionId, string fileName)
        {
            if (!String.IsNullOrWhiteSpace(fileName))
            {
                return HkSDK.OpenSDK_CapturePicture(sessionId, fileName) == 0 ? true : false;
            }
            return false;
        }

        //回调函数
        public static int MsgHandler(IntPtr sessionId, uint msgType, uint error, string info, IntPtr pUser)
        {
            switch (msgType)
            {
                case 20:
                    JObject obj = (JObject)JsonConvert.DeserializeObject(info);
                    if (error == 0)
                    {
                        //PlayMainWindow.jObjInfo = obj;
                        //PlayMainWindow.isOpertion = 2;
                    }
                    break;
                case 3:// 播放开始
                    break;
                case 4:// 播放终止
                    break;
                case 5:// 播放结束，回放结束时会有此消息
                    //PlayMainWindow.mType = PlayMainWindow.MessageType.INS_PLAY_ARCHIVE_END;
                    break;
                default:
                    break;
            }
            return 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LP_NSCBMsg
        {
            public ushort iErrorCode;
            public string pMessageInfo;
        }

        //public static System.Windows.Forms.Form MainForm { get; set; }

        //public static bool IsOpertion { get; set; }//1已处理  0未处理   2正在处理

        public class GetDevListResult
        {
            public int resultCode { get; set; }
            public int count { get; set; }
            public List<camera> cameraList { get; set; }
        }

        public class camera
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
    }
}
