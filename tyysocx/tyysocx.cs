using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace tyysocx
{
    [Guid("B9414270-ED53-46CE-A40F-802FE2D8AF8B")]
    public partial class tyysocx : UserControl, IObjectSafety
    {
        private int _playMode = -1;
        private const int MAX_PLAY_BOX = 16;
        private List<PictureBox> _listPlayBox = new List<PictureBox>(MAX_PLAY_BOX);
        private PictureBox _currSelectedBox = null;

        public tyysocx()
        {
            InitializeComponent();
            InitListPlayBox();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        //public PictureBox GetCurrSelectedBox
        //{
        //    get
        //    {
        //        return _currSelectedBox;
        //    }
        //}

        public bool LoginImmediately()
        {
            return HkApi.LoginImmediately();
        }

        public bool LoginByMid()
        {
            return HkApi.Login();
        }

        public string GetCameraList4JsonString()
        {
            return HkApi.GetCameraList4Json();
        }

        public HkApi.GetDevListResult GetCameraList()
        {
            return HkApi.GetCameraList();
        }

        /// <summary>
        /// 设置播放界面（1画面、4画面、16画面等） 
        /// </summary>
        /// <param name="playerMode"></param>
        public void InitPlayBox(int playerMode)
        {
            this._playMode = playerMode;
            int formWidth = playboxPanel.Width;
            int formHeight = playboxPanel.Height;
            int count = Convert.ToInt32(Math.Sqrt(playerMode));
            int padding = 3;
            int boxWidth = formWidth / count;
            int boxHeight = formHeight / count;
            playboxPanel.Controls.Clear();
            using (Graphics g = playboxPanel.CreateGraphics())
            {
                g.Clear(playboxPanel.BackColor);
            }
            for (int i = playerMode; i < MAX_PLAY_BOX; i++)
            {
                PictureBox box = _listPlayBox[i];
                PlayObject obj = box.Tag as PlayObject;
                OnClosePlayBox(obj);
                playboxPanel.Controls.Remove(box);
            }
            for (int i = 0; i < playerMode; i++)
            {
                PictureBox box = _listPlayBox[i];
                box.Size = new Size(boxWidth - padding * 2, boxHeight - padding * 2);
                box.Margin = new System.Windows.Forms.Padding(padding);
                playboxPanel.Controls.Add(box);
            }
        }

        public bool StartPlay(string cameraId)
        {
            if (_currSelectedBox != null)
            {
                PlayObject obj = _currSelectedBox.Tag as PlayObject;
                OnClosePlayBox(obj);
                IntPtr hwnd = _currSelectedBox.Handle;
                IntPtr sessionId = HkApi.AllocSession();
                HkApi.StartPlay(hwnd, cameraId, sessionId);

                obj.IsPlaying = true;
                obj.SessionId = sessionId;
                obj.CameraId = cameraId;
                OnPlayingBox(_currSelectedBox);
                _currSelectedBox = null;
            }
            else
            {
                PictureBox box = GetIdleBox();
                if (box != null)
                {
                    PlayObject obj = box.Tag as PlayObject;
                    IntPtr hwnd = box.Handle;
                    IntPtr sessionId = HkApi.AllocSession();
                    HkApi.StartPlay(hwnd, cameraId, sessionId);

                    obj.IsPlaying = true;
                    obj.SessionId = sessionId;
                    obj.CameraId = cameraId;
                    OnPlayingBox(box);
                }
            }
            return false;
        }


        /// <summary>
        /// 释放视频
        /// </summary>
        public void DisposeCamera()
        {
            try
            {
                foreach (PictureBox box in _listPlayBox)
                {
                    PlayObject obj = box.Tag as PlayObject;
                    OnClosePlayBox(obj);
                }
                HkApi.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            btn1.Click += Btn_Click;
            btn4.Click += Btn_Click;
            btn9.Click += Btn_Click;
            btn16.Click += Btn_Click;
            Btn_Click(btn4, EventArgs.Empty);//调用InitPlayBox，初始化界面，默认是4个播放页面；
            //PlayBoxClick(_listPlayBox[0], EventArgs.Empty); //默认选择第一个box;
            HkApi.Init();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_playMode > 0 && _listPlayBox.Count > 0)
            {
                InitPlayBox(_playMode);
            }
        }

        /// <summary>
        /// 获取空闲的播放box
        /// </summary>
        /// <returns></returns>
        private PictureBox GetIdleBox()
        {
            if (_listPlayBox.Count >= _playMode)
            {
                for (int i = 0; i < _playMode; i++)
                {
                    PictureBox box = _listPlayBox[i];
                    PlayObject obj = box.Tag as PlayObject;
                    if (!obj.IsPlaying)
                    {
                        return box;
                    }
                }
            }
            return null;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //...
        }

        private void OnClosePlayBox(PlayObject obj)
        {
            if (obj.IsPlaying)
            {
                HkApi.StopPlay(obj.SessionId);
                obj.SessionId = IntPtr.Zero;
                obj.CameraId = string.Empty;
                obj.IsPlaying = false;
            }
        }

        private void InitListPlayBox()
        {
            for (int i = 0; i < MAX_PLAY_BOX; i++)
            {
                PictureBox box = new PictureBox();
                box.BackColor = Color.Black;
                PlayObject obj = new PlayObject();
                obj.Index = i;
                box.Tag = obj;
                box.Click += PlayBoxClick;
                _listPlayBox.Add(box);
            }
        }

        private void PlayBoxClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox p = sender as PictureBox;
                _currSelectedBox = p;
                OnSelectedBox(p);
            }
            catch (Exception)
            {
            }
        }

        private void OnSelectedBox(PictureBox box)
        {
            using (Graphics g = playboxPanel.CreateGraphics())
            {
                g.Clear(playboxPanel.BackColor);
                Pen pen = new Pen(Color.Blue, 3);
                //g.DrawRectangle(pen, box.Bounds.X - 2, box.Bounds.Y - 2, box.Bounds.X + box.Bounds.Width, box.Bounds.Y + box.Bounds.Height);
                g.DrawRectangle(pen, box.Bounds.X - 2, box.Bounds.Y - 2, box.Bounds.Width + 3, box.Bounds.Height + 3);
            }
        }

        private void OnPlayingBox(PictureBox box)
        {
            using (Graphics g = playboxPanel.CreateGraphics())
            {
                g.Clear(playboxPanel.BackColor);
                Pen pen = new Pen(Color.DarkViolet, 3);
                //g.DrawRectangle(pen, box.Bounds.X - 2, box.Bounds.Y - 2, box.Bounds.X + box.Bounds.Width, box.Bounds.Y + box.Bounds.Height);
                g.DrawRectangle(pen, box.Bounds.X - 2, box.Bounds.Y - 2, box.Bounds.Width + 3, box.Bounds.Height + 3);
            }
        }

        private class PlayObject
        {
            public int Index;
            public IntPtr SessionId;
            public bool IsPlaying = false;
            public string CameraId;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Image bgImg = null;
            if (btn == this.btn1)
            {
                bgImg = Properties.Resources.v_1_a;
                _playMode = 1;
            }
            if (btn == btn4)
            {
                bgImg = Properties.Resources.v_4_a;
                _playMode = 4;
            }
            if (btn == btn9)
            {
                bgImg = Properties.Resources.v_9_a;
                _playMode = 9;
            }
            if (btn == btn16)
            {
                bgImg = Properties.Resources.v_16_a;
                _playMode = 16;
            }
            btn.BackgroundImage = null;
            btn.BackgroundImage = bgImg;
            InitPlayBox(_playMode);
        }

        #region IObjectSafety 

        private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";
        private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";
        private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";
        private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";
        private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

        private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001;
        private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002;
        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);
        private const int E_NOINTERFACE = unchecked((int)0x80004002);

        private bool _fSafeForScripting = true;
        private bool _fSafeForInitializing = true;

        public int GetInterfaceSafetyOptions(ref Guid riid, [MarshalAs(UnmanagedType.U4)] ref int pdwSupportedOptions, [MarshalAs(UnmanagedType.U4)] ref int pdwEnabledOptions)
        {
            int Rslt = E_FAIL;

            string strGUID = riid.ToString("B");
            pdwSupportedOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA;
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForScripting == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForInitializing == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_DATA;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }

            return Rslt;
        }

        public int SetInterfaceSafetyOptions(ref Guid riid, [MarshalAs(UnmanagedType.U4)] int dwOptionSetMask, [MarshalAs(UnmanagedType.U4)] int dwEnabledOptions)
        {
            int Rslt = E_FAIL;
            string strGUID = riid.ToString("B");
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_CALLER) && (_fSafeForScripting == true))
                        Rslt = S_OK;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_DATA) && (_fSafeForInitializing == true))
                        Rslt = S_OK;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }

            return Rslt;
        }

        #endregion
    }
}
