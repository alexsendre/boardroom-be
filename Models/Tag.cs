﻿namespace BoardRoom.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
