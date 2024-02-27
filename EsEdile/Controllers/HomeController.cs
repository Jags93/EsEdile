using EsEdile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsEdile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edile1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            List<Dipendenti> dipendente = new List<Dipendenti>();
            
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Dipendenti", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Dipendenti d = new Dipendenti();
                    d.IdDipendente = reader.GetInt32(0);
                    d.Nome = reader.GetString(1);
                    d.Cognome = reader.GetString(2);
                    d.Indirizzo = reader.GetString(3);
                    d.CF = reader.GetString(4);
                    d.Coniugato = reader.GetBoolean(5);
                    d.FigliACarico = reader.GetInt32(6);
                    d.Mansione = reader.GetString(7);
                    dipendente.Add(d);
                }
              
            }
            catch (SqlException e)
            {
                
               ViewBag.Message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return View(dipendente);
        }
        public ActionResult CreateDipendenti() { return View(); }
        [HttpPost]
        public ActionResult CreateDipendenti(Dipendenti dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edile1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CF, Coniugato, FigliACarico, Mansione) VALUES (@Nome, @Cognome, @Indirizzo, @CF, @Coniugato, @FigliACarico, @Mansione)", connection);
                command.Parameters.AddWithValue("@Nome", dipendente.Nome);
                command.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                command.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                command.Parameters.AddWithValue("@CF", dipendente.CF);
                command.Parameters.AddWithValue("@Coniugato", dipendente.Coniugato);
                command.Parameters.AddWithValue("@FigliACarico", dipendente.FigliACarico);
                command.Parameters.AddWithValue("@Mansione", dipendente.Mansione);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                ViewBag.Message = e.Message;
            }
            finally
            {
                connection.Close();
            }


            return RedirectToAction("Index");
        }

        
        
        public ActionResult DeleteDipendenti(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edile1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Dipendenti WHERE IdDipendente = @IdDipendente", connection);
                command.Parameters.AddWithValue("@IdDipendente", Id);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                ViewBag.Message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
       public ActionResult EditDipendenti(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edile1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            Dipendenti d = new Dipendenti();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Dipendenti WHERE IdDipendente = @IdDipendente", connection);
                command.Parameters.AddWithValue("@IdDipendente", Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    d.IdDipendente = reader.GetInt32(0);
                    d.Nome = reader.GetString(1);
                    d.Cognome = reader.GetString(2);
                    d.Indirizzo = reader.GetString(3);
                    d.CF = reader.GetString(4);
                    d.Coniugato = reader.GetBoolean(5);
                    d.FigliACarico = reader.GetInt32(6);
                    d.Mansione = reader.GetString(7);
                }
            }
            catch (SqlException e)
            {
                ViewBag.Message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(d);
        }

        [HttpPost]

        public ActionResult EditDipendenti(Dipendenti dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edile1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Dipendenti SET Nome = @Nome, Cognome = @Cognome, Indirizzo = @Indirizzo, CF = @CF, Coniugato = @Coniugato, FigliACarico = @FigliACarico, Mansione = @Mansione WHERE IdDipendente = @IdDipendente", connection);
                command.Parameters.AddWithValue("@IdDipendente", dipendente.IdDipendente);
                command.Parameters.AddWithValue("@Nome", dipendente.Nome);
                command.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                command.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                command.Parameters.AddWithValue("@CF", dipendente.CF);
                command.Parameters.AddWithValue("@Coniugato", dipendente.Coniugato);
                command.Parameters.AddWithValue("@FigliACarico", dipendente.FigliACarico);
                command.Parameters.AddWithValue("@Mansione", dipendente.Mansione);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                ViewBag.Message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Dipendenti()
        {
            ViewBag.Message = "Dipendenti";

            return View();
        }
    }
}