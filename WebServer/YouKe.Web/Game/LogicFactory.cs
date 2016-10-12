using System;
using System.Collections;
using System.Web;

/// <summary>
/// 游戏Logic处理工厂
/// </summary>
namespace YouKe.Web.Game
{
    public abstract class LogicFactory
    {
        private static Hashtable lookupType = new Hashtable();
        private static string LogicFormat = "YouKe.Web.Game.Logic.Logic{0}";

        public static BaseLogic Create(object actionType)
        {
            return Create((int)actionType);
        }

        public static BaseLogic Create(int actionId)
        {
            BaseLogic gameLogic = null;
            try
            {
                string name = string.Format(LogicFormat, actionId);
                var type = (Type)lookupType[name];
                lock (lookupType)
                {
                    if (type == null)
                    {
                        //HttpContext.Current.Response.Write("type == null" + name);
                        type = Type.GetType(name);
                        lookupType[name] = type;
                    }
                }
                if (type != null)
                {
                    gameLogic = Activator.CreateInstance(type) as BaseLogic;
                }
            }
            catch (Exception ex)
            {
                //Debug.LogError("GameAction create error:" + ex);
                //HttpContext.Current.Response.Write(ex);
            }
            return gameLogic;
        }
    }
}