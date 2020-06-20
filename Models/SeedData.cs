using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movie.Any() && context.Genre.Any())
                {
                    return;
                }

                // Look for any genres.
                if (!context.Genre.Any())
                {
                    context.Genre.AddRange(
                         new Genre
                         {
                             GenreName = "Comedy"
                         },

                         new Genre
                         {
                             GenreName = "Romantic Comedy"
                         },

                         new Genre
                         {
                             GenreName = "Inspirational"
                         }
                     );

                }

                // Look for any movies.
                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "17 Miracles",
                            ReleaseDate = DateTime.Parse("2011-7-01"),
                            GenreId = 3,
                            Price = 7.99M,
                            Rating = "PG",
                            Image = "17Miracles.jpg"
                        },

                        new Movie
                        {
                            Title = "Charley",
                            ReleaseDate = DateTime.Parse("2001-7-01"),
                            GenreId = 2,
                            Price = 3.99M,
                            Rating = "PG",
                            Image = "charly.jpg"
                        },

                        new Movie
                        {
                            Title = "The RM",
                            ReleaseDate = DateTime.Parse("2002-7-01"),
                            GenreId = 1,
                            Price = 9.99M,
                            Rating = "PG",
                            Image = "theRM.jpg"
                        },

                        new Movie
                        {
                            Title = "Singles Ward",
                            ReleaseDate = DateTime.Parse("2001-7-01"),
                            GenreId = 1,
                            Price = 3.99M,
                            Rating = "PG",
                            Image = "SinglesWard.jpg"
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}