using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Oblig1.Models
{
    public class DBInit : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var movie1 = new Movie
            {
                MId = 1,
                Title = "Mission: Impossible – Fallout",
                Price = 150,
                Dir = "Christopher McQuarrie",
                Year = 2018,
                ImgUrl = "~/Images/MI6.jpg",
                VidUrl = "https://www.youtube.com/embed/XiHiW4N7-bo",
                Plot = "Ethan Hunt and the IMF team join forces with CIA assassin August Walker to prevent a disaster of epic proportions. Arms dealer John Lark and a group of terrorists known as the Apostles plan to use three plutonium cores for a simultaneous nuclear attack on the Vatican, Jerusalem and Mecca, Saudi Arabia. When the weapons go missing, Ethan and his crew find themselves in a desperate race against time to prevent them from falling into the wrong hands.",
            };
            var movie2 = new Movie
            {
                MId = 2,
                Title = "Jurassic World: Fallen Kingdom",
                Price = 100,
                Dir = "J. A. Bayona",
                Year = 2018,
                ImgUrl = "~/Images/JWFK.jpg",
                VidUrl = "https://www.youtube.com/embed/vn9mMeWcgoM",
                Plot = "Three years after the destruction of the Jurassic World theme park, Owen Grady and Claire Dearing return to the island of Isla Nublar to save the remaining dinosaurs from a volcano that's about to erupt. They soon encounter terrifying new breeds of gigantic dinosaurs, while uncovering a conspiracy that threatens the entire planet.",
            };
            var movie3 = new Movie
            {
                MId = 3,
                Title = "Red Sparrow",
                Price = 90,
                Dir = "Francis Lawrence",
                Year = 2018,
                ImgUrl = "~/Images/RS.jpg",
                VidUrl = "https://www.youtube.com/embed/PmUL6wMpMWw",
                Plot = "Prima ballerina Dominika Egorova faces a bleak and uncertain future after she suffers an injury that ends her career. She soon turns to Sparrow School, a secret intelligence service that trains exceptional young people to use their minds and bodies as weapons. Egorova emerges as the most dangerous Sparrow after completing the sadistic training process. As she comes to terms with her new abilities, Dominika meets a CIA agent who tries to convince her that he is the only person she can trust.",
            };
            var movie4 = new Movie
            {
                MId = 4,
                Title = "Tomb Raider",
                Price = 100,
                Dir = "Roar Uthaug",
                Year = 2018,
                ImgUrl = "~/Images/TR.jpg",
                VidUrl = "https://www.youtube.com/embed/8ndhidEmUbI",
                Plot = "Lara Croft is the fiercely independent daughter of an eccentric adventurer who vanished years earlier. Hoping to solve the mystery of her father's disappearance, Croft embarks on a perilous journey to his last-known destination -- a fabled tomb on a mythical island that might be somewhere off the coast of Japan. The stakes couldn't be higher as Lara must rely on her sharp mind, blind faith and stubborn spirit to venture into the unknown.",
            };
            var movie5 = new Movie
            {
                MId = 5,
                Title = "Deadpool 2",
                Price = 150,
                Dir = "David Leitch",
                Year = 2018,
                ImgUrl = "~/Images/DP2.jpg",
                VidUrl = "https://www.youtube.com/embed/D86RtevtfrA",
                Plot = "Wisecracking mercenary Deadpool meets Russell, an angry teenage mutant who lives at an orphanage. When Russell becomes the target of Cable -- a genetically enhanced soldier from the future -- Deadpool realizes that he'll need some help saving the boy from such a superior enemy. He soon joins forces with Bedlam, Shatterstar, Domino and other powerful mutants to protect young Russell from Cable and his advanced weaponry.",
            };
            var movie6 = new Movie
            {
                MId = 6,
                Title = "The Nun",
                Price = 200,
                Dir = "Corin Hardy",
                Year = 2018,
                ImgUrl = "~/Images/TN.jpg",
                VidUrl = "https://www.youtube.com/embed/pzD9zGcUNrw",
                Plot = "When a young nun at a cloistered abbey in Romania takes her own life, a priest with a haunted past and a novitiate on the threshold of her final vows are sent by the Vatican to investigate. Together, they uncover the order's unholy secret. Risking not only their lives but their faith and their very souls, they confront a malevolent force in the form of a demonic nun.",
            };
            var movie7 = new Movie
            {
                MId = 7,
                Title = "Rampage",
                Price = 50,
                Dir = "Brad Peyton",
                Year = 2018,
                ImgUrl = "~/Images/R.jpg",
                VidUrl = "https://www.youtube.com/embed/coOKvrsmQiI",
                Plot = "Global icon Dwayne Johnson headlines the action adventure “Rampage,” directed by Brad Peyton. Johnson stars as primatologist Davis Okoye, a man who keeps people at a distance but shares an unshakable bond with George, the extraordinarily intelligent, incredibly rare albino silverback gorilla who has been in his care since he rescued the young orphan from poachers. But a rogue genetic experiment gone awry mutates this gentle ape into a raging creature of enormous size. To make matters worse, it’s soon discovered there are other similarly altered animals. As these newly created alpha predators tear across North America, destroying everything in their path, Okoye teams with discredited geneticist Kate Caldwell (Naomie Harris) to secure an antidote, fighting his way through an ever-changing battlefield, not only to halt a global catastrophe but to save the fearsome creature that was once his friend.",
            };
            var movie8 = new Movie
            {
                MId = 8,
                Title = "Avengers: Infinity War",
                Price = 200,
                Dir = "Anthony Russo, Joe Russo",
                Year = 2018,
                ImgUrl = "~/Images/AIW.jpg",
                VidUrl = "https://www.youtube.com/embed/QwievZ1Tx-8",
                Plot = "Iron Man, Thor, the Hulk and the rest of the Avengers unite to battle their most powerful enemy yet -- the evil Thanos. On a mission to collect all six Infinity Stones, Thanos plans to use the artifacts to inflict his twisted will on reality. The fate of the planet and existence itself has never been more uncertain as everything the Avengers have fought for has led up to this moment.",
            };
            var movie9 = new Movie
            {
                MId = 9,
                Title = "Hereditary",
                Price = 100,
                Dir = "Ari Aster",
                Year = 2018,
                ImgUrl = "~/Images/H.jpg",
                VidUrl = "https://www.youtube.com/embed/V6wWKNij_1M",
                Plot = "When the matriarch of the Graham family passes away, her daughter and grandchildren begin to unravel cryptic and increasingly terrifying secrets about their ancestry, trying to outrun the sinister fate they have inherited.",
            };
            var movie10 = new Movie
            {
                MId = 10,
                Title = "22 July",
                Price = 150,
                Dir = "Paul Greengrass",
                Year = 2018,
                ImgUrl = "~/Images/22J.jpg",
                VidUrl = "https://www.youtube.com/embed/ZVpUZGmHJB8",
                Plot = "Norway's deadliest terrorist attack, in which a right-wing extremist murders 77 teens at a youth camp in 2011, is dramatized.",
            };

            var admin = new UserAccount()
            {
                Username = "admin",
                Password = "password",
                ConfirmPassword = "password",
                FirstName = "admin",
                LastName = "admin",
                Email = "abc@email.com",
                DateRegistered = DateTime.UtcNow,
                IsDeleted = false,
                IsAdmin = true,
            };

            var client = new UserAccount()
            {
                Username = "test",
                Password = "tester",
                ConfirmPassword = "tester",
                FirstName = "test",
                LastName = "test",
                Email = "test@oslomet.no",
                DateRegistered = DateTime.UtcNow,
                IsAdmin = false,
                IsDeleted = false,
            };

            context.Movies.Add(movie1);
            context.Movies.Add(movie2);
            context.Movies.Add(movie3);
            context.Movies.Add(movie4);
            context.Movies.Add(movie5);
            context.Movies.Add(movie6);
            context.Movies.Add(movie7);
            context.Movies.Add(movie8);
            context.Movies.Add(movie9);
            context.Movies.Add(movie10);
            context.UserAccounts.Add(admin);
            context.UserAccounts.Add(client);

            base.Seed(context);
        }
    }
}