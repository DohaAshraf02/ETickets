﻿namespace ETickets.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie>? Movies { get; set; }
    }
}
