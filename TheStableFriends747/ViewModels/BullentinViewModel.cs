using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheStableFriends747.Models;

namespace TheStableFriends747.ViewModels
{
    internal class BullentinViewModel
    {
        public List<BullentinBoard> Bullentinboards { get; set; }

        public Loggo Loggo { get; set; }

        public BullentinViewModel()
        {
            Bullentinboards = new List<BullentinBoard>();

            //Lägger till data från databasen
            var task = Task.Run(() => GetNotesFromDB());
            task.Wait();
            Bullentinboards.AddRange(task.Result);

           

            Loggo = new Loggo()
            {
                HeaderImageSource = "background.jpg"
            };

        }
        
        private async Task<List<BullentinBoard>> GetNotesFromDB()
        {
            //Anropas högst upp för att hämta data från db
            List<BullentinBoard> notesFromDb = await Data.DB.BullentinCollection().AsQueryable().ToListAsync();
            return notesFromDb;

          
        }
    }
}
