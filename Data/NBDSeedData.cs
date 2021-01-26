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

                if(!context.Clients.Any())
                {
                    context.Clients.AddRange(
                        new Client 
                        {
                            ClientName="London Sq. Mall",
                            Address="12638 Mall Drive, Scotts Valley,CA95060",
                            Contact="Amy Benson, Mgr.",
                            Phone= 4088345603
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
                            ProjectName="LS Mall",
                            BeginDate=DateTime.Parse("1996-06-14"),
                            CompleteDate=DateTime.Parse("1996-06-18"),
                            ProjectSite="Main entrance Mall Dr./Cinema Lane",
                            ClientID=context.Clients.FirstOrDefault(c=>c.ClientName=="London Sq. Mall").ID
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
                            BidDate= DateTime.Parse("1996-05-06"),
                            BidAmount= 7651,
                            BidHours=10,
                            ProjectID=context.Projects.FirstOrDefault(p=>p.ProjectName=="LS Mall").ID
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
                            Hours=20,
                            BidID=context.Bids.FirstOrDefault(b=>b.BidDate==DateTime.Parse("1996-05-06")).ID
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
                            LaborType="Production worker",
                            LaborCost=18,
                            LaborPrice=50,
                            StaffID=context.Staffs.FirstOrDefault(s=>s.PositionName=="Designer").ID
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
                            Description="See NBD Case",
                            Size="10x20x20",
                            BidID=context.Bids.FirstOrDefault(b => b.BidDate == DateTime.Parse("1996-05-06")).ID
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
                            Type="Pottery",
                            Quantity=20,
                            Description="GFN48",
                            Size= "48in",
                            UnitPrice= 457,
                            InventoryID=context.Inventories.FirstOrDefault(i=>i.Code=="Lacco").ID
                        }
                        );
                    context.SaveChanges();
                }


            }
        }


    }
}
