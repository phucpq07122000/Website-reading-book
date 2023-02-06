using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VuThao.Train
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            DataRow drInfo = null;
            var dtInfo = DocumentTypeGetCache();
            DataTable dtNow = dtInfo.Copy();
            var drSelect = dtNow.Select("ID = 1");
            if (drSelect.Length > 0)
                drInfo = drSelect[0];
            Button1.Text = drInfo["Title"] + string.Empty;
        }

        public DataTable DocumentTypeGetCache()
        {
            var dtData = new DataTable();
            try
            {
                if (HttpContext.Current.Cache["7"] != null)
                {
                    dtData = HttpContext.Current.Cache["7"] as DataTable;
                }
                else
                {
                    dtData = new DataTable();
                    dtData.Columns.Add("ID");
                    dtData.Columns.Add("Title");
                    DataRow dr = dtData.NewRow();
                    dr["ID"] = 1;
                    dr["Title"] = "abc";
                    dtData.Rows.Add(dr);
                    if (dtData != null && dtData.Rows.Count > 0)
                        HttpContext.Current.Cache.Add("7", dtData, null,
                            DateTime.Now.AddMinutes(1), TimeSpan.Zero, CacheItemPriority.Default, null);
                }
            }
            catch (Exception ex)
            {
                //CmmFunc.LogErr(ex, "Author: huynhpb - Method: DocumentCategoryGetCache - File: DBCache");
            }

            return dtData;
        }
    }
}