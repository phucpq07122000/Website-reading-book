using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VuThao.Train.Common.Model;

namespace VuThao.Train.Project
{
    public partial class WebForm2 : System.Web.UI.Page,ICallbackEventHandler
    {
        string tempVar;

        public string GetCallbackResult()
        {
            return tempVar;
        }

        public void RaiseCallbackEvent(string eventArgument)
       {
            User user = JsonConvert.DeserializeObject<User>(eventArgument);
            List<User> profile = new bus().SelectUsetProfile(user);
            Object[] result = profile.Cast<object>().ToArray();
            tempVar = JsonConvert.SerializeObject(result); //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the Page's ClientScript and assign it to a ClientScriptManger
            ClientScriptManager cm = Page.ClientScript;

            //Generate the callback reference
            string cbReference = cm.GetCallbackEventReference(this, "arg", "HandleResult", "");

            //Build the callback script block
            string cbScript = "function CallServer(arg, context){" + cbReference + ";}";

            //Register the block
            cm.RegisterClientScriptBlock(this.GetType(), "CallServer", cbScript, true);
        }
    }
}
