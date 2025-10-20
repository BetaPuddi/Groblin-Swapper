using System.Collections.Generic;
using Encounters;
using UnityEngine;

namespace Rooms
{
    [CreateAssetMenu(menuName = "Dungeon/New Room", order = 1, fileName = "NewRoom")]
    public class RoomBase : ScriptableObject
    {
        public string roomName;
        public List<Encounter> encounters;
        public bool isChainRoom;
    }
}