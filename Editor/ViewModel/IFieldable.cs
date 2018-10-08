using JetBrains.Annotations;

namespace Editor.ViewModel
{
    public interface IFieldable
    {
        uint HP { get; set; }
        string Title { get; set; }
        [CanBeNull] string ImageUrl { get; set; }
    }
}
