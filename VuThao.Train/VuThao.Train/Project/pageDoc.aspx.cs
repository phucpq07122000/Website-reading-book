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
    public partial class pageDoc : System.Web.UI.Page,ICallbackEventHandler
    {
        string tempVar;

        public string GetCallbackResult()
        {
            return tempVar;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            int idbook = int.Parse(eventArgument);
            Book book = new bus().SelectbookById(idbook);
            //List<User> profile = new bus().SelectUsetProfile(eventArgument);
            //Object[] result = profile.Cast<object>().ToArray();
            tempVar = JsonConvert.SerializeObject(book); //ret
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