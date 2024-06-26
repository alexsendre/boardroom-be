﻿namespace BoardRoom.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public int SellerId { get; set; }

        public ICollection<User>? Users { get; set; }
        public ICollection<Item>? Items { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}
