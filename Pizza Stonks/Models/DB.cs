using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public List<OrderGegevens> GetOrderGegevens()
        {
            List<OrderGegevens> methodResultaat = new List<OrderGegevens>();
            try
            {
                //select p.name as 'pizzaname', o.name as 'customerName', op.order_id
                //    from order_pizza op 
                //    inner join pizza p on op.pizza_id = p.id
                //    inner JOIN `order` o on o.id = op.order_id
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"
                        SELECT o.id, o.name, s.name as 'statusname'
                        FROM `order` o
                        INNER JOIN states s ON s.id = o.status_id

                ;";

                MySqlDataReader reader = sql.ExecuteReader();
                
                while (reader.Read())
                {
                    OrderGegevens OrderGegevens = new OrderGegevens()
                    {
                        Id = (ulong)reader["id"],
                        Name = (string)reader["name"],
                        StatusName = (string)reader["statusname"],
                        //Name = (string)reader["name"],
                        //Email = (string)reader["emailadres"],
                        //Phone = (int)reader["phone"],
                        //Address = (string)reader["address"],
                        //Zipcode = (string)reader["zipcode"]
                    };
                    methodResultaat.Add(OrderGegevens);
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

        public List<Order_Pizza> GetpizzasByOrderId(ulong orderiD)
        {
            List<Order_Pizza> methodResultaat = new List<Order_Pizza>();
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"
                    SELECT orp.order_id, orp.qty, orp.size, p.name, p.price
                    FROM `order_pizza` orp
                    INNER JOIN pizza p ON p.id = orp.pizza_id
                    WHERE order_id = @orderiD  
                    ";
                sql.Parameters.AddWithValue("@orderiD", orderiD);


                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Order_Pizza Orders = new Order_Pizza()
                    {
                        Id_Order = (ulong)reader["order_id"],

                        Qty = (int)reader["qty"],

                        Size = (int)reader["size"],

                        Name_Pizza = (string)reader["name"],

                        Price__Pizza = (double)reader["price"],
                    };

                    methodResultaat.Add(Orders);
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

        public List<Ingredients> GetIngredientsInPizza(ulong pizza_id)
        {
            List<Ingredients> methodResultaat = new List<Ingredients>();
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"SELECT ingredients.name, ingredients.id, ingredients.price  FROM ingredient_pizza INNER JOIN ingredients ON ingredient_pizza.ingredient_id = ingredients.id WHERE ingredient_pizza.pizza_id = @pizza_id;";

                sql.Parameters.AddWithValue("@pizza_id", pizza_id);

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

        public bool AddIngr_Pizza(ulong idPizza, ulong idIngr)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO ingredient_pizza (pizza_id, ingredient_id) VALUES (@idpizza, @idIngr);";
                command.Parameters.AddWithValue("@idpizza", idPizza);
                command.Parameters.AddWithValue("@idIngr", idIngr);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }

            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return succes;
        }

        public bool Delete_Ingr_Pizza(ulong idIngr)
        {

            bool succes = false;
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM ingredient_pizza WHERE (pizza_id, ingredient_id) = (@idIngr);";
                //command.Parameters.AddWithValue("@idPizza", idPizza);
                command.Parameters.AddWithValue("@idIngr", idIngr);

                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }

            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return succes;
        }

        //public List<Ingredient_Pizza> GetAllIngrOnPizza(int id)
        //{
        //    List<Ingredient_Pizza> methodResultaat = new List<Ingredient_Pizza>();
        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand sql = conn.CreateCommand();
        //        // sql.CommandText = "select * FROM order_pizza;";
        //        sql.CommandText = @"SELECT order_pizzaz.*, vakantielanden.*
        //        FROM favouritelanden
        //        INNER JOIN vakantielanden ON favouritelanden.vakantielanden_idvakantielanden = ``.idvakantielanden
        //        WHERE favouritelanden.personeel_idpersoneel = @id ORDER BY vakantieland ASC";

        //        MySqlDataReader reader = sql.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Ingredient_Pizza Order = new Ingredient_Pizza()
        //            {
        //                Pizza_id = (ulong)reader["pizza_id"],

        //                Ingredient_id = (ulong)reader["ingredient_id"]
        //            };

        //            methodResultaat.Add(Order);
        //        }
        //        return methodResultaat;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Error.WriteLine(e.Message);

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }

}
