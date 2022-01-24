﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Configuration;
namespace Pizza_Stonks.Models
{
   public class DB
    {
        readonly MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["project4"].ConnectionString);
        public List<Order> GetOrder()
        {
            List<Order> methodResultaat = new List<Order>();
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = "select * FROM order_pizza;";

                //sql.CommandText =
                //      @"
                //select* FROM order_pizza; 
                //      ";
                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Order Order = new Order()
                    {
                        Pizza = (ulong)reader["pizza_id"],
                       
                        Orders = (ulong)reader["order_id"]
                    };

                    methodResultaat.Add(Order);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return methodResultaat;
        }
    }
}
