using System;
using System.Data.SqlClient;

namespace kursDB1.Utils
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void EnsureDatabaseCreated()
        {
            string[] createTableCommands = {
                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='albums' AND xtype='U')
                CREATE TABLE albums (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255),
                    count_arts INT,
                    drop_day DATE);",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='artists' AND xtype='U')
                CREATE TABLE artists (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255),
                    count_arts INT);",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='arts' AND xtype='U')
                CREATE TABLE arts (
                    id INT IDENTITY PRIMARY KEY,
                    id_label INT FOREIGN KEY REFERENCES labels(id),
                    id_artist INT FOREIGN KEY REFERENCES artists(id),
                    id_album INT FOREIGN KEY REFERENCES albums(id),
                    id_studio INT FOREIGN KEY REFERENCES studios(id),
                    id_director INT FOREIGN KEY REFERENCES directors(id),
                    id_genre INT FOREIGN KEY REFERENCES genres(id),
                    duration INT,
                    mark_art INT);",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='directors' AND xtype='U')
                CREATE TABLE directors (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255));",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='genres' AND xtype='U')
                CREATE TABLE genres (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255));",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='labels' AND xtype='U')
                CREATE TABLE labels (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255),
                    count_arts INT,
                    b_date DATE);",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='marks' AND xtype='U')
                CREATE TABLE marks (
                    id INT IDENTITY PRIMARY KEY,
                    id_user INT FOREIGN KEY REFERENCES users(id),
                    id_art INT FOREIGN KEY REFERENCES arts(id),
                    mark INT);",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='roles' AND xtype='U')
                CREATE TABLE roles (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255));",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='studios' AND xtype='U')
                CREATE TABLE studios (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255),
                    count_arts INT,
                    b_day DATE);",

                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' AND xtype='U')
                CREATE TABLE users (
                    id INT IDENTITY PRIMARY KEY,
                    name NVARCHAR(255),
                    email NVARCHAR(255),
                    password NVARCHAR(255),
                    role_id INT FOREIGN KEY REFERENCES roles(id));"
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var sql in createTableCommands)
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
