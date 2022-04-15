using DungeonsAndDragonsWeb.Models.Database;
using MySql.Data.MySqlClient;
using System;
using ProvesAI.Code.Utilities.Objects;

namespace DungeonsAndDragonsWeb.Models.Resources
{
    public static class DatabaseDelegator
    {
        static string connection;
        static DatabaseDelegator() { }
        public static bool HasRoute { get => !string.IsNullOrEmpty(connection); }

        public static void SetConnection(string conn) { connection = conn; }
        public static bool TryConnection()
        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                if (HasRoute)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT SYSDATE() FROM DUAL", conn);
                    return !(cmd.ExecuteScalar() is null);
                }
                else return false;
            }
            catch (Exception) { return false; }
            finally { conn.Close(); }
        }
        public static MySqlConnection GetConnection(bool opened = true)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connection);
                if (opened) conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                if (HasRoute) throw new DatabaseConnectionException("The connection is null or empty!", e);
                else throw new DatabaseConnectionException("Database connection failed!", e);
            }
        }

        public static int GetCharacterCount()
        {
            MySqlConnection conn = GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM character", conn);
                if (cmd.ExecuteScalar() is null) throw new DatabaseResultException("The query '" + cmd.CommandText + "' couldn't be executed!");
                else if (int.TryParse(cmd.ExecuteScalar().ToString(), out int count)) return count;
                else throw new DatabaseResultException("The result of '" + cmd.CommandText + "' couldn't be converted to int!");
            }
            finally { conn.Close(); }
        }
        public static int GetGameCount()
        {
            MySqlConnection conn = GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM game", conn);
                if (cmd.ExecuteScalar() is null) throw new DatabaseResultException("The query '" + cmd.CommandText + "' couldn't be executed!");
                else if (int.TryParse(cmd.ExecuteScalar().ToString(), out int count)) return count;
                else throw new DatabaseResultException("The result of '" + cmd.CommandText + "' couldn't be converted to int!");
            }
            finally { conn.Close(); }
        }
        public static int GetUniverseCount()
        {
            MySqlConnection conn = GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM universe", conn);
                if (cmd.ExecuteScalar() is null) throw new DatabaseResultException("The query '" + cmd.CommandText + "' couldn't be executed!");
                else if (int.TryParse(cmd.ExecuteScalar().ToString(), out int count)) return count;
                else throw new DatabaseResultException("The result of '" + cmd.CommandText + "' couldn't be converted to int!");
            }
            finally { conn.Close(); }
        }
        public static bool CheckPassword(string email, string password)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                string sql = "SELECT banned FROM user WHERE email = @email AND password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                return !(cmd.ExecuteScalar() is null) && !Convert.ToBoolean(cmd.ExecuteScalar());
            }
            finally { conn.Close(); }
        }
        public static bool CheckPassword(User u) => CheckPassword(u.Email, u.Password);

        public static bool SetSession(string email, string code)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                string sql = "INSERT INTO session(user_email,code) VALUES (@user_email, @code)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user_email", email);
                cmd.Parameters.AddWithValue("@code", code);
                return cmd.ExecuteNonQuery() == 1;
            }
            finally { conn.Close(); }
        }
        public static bool SetSession(User u, string code) => SetSession(u.Email, code);

        public static string GetSessionUser(string code)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                string sql = "SELECT user_email FROM session WHERE code = @code";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@code", code);
                if (cmd.ExecuteScalar() is null) throw new DatabaseResultException("Couldn't get the user from the session");
                else return (string)cmd.ExecuteScalar();
            }
            finally { conn.Close(); }
        }

        public static User GetUser(string username)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                Iterator i = new Iterator();
                User u = new User();
                string sql = "SELECT * FROM user WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", username);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        u.Email = dr.GetString(i.Iterate());
                    }
                }
                return u;
            }
            finally { conn.Close(); }
        }
    }
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException() { }
        public DatabaseConnectionException(string message) : base(message) { }
        public DatabaseConnectionException(string message, Exception inner) : base(message, inner) { }
    }
    public class DatabaseResultException : Exception
    {
        public DatabaseResultException() { }
        public DatabaseResultException(string message) : base(message) { }
        public DatabaseResultException(string message, Exception inner) : base(message, inner) { }
    }
    public class DatabaseParameterException : Exception
    {
        public DatabaseParameterException() { }
        public DatabaseParameterException(string message) : base(message) { }
        public DatabaseParameterException(string message, Exception inner) : base(message, inner) { }
    }
}
