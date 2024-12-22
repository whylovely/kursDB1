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
                @"CREATE TABLE IF NOT EXISTS albums (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255),
                    count_arts INTEGER,
                    drop_day DATE);",

                @"CREATE TABLE IF NOT EXISTS artists (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255),
                    count_arts INTEGER);",

                @"CREATE TABLE IF NOT EXISTS arts (
                    id SERIAL PRIMARY KEY,
                    id_label INTEGER REFERENCES labels(id),
                    id_artist INTEGER REFERENCES artists(id),
                    id_album INTEGER REFERENCES albums(id),
                    id_studio INTEGER REFERENCES studios(id),
                    id_director INTEGER REFERENCES directors(id),
                    id_genre INTEGER REFERENCES genres(id),
                    duration INTEGER,
                    mark_art INTEGER);",

                @"CREATE TABLE IF NOT EXISTS directors (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255));",

                @"CREATE TABLE IF NOT EXISTS genres (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255));",

                @"CREATE TABLE IF NOT EXISTS labels (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255),
                    count_arts INTEGER,
                    b_date DATE);",

                @"CREATE TABLE IF NOT EXISTS marks (
                    id SERIAL PRIMARY KEY,
                    id_user INTEGER REFERENCES users(id),
                    id_art INTEGER REFERENCES arts(id),
                    mark INTEGER);",

                @"CREATE TABLE IF NOT EXISTS roles (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255));",

                @"CREATE TABLE IF NOT EXISTS studios (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255),
                    count_arts INTEGER,
                    b_day DATE);",

                @"CREATE TABLE IF NOT EXISTS users (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(255),
                    email VARCHAR(255),
                    password VARCHAR(255),
                    role_id INTEGER REFERENCES roles(id));"
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
    }
}
