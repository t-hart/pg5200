using CardCreator.Interfaces;
using CardCreator.Model;
using JetBrains.Annotations;
using StringUtils;

namespace CardCreator.ViewModel
{
    public class Move : IMove
    {
        public IResettable Reset()
        {
            Name = string.Empty;
            Description = string.Empty;
            Damage.Reset();
    
            return this;
        }

        [NotNull] private string _name = "";

        public string Name
        {
            get => _name;
            set { if (value != _name) { _name = value.Truncate(Config.General.MaxMoveNameLength); } }
        }

        [NotNull] private string _description = "";
        public string Description
        {
            get => _description;
            set { if (value != _description) { _description = value.Truncate(Config.General.MaxMoveDescriptionLength); } }
        }

        public IStat Damage { get; set; }
        public Move(
            [NotNull] string name = "",
            [NotNull] string description = "",
            uint damage = 0
        )
        {
            Name = name;
            Description = description;
            Damage = new Stat.Damage(damage);
        }
    }
}
