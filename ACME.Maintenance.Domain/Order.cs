using ACME.Maintenance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Maintenance.Domain
{
    public class Order
    {
        public string OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public int OrderItemCount { get; set; }
        public double Subtotal { get; set; }

        private List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public IReadOnlyList<OrderItem> Items
        {
            get { return OrderItems; }
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItemCount = 0;
            Subtotal = 0.0;

            OrderItems.Add(orderItem);
            foreach (var item in OrderItems)
            {
                OrderItemCount += item.Quantity;
                Subtotal += item.LineTotal;

            }
        }

    }
}
