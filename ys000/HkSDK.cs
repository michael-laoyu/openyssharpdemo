using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ys000
{
    public class HkSDK
    {

        [DllImport("OpenNetStream.dll")]//SDK启动
        public static extern int OpenSDK_InitLib(string AuthAddr, string Platform, string AppId);


        [DllImport("OpenNetStream.dll")]//SDK关闭
        public static extern int OpenSDK_FiniLib();


        [DllImport("OpenNetStream.dll")]//SDK第三方登陆
        public static extern int OpenSDK_Mid_Login(ref string pToken, ref int TokenLth);
                
        [DllImport("OpenNetStream.dll")]
        public static extern int OpenSDK_HttpSendWithWait(string szUri, string szHeaderParam, string szBody, out IntPtr iMessage, out int iLength);

        [DllImport("OpenNetStream.dll")]//SDK申请会话
        public static extern int OpenSDK_AllocSession(MsgHandler CallBack, IntPtr UserID, ref IntPtr pSID, ref int SIDLth, bool bSync, uint timeout);
        //及其回调函数格式
        public delegate int MsgHandler(IntPtr SID, uint MsgType, uint Error, string Info, IntPtr pUser);
        
        //回调实例
        public static int HandlerWork(IntPtr SID, uint MsgType, uint Error, string Info, IntPtr pUser)
        {
            return 0;
        }

        [DllImport("OpenNetStream.dll")]//SDK关闭会话
        public static extern int OpenSDK_FreeSession(string SID);

        [DllImport("OpenNetStream.dll")]//SDK开始播放
        public static extern int OpenSDK_StartRealPlay(IntPtr SID, IntPtr PlayWnd, string CameraId, string Token, int VideoLevel, string SafeKey, string AppKey, uint pNSCBMsg);

        [DllImport("OpenNetStream.dll")]//SDK关闭播放
        public static extern int OpenSDK_StopRealPlay(IntPtr SID,uint pNSCBMsg);

        
        [DllImport("OpenNetStream.dll")]//截屏
        public static extern int OpenSDK_CapturePicture(IntPtr SID, string szFileName);

        [DllImport("OpenNetStream.dll")]//设置数据回调窗口
        public static extern int OpenSDK_SetDataCallBack(IntPtr sessionId, OpenSDK_DataCallBack pDataCallBack, string pUser);

        //SDK获取所有设备摄像机列表
        [DllImport("OpenNetStream.dll")]
        public static extern int OpenSDK_Data_GetDevList(string accessToken, int iPageStart, int iPageSize, out IntPtr iMessage, out int iLength);

        //回调函数格式
        public delegate void OpenSDK_DataCallBack(CallBackDateType dateType, IntPtr dateContent, int dataLen, string pUser);
        public static void DataCallBackHandler(CallBackDateType dataType, IntPtr dataContent, int dataLen, string pUser)
        {

        }
        //数据回调设置
        public enum CallBackDateType
        {
            NET_DVR_SYSHEAD = 0,
            NET_DVR_STREAMDATA = 1,
            NET_DVR_RECV_END = 2,
        };

              

        /*
        //SDK Http请求接口
        [DllImport(@"OpenNetStream.dll")]
        public static extern int OpenSDK_HttpSendWithWait(string szUri, string szHeaderParam, string szBody, out IntPtr iMessage, out int iLength);

        
        //SDK获取指定设备摄像机信息
        [DllImport(@"OpenNetStream.dll")]
        public static extern int OpenSDK_Data_GetDeviceInfo(string accessToken, string szDeviceSerial, out IntPtr iMessage, out int iLength);

        //SDK播放指定摄像机
        [DllImport(@"OpenNetStream.dll", EntryPoint = "OpenSDK_StartRealPlay", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int OpenSDK_StartRealPlay(string szSessionId, IntPtr hPlayWnd, string szCameraId, string szAccessToken, int iVideoLevel, string szSafeKey, string szAppKey);
        */
    }
}
