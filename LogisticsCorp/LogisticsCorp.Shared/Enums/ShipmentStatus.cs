namespace LogisticsCorp.Shared.Enums;

/// <summary>
/// Status of a shipment in its lifecycle
/// </summary>
public enum ShipmentStatus
{
    Registered = 1,
    InTransit = 2,
    Delivered = 3,
    Cancelled = 4
}