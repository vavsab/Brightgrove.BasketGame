using Brightgrove.BasketGame.Players.Base;
using System;
using System.Xml.Serialization;

namespace Brightgrove.BasketGame.Game.Config
{
    [Serializable]
    public class PlayerConfig
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public PlayerType Type { get; set; }
    }
}
