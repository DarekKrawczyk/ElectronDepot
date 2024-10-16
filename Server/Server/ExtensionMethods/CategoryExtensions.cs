using ElectroDepotClassLibrary.DTOs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class CategoryExtensions
    {
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO(
                category.CategoryID,
                category.Name,
                category.Description
            );
        }

        public static Category ToCategory(this CategoryDTO categoryDTO)
        {
            return new Category()
            {
                CategoryID = categoryDTO.ID,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
        }

        public static Category ToCategory(this CreateCategoryDTO categoryDTO)
        {
            return new Category()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
        }

        public static Category ToCategory(this UpdateCategoryDTO categoryDTO)
        {
            return new Category()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
        }
    }
}
