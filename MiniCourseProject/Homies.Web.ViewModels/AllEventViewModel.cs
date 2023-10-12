namespace Homies.Web.ViewModels
{
    public class AllEventViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
