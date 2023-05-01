using System;
using FlashProductAPI_7.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FlashProductAPI_7.Db.DbModels
{
    public class Product    
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<CustomField>? CustomFields { get; set; }

    }
}