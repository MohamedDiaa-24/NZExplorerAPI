﻿namespace NZExplorer.API.Models
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        public string? ImageURL { get; set; }
        public IEnumerable<Walk> Walks { get; set; }
    }
}
