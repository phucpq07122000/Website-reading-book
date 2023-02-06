using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VuThao.Train.Common.Model;

namespace VuThao.Train.Common.API
{
    public class ApiHandler : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable => true;

        // Tham số querystring truyền vào dữ liệu
        private static class PRA_KEYNAME
        {
            public static readonly string FUNC = "func"; // Function sẽ lấy dữ liệu
            public static readonly string POST_DATA = "data"; // postData
            public static readonly string TBL = "tbl"; // Table cua resource
            public static readonly string GET_RID = "rid"; // ResourceId
        }

        public void ProcessRequest(HttpContext context)
        {
            object retData = null;
            var resStatus = RESPONES_STATE.NONE;
            var errMess = default(KeyValuePair<string, string>);
            var retDate = DateTime.Now;
            int intLcid = PAR(context, "langid") == "1033" ? 1033 : 1066;
            var func = PAR(context, PRA_KEYNAME.FUNC);
            try
            {
                var strPostData = PAR(context, PRA_KEYNAME.POST_DATA);
                var tbl = PAR(context, PRA_KEYNAME.TBL);

                if (resStatus == RESPONES_STATE.NONE)
                {
                    resStatus = RESPONES_STATE.ERR;
                    var dbHandler = new DBHandler();

                    switch (tbl)
                    {

                        #region User

                        case "User":
                            {

                                switch (func)
                                {
                                    #region insert

                                    case "insert":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                                User user = JsonConvert.DeserializeObject<User>(strPostData);
                                                bool addUser = new bus().AddUserAcc(user);

                                                retData = addUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region SendMessage
                                    case "SendMes":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                                ThongBao mes = JsonConvert.DeserializeObject<ThongBao>(strPostData);
                                                bool send = new bus().sendMessage(mes);

                                                retData = send; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region readTeam

                                    case "ReadTeam":
                                        {
                                         
                                                //thực hiện lệnh sql ở đây
                                               
                                                List<TeamStanlate> Team = new bus().ReadTeam();
                                                retData = Team; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                           

                                            break;
                                        }

                                    #endregion

                                    #region readActor


                                    case "ReadActor":
                                        {

                                            //thực hiện lệnh sql ở đây

                                            List<Actor> actors = new bus().ReadActor();
                                            retData = actors; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                            resStatus = RESPONES_STATE.SUCCESS;


                                            break;
                                        }

                                    #endregion
                                    #region checkLogin

                                    case "check":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                                User user = JsonConvert.DeserializeObject<User>(strPostData);
                                                List<User> addUser = new bus().CheckUser(user);

                                                retData = addUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region delete

                                    case "delete":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                                JObject objData = JsonConvert.DeserializeObject<JObject>(strPostData);
                                                if (dbHandler.LikeDelete(objData) > 0)
                                                {
                                                    retData = ""; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                    resStatus = RESPONES_STATE.SUCCESS;
                                                }
                                                else
                                                {
                                                    errMess = new KeyValuePair<string, string>("200", "Lỗi");
                                                }
                                            }

                                            break;
                                        }

                                    #endregion

                                    #region Profile
                                        // note: case" profile " lỗi
                                    case "profile":
                                        {
                                            //if (!string.IsNullOrEmpty(strPostData))
                                            //{
                                                
                                            //    User user = JsonConvert.DeserializeObject<User>(strPostData);
                                               
                                            //    List<User> profileUser = new bus().SelectUsetProfile(user);
                                            //    retData = profileUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                            //    resStatus = RESPONES_STATE.SUCCESS;
                                            //}
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                                User user = JsonConvert.DeserializeObject<User>(strPostData);
                                                List<User> addUser = new bus().SelectUsetProfile(user);

                                                retData = addUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                    #endregion

                                    #region update

                                    case "Update":
                                        {
                                            
                                            
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                               
                                                User user = JsonConvert.DeserializeObject<User>(strPostData);
                                                bool updateUser = new bus().UpdateUserAcc(user);
                                                retData = updateUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region phantrangbook
                                    case "phantrangUser":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                PageSize page = JsonConvert.DeserializeObject<PageSize>(strPostData);

                                                //List<NV_Image> nhanvien = new bus().SelectPhanTrang(addPage);
                                                PhanTrang user = new bus().SelectPhanUser(page);
                                                retData = user;

                                                resStatus = RESPONES_STATE.SUCCESS;

                                            }

                                            break;
                                        }
                                        #endregion
                                }

                            }
                            break;
                        #endregion
                        #region Image

                        case "Image":
                            {

                                switch (func)
                                {
                                    #region insert

                                    case "upload":
                                        {
                                            if (HttpContext.Current.Request.Files.Count > 0)
                                            {
                                                var file = HttpContext.Current.Request.Files[0];
                                                System.IO.Stream fs = file.InputStream;
                                                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                                Image image = JsonConvert.DeserializeObject<Image>(strPostData);
                                                    
                                                dbHandler.LikeUpdate(file.FileName, bytes, image);
                                            }
                                            break;
                                        }

                                    #endregion

                                    #region delete

                                    case "delete":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                                JObject objData = JsonConvert.DeserializeObject<JObject>(strPostData);
                                                if (dbHandler.LikeDelete(objData) > 0)
                                                {
                                                    retData = ""; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                    resStatus = RESPONES_STATE.SUCCESS;
                                                }
                                                else
                                                {
                                                    errMess = new KeyValuePair<string, string>("200", "Lỗi");
                                                }
                                            }

                                            break;
                                        }

                                        #endregion
                                }

                            }
                            break;
                        #endregion

                        #region Book

                        case "Book":
                            {

                                switch (func)
                                {
                                    #region insert

                                    case "Create":
                                        {
                                            if (HttpContext.Current.Request.Files.Count > 0)
                                            {
                                                var file = HttpContext.Current.Request.Files[0];
                                                System.IO.Stream fs = file.InputStream;
                                                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                                Book book = JsonConvert.DeserializeObject<Book>(strPostData);

                                                dbHandler.LoadBook( bytes, book);
                                              
                                            }
                                            break;
                                        }

                                    #endregion

                                    #region Read

                                    case "Read":
                                        {
                                            List<Book> books = new bus().SelectAll();
                                            retData = books;
                                            resStatus = RESPONES_STATE.SUCCESS;
                                            break;
                                        
                                        }

                                    #endregion
                                    #region ReadAdmin

                                    case "Readadmin":
                                        {
                                            List<Book> books = new bus().SelectAllAdmin();
                                            retData = books;
                                            resStatus = RESPONES_STATE.SUCCESS;
                                            break;

                                        }

                                    #endregion
                                    #region BookBYTeam
                                    case "SeBookByTeam":
                                        {
                                           
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                int idbook = int.Parse(strPostData);
                                                List<Book> books = new bus().SelectbookByIdTeam(idbook);
                                                //List<User> profile = new bus().SelectUsetProfile(eventArgument);
                                                //Object[] result = profile.Cast<object>().ToArray();
                                                retData = books; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;

                                            }
                                            break;

                                        }

                                    #endregion

                                    #region vol
                                    case "AddVol":
                                        if (!string.IsNullOrEmpty(strPostData))
                                        {
                                            //thực hiện lệnh sql ở đây
                                            Vol_book vol = JsonConvert.DeserializeObject<Vol_book>(strPostData);
                                            bool addUser = new bus().AddVol(vol);

                                            retData = addUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                            resStatus = RESPONES_STATE.SUCCESS;
                                        }

                                        break;
                                    #endregion

                                    #region ReadVol

                                    case "ReadVol":
                                        if (!string.IsNullOrEmpty(strPostData))
                                        {
                                            int idbook = int.Parse(strPostData);
                                            List<Vol_book> books = new bus().ReadVol(idbook);
                                            //List<User> profile = new bus().SelectUsetProfile(eventArgument);
                                            //Object[] result = profile.Cast<object>().ToArray();
                                            retData = books; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                            resStatus = RESPONES_STATE.SUCCESS;

                                        }
                                        break;

                                    #endregion
                                    #region ReadVolAdmin

                                    case "ReadVolAdmin":
                                        if (!string.IsNullOrEmpty(strPostData))
                                        {
                                            int idbook = int.Parse(strPostData);
                                            List<Vol_book> books = new bus().ReadVolAdmin(idbook);
                                            //List<User> profile = new bus().SelectUsetProfile(eventArgument);
                                            //Object[] result = profile.Cast<object>().ToArray();
                                            retData = books; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                            resStatus = RESPONES_STATE.SUCCESS;

                                        }
                                        break;

                                    #endregion

                                    #region UpdateBook

                                    case "Update":
                                        {
                                            if (HttpContext.Current.Request.Files.Count > 0)
                                            {
                                                var file = HttpContext.Current.Request.Files[0];
                                                System.IO.Stream fs = file.InputStream;
                                                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                                Book book = JsonConvert.DeserializeObject<Book>(strPostData);

                                                dbHandler.UpdateBook(bytes, book);

                                            }else if(!string.IsNullOrEmpty(strPostData))
                                            {
                                             
                                                    Book update = JsonConvert.DeserializeObject<Book>(strPostData);
                                                dbHandler.UpdateBook(null, update);
                                               
                                               
                                            };
                                            break;
                                        }

                                    #endregion
                                    #region UpdateVol
                                    case "UpdateVol":
                                        {
                                             if (!string.IsNullOrEmpty(strPostData))
                                            {

                                                Vol_book update = JsonConvert.DeserializeObject<Vol_book>(strPostData);
                                                bool updateUser = new bus().UpdateVol(update);
                                                retData = updateUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;


                                            };
                                            break;
                                        }

                                    #endregion

                                    #region deletevol

                                    case "deleteVol":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {

                                               string i = JsonConvert.DeserializeObject<string>(strPostData);

                                                bool del = new bus().delVol(i);
                                   
                                                retData = del; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                                break;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region deletebook

                                    case "deletebook":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {

                                                string i = JsonConvert.DeserializeObject<string>(strPostData);
                                                int a = int.Parse(i);
                                                bool del = new bus().delBook(a);

                                                retData = del; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                                break;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region restorebook

                                    case "restorebook":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {

                                                string i = JsonConvert.DeserializeObject<string>(strPostData);
                                                int a = int.Parse(i);
                                                bool del = new bus().RestoreBook(a);

                                                retData = del; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                                break;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region Cleanbook

                                    case "Cleanbook":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {

                                                string i = JsonConvert.DeserializeObject<string>(strPostData);
                                                int a = int.Parse(i);
                                                bool del = new bus().CleanBook(a);

                                                retData = del; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                                break;
                                            }

                                            break;
                                        }

                                    #endregion
                                    #region phantrangbook
                                    case "phantrangbook":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                PageSize page = JsonConvert.DeserializeObject<PageSize>(strPostData);
                                                
                                                //List<NV_Image> nhanvien = new bus().SelectPhanTrang(addPage);
                                                PhanTrang nhanvien = new bus().SelectPhanTrang(page);
                                                retData = nhanvien;

                                                resStatus = RESPONES_STATE.SUCCESS;

                                            }

                                            break;
                                        }
                                    #endregion

                                    #region LoadFollow

                                    case "follow":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                Follow follow = JsonConvert.DeserializeObject<Follow>(strPostData);
                                                int have = new bus().LoadFollow(follow);
                                                //List<User> profile = new bus().SelectUsetProfile(eventArgument);
                                                //Object[] result = profile.Cast<object>().ToArray();
                                                retData = have; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;

                                            }
                                            break;
                                        }

                                    #endregion

                                    #region clickFollow

                                    case "clickfollow":
                                        {
                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                Follow follow = JsonConvert.DeserializeObject<Follow>(strPostData);
                                                int have = new bus().clickFollow(follow);
                                                //List<User> profile = new bus().SelectUsetProfile(eventArgument);
                                                //Object[] result = profile.Cast<object>().ToArray();
                                                retData = have; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;

                                            }
                                            break;
                                        }

                                    #endregion

                                    #region ReadFollow
                                    case "Follow":
                                        {

                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                int IdUser = int.Parse(strPostData);
                                                List<Book> books = new bus().ReadFollow(IdUser);
                                                //List<User> profile = new bus().SelectUsetProfile(eventArgument);
                                                //Object[] result = profile.Cast<object>().ToArray();
                                                retData = books; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;

                                            }
                                            break;

                                        }

                                        #endregion

                                }

                            }
                            break;
                        #endregion

                        #region admin

                        case "Admin":
                            {

                                switch (func)
                                {
                                   
                                    case "ReadAlbert":
                                        {

                                            //thực hiện lệnh sql ở đây

                                            int count = new bus().ReadThongBao();
                                            retData = count; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                            resStatus = RESPONES_STATE.SUCCESS;


                                            break;
                                        }
                                    #region updatea

                                    case "Update":
                                        {


                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây

                                                User user = JsonConvert.DeserializeObject<User>(strPostData);
                                                bool updateUser = new bus().UpdateUserAccAdmin(user);
                                                retData = updateUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                    #endregion

                                    #region ban_reban

                                    case "Ban_Re":
                                        {


                                            if (!string.IsNullOrEmpty(strPostData))
                                            {
                                                //thực hiện lệnh sql ở đây
                                               
                                                chose ban_ReBan = JsonConvert.DeserializeObject<chose>(strPostData);
                                                bool updateUser = new bus().Ban_ReBanUser(ban_ReBan);
                                                retData = updateUser; //return thông tin cần thiết về client, có thể return bất kì dữ liệu gì
                                                resStatus = RESPONES_STATE.SUCCESS;
                                            }

                                            break;
                                        }

                                        #endregion

                                }

                            }
                            break;
                            #endregion
                    }
                }
            }                                                
            catch (Exception ex)
            {
                resStatus = RESPONES_STATE.ERR;
                errMess = new KeyValuePair<string, string>("199", ex.Message);
            }

            ReponseData(context, retData, resStatus, errMess, retDate);
        }

        /// <summary>
        /// Trả về kết quả cho Client
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data">Kết quả dữ liệu</param>
        /// <param name="status">Trạng thái kết quả lấy dữ liệu</param>
        /// <param name="mess">Nội dung báo lỗi khi status là ERR</param>
        /// <param name="dateNow"></param>
        /// <param name="moreData"></param>
        public virtual void ReponseData(HttpContext context, object data, 
            RESPONES_STATE status = RESPONES_STATE.SUCCESS, KeyValuePair<string, 
                string> mess = default(KeyValuePair<string, string>), DateTime dateNow = default(DateTime), 
            object moreData = null)
        {
            if (dateNow == default(DateTime))
            {
                dateNow = DateTime.Now;
            }

            RES_DATA retData = new RES_DATA();
            retData.status = status.ToString();
            retData.mess = mess;
            retData.data = data;
            retData.dateNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write(JsonConvert.SerializeObject(retData));
            context.Response.Flush();
            context.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// Class Format dữ liệu trả về
        /// </summary>
        public class RES_DATA
        {
            public string status { get; set; }
            public KeyValuePair<string, string> mess { get; set; }
            public object data { get; set; }
            public string dateNow { get; set; }
        }

        /// <summary>
        /// Trạng thái kết quả trả về
        /// </summary>
        public enum RESPONES_STATE
        {
            SUCCESS = 1,
            MESSAGE = 0,
            ERR = -1,
            NONE = 2
        }

        public string PAR(HttpContext context, string keyName, string Decode = "")
        {
            string retValue = "";

            if (context.Request.Params[keyName] != null)
            {
                retValue = context.Request.Params[keyName].ToString();
            }
            return retValue;
        }

      
    }
    #endregion
    public class chose
    {
        public string code { get; set; }
        public bool chosse { get; set; }
    }
}