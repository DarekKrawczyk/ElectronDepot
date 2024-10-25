﻿namespace ElectroDepotClassLibrary.DTOs
{
    public record ProjectDTO(
        int ID,
        int UserID,
        string Name,
        string Description,
        DateTime CreatedAt
    );

    public record CreateProjectDTO(
        int UserID,
        string Name,
        string Description
    );

    public record UpdateProjectDTO(
        string Name,
        string Description
    );
}
