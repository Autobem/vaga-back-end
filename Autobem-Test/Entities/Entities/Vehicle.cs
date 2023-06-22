﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Year { get; set; }

    [ForeignKey("Owner")]
    public Guid OwnerId { get; set; }
}