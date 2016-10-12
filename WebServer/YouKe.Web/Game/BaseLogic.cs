using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouKe.Data;
using YouKe.Web.Game;

public abstract class BaseLogic
{
    public BaseLogic(int logicId)
    {
        this.logicId = logicId;
        writeData = new NetWrite();
    }

    #region 数据定义
    public int logicId;
    public int UserId;
    /// <summary> 响应数据 </summary>
    public NetWrite writeData;

    /// <summary>
    /// 是否是错误的URL请求串
    /// </summary>
    private bool IsError = false;
    /// <summary>
    /// 返回Logic是否为ErrorAction
    /// </summary>
    /// <returns></returns>
    public bool GetError()
    {
        return IsError;
    }
    private string errorInfo;
    /// <summary>
    /// 获取或设置错误信息
    /// </summary>
    public string ErrorInfo
    {
        get
        {
            return errorInfo;
        }
        set
        {
            if (!string.IsNullOrEmpty(errorInfo))
            {
                writeData.cmdId = (int)NetMessageDef.ResErrorInfo;
                IsError = true;
            }
            errorInfo = value;
        }
    }
    #endregion

    /// <summary>
    /// 子类实现Logic处理
    /// </summary>
    /// <returns></returns>
    public abstract bool TakeLogic();

    /// <summary>
    /// 处理结束执行
    /// </summary>
    public virtual void TakeLogicAffter(bool state)
    {
    }

    /// <summary>
    /// 执行Logic处理
    /// </summary>
    /// <returns></returns>
    public bool DoLogic()
    {
        bool result;
        try
        {
            result = TakeLogic();
            TakeLogicAffter(result);
        }
        catch (Exception ex)
        {
            return false;
        }
        return result;
    }


    #region 数据下发

    public void PushInfoId(int cmdId)
    {
        writeData.cmdId = cmdId;
    }
    public void PushIntoStack(byte[] bytes)
    {
        writeData.bytes = bytes;
    }

    public void Write()
    {
        if (GetError())
        {
            writeData.WriteError(ErrorInfo);
        }
        else
        {
            writeData.Write();
        }
    }

    #endregion
}
