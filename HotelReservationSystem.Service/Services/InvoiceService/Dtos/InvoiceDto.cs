﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Service.Services.InvoiceService.Dtos
{
    public class InvoiceDto
    {
        public DateTime InvoiceDate { get; set; }
        public int ReservationId { get; set;}
    }
}