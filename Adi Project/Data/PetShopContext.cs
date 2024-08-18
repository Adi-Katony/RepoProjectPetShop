using Microsoft.EntityFrameworkCore;
using ProjectPetShop.Models;

namespace ProjectPetShop.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Mammal" },
                new Category { CategoryId = 2, CategoryName = "Bird" },
                new Category { CategoryId = 3, CategoryName = "Aquatic" },
                new Category { CategoryId = 4, CategoryName = "Reptile" },
                new Category { CategoryId = 5, CategoryName = "Amphibian" }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    AnimalId = 1,
                    Name = "Lion",
                    CategoryId = 1,
                    Age = 5,
                    PictureName = "Images/Lion.png",
                    Description = "The lion is known as the king of the jungle, renowned for its majestic appearance and commanding presence. With its powerful build, golden mane, and impressive roar, the lion is a symbol of strength and courage. Lions are social animals that live in prides and are found in the grasslands and savannas of Africa. They primarily hunt in groups, using teamwork to bring down large prey such as zebras and buffaloes."
                },
                new Animal
                {
                    AnimalId = 2,
                    Name = "Eagle",
                    CategoryId = 2,
                    Age = 3,
                    PictureName = "Images/Eagle.png",
                    Description = "Eagles are large, powerful birds of prey known for their keen eyesight and impressive hunting skills. With their sharp talons and strong beaks, eagles are formidable predators that primarily hunt fish, small mammals, and other birds. They have a broad wingspan that allows them to soar high in the sky and spot prey from great distances. Eagles are often associated with freedom and strength and can be found in a variety of habitats, including mountains, forests, and near bodies of water."
                },
                new Animal
                {
                    AnimalId = 3,
                    Name = "Shark",
                    CategoryId = 3,
                    Age = 7,
                    PictureName = "Images/Shark.png",
                    Description = "Sharks are a diverse group of predatory fish known for their keen sense of smell and streamlined bodies, which make them efficient hunters. They have existed for over 400 million years and have adapted to various marine environments. Sharks come in various sizes, from the tiny pygmy shark to the massive whale shark. They are crucial to ocean ecosystems as apex predators, maintaining the balance of marine life by controlling the population of other fish and marine animals."
                },
                new Animal
                {
                    AnimalId = 4,
                    Name = "Turtle",
                    CategoryId = 4,
                    Age = 50,
                    PictureName = "Images/SeaTurtle.png",
                    Description = "Turtles are reptiles known for their distinctive hard shells, which provide protection from predators. They are found in a variety of environments, including oceans, rivers, and land. Turtles have a slow metabolism and can live for several decades, with some species reaching over 100 years in age. They are known for their longevity and resilience. Sea turtles are particularly notable for their long migrations across oceans, returning to the same beaches where they were born to lay their eggs."
                },
                new Animal
                {
                    AnimalId = 5,
                    Name = "Frog",
                    CategoryId = 5,
                    Age = 2,
                    PictureName = "Images/Frog.png",
                    Description = "Frogs are amphibians recognized for their smooth, moist skin and distinctive croaking sounds. They are highly adaptable and can be found in various habitats, from tropical rainforests to temperate woodlands and even arid deserts. Frogs have a unique life cycle, starting as aquatic tadpoles before undergoing metamorphosis to become adult frogs. They play an important role in their ecosystems as both predators and prey, feeding on insects and serving as food for various animals."
                },
                new Animal
                {
                    AnimalId = 6,
                    Name = "Elephant",
                    CategoryId = 1,
                    Age = 10,
                    PictureName = "Images/Elephent.png",
                    Description = "Elephants are the largest land animals, known for their impressive size, large ears, and long trunks. Their trunks are versatile tools used for feeding, communication, and social interactions. Elephants are highly social animals, living in tight-knit family groups led by matriarchs. They are found in diverse habitats, including savannas, forests, and deserts. Elephants play a crucial role in their ecosystems by creating waterholes, dispersing seeds, and maintaining the balance of vegetation."
                },
                new Animal
                {
                    AnimalId = 7,
                    Name = "Parrot",
                    CategoryId = 2,
                    Age = 4,
                    PictureName = "Images/Parrot.png",
                    Description = "Parrots are vibrant and intelligent birds known for their colorful plumage and remarkable ability to mimic sounds and human speech. They have strong, curved beaks and zygodactyl feet (two toes facing forward and two backward), which aid in grasping and manipulating objects. Parrots are native to tropical and subtropical regions and live in various habitats, including rainforests, savannas, and coastal mangroves. They are highly social and often form strong bonds with their mates and companions."
                },
                new Animal
                {
                    AnimalId = 8,
                    Name = "Goldfish",
                    CategoryId = 3,
                    Age = 1,
                    PictureName = "Images/GoldFish.png",
                    Description = "Goldfish are one of the most popular aquarium fish, known for their bright orange color and graceful swimming. They are a domesticated version of a wild species and have been bred for various colors and fin shapes. Goldfish are hardy and adaptable, making them a favorite choice for home aquariums. They have a relatively short lifespan compared to other fish species, but with proper care, they can live up to 10-15 years. Goldfish are often kept for their beauty and the calming effect of watching them swim."
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, AnimalId = 1, Review = "Amazing animal!" },
                new Comment { CommentId = 2, AnimalId = 2, Review = "Such a majestic bird." },
                new Comment { CommentId = 3, AnimalId = 3, Review = "A true ocean king." },
                new Comment { CommentId = 4, AnimalId = 4, Review = "So slow but steady." },
                new Comment { CommentId = 5, AnimalId = 5, Review = "A lively little creature." },
                new Comment { CommentId = 6, AnimalId = 6, Review = "Impressive and intelligent." },
                new Comment { CommentId = 7, AnimalId = 7, Review = "Bright and cheerful." },
                new Comment { CommentId = 8, AnimalId = 8, Review = "A delightful pet." },
                new Comment { CommentId = 9, AnimalId = 3, Review = "It can smell blood." },
                new Comment { CommentId = 10, AnimalId = 1, Review = "A really big cat." },
                new Comment { CommentId = 11, AnimalId = 7, Review = "beautiful colors." },
                new Comment { CommentId = 12, AnimalId = 7, Review = "I love watching them." },
                new Comment { CommentId = 13, AnimalId = 1, Review = "Known for it's strength, majestic mane, and commanding presence." }


            );
        }

    }
}
