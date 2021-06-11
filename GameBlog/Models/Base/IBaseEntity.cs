using System;

namespace GameBlog.Models.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }

        string MetaDescription { get; set; }
        string MetaKeywords { get; set; }

        string Name { get; set; }
        string Slug { get; set; }
    }
}