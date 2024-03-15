using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using MongoDB.Driver;
using TheStableFriends747.Models;

namespace TheStableFriends747.Data
{
    internal class DB
    {

        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://elvirarunnberg:A6JVaSQfegXJlVeF@stablefriends.3n6q1xf.mongodb.net/?retryWrites=true&w=majority&appName=Stablefriends";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            return mongoClient;

        }

        public static IMongoCollection<BullentinBoard> BullentinCollection()
        {
            var clients = GetClient();

            var datas = clients.GetDatabase("StableFriendsApp");

            var bullentinCollection = datas.GetCollection<BullentinBoard>("MyStableNotes");

            return bullentinCollection;
        }

        public static IMongoCollection<Horse> HorseCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("StableFriends");

            var horseCollection = database.GetCollection<Horse>("StableFriends");

            return horseCollection;

        }

     

    }
}
