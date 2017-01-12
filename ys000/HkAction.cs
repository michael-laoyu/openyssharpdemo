using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ys000
{
    public class HkAction
    {        
        private static string _SafeKey = "ABCDEF";
        //访问令牌，通过接口调用获得
        public static string AccessToken;
        private static string ApiUrl = "https://open.ys7.com/api/method";
        private static string AppKey = "5c8abc7e11c94606b199fb771088c4db";//ConfigurationManager.AppSettings["AppKey"].ToString();//
        private static string AuthAddr = "https://auth.ys7.com";
        public static bool IsLoaded = false;//记录登录状态
        private static string PhoneNumber = "13384271168";//ConfigurationManager.AppSettings["PhoneNumber"].ToString();//
        private static string PlatformAddr = "https://open.ys7.com";
        private static string SecretKey = "d8289da6bec56abc8c7dce10d49af7e7"; // ConfigurationManager.AppSettings["SecretKey"].ToString();//
        public static IntPtr SessionId;
        public static int SessionIdLth;
        public static string SessionIdstr;
        private static int TokenLth = 0;
        private static int level = 0;//清晰度，0流畅，1标清，2高清
        public static string userId = "1b14cf56-b61d-43f5-a2c8-62b9626cbaaf";//自定义用户名，用guid防止重复
        //分配会话后，调用方法之后执行的回调函数
        static HkSDK.MsgHandler callBack = new HkSDK.MsgHandler(HkAction.HandlerWork);
        

        //初始化库
        public static bool Start()
        {
            return (HkSDK.OpenSDK_InitLib(AuthAddr, PlatformAddr, AppKey) == 0);
            
        }
        //反初始化库
        public static bool Close()
        {
            return (HkSDK.OpenSDK_FiniLib() == 0);
        }
        
        //获取accesstoken
        public static string GetAccessToken()
        {
            
            IntPtr iMessage;
            int iLength;
            string jsonStr = BuildParams("token");
            int aaa = HkSDK.OpenSDK_HttpSendWithWait(ApiUrl, jsonStr, "", out iMessage, out iLength);
           
            string returnstr = Marshal.PtrToStringAnsi(iMessage, iLength);
          
            if (aaa == 0)
            {
                JObject result = (JObject)JsonConvert.DeserializeObject(returnstr);
                if (result["result"]["code"].ToString() == "200")
                {
                    AccessToken = result["result"]["data"]["accessToken"].ToString();
                   
                    Debug.WriteLine(AccessToken);
                    
                }
                else
                {
                    Debug.WriteLine(result["result"]["code"].ToString());
                }
            }
            return AccessToken;
        }

        //处理json获取token
        public static string BuildParams(string _type)
        {
            string str = string.Empty;
            string str6 = _type.ToLower();
            if (str6 != null)
            {
                if (!(str6 == "token"))
                {
                    if (str6 == "msg")
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
        public static string MD5Encrypt(string str, int code)
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
        public static bool Login()
        {
            int num = HkSDK.OpenSDK_Mid_Login(ref AccessToken, ref TokenLth);
            return (HkSDK.OpenSDK_Mid_Login(ref AccessToken, ref TokenLth) == 0);
        }
        /*
        public static bool Login()
        {
            return (HkSDK.OpenSDK_Mid_Login(ref AccessToken, ref TokenLth) == 0);
        }*/

        //申请会话
        public static IntPtr AllocSession()
        {
            IntPtr userID = Marshal.StringToHGlobalAnsi(userId);
            bool flag = HkSDK.OpenSDK_AllocSession(callBack, userID, ref SessionId, ref SessionIdLth, false, uint.MaxValue) == 0;
            SessionIdstr = Marshal.PtrToStringAnsi(SessionId, SessionIdLth);
            return SessionId;
        }
        /*
        public static bool allocion()
        {
            HkSDK.MsgHandler Handler = new HkSDK.MsgHandler(HkSDK.HandlerWork);
            IntPtr UserID =Marshal.StringToHGlobalAnsi(userId);
            bool result = (HkSDK.OpenSDK_AllocSession(Handler, UserID, ref SessionId, ref SessionIdLth, false, 0xEA60) == 0);
            SessionIdstr = Marshal.PtrToStringAnsi(SessionId, SessionIdLth);
            return SessionIdstr;
        }*/

        //结束会话
        public static bool closeAllocion(IntPtr sid)
        {
            string sid1 = sid.ToString();
            return (HkSDK.OpenSDK_FreeSession(sid1)==0);
        }
        //结束会话重载无参
        public static bool closeAllocion1()
        {
            string sid1 = SessionId.ToString();
            return (HkSDK.OpenSDK_FreeSession(sid1) == 0);
        }

        //申请设备列表
        public static string playList()
        {
            IntPtr iMessage;
            int iLength;
            int aaa = HkSDK.OpenSDK_Data_GetDevList(AccessToken, 0, 50, out iMessage, out iLength);
            string returnstr = Marshal.PtrToStringAnsi(iMessage);
            if (aaa == 0)
            {
                JObject result = (JObject)JsonConvert.DeserializeObject(returnstr);
            }
            //Marshal.FreeHGlobal(iMessage); 
            return returnstr;
                             
        }

        //播放视频（预览）
        public static bool Play(IntPtr PlayWnd, string CameraId,IntPtr SessionId)
        {

            return (HkSDK.OpenSDK_StartRealPlay(SessionId, PlayWnd, CameraId, AccessToken, level, _SafeKey, AppKey, 0) == 0);
        }
        //停止播放（预览）
        public static bool Stop(IntPtr SessionId)
        {
            closeAllocion(SessionId);//每次播放结束会话            
            return HkSDK.OpenSDK_StopRealPlay(SessionId, 0)==0;            
        }

        //停止播放（预览）重载无参
        public static bool Stop1()
        {
            closeAllocion1();//每次播放结束会话
            if (HkSDK.OpenSDK_StopRealPlay(SessionId, 0) == 0)
                return HkSDK.OpenSDK_StopRealPlay(SessionId, 0) == 0;
            else return false;
        }
        //截图
        public static bool CapturePicture(string fileName)
        {
            if (!String.IsNullOrWhiteSpace(fileName))
            {
                return HkSDK.OpenSDK_CapturePicture(SessionId, fileName) == 0 ? true : false;
            }
            return false;
        }

        //回调函数
        public static int HandlerWork(IntPtr SessionId, uint MsgType, uint Error, string Info, IntPtr pUser)
        {
            switch (MsgType)
            {
                case 20:
                    JObject obj = (JObject)JsonConvert.DeserializeObject(Info);
                    if (Error == 0)
                    {
                        PlayMainWindow.jObjInfo = obj;
                        PlayMainWindow.isOpertion = 2;
                    }
                    break;
                case 3:// 播放开始
                    break;
                case 4:// 播放终止
                    break;
                case 5:// 播放结束，回放结束时会有此消息
                    PlayMainWindow.mType = PlayMainWindow.MessageType.INS_PLAY_ARCHIVE_END;
                    break;
                default:
                    break;
            }
            return 0;
        }
        public int MsgHandler1(IntPtr SessionId, uint MsgType, uint Error, string Info, IntPtr pUser)
        {
            return 1;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LP_NSCBMsg
        {
            public ushort iErrorCode;
            public string pMessageInfo;
        }

        public static Form MainForm { get; set; }

        public static bool IsOpertion { get; set; }//1已处理  0未处理   2正在处理
    }
    
}
