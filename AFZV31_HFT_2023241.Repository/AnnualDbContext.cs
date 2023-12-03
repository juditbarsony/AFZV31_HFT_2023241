using AFZV31_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Repository
{
    public class AnnualDbContext : DbContext
    {
        public DbSet<Annual> Annuals { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public AnnualDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\annuals.mdf;Integrated Security=True;MultipleActiveResultSets=True";
                //builder
                //.UseSqlServer(conn)
                //.UseLazyLoadingProxies();


                builder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("annual");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
            .HasOne(area => area.Annuals)
            .WithMany(annual => annual.Areas)
            .HasPrincipalKey(area => area.AnnualCode);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
            .HasOne(order => order.Annuals)
            .WithMany(annual => annual.Orders)
            .HasPrincipalKey(order => order.AnnualCode);
            //.OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Annual>().HasData(new Annual[]
                {
                 new Annual("1#AchFiliCG#Achillea filipendulina ’Coronation Gold’#5"),
                 new Annual("2#BergCord#Bergenia cordifolia#7"),
                 new Annual("3#EchPurpA#Echinacea purpurea ’Alba’#7"),
                 new Annual("4#EchPurpM#Echinacea purpurea ’Magnus’#7"),
                 new Annual("5#GerSangTM#Geranium sanguineum 'Tiny Monster'#9"),
                 new Annual("6#GerMac#Geranium macrorrhizum#9"),
                 new Annual("7#HeliItal#Helichrysum italicum#7"),
                 new Annual("8#KoelGlau#Koeleria glauca#7"),
                 new Annual("9#MelOff#Melissa officinalis#9"),
                 new Annual("10#MentPip#Mentha x piperita#9"),
                 new Annual("11#PanVirH#Panicum virgatum ’Heavymetal’#7"),
                 new Annual("12#RosmOff#Rosmarinus officinalis#5"),
                 new Annual("13#SedAlb#Sedum album#9"),
                 new Annual("14#SedRup#Sedum rupestre#9"),
                 new Annual("15#SedEll#Sedum ellacombianum#9"),
                 new Annual("16#StipatTenu#Stipa tenuissima#5"),
                 new Annual("17#SalvOff#Salvia officinalis#7"),
                 new Annual("18#SalvOffIct#Salvia officinalis ’Icterina’#7"),
                 new Annual("19#SalvoffPur#Salvia officinalis ’Purpurascens’#7"),
                 new Annual("20#SalvOffTr#Salvia officinalis ’Tricolor’#7"),
                 new Annual("21#SantCham#Santolina Chamaecyparissus#7"),
                 new Annual("22#TeCha#Teucrium chamaedrys#9"),
                 new Annual("23#ThyVul#Thymus vulgaris#9"),
                 new Annual("24#AcSpin#Acanthus Spinosus#5")

                });

            modelBuilder.Entity<Area>().HasData(new Area[]
                {
                    new Area("12#3,66#AcSpin"),
                    new Area("230#2,43#AchFiliCG"),
                    new Area("240#3,42#AchFiliCG"),
                    new Area("238#3,05#AchFiliCG"),
                    new Area("236#2,03#AchFiliCG"),
                    new Area("234#0,99#AchFiliCG"),
                    new Area("176#0,88#AchFiliCG"),
                    new Area("261#4,94#AchFiliCG"),
                    new Area("180#1,19#AchFiliCG"),
                    new Area("272#0,52#AchFiliCG"),
                    new Area("109#11,23#BergCord"),
                    new Area("125#14,40#BergCord"),
                    new Area("243#1,13#EchPurpA"),
                    new Area("245#4,83#EchPurpA"),
                    new Area("225#2,75#EchPurpA"),
                    new Area("57#0,54#EchPurpA"),
                    new Area("170#1,10#EchPurpA"),
                    new Area("172#0,66#EchPurpA"),
                    new Area("178#0,99#EchPurpA"),
                    new Area("50#0,69#EchPurpA"),
                    new Area("244#1,57#EchPurpM"),
                    new Area("246#3,39#EchPurpM"),
                    new Area("106#10,01#GerMac"),
                    new Area("126#13,03#GerMac"),
                    new Area("4#23,91#GerSangTM"),
                    new Area("139#20,64#GerSangTM"),
                    new Area("18#9,94#GerSangTM"),
                    new Area("140#6,94#GerSangTM"),
                    new Area("248#5,69#GerSangTM"),
                    new Area("91#3,43#GerSangTM"),
                    new Area("14#8,14#HeliItal"),
                    new Area("96#3,78#KoelGlau"),
                    new Area("60#4,33#KoelGlau"),
                    new Area("118#5,35#KoelGlau"),
                    new Area("87#23,75#KoelGlau"),
                    new Area("84#16,07#KoelGlau"),
                    new Area("82#12,73#KoelGlau"),
                    new Area("79#11,18#KoelGlau"),
                    new Area("251#18,92#KoelGlau"),
                    new Area("256#4,63#KoelGlau"),
                    new Area("268#4,58#KoelGlau"),
                    new Area("259#6,29#KoelGlau"),
                    new Area("153#5,70#KoelGlau"),
                    new Area("192#7,54#KoelGlau"),
                    new Area("273#16,35#KoelGlau"),
                    new Area("226#1,57#MelOff"),
                    new Area("224#4,88#MentPip"),
                    new Area("53#2,53#MentPip"),
                    new Area("179#2,11#MentPip"),
                    new Area("171#2,10#MentPip"),
                    new Area("81#22,30#PanVirH"),
                    new Area("73#3,19#PanVirH"),
                    new Area("76#5,47#PanVirH"),
                    new Area("63#13,81#PanVirH"),
                    new Area("35#14,98#PanVirH"),
                    new Area("95#21,23#PanVirH"),
                    new Area("90#9,03#PanVirH"),
                    new Area("229#5,07#RosmOff"),
                    new Area("227#7,51#SalvOff"),
                    new Area("239#6,25#SalvOffIct"),
                    new Area("231#4,13#SalvOffIct"),
                    new Area("51#3,21#SalvOffIct"),
                    new Area("173#3,32#SalvOffIct"),
                    new Area("237#8,63#SalvOffPur"),
                    new Area("56#1,72#SalvoffPur"),
                    new Area("177#3,84#SalvoffPur"),
                    new Area("235#5,53#SalvOffTr"),
                    new Area("13#11,70#SantCham"),
                    new Area("3#9,28#SedAlb"),
                    new Area("21#22,09#SedAlb"),
                    new Area("70#43,25#SedAlb"),
                    new Area("52#2,16#SedAlb"),
                    new Area("15#16,27#SedAlb"),
                    new Area("19#6,85#SedEll"),
                    new Area("80#41,30#SedEll"),
                    new Area("86#37,71#SedEll"),
                    new Area("5#9,30#SedEll"),
                    new Area("20#10,81#SedRup"),
                    new Area("16#8,15#SedRup"),
                    new Area("88#25,60#SedRup"),
                    new Area("83#49,66#SedRup"),
                    new Area("77#27,35#SedRup"),
                    new Area("6#11,21#StipatTenu"),
                    new Area("131#4,51#StipatTenu"),
                    new Area("137#9,79#StipatTenu"),
                    new Area("10#10,59#StipatTenu"),
                    new Area("26#11,97#StipatTenu"),
                    new Area("141#11,75#StipatTenu"),
                    new Area("144#3,77#StipatTenu"),
                    new Area("163#8,31#StipatTenu"),
                    new Area("39#9,32#StipatTenu"),
                    new Area("253#16,77#StipatTenu"),
                    new Area("266#1,70#StipatTenu"),
                    new Area("213#2,09#TeCha"),
                    new Area("55#2,96#TeCha"),
                    new Area("241#6,05#ThyVul"),
                    new Area("280#4,72#ThyVul"),
                    new Area("233#2,72#ThyVul"),
                    new Area("49#2,08#ThyVul"),
                    new Area("58#1,91#ThyVul"),
                    new Area("169#2,52#ThyVul"),
                    new Area("181#1,73#ThyVul")
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                    new Order("1#AchFiliCG#Megyeri#11x11#1190"),
                    new Order("2#BergCord#Megyeri#9x9#1290"),
                    new Order("3#EchPurpA#Beretvás#9x9#350"),
                    new Order("4#EchPurpM#Beretvás#9x9#350"),
                    new Order("5#GerSangTM#Beretvás#9x9#350"),
                    new Order("6#GerMac#Megyeri#9x9#1190"),
                    new Order("7#HeliItal#Megyeri#9x9#2500"),
                    new Order("8#KoelGlau#Megyeri#10,5#1690"),
                    new Order("9#MelOff#Prenor#9x9#390"),
                    new Order("10#MentPip#Prenor#CSP11 1xi#390"),
                    new Order("11#PanVirH#Megyeri#9x9#990"),
                    new Order("12#RosmOff#Mocsáry#9x9#500"),
                    new Order("13#SedAlb#Mocsáry#9x9#500"),
                    new Order("14#SedRup#Megyeri#7x7#890"),
                    new Order("15#SedEll#Megyeri#10,5#1490"),
                    new Order("16#StipatTenu#Mocsáry#9x9#500"),
                    new Order("17#SalvOff#Mocsáry#9x9#400"),
                    new Order("18#SalvOffIct#Beretvás#14#680"),
                    new Order("19#SalvoffPur#Beretvás#14#680"),
                    new Order("20#SalvOffTr#Beretvás#14#680"),
                    new Order("21#SantCham#Mocsáry#14#680"),
                    new Order("22#TeCha#Beretvás#9x9#350"),
                    new Order("23#ThyVul#Megyeri#10#590")
            });

            base.OnModelCreating(modelBuilder);//ezt nem tudom mire jó

        }







    }
}
