using Povio.FlowerSpot.Domain.Entities;
using Povio.FlowerSpot.Domain.ValueObjects;
using Povio.FlowerSpot.Persistence;

namespace Povio.FlowerSpot.IntegrationTests.Database
{
    public class Seeder
    {
        public static void Seed(FlowerSpotDbContext dbContext)
        {
            // flowers
            dbContext.Flowers.AddRange(GenerateFlowers());
            dbContext.SaveChanges();

            // users
            dbContext.User.AddRange(GenerateUsers());
            dbContext.SaveChanges();

            // sightings
            dbContext.Sighting.AddRange(GenerateSightings());
            dbContext.SaveChanges();

            // likes
            dbContext.Like.AddRange(GenerateLikes());
            dbContext.SaveChanges();
        }
        private static List<Flower> GenerateFlowers()
        {
            var flowerId = 1;

            return new()
            {
                new Flower()
                {
                    CreatedDate = DateTime.UtcNow,
                    Description = $"description-{flowerId}",
                    ImageRef = $"imageRef-{flowerId}",
                    Name = $"name-{flowerId++}"
                },
                new Flower()
                {
                    CreatedDate = DateTime.UtcNow,
                    Description = $"description-{flowerId}",
                    ImageRef = $"imageRef-{flowerId}",
                    Name = $"name-{flowerId++}"
                },
                new Flower()
                {
                    CreatedDate = DateTime.UtcNow,
                    Description = $"description-{flowerId}",
                    ImageRef = $"imageRef-{flowerId}",
                    Name = $"name-{flowerId++}"
                }
            };
        }

        private static List<User> GenerateUsers()
        {
            var userId = 2;

            return new()
            {
                new User()
                {
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                    Email = $"email-{userId}@test.com",
                    Password = "password",
                    Username = $"test{userId++}"
                },
                new User()
                {
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                    Email = $"email-{userId}@test.com",
                    Password = "password",
                    Username = $"test{userId++}"
                },
                new User()
                {
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                    Email = $"email-{userId}@test.com",
                    Password = "password",
                    Username = $"test{userId++}"
                }
            };
        }

        private static List<Sighting> GenerateSightings()
        {
            return new()
            {
                new Sighting()
                {
                   CreatedDate = DateTime.UtcNow,
                   FlowerId = 1,
                   UserId = 1,
                   ImageRef = "image-ref",
                   Quote = "quote",
                   Coordinates = new Coordinates(100, 50)
                },
                new Sighting()
                {
                   CreatedDate = DateTime.UtcNow,
                   FlowerId = 2,
                   UserId = 1,
                   ImageRef = "image-ref",
                   Quote = "quote",
                   Coordinates = new Coordinates(100, 50)
                },
                new Sighting()
                {
                   CreatedDate = DateTime.UtcNow,
                   FlowerId = 3,
                   UserId = 1,
                   ImageRef = "image-ref",
                   Quote = "quote",
                   Coordinates = new Coordinates(100, 50)
                },
                new Sighting()
                {
                   CreatedDate = DateTime.UtcNow,
                   FlowerId = 2,
                   UserId = 2,
                   ImageRef = "image-ref",
                   Quote = "quote",
                   Coordinates = new Coordinates(100, 50)
                },
                new Sighting()
                {
                   CreatedDate = DateTime.UtcNow,
                   FlowerId = 3,
                   UserId = 2,
                   ImageRef = "image-ref",
                   Quote = "quote",
                   Coordinates = new Coordinates(100, 50)
                },
                new Sighting()
                {
                   CreatedDate = DateTime.UtcNow,
                   FlowerId = 3,
                   UserId = 3,
                   ImageRef = "image-ref",
                   Quote = "quote",
                   Coordinates = new Coordinates(100, 50)
                }
            };
        }

        private static List<Like> GenerateLikes()
        {
            return new()
            {
                new Like()
                {
                    UserId = 1,
                    SightingId = 1,
                    CreatedDate = DateTime.UtcNow
                },
                new Like()
                {
                    UserId = 2,
                    SightingId = 2,
                    CreatedDate = DateTime.UtcNow
                },
                new Like()
                {
                    UserId = 3,
                    SightingId = 3,
                    CreatedDate = DateTime.UtcNow
                },
            };
        }
    }
}
