﻿using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Repository.Specification.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Repository.Specification.ReservationSpecifications
{
    public class ReservationSpecificationForRevenueReport : BaseSpecifications<Reservation>
    {
        public ReservationSpecificationForRevenueReport(SpecParams spec, DateTime firstDate, DateTime secondDate)
             : base(res => res.CheckInDate >= firstDate &&
                           res.CheckInDate <= secondDate &&
                           (res.Status == ReservationStatus.PaymentReceived ||
                            res.Status == ReservationStatus.CheckedIn ||
                            res.Status == ReservationStatus.CheckedOut))
        {

            Includes.Add(r => r.Include(r => r.Room));
            Includes.Add(r => r.Include(r => r.Customer));

            if (!string.IsNullOrEmpty(spec.Sort))
            {
                switch (spec.Sort)
                {
                    case "AmountAsc":
                        AddOrderBy(R => R.TotalAmount);
                        break;
                    case "AmountDesc":
                        AddOrderByDesc(R => R.TotalAmount);
                        break;
                }
            }

            ApplyPagination(spec.PageSize * (spec.PageIndex - 1), spec.PageSize);
        }
    }
}