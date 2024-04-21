using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documental",
                    Rating = "G",
                    Price = 7.99M,
                    Image = "/images/meet-the-mormons.jpg",
                    Description = "Meet the Mormons is a 2014 American documentary film directed by Blair Treu and produced by the Church of Jesus Christ of Latter-day Saints (LDS Church). The film documents the lives of six devout Mormons living in the United States, Costa Rica, and Nepal."
                },
                new Movie
                {
                    Title = "Ephraim's Rescue",
                    ReleaseDate = DateTime.Parse("2013-5-31"),
                    Genre = "Drama",
                    Rating = "G",
                    Price = 8.99M,
                    Image = "/images/ephraims-rescue.jpg",
                    Description = "Ephraim's Rescue is a religious historical drama film by T. C. Christensen, released in 2013 by Excel Entertainment Group. It is based on the true stories of Mormon pioneers Ephraim Hanks and Thomas Dobson and their experiences in the handcart brigades."
                },
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Drama",
                    Rating = "PG",
                    Price = 9.99M,
                    Image = "/images/the-other-side-of-heaven.jpg",
                    Description = "THE OTHER SIDE OF HEAVEN tells the story of a Mormon missionary, John Groberg, who is sent to a South Pacific island. John's attempts to win the natives to Mormonism are opposed by the native Christian pastor, who even sends thugs to beat him up."
                },
                new Movie
                {
                    Title = "Once I Was a Beehive",
                    ReleaseDate = DateTime.Parse("2015-08-14"),
                    Genre = "Comedy/Drama",
                    Rating = "G",
                    Price = 3.99M,
                    Image = "/images/once-i-was-a-beehive.jpg",
                    Description = "Parents need to know that Once I Was a Beehive is a comedy about a non-Mormon teenager who goes to a Latter-day Saints summer camp. The film pokes fun at a lot of stereotypes about Mormons and shows that there's more to the campers (and all Mormons) than the preconceived notions held by the main character."
                }
            );
            context.SaveChanges();
        }
    }
}