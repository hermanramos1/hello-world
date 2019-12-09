using System;
using System.Collections.Generic;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.PizzaBoxDb;

namespace PizzaBox.Client
{
    class Program
    {
      private static SqlAdapter _sql = new SqlAdapter();


        static void Main(string[] args)
        {
            Address sampleAddress = new Address();
            sampleAddress.Address1 = "123 Abram";
            _sql.CreateAddress(sampleAddress);
            User sampleUser = new User();
            sampleUser.Username = "Herman";
            sampleUser.Address = sampleAddress;
            _sql.CreateUser(sampleUser);
            Console.WriteLine(sampleUser.Username);
            User user = _sql.FindUser(Console.ReadLine());
            Console.WriteLine(user.Username);
            User herman = _sql.FindUser("Herman");

            Crust thinCrust = _sql.FindCrust(1);
            Size smallSize = _sql.FindSize(1);

            Pizza samplePizza = new Pizza();
            samplePizza.Crust = thinCrust;
            samplePizza.Size = smallSize;
            samplePizza.Price = 11.00M;

            OrderPizza p = new OrderPizza();
            p.Pizza = samplePizza;

            Store littleItaly = _sql.FindStore(1);
            Order sampleOrder = new Order();
            sampleOrder.Customer = sampleUser;
            sampleOrder.Store = littleItaly;
            sampleOrder.TotalCost = 189.00M;
            DateTime current = DateTime.Now;
            sampleOrder.OrderDate = current;
            sampleOrder.OrderPizza.Add(p);
            _sql.CreateOrder(sampleOrder);

            List<Order> usersOrder = _sql.FindUsersOrders(herman);
            


            foreach(Order o in usersOrder)
            {

              Console.WriteLine(o.Customer.Username);
              Console.WriteLine(o.OrderDate.Date);
              Console.WriteLine(o.TotalCost.Value);
              List<Pizza> OrdersPizza = _sql.FindOrdersPizzas(o);
              foreach(Pizza p in OrdersPizza)
              {
              Console.WriteLine(p.Price);
              Console.WriteLine(p.Crust);
              Console.WriteLine(p.Size);


              }

            }
          



        }
    }
}
