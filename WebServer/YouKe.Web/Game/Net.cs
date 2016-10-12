using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using YouKe.Common;

namespace YouKe.Web.Game
{
    public class Net
    {
        #region 数据定义
        private static Net mInstance;
        public static Net Instance
        {
            get
            {
                if(mInstance == null)
                {
                    mInstance = new Net();
                }
                return mInstance;
            }
            
        }
        /// <summary>
        /// 请求
        /// </summary>
        public HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        /// <summary>
        /// 响应
        /// </summary>
        public HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }

        #endregion

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="response">响应</param>
        public void Receive()
        {
            if(YKRequest.IsPost())
            {
                PostReceive();
            }
            else if(YKRequest.IsGet())
            {
                GetReceive();
            }
        }

        /// <summary>
        /// post 接收protobuf
        /// </summary>
        private void PostReceive()
        {
            try
            {
                NameValueCollection header = Request.Headers;

                string[] reqCmdId = header.GetValues("cmdId");
                string[] reqUserId = header.GetValues("userId");

                int id = int.Parse(reqCmdId[0]);
                int userId = int.Parse(reqUserId[0]);
                BaseLogic gameLogic = LogicFactory.Create(id);
                if (gameLogic == null)
                {
                    throw new ArgumentException(string.Format("Not found {0} of GameLogic object.", id));
                }
                if(gameLogic.DoLogic())
                {
                    //gameLogic.BuildPacket();
                }
                gameLogic.Write();
            }
            catch(Exception e)
            {
                Response.Write(e);
            }
        }

        /// <summary>
        /// get 接收json
        /// </summary>
        private void GetReceive()
        {
            Response.Write("不支持GET访问，请用post发送！");
        }
    }
}