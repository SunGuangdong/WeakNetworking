using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouKe.Web.Game
{
    public class NetWrite
    {
        public int cmdId;
        public int user_id = 1;
        public byte[] bytes;

        public void Write()
        {
            Net.Instance.Response.AddHeader("cmdId", cmdId.ToString());
            Net.Instance.Response.AddHeader("userId", user_id.ToString());
            Net.Instance.Response.BinaryWrite(bytes);
        }

        public void WriteError(string errorInfo)
        {
            Net.Instance.Response.Write(errorInfo);
        }
    }
}