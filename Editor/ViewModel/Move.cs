using System.Collections.Generic;
using System.Linq;
using Editor.CardProperties;
using Editor.Interfaces;
using JetBrains.Annotations;
using StringUtils;

namespace Editor.ViewModel
{
    public class Move : IMove
    {
        public IResettable Reset()
        {
            throw new System.NotImplementedException();
        }

        [NotNull] private string _name = "";

        public string Name
        {
            get => _name;
            set { if (value != _name) { _name = value.Truncate(Config.MaxMoveNameLength); } }
        }

        [NotNull] private string _description = "";
        public string Description
        {
            get => _description;
            set { if (value != _description) { _description = value.Truncate(Config.MaxMoveDescriptionLength); } }
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
            Damage = Stat.Damage(damage);
        }
    }
}
