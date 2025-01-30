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
                    id_artist INTEGER NOT NULL
                );
                CREATE INDEX idx_albums_id_artist ON albums (id_artist);

                CREATE TABLE artists (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL
                );

                CREATE TABLE directors (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL
                );

                CREATE TABLE genres (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255)
                );

                CREATE TABLE labels (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL,
                    b_date DATE
                );

                CREATE TABLE roles (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL
                );

                CREATE TABLE studios (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    count_arts INTEGER NOT NULL,
                    b_day DATE
                );

                CREATE TABLE users (
                    id SERIAL PRIMARY KEY NOT NULL,
                    name VARCHAR(255) NOT NULL,
                    email VARCHAR(255) NOT NULL,
                    password VARCHAR(255) NOT NULL,
                    role_id INTEGER REFERENCES roles(id) NOT NULL
                );
                CREATE INDEX idx_users_email ON users (email);
                CREATE INDEX idx_users_role_id ON users (role_id);
                
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
                    name VARCHAR(100)
                );
                CREATE INDEX idx_arts_id_label ON arts (id_label);
                CREATE INDEX idx_arts_id_artist ON arts (id_artist);
                CREATE INDEX idx_arts_id_album ON arts (id_album);
                CREATE INDEX idx_arts_id_studio ON arts (id_studio);
                CREATE INDEX idx_arts_id_director ON arts (id_director);
                CREATE INDEX idx_arts_id_genre ON arts (id_genre);
                    
                CREATE TABLE marks (
                    id SERIAL PRIMARY KEY NOT NULL,
                    id_user INTEGER REFERENCES users(id) NOT NULL,
                    id_art INTEGER REFERENCES arts(id) NOT NULL,
                    mark INTEGER NOT NULL,
                    created_at timestamp without time zone
                );
                CREATE INDEX idx_marks_id_user ON marks (id_user);
                CREATE INDEX idx_marks_id_art ON marks (id_art); "};

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
