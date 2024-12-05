using System;
using System.Collections.Generic;
using System.Data;
using Npgsql; // Для работы с PostgreSQL
using kursDB1.Models;

namespace kursDB1.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService()
        {
            // Строка подключения к базе данных
            _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";
        }

        public List<Art> GetArts()
        {
            var arts = new List<Art>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT id, name, id_genre FROM Arts";
                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        arts.Add(new Art
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            GenreId = reader.GetInt32(0)
                        });
                    }
                }
            }

            return arts;
        }

        public void RateArt(int userId, int artId, int mark)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = $"INSERT INTO Marks (id_user, id_art, mark, created_at) VALUES ('{userId}', '{artId}', '{mark}', '{DateTime.Now}')";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@artId", artId);
                    command.Parameters.AddWithValue("@mark", mark);
                    command.Parameters.AddWithValue("@addedDate", DateTime.Now); // Устанавливаем текущую дату и время

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Mark> GetUserMarks(int userId)
        {
            var marks = new List<Mark>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = $"SELECT id_art, mark FROM Marks WHERE user_id = '{userId}'";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marks.Add(new Mark
                            {
                                ArtId = reader.GetInt32(0),
                                MarkValue = reader.GetInt32(1)
                            });
                        }
                    }
                }
            }

            return marks;
        }
    }
}
