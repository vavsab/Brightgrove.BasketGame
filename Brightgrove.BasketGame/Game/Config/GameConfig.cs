using System;
using System.Collections.Generic;

namespace Brightgrove.BasketGame.Game.Config
{
    [Serializable]
    public class GameConfig
    {
        public List<PlayerConfig> Players { get; } = new List<PlayerConfig>();
    }
}
