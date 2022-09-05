﻿using AutoMapper;
using Entites.Concrete;
using Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.MyAllProfiles
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderTicketDTO>();
        }
    }
}
