using EndpointImplementationProject.Models;

namespace EndpointImplementationProject.Services
{
    public static class ToyStorage
    {
        public static List<Toy> Toys { get; } = new List<Toy>
    {
        new Toy
        {
            ToyId = 0,
            ElementId = "element-0",
            UserId = "user-0",
            PictureId = "picture-0",
            Description = "description for toy 0"
        },
        new Toy
        {
            ToyId = 1,
            ElementId = "element-1",
            UserId = "user-0",
            PictureId = "picture-1",
            Description = "description for toy 1"
        },
        new Toy
        {
            ToyId = 2,
            ElementId = "element-0",
            UserId = "user-0",
            PictureId = "picture-2",
            Description = "description for toy 2"
        },
    };
    }
}
