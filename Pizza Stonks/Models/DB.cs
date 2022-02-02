using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Controls;
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

        public bool Insertingredient(string name, string price)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO `ingredients`(`id`, `name`, `price`) VALUES (null, @name, @price); ";

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception e)
            {
                //Problem with the database
            }
            finally
            {
                conn.Close();
            }
            return succes;
        }

        public List<OrderGegevens> GetOrderGegevens()
        {
            List<Order> methodResultaatOrder = new List<Order>();

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
                    Order Order = new Order()
                    {  
                        
                        Orders = (ulong)reader["order_id"]
                     
                    };
                    OrderGegevens OrderGegevens = new OrderGegevens()
                    {
                        //Id = (int)reader["id"],
                        Name = (string)reader["customerName"],
                        //Email = (string)reader["emailadres"],
                        //Phone = (int)reader["phone"],
                        //Address = (string)reader["address"],
                        //Zipcode = (string)reader["zipcode"]
                    };
                    PizzaGegevens pizzaGegevens = new PizzaGegevens()
                    {
                        //Id = (int)reader["id"],
                        PizzaName = (string)reader["pizzaname"],
                        //Price = (double)reader["price"]

                    };
                    methodResultaat.Add(OrderGegevens);
                    methodResultaatOrder.Add(Order);
                    methodResultaatPizza.Add(pizzaGegevens);
                  //  var bestelling = methodResultaat , methodResultaatOrder , methodResultaatPizza;
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
                        Id = (ulong)reader["id"],

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

        public List<Ingredients> GetIngredients()
        {
            List<Ingredients> methodResultaat = new List<Ingredients>();
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"SELECT * FROM ingredients;";


                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Ingredients Ingredients = new Ingredients()
                    {
                        Id = (ulong)reader["id"],

                        Name = (string)reader["name"],

                        Price = (int)reader["price"]
                    };

                    methodResultaat.Add(Ingredients);
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

        internal bool GetMenuById(string menuId)
        {
            bool succes = false;

            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "select * FROM pizza where id = @id;";
                command.Parameters.AddWithValue("@id", menuId);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }

            catch (Exception e)
            {
                //Problem with the database
                Console.Error.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return succes;

        }

        public bool DeleteIngredient(string id)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM ingredients WHERE id = @id;";
                //DELETE FROM `personeel` WHERE `idpersoneel` = 5
                command.Parameters.AddWithValue("@id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }

            catch (Exception e)
            {
                //Problem with the database
                Console.Error.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return succes;

        }


        public bool UpdateIngredients(string tbID, string name, string price)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE `ingredients` SET `id`= @id,`name`=@name,`price`=@price WHERE `ingredients`. `id` =@id; ";
                command.Parameters.AddWithValue("@id", tbID);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception e)
            {
                //Problem with the database
            }
            finally
            {
                conn.Close();
            }
            return succes;
        }


        public bool DeletePizza(string id)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM pizza WHERE id = @id;";
                //DELETE FROM `personeel` WHERE `idpersoneel` = 5
                command.Parameters.AddWithValue("@id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }

            catch (Exception e)
            {
                //Problem with the database
                Console.Error.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return succes;

        }

        public bool InsertPizza(string name, string price)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO `pizza`(`id`, `name`, `price`) VALUES (null, @name, @price); ";

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception e)
            {
                //Problem with the database
            }
            finally
            {
                conn.Close();
            }
            return succes;
        }


        public bool UpdatePizza(string tbID, string name, string price)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE `pizza` SET `id`= @id,`name`=@name,`price`=@price WHERE `pizza`. `id` =@id; ";
                command.Parameters.AddWithValue("@id", tbID);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception e)
            {
                //Problem with the database
            }
            finally
            {
                conn.Close();
            }
            return succes;
        }





        //  return succes.Rows[0].ItemArray[1].ToString();
    }

    //public bool UpdateIngredients((ulong Id, string Name, int Price) p)
    //{
    //    throw new NotImplementedException();
    //}
}
