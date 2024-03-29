using System;

namespace AnimalShelter.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
    }
}