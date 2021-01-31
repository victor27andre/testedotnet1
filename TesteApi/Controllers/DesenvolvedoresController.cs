﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using TesteApi.Models;

namespace TesteApi.Controllers
{
    public class DesenvolvedoresController : ApiController
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;

        string strSQL;

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");
                strSQL = "SELECT * FROM[TesteApiBd].[dbo].Desenvolvedores";
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strSQL, conexao);
                conexao.Open();
                da.Fill(ds);
                return Ok(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        public void Post(string nome)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");
                if (!string.IsNullOrEmpty(nome))
                {
                    strSQL = "INSERT INTO [dbo].[Desenvolvedores] ([Nome]) VALUES (@Nome);";
                    comando = new SqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@Nome", nome);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;

            }
        }

        public void DeleteId(string id)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");
                if (!string.IsNullOrEmpty(id))
                {

                    strSQL = "DELETE TesteApiBd.dbo.Desenvolvedores WHERE ID = @Id";

                    comando = new SqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@Id", id);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;

            }

        }
    }
}