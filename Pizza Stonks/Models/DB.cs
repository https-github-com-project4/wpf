using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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


        public List<OrderGegevens> GetOrderGegevens()
        {
            List<OrderGegevens> methodResultaat = new List<OrderGegevens>();
            List<PizzaGegevens> methodResultaatPizza = new List<PizzaGegevens>();
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"
select p.name as 'pizzaname', o.name as 'customerName', op.order_id
from order_pizza op
inner join pizza p on op.pizza_id = p.id
inner JOIN `order` o on o.id = op.order_id
;";

                //sql.CommandText =
                //      @"
                //select* FROM order_pizza; 
                //      ";
                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    //Order Order = new Order()
                    //{
                    //    Pizza = (ulong)reader["pizza_id"],

                    //    Orders = (ulong)reader["order_id"]
                    //};
                    OrderGegevens OrderGegevens = new OrderGegevens()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["customerName"],
                        Email = (string)reader["emailadres"],
                        Phone = (int)reader["phone"],
                        Address = (string)reader["address"],
                        Zipcode = (string)reader["zipcode"]
                    };
                    PizzaGegevens pizzaGegevens = new PizzaGegevens()
                    {
                        Id = (int)reader["id"],
                        PizzaName = (string)reader["name"],
                        Price = (double)reader["price"]
                  
                    };
                    methodResultaat.Add(OrderGegevens);
                    methodResultaatPizza.Add(pizzaGegevens);
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






        public List<Pizzas> Getpizzas()
        {
            List<Pizzas> methodResultaat = new List<Pizzas>();
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"select * FROM pizza;";

               
                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Pizzas Pizzas = new Pizzas()
                    {
                        Id = (int)reader["id"],

                        Name = (string)reader["name"],

                        Price = (double)reader["price"]
                    };

                    methodResultaat.Add(Pizzas);
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
