﻿
namespace BO;

public class EngineerInList
{
    public required int ID { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public override string ToString() => this.ToStringProperty();
}
