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
                            Phone = 1629465579
                        },

                        new Employee
                        {
                            FirstName = "Abby",
                            LastName = "Davidson",
                            eMail = "bbyd@gmail.com",
                            Phone = 2465971562
                        },

                        new Employee
                        {
                            FirstName = "Ethan",
                            LastName = "Smith",
                            eMail = "ethan.smith@gmail.com",
                            Phone = 5462870264
                        },

                        new Employee
                        {
                            FirstName = "David",
                            LastName = "Jones",
                            eMail = "djones12@gmail.com",
                            Phone = 2113408579
                        },

                        new Employee
                        {
                            FirstName = "Jessica",
                            LastName = "Williams",
                            eMail = "jessica.williams@gmail.com",
                            Phone = 1603189463
                        },

                         new Employee
                         {
                             FirstName = "Dalton",
                             LastName = "Davis",
                             eMail = "daltond@gmail.com",
                             Phone = 5408956735
                         },

                        new Employee
                        {
                            FirstName = "Jason",
                            LastName = "Miller",
                            eMail = "j.miller@gmail.com",
                            Phone = 5468217305
                        },

                        new Employee
                        {
                            FirstName = "Lisa",
                            LastName = "Thomas",
                            eMail = "l.thomas@gmail.com",
                            Phone = 2475971562
                        },

                        new Employee
                        {
                            FirstName = "Carlos",
                            LastName = "Garcia",
                            eMail = "carlosg1234@gmail.com",
                            Phone = 6547359046
                        },

                        new Employee
                        {
                            FirstName = "Penelope",
                            LastName = "Wilson",
                            eMail = "pwils97@gmail.com",
                            Phone = 5469173586
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
                            BidAmount = 7651,
                            BidHours = 10,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "LS Mall Entrance").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Dalton").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Josh").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("1997-11-01"),
                            EstBeginDate = DateTime.Parse("1997-11-23"),
                            EstComplDate = DateTime.Parse("1997-11-29"),
                            BidAmount = 2985,
                            BidHours = 5,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "LS Mall Food Court").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Jason").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Ethan").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2001-06-01"),
                            EstBeginDate = DateTime.Parse("2001-06-07"),
                            EstComplDate = DateTime.Parse("2001-06-14"),
                            BidAmount = 5386,
                            BidHours = 8,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Fairview Mall East").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Penelope").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Jessica").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2007-07-24"),
                            EstBeginDate = DateTime.Parse("2007-08-11"),
                            EstComplDate = DateTime.Parse("2007-08-19"),
                            BidAmount = 13495,
                            BidHours = 20,
                            ApprovalbyNBD = false,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Fairview Mall West").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Carlos").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "David").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2006-04-07"),
                            EstBeginDate = DateTime.Parse("2006-04-21"),
                            EstComplDate = DateTime.Parse("2006-04-28"),
                            BidAmount = 10529,
                            BidHours = 15,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Pen Centre Theatre Entrance").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Lisa").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Abby").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2012-04-29"),
                            EstBeginDate = DateTime.Parse("2012-05-09"),
                            EstComplDate = DateTime.Parse("2012-05-17"),
                            BidAmount = 20168,
                            BidHours = 25,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Pen Centre Main Entrance").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Dalton").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Jessica").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2007-07-01"),
                            EstBeginDate = DateTime.Parse("2007-07-07"),
                            EstComplDate = DateTime.Parse("2007-07-18"),
                            BidAmount = 11536,
                            BidHours = 10,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "BW Hotel Pool").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Penelope").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Josh").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2015-03-18"),
                            EstBeginDate = DateTime.Parse("2015-03-25"),
                            EstComplDate = DateTime.Parse("2015-04-02"),
                            BidAmount = 6421,
                            BidHours = 7,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "BW Hotel Entrance").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Jason").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Abby").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2011-02-20"),
                            EstBeginDate = DateTime.Parse("2011-02-28"),
                            EstComplDate = DateTime.Parse("2011-03-05"),
                            BidAmount = 6165,
                            BidHours = 5,
                            ApprovalbyNBD = false,
                            ApprovalbyClient = false,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Mapleview Mall Food Court").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Lisa").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "Ethan").ID
                        },

                        new Bid
                        {
                            BidDate = DateTime.Parse("2018-09-04"),
                            EstBeginDate = DateTime.Parse("2018-09-13"),
                            EstComplDate = DateTime.Parse("2018-09-21"),
                            BidAmount = 9462,
                            BidHours = 12,
                            ApprovalbyNBD = true,
                            ApprovalbyClient = true,
                            ProjectID = context.Projects.FirstOrDefault(p => p.ProjectName == "Mapleview Mall Entrance").ID,
                            EmployeeID = context.Employees.FirstOrDefault(d => d.FirstName == "Carlos").ID,
                            Employee2ID = context.Employees.FirstOrDefault(s => s.FirstName == "David").ID
                        }
                        );
                    context.SaveChanges();
                }
                #endregion

                #region Staff
                //staff 

                //if (!context.Staffs.Any())
                //{
                //    context.Staffs.AddRange(
                //        new Staff
                //        {
                //            PositionName = "Designer",
                //            Salary = 50000,
                //            Hours = 20,
                //            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                //        }
                //        );
                //    context.SaveChanges();
                //}
                #endregion

                #region Labor
                //labor

                //if (!context.Labors.Any())
                //{
                //    context.Labors.AddRange(
                //        new Labor
                //        {
                //            LaborType = "Production worker",
                //            LaborCost = 18,
                //            LaborPrice = 50                         
                //        }
                //        );
                //    context.SaveChanges();
                //}
                #endregion

                #region Category
                //Category

                //if (!context.Categories.Any())
                //{
                //    context.Categories.AddRange(
                //        new Category
                //        {
                //            CategoryName="Plant"
                //        },

                //         new Category
                //         {
                //             CategoryName = "Pottery"
                //         },

                //          new Category
                //          {
                //              CategoryName = "Materials"
                //          }
                //        );
                //    context.SaveChanges();
                //}
                #endregion

                #region Material
                //Material 

                //if (!context.Materials.Any())
                //{
                //    context.Materials.AddRange(
                //        new Material
                //        {
                //            Code="TCP50",
                //            Quantity = 20,
                //            Description = "t/c pot",
                //            Size = "50 gal",
                //            UnitPrice = 54, 
                //            CategoryID=context.Categories.FirstOrDefault(c=>c.CategoryName=="Pottery").ID
                //        }
                //        );
                //    context.SaveChanges();
                //}
                #endregion

                #region Inventory
                //Inventory 

                //if (!context.Inventories.Any())
                //{
                //    context.Inventories.AddRange(
                //        new Inventory
                //        {
                //            Quantity=20,                           
                //            MaterialID=context.Materials.FirstOrDefault(m=>m.Description=="t/c pot").ID,                           
                //            BidID = context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
                //        }
                //        );
                //    context.SaveChanges();
                //}
                #endregion

              

                

            }
        }


    }
}
