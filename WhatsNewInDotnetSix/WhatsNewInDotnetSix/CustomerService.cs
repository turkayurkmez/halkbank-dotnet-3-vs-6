using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInDotnetSix
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Country { get; set; }
    }
    public class CustomerService
    {
        private List<Customer> customers = new()
        {
            new(){ Id=1, Name="BT Akademi", Budget=15000000, Country="Türkiye"},
            new(){ Id=5, Name="AAA", Budget=3000000000, Country="Amerika"},
            new(){ Id=3, Name="Halkbank", Budget=3000000000, Country ="Türkiye"},
            new(){ Id=4, Name="Kardeşler inşaat", Budget=5000000, Country="Türkiye"},


        };

        public IEnumerable<Customer> GetCustomers() => customers;

    }
}
