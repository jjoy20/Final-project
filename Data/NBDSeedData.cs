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
                #region Clients
                //client 

                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                        new Client
                        {
                            ClientName = "London Sq. Mall",
                            Address = "12638 Mall Drive, Scotts Valley, CA95060",
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
                #endregion

                #region Projects
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
                #endregion

                #region Category
                //Category

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            CategoryName = "Plants"
                        },

                         new Category
                         {
                             CategoryName = "Pottery"
                         },

                          new Category
                          {
                              CategoryName = "Materials"
                          }
                        );
                    context.SaveChanges();
                }
                #endregion

                #region Material
                //Material 

                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(
                        new Material
                        {
                            Code = "TCP50",
                            Description = "t/c pot",
                            Size = "50 gal",
                            UnitPrice = 53.95m,
                            CategoryID = context.Categories.FirstOrDefault(c => c.CategoryName == "Pottery").ID
                        },
                         new Material
                         {
                             Code = "lacco",
                             Description = "austraasica palm",
                             Size = "15 gal",
                             UnitPrice = 450.00m,
                             CategoryID = context.Categories.FirstOrDefault(c => c.CategoryName == "Plants").ID
                         },
                          new Material
                          {
                              Code = "CBRK5",
                              Description = "decorative cedar bark",
                              Size = "5 cu ft",
                              UnitPrice = 7.50m,
                              CategoryID = context.Categories.FirstOrDefault(c => c.CategoryName == "Materials").ID
                          }
                        );
                    context.SaveChanges();
                }
                #endregion

                #region labors
                //labor
                if (!context.Labors.Any())
                {
                    context.Labors.AddRange(
                        new Labor
                        {
                            LaborType="Production worker",
                            LaborCost=18m,
                            LaborPrice=50m
                        },

                        new Labor
                        {
                            LaborType = "Heavy equipment operator",
                            LaborCost = 25m,
                            LaborPrice = 65m

                        },
                         new Labor
                         {
                             LaborType = "Designer Consultant",
                             LaborCost = 25m,
                             LaborPrice = 65m

                         },
                          new Labor
                          {
                              LaborType = "Sales",
                              LaborCost = 50m,
                              LaborPrice = 75m

                          },
                          new Labor
                          {
                              LaborType = "Botanist",
                              LaborCost = 50m,
                              LaborPrice = 75m

                          }
                        );
                    context.SaveChanges();
                }
                #endregion

                #region Employees
                //employee

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee
                        {
                            FirstName = "Josh",
                            LastName = "Picard",
                            eMail = "jpicard@gmail.com",
                            Phone = 1629465579,
                            LaborID= context.Labors.FirstOrDefault(l => l.LaborType == "Sales").ID
                        },

                        new Employee
                        {
                            FirstName = "Abby",
                            LastName = "Davidson",
                            eMail = "bbyd@gmail.com",
                            Phone = 2465971562,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Sales").ID

                        },

                        new Employee
                        {
                            FirstName = "Ethan",
                            LastName = "Smith",
                            eMail = "ethan.smith@gmail.com",
                            Phone = 5462870264,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Sales").ID
                        },

                        new Employee
                        {
                            FirstName = "David",
                            LastName = "Jones",
                            eMail = "djones12@gmail.com",
                            Phone = 2113408579,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Sales").ID
                        },

                        new Employee
                        {
                            FirstName = "Jessica",
                            LastName = "Williams",
                            eMail = "jessica.williams@gmail.com",
                            Phone = 1603189463,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Sales").ID
                        },

                         new Employee
                         {
                             FirstName = "Dalton",
                             LastName = "Davis",
                             eMail = "daltond@gmail.com",
                             Phone = 5408956735,
                             LaborID=context.Labors.FirstOrDefault(l=>l.LaborType== "Designer Consultant").ID
                         },

                        new Employee
                        {
                            FirstName = "Jason",
                            LastName = "Miller",
                            eMail = "j.miller@gmail.com",
                            Phone = 5468217305,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Designer Consultant").ID
                        },

                        new Employee
                        {
                            FirstName = "Lisa",
                            LastName = "Thomas",
                            eMail = "l.thomas@gmail.com",
                            Phone = 2475971562,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Designer Consultant").ID
                        },

                        new Employee
                        {
                            FirstName = "Carlos",
                            LastName = "Garcia",
                            eMail = "carlosg1234@gmail.com",
                            Phone = 6547359046,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Designer Consultant").ID
                        },

                        new Employee
                        {
                            FirstName = "Penelope",
                            LastName = "Wilson",
                            eMail = "pwils97@gmail.com",
                            Phone = 5469173586,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Designer Consultant").ID
                        },

						new Employee
                        {
                            FirstName = "Monica",
                            LastName = "Wilson",
                            eMail = "mwils97@gmail.com",
                            Phone = 5469173563,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Production worker").ID
                        },

						new Employee
                        {
                            FirstName = "Bert",
                            LastName = "Wilson",
                            eMail = "bwils97@gmail.com",
                            Phone = 5469173578,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Production worker").ID
                        },

                        new Employee
                        {
                            FirstName = "Erbt",
                            LastName = "Wilson",
                            eMail = "ewils17@gmail.com",
                            Phone = 5469173508,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Heavy equipment operator").ID
                        },

                         new Employee
                         {
                             FirstName = "Terb",
                             LastName = "Wilson",
                             eMail = "ewils97@gmail.com",
                             Phone = 5469173508,
                             LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Botanist").ID
                         }
                        );
                    context.SaveChanges();
                }

                #endregion


                #region Bids
                //bid

                if (!context.Bids.Any())
                {
                    context.Bids.AddRange(
                        new Bid
                        {
                            BidDate = DateTime.Parse("1996-05-06"),
                            EstBeginDate = DateTime.Parse("1996-06-14"),
                            EstComplDate = DateTime.Parse("1996-06-18"),
                            BidAmount = 7651m,
                            BidHours = 10,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "LS Mall Entrance").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Dalton").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Josh").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("1997-11-01"),
                            EstBeginDate = DateTime.Parse("1997-11-23"),
                            EstComplDate = DateTime.Parse("1997-11-29"),
                            BidAmount = 2985m,
                            BidHours = 5,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "LS Mall Food Court").ID,                          
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Jason").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Ethan").ID
                        }, 

                        new Bid
                        {
                            BidDate = DateTime.Parse("2001-06-01"),
                            EstBeginDate = DateTime.Parse("2001-06-07"),
                            EstComplDate = DateTime.Parse("2001-06-14"),
                            BidAmount = 5386m,
                            BidHours = 8,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Fairview Mall East").ID,                   
                                DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Penelope").ID,
                                SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Jessica").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2007-07-24"),
                            EstBeginDate = DateTime.Parse("2007-08-11"),
                            EstComplDate = DateTime.Parse("2007-08-19"),
                            BidAmount = 13495m,
                            BidHours = 20,
                            ApprovalbyNBD = false,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Fairview Mall West").ID,                     
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Carlos").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "David").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2006-04-07"),
                            EstBeginDate = DateTime.Parse("2006-04-21"),
                            EstComplDate = DateTime.Parse("2006-04-28"),
                            BidAmount = 10529m,
                            BidHours = 15,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Pen Centre Theatre Entrance").ID,                        
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Lisa").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Abby").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2012-04-29"),
                            EstBeginDate = DateTime.Parse("2012-05-09"),
                            EstComplDate = DateTime.Parse("2012-05-17"),
                            BidAmount = 20168m,
                            BidHours = 25,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Pen Centre Main Entrance").ID,                
                           DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Dalton").ID,
                           SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Jessica").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2007-07-01"),
                            EstBeginDate = DateTime.Parse("2007-07-07"),
                            EstComplDate = DateTime.Parse("2007-07-18"),
                            BidAmount = 11536m,
                            BidHours = 10,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "BW Hotel Pool").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Penelope").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Josh").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2015-03-18"),
                            EstBeginDate = DateTime.Parse("2015-03-25"),
                            EstComplDate = DateTime.Parse("2015-04-02"),
                            BidAmount = 6421m,
                            BidHours = 7,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "BW Hotel Entrance").ID,
                           DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Jason").ID,
                           SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Abby").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2011-02-20"),
                            EstBeginDate = DateTime.Parse("2011-02-28"),
                            EstComplDate = DateTime.Parse("2011-03-05"),
                            BidAmount = 6165m,
                            BidHours = 5,
                            ApprovalbyNBD = false,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Mapleview Mall Food Court").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Lisa").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "Ethan").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2018-09-04"),
                            EstBeginDate = DateTime.Parse("2018-09-13"),
                            EstComplDate = DateTime.Parse("2018-09-21"),
                            BidAmount = 9462m,
                            BidHours = 12,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Mapleview Mall Entrance").ID,
                            DesignerID = context.Employees.FirstOrDefault(d => d.FirstName == "Carlos").ID,
                            SalesID = context.Employees.FirstOrDefault(s => s.FirstName == "David").ID
                        }
                        );
                    context.SaveChanges();
                }
                #endregion

                #region Staff
                //staff 

                if (!context.Staffs.Any())
                {
                    context.Staffs.AddRange(
                        new Staff
                        {
                            Hours = 20,
                            LaborID=context.Labors.FirstOrDefault(l=>l.LaborType=="Production worker").ID,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        },
                        new Staff
                        {
                            Hours = 10,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Heavy equipment operator").ID,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        },
                        new Staff
                        {
                            Hours = 5,
                            LaborID = context.Labors.FirstOrDefault(l => l.LaborType == "Designer Consultant").ID,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        }
                        );
                    context.SaveChanges();
                }
                #endregion              

                #region Inventory
                //Inventory 

                if (!context.Inventories.Any())
                {
                    context.Inventories.AddRange(
                        new Inventory
                        {
                            Quantity = 20,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Code == "TCP50").ID,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        },
                        new Inventory
                        {
                            Quantity = 10,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Code == "lacco").ID,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        },
                        new Inventory
                        {
                            Quantity = 5,
                            MaterialID = context.Materials.FirstOrDefault(m => m.Code == "CBRK5").ID,
                            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                        }
                        );
                    context.SaveChanges();
                }
                #endregion        

            }
        }
    }
}
