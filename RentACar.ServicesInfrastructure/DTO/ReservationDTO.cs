﻿using RentACar.DataContext.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        public float FinalPrice { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public CarReservationDTO Car { get; set; }
        public PeriodDTO Period { get; set; }
    }
}
