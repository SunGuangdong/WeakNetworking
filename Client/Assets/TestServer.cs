using UnityEngine;
using System.Collections;
using System;
using YouKe.Data;

public class TestServer : MonoBehaviour, INotifier
{
    private GameServerMgr _gsMgr;

    void Start()
    {
        _gsMgr = GameServerMgr.GetInstance();

        // 注册 收听器
        _gsMgr.RegisterNotifier(NetMessageDef.ResReturnDefaultInfo, this);

        // 发请求
        protos.Login.ReqLogin loginTest = new protos.Login.ReqLogin();
        loginTest.account = "s001";
        loginTest.password = "123456";
        _gsMgr.SendMessage(new MuffinMsg(100, loginTest));

        //_gsMgr.Test();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmdId"></param>
    /// <param name="param1">接收到的信息</param>
    /// <param name="param2">接收到的附加信息， 扩展暂时用不到</param>
    public void OnReceiveData(uint cmdId, object param1, object param2)
    {
        protos.ReturnMessage.ResDefaultInfo info = param1 as protos.ReturnMessage.ResDefaultInfo;

        Debug.Log("返回结果： " + info.results);
        Debug.Log("返回细节： " + info.details);
    }
}
