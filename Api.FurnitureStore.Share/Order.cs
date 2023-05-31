﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.FurnitureStore.Share
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
