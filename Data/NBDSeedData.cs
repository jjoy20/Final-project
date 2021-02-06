using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NBDcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Data
{
    public static class NBDSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new NBDContext(
                serviceProvider.GetRequiredService<DbContextOptions<NBDContext>>()))
            {
                //client 

                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                        new Client
                        {
                            ClientName = "London Sq. Mall",
                            Address = "12638 Mall Drive, Scotts Valley,CA95060",
                            Contact = "Amy Benson, Mgr.",
                            Phone = 4088345603
                        },

                        new Client
                        {
                            ClientName = "Fairview Mall",
                            Address = "285 Geneva Street, St. Catharines, ON M2J5A7",
                            Contact = "John Smith, Mgr.",
                            Phone = 9056463165
                        },

                        new Client
                        {
                            ClientName = "Pen Centre",
                            Address = "221 Glendale Ave., St. Catharines, ON L2T2K9",
                            Contact = "Amanda Roberts, Mgr.",
                            Phone = 9056876622
                        },

                        new Client
                        {
                            ClientName = "Best Western Hotel",
                            Address = "2 N Service Road, St. Catharines, ON L2N4G9",
                            Contact = "Nick King, Mgr.",
                            Phone = 9059348000
                        },

                        new Client
                        {
                            ClientName = "MapleView Shopping Centre",
                            Address = "900 Maple Ave., Burlington, ON L7S2J8",
                            Contact = "James Gordon, Mgr.",
                            Phone = 9056812900
                        }
                        );
                    context.SaveChanges();
                }

                //project
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                        new Project
                        {
                            ProjectName = "LS Mall Entrance",
                            BeginDate = DateTime.Parse("1996-06-14"),
                            CompleteDate = DateTime.Parse("1996-06-18"),
                            ProjectSite = "Main entrance Mall Dr./Cinema Lane",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "London Sq. Mall").ID
                        },

                        new Project
                        {
                            ProjectName = "LS Mall Food Court",
                            BeginDate = DateTime.Parse("1997-11-23"),
                            CompleteDate = DateTime.Parse("1997-11-29"),
                            ProjectSite = "Food Court",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "London Sq. Mall").ID
                        },

                        new Project
                        {
                            ProjectName = "Fairview Mall East",
                            BeginDate = DateTime.Parse("2001-06-07"),
                            CompleteDate = DateTime.Parse("2001-06-14"),
                            ProjectSite = "Main entrance on east side",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Fairview Mall").ID
                        },

                        new Project
                        {
                            ProjectName = "Fairview Mall West",
                            BeginDate = DateTime.Parse("2007-08-11"),
                            CompleteDate = DateTime.Parse("2007-08-19"),
                            ProjectSite = "West entrance",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Fairview Mall").ID
                        },

                        new Project
                        {
                            ProjectName = "Pen Centre Theatre Entrance",
                            BeginDate = DateTime.Parse("2006-04-21"),
                            CompleteDate = DateTime.Parse("2006-04-28"),
                            ProjectSite = "Mall entrance near movie theatre",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Pen Centre").ID
                        },

                        new Project
                        {
                            ProjectName = "Pen Centre Main Entrance",
                            BeginDate = DateTime.Parse("2012-05-09"),
                            CompleteDate = DateTime.Parse("2012-05-17"),
                            ProjectSite = "Main entrance",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Pen Centre").ID
                        },

                        new Project
                        {
                            ProjectName = "BW Hotel Pool",
                            BeginDate = DateTime.Parse("2007-07-07"),
                            CompleteDate = DateTime.Parse("2007-07-18"),
                            ProjectSite = "Pool",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Best Western Hotel").ID
                        },

                        new Project
                        {
                            ProjectName = "BW Hotel Entrance",
                            BeginDate = DateTime.Parse("2015-03-25"),
                            CompleteDate = DateTime.Parse("2015-04-02"),
                            ProjectSite = "Main entrance",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "Best Western Hotel").ID
                        },

                        new Project
                        {
                            ProjectName = "Mapleview Mall Food Court",
                            BeginDate = DateTime.Parse("2011-02-28"),
                            CompleteDate = DateTime.Parse("2011-03-05"),
                            ProjectSite = "Food Court",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "MapleView Shopping Centre").ID
                        },

                        new Project
                        {
                            ProjectName = "Mapleview Mall Entrance",
                            BeginDate = DateTime.Parse("2018-09-13"),
                            CompleteDate = DateTime.Parse("2018-09-21"),
                            ProjectSite = "Main entrance",
                            ClientID = context.Clients.FirstOrDefault(c => c.ClientName == "MapleView Shopping Centre").ID
                        }
                        );
                    context.SaveChanges();
                }

                //bid

                if (!context.Bids.Any())
                {
                    context.Bids.AddRange(
                        new Bid
                        {
                            BidDate = DateTime.Parse("1996-05-06"),
                            BidAmount = 7651,
                            BidHours = 10,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "LS Mall Entrance").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("1997-11-01"),
                            BidAmount = 2985,
                            BidHours = 5,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "LS Mall Food Court").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2001-06-01"),
                            BidAmount = 5386,
                            BidHours = 8,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Fairview Mall East").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2007-08-04"),
                            BidAmount = 13495,
                            BidHours = 20,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Fairview Mall West").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2006-04-07"),
                            BidAmount = 10529,
                            BidHours = 15,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Pen Centre Theatre Entrance").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2012-04-29"),
                            BidAmount = 20168,
                            BidHours = 25,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Pen Centre Main Entrance").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2007-07-01"),
                            BidAmount = 11536,
                            BidHours = 10,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "BW Hotel Pool").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2015-03-18"),
                            BidAmount = 6421,
                            BidHours = 7,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "BW Hotel Entrance").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2011-02-20"),
                            BidAmount = 6165,
                            BidHours = 5,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Mapleview Mall Food Court").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2018-09-04"),
                            BidAmount = 9462,
                            BidHours = 12,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Mapleview Mall Entrance").ID
                        }
                        );
                    context.SaveChanges();
                }

                //staff 

                if (!context.Staffs.Any())
                {
                    context.Staffs.AddRange(
                        new Staff
                        {
                            PositionName = "Designer",
                            Salary = 50000,
                            Hours = 20,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        }
                        );
                    context.SaveChanges();
                }

                //labor

                if (!context.Labors.Any())
                {
                    context.Labors.AddRange(
                        new Labor
                        {
                            LaborType = "Production worker",
                            LaborCost = 18,
                            LaborPrice = 50                         
                        }
                        );
                    context.SaveChanges();
                }

                //Inventory 

                if (!context.Inventories.Any())
                {
                    context.Inventories.AddRange(
                        new Inventory
                        {
                            Code = "Lacco",
                            Description = "See NBD Case",
                            Size = "10x20x20",
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        }
                        );
                    context.SaveChanges();
                }

                //Material 

                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(
                        new Material
                        {
                            Type = "Pottery",
                            Quantity = 20,
                            Description = "GFN48",
                            Size = "48in",
                            UnitPrice = 457                            
                        }
                        );
                    context.SaveChanges();
                }


            }
        }


    }
}
