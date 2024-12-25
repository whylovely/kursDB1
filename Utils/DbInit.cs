using Npgsql;

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
                @"CREATE TABLE albums (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL,
                    drop_day DATE,
                    id_arttist INTEGER NOT NULL );
                CREATE TABLE artists (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL );
                CREATE TABLE arts (
                    id SERIAL PRIMARY KEY NOT NULL,
                    id_label INTEGER REFERENCES labels(id) NOT NULL,
                    id_artist INTEGER REFERENCES artists(id) NOT NULL,
                    id_album INTEGER REFERENCES albums(id) NOT NULL,
                    id_studio INTEGER REFERENCES studios(id) NOT NULL,
                    id_director INTEGER REFERENCES directors(id) NOT NULL,
                    id_genre INTEGER REFERENCES genres(id) NOT NULL,
                    duration INTEGER NOT NULL,
                    mark_art INTEGER NOT NULL,
                    name VARCHAR(100));
                CREATE TABLE directors (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL );
                CREATE TABLE genres (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) );
                CREATE TABLE labels (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL,
                    b_date DATE );
                CREATE TABLE marks (
                    id SERIAL PRIMARY KEY NOT NULL,
                    id_user INTEGER REFERENCES users(id) NOT NULL,
                    id_art INTEGER REFERENCES arts(id) NOT NULL,
                    mark INTEGER NOT NULL,
                    created_at timestamp without time zone );
                CREATE TABLE roles (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL );
                CREATE TABLE studios (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL,
                    b_day DATE );
                CREATE TABLE users (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    email VARCHAR(255) NOT NULL,
                    password VARCHAR(255) NOT NULL,
                    role_id INTEGER REFERENCES roles(id) NOT NULL ); "
            };

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var sql in createTableCommands)
                {
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool DatabaseExists()
        {
            var builder = new NpgsqlConnectionStringBuilder(_connectionString);
            builder.Database = "postgres";
            
            using (var conn = new NpgsqlConnection(builder.ToString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT 1 FROM pg_database WHERE datname = db1";
                    
                    return cmd.ExecuteScalar() != null;
                }
            }
        }

        public void CreateDatabase()
        {
            var builder = new NpgsqlConnectionStringBuilder(_connectionString);
            builder.Database = "postgres";
            
            using (var conn = new NpgsqlConnection(builder.ToString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE db1";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
