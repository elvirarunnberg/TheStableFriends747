using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheStableFriends747.Models;

namespace TheStableFriends747.ViewModels
{
    internal class HorsePageViewModel
    {
        public  List <Horse> Horses{ get; set; }

        public Loggo Loggo { get; set; }

            public HorsePageViewModel()
            {
                Horses = new List<Horse>();

            //Hämta data från databasen
            var task = Task.Run(() => GetHorsesFromDB());
            task.Wait();
            Horses.AddRange(task.Result);

          
            Loggo = new Models.Loggo()
            {
              
                HeaderImageSource = "background.jpg"
            };

            }
        
        private async Task<List<Horse>> GetHorsesFromDB()
        {
            //Hämta hästar från db
            List<Horse> horsesFromDb = await Data.DB.HorseCollection().AsQueryable().ToListAsync();
            return horsesFromDb;

           
        }

    }
    }

