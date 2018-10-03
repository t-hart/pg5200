using JetBrains.Annotations;

namespace Editor.ViewModel
{
    interface IFieldable
    {
        uint HP { get; set; }
        string Title { get; set; }
        [CanBeNull] string ImageUrl { get; set; }
    }
}
