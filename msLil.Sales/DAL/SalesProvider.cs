using msLil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLil.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();
        public SalesProvider()
        {
            repo.Add(new Order()
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddDays(-10),
                Total = 50,
                Items = new List<OrderItem>()
                {
                    new OrderItem(){ OrderId = "0001",Id =1, Price=50, ProducId="23", Quantity =2},
                    new OrderItem(){ OrderId = "0001",Id =2, Price=50, ProducId="25", Quantity =3}
                }

            });
            repo.Add(new Order()
            {
                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddDays(-10),
                Total = 50,
                Items = new List<OrderItem>()
                {
                    new OrderItem(){ OrderId = "0002",Id =1, Price=50, ProducId="13", Quantity =2},
                    new OrderItem(){ OrderId = "0002",Id =2, Price=50, ProducId="3", Quantity =2}
                }

            });
            repo.Add(new Order()
            {
                Id = "0003",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddDays(-10),
                Total = 50,
                Items = new List<OrderItem>()
                {
                    new OrderItem(){ OrderId = "0004",Id =1, Price=50, ProducId="56", Quantity =2},
                    new OrderItem(){ OrderId = "0004",Id =2, Price=50, ProducId="45", Quantity =5}
                }

            });
            repo.Add(new Order()
            {
                Id = "0004",
                CustomerId = "4",
                OrderDate = DateTime.Now.AddDays(-10),
                Total  = 50,
                Items =  new List<OrderItem>()
                {
                    new OrderItem(){ OrderId = "0004",Id =1, Price=50, ProducId="23", Quantity =2}
                }

            });
        }

        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(o => o.CustomerId.Equals(customerId)).ToList();
            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
