﻿using ETickets.Data.Enums;

namespace ETickets.ViewModels
{
    public class MovieDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; }
        public int CinemaId { get; set; }
        public string? CinemaName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual List<ActorDto>? Actors { get; set; }

    }
}
