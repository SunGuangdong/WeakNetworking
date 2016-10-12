using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace YouKe.Data
{
    public class MuffinMsg
    {
        public uint cmdId = 0;
        /// <summary>
        /// ProtocalBuffer的数据类
        /// </summary>
        public object pBObject = null;

        public MuffinMsg(uint cmd, object pb)
        {
            cmdId = cmd;
            pBObject = pb;
        }
    }

    public class Serialization
    {
        public Serialization() { }

        #region 序列化proto
        /// <summary>
        /// 序列化成proto
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] Serialize(MuffinMsg msg)
        {
            MemoryStream memStream = new MemoryStream();
            ProtoBuf.Serializer.Serialize<IExtensible>(memStream, msg.pBObject as IExtensible);
            byte[] x = memStream.ToArray();
            memStream.Close();
            return x;
        }
        #endregion

        #region 反序列化proto
        /// <summary>
        /// 反序列化proto
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object Deserialize(uint cmdId, byte[] bytes)
        {
            switch (cmdId)
            {
                case NetMessageDef.ReqLogin:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.Login.ReqLogin>(new MemoryStream(bytes));
                    }
                case NetMessageDef.ReqCreateAccount:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.Login.ReqCreateAccount>(new MemoryStream(bytes));
                    }
                case NetMessageDef.ResReturnDefaultInfo:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.ReturnMessage.ResDefaultInfo>(new MemoryStream(bytes));
                    }
                case NetMessageDef.ReqGetRole:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.Login.ReqGetRole>(new MemoryStream(bytes));
                    }
                case NetMessageDef.ResGetRole:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.Login.ResGetRole>(new MemoryStream(bytes));
                    }
                case NetMessageDef.ReqGetFriendList:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.friend.ReqGetFriendList>(new MemoryStream(bytes));
                    }
                case NetMessageDef.ResFriendList:
                    {
                        return ProtoBuf.Serializer.Deserialize<protos.friend.ResFriendList>(new MemoryStream(bytes));
                    }
                default:
                    {
                        Console.WriteLine("MuffinMsg.Deserialize: unhandled cmdId->" + cmdId.ToString());
                        return null;
                    }
            }
            //return ProtoBuf.Serializer.Deserialize<test.HeroLevel>(new MemoryStream(bytes));
        }
        #endregion
    }
}