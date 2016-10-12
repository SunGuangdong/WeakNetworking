using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouKe.Common;
using YouKe.Web.Logic;
using YouKe.Web.Game;

namespace YouKe.Web
{
    public partial class Server : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Net.Instance.Receive();
        }
    }
}