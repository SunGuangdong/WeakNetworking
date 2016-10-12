using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouKe.Data;

namespace YouKe.Web.Game.Logic
{
    public class Logic100 : BaseLogic
    {
        public Logic100()
            : base(100)
        {

        }

        public override bool TakeLogic()
        {


            //ErrorInfo = "错误信息";
            //PushInfoId(100);


            //object obj = Serialization.Deserialize(NetMessageDef.ReqCreateRole, base.writeData);

            //protos.Login.ReqCreateRole reqCreateRole = obj as protos.Login.ReqCreateRole;


            protos.ReturnMessage.ResDefaultInfo resInfo = new protos.ReturnMessage.ResDefaultInfo();

            PushInfoId((int)NetMessageDef.ResReturnDefaultInfo);
            resInfo.results = 0;
            resInfo.details = "账号不存在!";
            byte[] bytes = Serialization.Serialize(new MuffinMsg(NetMessageDef.ResReturnDefaultInfo, resInfo));
            PushIntoStack(bytes);
            return true;
        }

    }
}