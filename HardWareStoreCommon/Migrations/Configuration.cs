namespace HardwareStoreCommon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HardwareStoreCommon.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HardwareStoreCommon.Storage.HardwareStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HardwareStoreCommon.Storage.HardwareStoreContext context)
        {
            context.Tools.AddOrUpdate(t => t.Name,
                new Tool
                {
                    Name = "Ryobi kultivator",
                    Description = "Robust kultivator fra Ryobi med en kraftfuld 120 watt motor og en fræsebredde på 25 cm." +
                                  " Kultivatoren er udstyret med 4 stk. metalknive, der sikrer konstant bevægelse, og de justerbare baghjul<br>" +
                                  "gør den let at manøvrere og transportere. Håndtaget er desuden foldbart, så kultivatoren opnår en kompakt størrelse og er let at opbevare.",
                    Deposit = 1000,
                    PricePerDay = 299,
                    ImgSrc ="~/Content/images/kultivator.jpg"
                });
            context.Tools.AddOrUpdate(t => t.Name,
                new Tool
                {
                    Name = "Powerworks batteri græs- og buskrydder",
                    Description = "Kraftfuld græstrimmer og buskrydder med en klippebredde på 40 cm fra Powerworks' 60 V serie." +
                    " Buskrydderen har en klippehastighed på 6000 rpm, som kan justeres på det praktiske håndtag." +
                    " Havemaskinen er velegnet som almindelig græstrimmer, men kan ligeledes klare tættere beplantning på grund af buskrydderen.",
                    Deposit = 500,
                    PricePerDay = 199,
                    ImgSrc = "~/Content/images/buskrydder.jpg"
                });
            context.Tools.AddOrUpdate(t => t.Name,
                new Tool
                {
                    Name = "Nilfisk højtryksrenser",
                    Description = "Kraftfuld Nilfisk-højtryksrenser, som er en effektiv maskine velegnet til både store og små rengøringsopgaver i og omkring hjemmet." + 
                                  " Med højtryksrenserens opretstående design og kørevogn er du sikret en optimal ergonomisk arbejdsstilling.",
                    Deposit = 800,
                    PricePerDay = 249,
                    ImgSrc = "~/Content/images/hoejtryksrenser.jpg"
                });
        }
    }
}
