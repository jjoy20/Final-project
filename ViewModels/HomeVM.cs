using NBDcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.ViewModels
{
    public class HomeVM
    {
        public List<Bid> Bids { get; set; }

        public List<Client> Clients { get; set; }

        public List<Project> Projects { get; set; }
    }
}
