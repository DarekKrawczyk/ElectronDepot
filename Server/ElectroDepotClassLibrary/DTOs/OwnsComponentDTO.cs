namespace ElectroDepotClassLibrary.DTOs
{
    public record OwnsComponentDTO(
        int ID,
        int UserID,
        int ComponentID,
        int Quantity
    );

    public record UpdateOwnsComponentDTO(
        int Quantity
    );

    public record CreateOwnsComponentDTO(
        int UserID,
        int ComponentID,
        int Quantity
    );
}
