using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDragonsWeb.Models.Resources
{
    public static class DatabaseDelegator
    {
        static string connection;
        static DatabaseDelegator() { }
        public static bool HasConnection { get => !string.IsNullOrEmpty(connection); }

        public static void SetConnection(string conn) { connection = conn; }
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
                if (HasConnection) throw new DatabaseConnectionException("The connection is null or empty!", e);
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
