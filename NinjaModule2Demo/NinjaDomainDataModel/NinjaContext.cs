using NinjaDomain.Classes;
using System.Data.Entity;

namespace NinjaDomainDataModel
{
    public class NinjaContext : DbContext
    {
        //DbContext API - interacts with db
        //DbSet - maintains particular set of types , maintains in memory collection of entities
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }
    }
}
