using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using VuThao.Train.Common.API;
using VuThao.Train.Common.Model;

namespace VuThao.Train
{
    public class bus
    {
        String strCon = ConfigurationManager.ConnectionStrings["contr"].ConnectionString;

        public bool AddUserAcc(User user)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AddUserAcc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.PassWord);
                cmd.Parameters.AddWithValue("@sex", user.Sex);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@role", false);
                cmd.Parameters.AddWithValue("@CreDate", DateTime.Now);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        public bool UpdateUserAcc(User user)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateUserAcc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", user.IdUser);
                cmd.Parameters.AddWithValue("@userName", user.UserName);

                cmd.Parameters.AddWithValue("@password", user.PassWord);
                cmd.Parameters.AddWithValue("@sex", user.Sex);
                cmd.Parameters.AddWithValue("@email", user.Email);

                cmd.Parameters.AddWithValue("@CreDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifyUser", user.UserName);
                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        public bool UpdateUserAccAdmin(User user)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateUserAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", user.IdUser);        
                cmd.Parameters.AddWithValue("@idTeam", user.IdTeam);       
                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
        public List<User> CheckUser(User user)
        {
            SqlConnection con = new SqlConnection(strCon);
            List<User> users = new List<User>();
            con.Open();
            try
            {


                SqlCommand cmd = new SqlCommand("CheckUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.PassWord);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    User checkUser = new User()
                    {
                        IdUser = (int)dr["IdUser"],
                        IdTeam = (int)dr["IdTeam"],
                        PassWord = (string)dr["PassWord"],
                        UserName = (string)dr["UserName"],
                        Email = (string)dr["Email"],
                        Sex = (string)dr["Sex"],
                        Role = (bool)dr["Role"],
                        //Image = (byte[])dr["Image"],
                        //NameTeam = (string)dr["NameTeam"],
                    };
                    users.Add(checkUser);
                }
                con.Close();
                return users;
            }
            catch
            {
                return null;
            }
        }
        public List<User> SelectUsetProfile(User user)
        {
            SqlConnection con = new SqlConnection(strCon);
            List<User> users = new List<User>();

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("SP_UserProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUser", user.IdUser);

                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //byte[] Attachment = (byte[])dr["Image"];
                    if ((byte[])dr["Image"] != null)
                    {
                        User checkUser = new User()
                        {
                            IdUser = (int)dr["IdUser"],
                            PassWord = (string)dr["PassWord"],
                            UserName = (string)dr["UserName"],
                            Email = (string)dr["Email"],
                            Sex = (string)dr["Sex"],
                            Image = (byte[])dr["Image"],

                            NameTeam = (string)dr["NameTeam"],

                        };
                        users.Add(checkUser);
                    }
                    else
                    {
                        User checkUser = new User()
                        {
                            IdUser = (int)dr["IdUser"],
                            PassWord = (string)dr["PassWord"],
                            UserName = (string)dr["UserName"],
                            Email = (string)dr["Email"],
                            Sex = (string)dr["Sex"],


                            NameTeam = (string)dr["NameTeam"],

                        };
                        users.Add(checkUser);
                    }


                }
                con.Close();
                return users;
            }
            catch
            {
                return null;
            }
        }
        public List<Book> SelectAll()
        {
            List<Book> books = new List<Book>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Event", "Select");
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Book book = new Book()
                    {
                        IdBook = (int)dr["IDBook"],
                        Name = (string)dr["Name"].ToString(),
                        Categories = (string)dr["Categories"].ToString(),
                        Description = (string)dr["Description"].ToString(),
                        Image = (byte[])dr["Image"],



                    };
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
               
            }
            con.Close();
            return books;
        }
        public List<Book> SelectAllAdmin()
        {
            List<Book> books = new List<Book>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadBookAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Event", "Select");
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Book book = new Book()
                    {
                        IdBook = (int)dr["IDBook"],
                        Name = (string)dr["Name"].ToString(),
                        Categories = (string)dr["Categories"].ToString(),
                        Description = (string)dr["Description"].ToString(),
                        Image = (byte[])dr["Image"],
                        IsActivity = (bool)dr["IsActive"],

                    };
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return books;
        }
        public Book SelectbookById(int id)
        {
          
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SelectBookByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBook", id);
            SqlDataReader dr = cmd.ExecuteReader();
            Book book = new Book();
            dr.Read();
            book.IdBook = id;
            book.Name = (string)dr["Name"];
            book.NameTeam= (string)dr["NameTeam"].ToString();
            book.IdActor = (int)dr["IdActor"];
            book.NameActor= (string)dr["NameActor"].ToString();
            book.Categories = (string)dr["Categories"].ToString();
            book.Description = (string)dr["Description"].ToString();
            book.Image = (byte[])dr["Image"];
            con.Close();
            return book;

            //while (dr.Read())
            //{
            //    Book book = new Book()
            //    {
            //        IdBook = (int)dr["IDBook"],
            //        Name = (string)dr["Name"].ToString(),
            //        Categories = (string)dr["Categories"].ToString(),
            //        Description = (string)dr["Description"].ToString(),
            //        Image = (byte[])dr["Image"],


            //    };
            //    books.Add(book);
            //}

        }

        public List<Book> SelectbookByIdTeam(int id)
        {
            List<Book> books = new List<Book>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SelectBookByTeam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTeam", id);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Book book = new Book()
                    {

                        IdBook = (int)dr["IdBook"],
       
                        Name = (string)dr["Name"],
                        NameTeam = (string)dr["NameTeam"].ToString(),
                        NameActor = (string)dr["NameActor"].ToString(),
                        Categories = (string)dr["Categories"].ToString(),
                        Description = (string)dr["Description"].ToString(),
                        Image = (byte[])dr["Image"],
                        CreatedUser = (string)dr["CreatedUser"],
                        
                      };
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return books;


        }
        public List<TeamStanlate> ReadTeam()
        {
            List<TeamStanlate> Teams = new List<TeamStanlate>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadTeam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TeamStanlate Team = new TeamStanlate()
                {
                    IdTeam = (int)dr["IdTeam"],
                    NameTeam = (string)dr["NameTeam"],
                    //Created = (string)dr["Created"].ToString(),
                };
                Teams.Add(Team);
            }
            con.Close();
            return Teams;
        }
        public List<Actor> ReadActor()
        {
            List<Actor> actors = new List<Actor>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadActor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Actor actor = new Actor()
                {
                    IdActor = (int)dr["IdActor"],
                    NameActor = (string)dr["NameActor"],
                    //Created = (string)dr["Created"].ToString(),
                };
                actors.Add(actor);
            }
            con.Close();
            return actors;
        }

        public bool AddVol(Vol_book vol)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AddVol", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idBook", vol.IdBook);
                cmd.Parameters.AddWithValue("@idVol", vol.IdVol);
                cmd.Parameters.AddWithValue("@nameVol", vol.NameVol);
                cmd.Parameters.AddWithValue("@part", vol.Part);
                cmd.Parameters.AddWithValue("@vol", vol.Vol);
                cmd.Parameters.AddWithValue("@CreDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@CreUser", vol.CreUser);
             
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        public bool UpdateVol(Vol_book vol)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateVol", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVol", vol.IdVol);
                cmd.Parameters.AddWithValue("@nameVol", vol.NameVol);
                cmd.Parameters.AddWithValue("@part", vol.Part);
                cmd.Parameters.AddWithValue("@vol", vol.Vol);
                cmd.Parameters.AddWithValue("@modify", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModiUser", vol.CreUser);

                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
        public bool delVol(string idVol)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DelVol", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVol", idVol);
                //cmd.Parameters.AddWithValue("@idVol", idVol);
                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
        public bool delBook(int idbook)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DelBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBook", idbook);
                //cmd.Parameters.AddWithValue("@idVol", idVol);
                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
        public bool RestoreBook(int idbook)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("RestoreBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBook", idbook);
                //cmd.Parameters.AddWithValue("@idVol", idVol);
                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
        public bool CleanBook(int idbook)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBook", idbook);
                //cmd.Parameters.AddWithValue("@idVol", idVol);
                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        public int ReadThongBao()
        {
            int count = 0;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //SqlCommand com = new SqlCommand("sp_VuThao_User_Select", con);
            SqlCommand com = new SqlCommand("ReadThongBao", con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            SqlDataReader dr = com.ExecuteReader();


         
            foreach (DataRow row in ds.Tables[0].Rows)
            {
               count = (int)row["TOTAL"];

            }
            con.Close();
            return count;
        }
        public List<Vol_book> ReadVol(int idbook)
        {
            List<Vol_book> vols = new List<Vol_book>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadVol", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBook", idbook);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Vol_book vol = new Vol_book()
                {
                    IdVol = (string)dr["IdVol"],
                    IdBook = (int)dr["IdBook"],
                    NameVol = (string)dr["NameVol"].ToString(),
                    IsActivity = (bool)dr["IsActivity"],
                    Vol = (string)dr["Vol"].ToString(),
                    Part = (string)dr["Part"].ToString(),
                    CreDate = (DateTime)dr["Created"],
                    CreUser = (string)dr["CreateUser"],
                    
                };
                vols.Add(vol);
            }
            con.Close();
            return vols;
        }
        public List<Vol_book> ReadVolAdmin(int idbook)
        {
            List<Vol_book> vols = new List<Vol_book>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadVolAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBook", idbook);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Vol_book vol = new Vol_book()
                {
                    IdVol = (string)dr["IdVol"],
                    IdBook = (int)dr["IdBook"],
                    NameVol = (string)dr["NameVol"].ToString(),
                    IsActivity = (bool)dr["IsActivity"],
                    Vol = (string)dr["Vol"].ToString(),
                    Part = (string)dr["Part"].ToString(),
                    CreDate = (DateTime)dr["Created"],
                    CreUser = (string)dr["CreateUser"],

                };
                vols.Add(vol);
            }
            con.Close();
            return vols;
        }
        public PhanTrang SelectPhanTrang(PageSize page)
        {
            //List<NV_Image> NhanViens = new List<NV_Image>();
            //TwoTable tw = new TwoTable();

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //SqlCommand com = new SqlCommand("sp_VuThao_User_Select", con);
            SqlCommand com = new SqlCommand("sp_phantrangbook", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PageNumber", page.page);
            com.Parameters.AddWithValue("@PageSize", page.pageSize);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            SqlDataReader dr = com.ExecuteReader();


            PhanTrang T = new PhanTrang();
            T.listBook = new List<Book>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                //string a2 = (string)row["Sex"];
                //string a3 = (string)row["Unit"];
                Book book = new Book()
                {
                    Row = (int)row["Row"],
                    IdBook = (int)row["IDBook"],
                    Name = (string)row["Name"].ToString(),
                    Categories = (string)row["Categories"].ToString(),
                    Description = (string)row["Description"].ToString(),
                    Image = (byte[])row["Image"],
                    IsActivity = (bool)row["IsActive"],
                    NameActor = (string)row["NameActor"],
                    NameTeam = (string)row["NameTeam"],
                    Created = (DateTime)row["Created"],
                    CreatedUser = (string)row["CreatedUser"],
                    //Modify = (DateTime)row["Modify"],
                    //ModifyUser = (string)row["ModifyUser"],
                };
                T.listBook.Add(book);
            }
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                T.total = (int)row["TOTAL"];

            }
            con.Close();
            return T;
        }
        public PhanTrang SelectPhanUser(PageSize page)
        {
            //List<NV_Image> NhanViens = new List<NV_Image>();
            //TwoTable tw = new TwoTable();

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //SqlCommand com = new SqlCommand("sp_VuThao_User_Select", con);
            SqlCommand com = new SqlCommand("sp_phantrangUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PageNumber", page.page);
            com.Parameters.AddWithValue("@PageSize", page.pageSize);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            SqlDataReader dr = com.ExecuteReader();


            PhanTrang T = new PhanTrang();
            T.listUser = new List<User>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                //string a2 = (string)row["Sex"];
                //string a3 = (string)row["Unit"];
                User user = new User()
                {
                    Row = (int)row["Row"],
                    IdUser = (int)row["IDUser"],
                    UserName = (string)row["UserName"].ToString(),
                    PassWord = (string)row["Password"].ToString(),
                    Email = (string)row["Email"].ToString(),
                    Sex= (string)row["Sex"].ToString(),
                    Image = (byte[])row["Image"],
                    Role = (bool)row["Role"],
                    IsActivity = (bool)row["IsActivity"],
                    NameTeam = (string)row["NameTeam"],
                    Created = (DateTime)row["CreDate"],
                    
                    //Modify = (DateTime)row["ModifyDate"],
                    //ModifyUser = (string)row["ModifyUser"],
                };
                T.listUser.Add(user);
            }
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                T.total = (int)row["TOTAL"];

            }
            con.Close();
            return T;
        }
        public bool sendMessage(ThongBao mes)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ThongBao", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUser", mes.IdUser);
                cmd.Parameters.AddWithValue("@content_A", mes.content);
               
                cmd.Parameters.AddWithValue("@createdUser",mes.creUser);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }


        public bool Ban_ReBanUser(chose chosse)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Ban_ReBanUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", chosse.code);
                cmd.Parameters.AddWithValue("@chose", chosse.chosse);
                

                result = cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        public int LoadFollow(Follow follow)
        {

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Follow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBook", follow.IdBook);
            cmd.Parameters.AddWithValue("@idUser", follow.IdUser);
            SqlDataReader dr = cmd.ExecuteReader();
            Follow have = new Follow();
            dr.Read();
            have.have = (int)dr["Have"];
           
            con.Close();
            return have.have;

            

        }
        public int clickFollow(Follow follow)
        {

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ClickFollow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBook", follow.IdBook);
            cmd.Parameters.AddWithValue("@idUser", follow.IdUser);
            SqlDataReader dr = cmd.ExecuteReader();
            Follow have = new Follow();
            dr.Read();
            have.have = (int)dr["Have"];

            con.Close();
            return have.have;



        }
        public List<Book> ReadFollow(int iduser)
        {
            List<Book> books = new List<Book>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ReadFollow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUser", iduser);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Book book = new Book()
                    {
                        IdBook = (int)dr["IDBook"],
                        Name = (string)dr["Name"].ToString(),
                       
                        Image = (byte[])dr["Image"],
                     

                    };
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return books;
        }
    }
}

