using System;
using SQLite;

namespace MovieApp.Models
{
	public class Repository
	{
		private readonly SQLiteConnection _database;

		public Repository()
		{
			var dbpath = Path.Combine(
				Environment.GetFolderPath(
				Environment.SpecialFolder.LocalApplicationData),
				"movies.db");

			_database = new SQLiteConnection(dbpath);
			_database.CreateTable<Movie>();
		}

		public List<Movie> GetMovies()
		{
			return _database.Table<Movie>().ToList();
			//return _database.Query<Movie>("select * from Movie where ID > 3");
		}

		public void SaveMovie(Movie movie)
		{
			_database.Insert(movie);
		}
	}
}

