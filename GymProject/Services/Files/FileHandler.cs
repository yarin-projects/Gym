using GymProject.Models;
using Newtonsoft.Json;
using System.IO;

namespace GymProject.Services.Files
{
    class FileHandler
    {
        const string CLIENT_FOLDER = "Clients";
        const string COACH_FOLDER = "Coaches";
        const string FILE_NAME = "Data.txt";

        /// <summary>
        /// saves a client object in the 'Clients' folder
        /// </summary>
        /// <param name="c">Client object</param>
        public static void SaveClient(Client c)
        {
            string folderPath = Path.Combine(CLIENT_FOLDER, c.Id);
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, FILE_NAME);
            string json = JsonConvert.SerializeObject(c);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Searches for a client with the same ID as the parameter passed through
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if theres a client with the same ID</returns>
        public static bool SearchClient(string id)
        {
            string[] allClientDirs = Directory.GetDirectories(CLIENT_FOLDER);
            for (int i = 0; i < allClientDirs.Length; i++)
            {
                if (allClientDirs[i].Remove(0, 8) == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns array of all client objects within the 'Clients' folder
        /// </summary>
        public static Client[] LoadClients()
        {
            string[] allClientDirs = Directory.GetDirectories(CLIENT_FOLDER);
            Client[] clients = new Client[allClientDirs.Length];
            for (int i = 0; i < clients.Length; i++)
            {
                string[] files = Directory.GetFiles(allClientDirs[i]);
                string json = File.ReadAllText(files[0]);
                Client c = JsonConvert.DeserializeObject<Client>(json);
                clients[i] = c;
            }
            return clients;
        }

        /// <summary>
        /// Saves a coach object in the 'Coaches' folder
        /// </summary>
        /// <param name="c">Coach object</param>
        public static void SaveCoach(Coach c)
        {
            string folderPath = Path.Combine(COACH_FOLDER, c.Id);
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, FILE_NAME);
            string json = JsonConvert.SerializeObject(c);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Searches for a coach with the same ID as the parameter passed through
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if theres a coach with the same ID</returns>
        public static bool SearchCoach(string id)
        {
            string[] allCoachDirs = Directory.GetDirectories(COACH_FOLDER);
            for (int i = 0; i < allCoachDirs.Length; i++)
            {
                if (allCoachDirs[i].Remove(0, 8) == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns array of all coach objects within the 'Coaches' folder
        /// </summary>
        public static Coach[] LoadCoaches()
        {
            string[] allCoachDirs = Directory.GetDirectories(COACH_FOLDER);
            Coach[] coaches = new Coach[allCoachDirs.Length];
            for (int i = 0; i < coaches.Length; i++)
            {
                string[] files = Directory.GetFiles(allCoachDirs[i]);
                string json = File.ReadAllText(files[0]);
                Coach c = JsonConvert.DeserializeObject<Coach>(json);
                coaches[i] = c;
            }
            return coaches;
        }

    }
}
