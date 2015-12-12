using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Helenium.Models;

namespace Helenium.DAL
{
    /// <summary>
    /// Data initializer
    /// </summary>
    public class ConfigDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HeleniumDbContext>
    {
        /// <summary>
        /// Fills the default data.
        /// </summary>
        /// <param name="context">Context</param>
        protected override void Seed(HeleniumDbContext context)
        {
            DoInit(context);
        }

        /// <summary>
        /// Does the initialize.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void DoInit(HeleniumDbContext context)
        {
            var data = new List<ConfigData>
            {
                new ConfigData
                {
                    DelayMs=500,IsDebugger=false,LogPath="d:\\log",MaxHtmlLength=1024*1024,HasChanged =false,IsRunnning = false,UrlPattern ="",UrlsSerialized="",MaxLevel=2,
                    UserData = new UserData() { PersonaName = "Unknown" }
                }
            };
            data.ForEach(s => context.ConfigData.Add(s));
            context.SaveChanges();
        }
    }
}