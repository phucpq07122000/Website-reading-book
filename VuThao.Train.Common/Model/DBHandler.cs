using System;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace VuThao.Train.Common.Model
{
    public class DBHandler
    {
        String strCon = ConfigurationManager.ConnectionStrings["contr"].ConnectionString;

        #region Like

        /// <summary>
        /// thực hiện lệnh insert like
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        public int LikeUpdate(string FileName, byte[] content, Image image)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            var countLike = 0;
          
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Upload", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", image.IdUser);
                cmd.Parameters.AddWithValue("@image", content);
                cmd.Parameters.AddWithValue("@modifyUser", image.LoginName);
                cmd.Parameters.AddWithValue("@modifyDate", DateTime.Now);

     
                cmd.ExecuteNonQuery();
                con.Close();
                countLike = 1;
            }
            catch (Exception ex)
            {
                countLike = 0;
            }

            return countLike;
        }

        public int LoadBook(byte[] content, Book book)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            var countLike = 0;

            try
            {
                string listvalue = string.Join(", ", JArray.Parse(book.Categories));
                SqlCommand cmd = new SqlCommand("SP_AddBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", book.Name);
                cmd.Parameters.AddWithValue("@idActor", book.IdActor);
                cmd.Parameters.AddWithValue("@idTeam", book.IdTeam);
                cmd.Parameters.AddWithValue("@descripton", book.Description);
                cmd.Parameters.AddWithValue("@categories", listvalue);
                cmd.Parameters.AddWithValue("@image", content);
                cmd.Parameters.AddWithValue("@creUser","admin");
                cmd.Parameters.AddWithValue("@creDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                con.Close();
                countLike = 1;
            }
            catch (Exception ex)
            {
                countLike = 0;
            }

            return countLike;
        }


        public int UpdateBook(byte[] content, Book book)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            var countLike = 0;

            try
            {
                string listvalue = string.Join(", ", JArray.Parse(book.Categories));
                SqlCommand cmd = new SqlCommand("SP_UpdateBook", con);

                cmd.CommandType = CommandType.StoredProcedure;
                if (content != null) { 
                cmd.Parameters.AddWithValue("@idBook",book.IdBook);
                cmd.Parameters.AddWithValue("@name", book.Name);
                cmd.Parameters.AddWithValue("@idActor", book.IdActor);

                cmd.Parameters.AddWithValue("@descripton", book.Description);
                cmd.Parameters.AddWithValue("@categories", listvalue);
                cmd.Parameters.AddWithValue("@image", content);
                cmd.Parameters.AddWithValue("@ModUser",book.ModifyUser);
                cmd.Parameters.AddWithValue("@ModDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    countLike = 1;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@image", 0);
                    cmd.Parameters.AddWithValue("@idBook", book.IdBook);
                    cmd.Parameters.AddWithValue("@name", book.Name);
                    cmd.Parameters.AddWithValue("@idActor", book.IdActor);
                  
                    cmd.Parameters.AddWithValue("@descripton", book.Description);
                    cmd.Parameters.AddWithValue("@categories", listvalue);
                    cmd.Parameters.AddWithValue("@ModUser", book.ModifyUser);
                    cmd.Parameters.AddWithValue("@ModDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    countLike = 1;
                }
               
            }
            catch (Exception ex)
            {
                countLike = 0;
            }

            return countLike;
        }
        /// <summary>
        /// thực hiện lệnh delete like
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        public int LikeDelete(JObject objData)
        {
            var countLike = 0;
            try
            {

            }
            catch (Exception ex)
            {
                countLike = 0;
            }
            return countLike;
        }

        #endregion
    }
}