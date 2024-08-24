using System;
using System.Collections.Generic;
using System.Linq;

namespace patika_csharp_kurs.VotingApplication
{
    public class VotingApp
    {
        //username, sifre
        private Dictionary<string, string> users = new();

        //kategori, oy
        private Dictionary<string, int> votes = new();
        private List<string> categories = new() { "Film", "Tech Stack", "Spor" };

        public void Run()
        {
            Console.WriteLine("Oylamaya Hoşgeldiniz!");
            string username = GetOrRegisterUser();

            bool voting = true;
            while (voting)
            {
                ShowCategories();
                int choice = GetValidCategoryChoice();
                RecordVote(choice);

                Console.WriteLine("Başka bir oy kullanmak ister misiniz? (E/H)");
                voting = Console.ReadLine().ToUpper() == "E";
            }

            ShowResults();
        }

        private string GetOrRegisterUser()
        {
            Console.Write("Kullanıcı adınızı girin: ");
            string username = Console.ReadLine();

            if (!users.ContainsKey(username))
            {
                Console.WriteLine("Bu kullanıcı sistemde kayıtlı değil. Şimdi kayıt olmalısınız.");
                RegisterUser(username);
            }

            return username;
        }

        private void RegisterUser(string username)
        {
            Console.Write("Şifre oluşturun: ");
            users[username] = Console.ReadLine();
            Console.WriteLine("Başarıyla kayıt oldunuz.");
        }

        private void ShowCategories()
        {
            Console.WriteLine("\nOylamak istediğiniz kategoriyi seçiniz:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }
        }

        private int GetValidCategoryChoice()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= categories.Count)
                {
                    return choice - 1;
                }
                Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
            }
        }

        private void RecordVote(int choice)
        {
            string category = categories[choice];
            votes[category] = votes.GetValueOrDefault(category, 0) + 1;
            Console.WriteLine($"{category} kategorisine oy verdiniz.");
        }

        private void ShowResults()
        {
            Console.WriteLine("\nOylama Sonuçları:");
            int totalVotes = votes.Values.Sum();

            foreach (var category in categories)
            {
                int voteCount = votes.GetValueOrDefault(category, 0);
                double percentage = totalVotes > 0 ? (double)voteCount / totalVotes * 100 : 0;
                Console.WriteLine($"{category}: {voteCount} oy (%{percentage:F2})");
            }
        }
    }
}
