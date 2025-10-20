using Enums;
using UnityEngine;

namespace Encounters
{
    public abstract class Encounter : ScriptableObject
    {
        public string encounterName;
        public EEncounterTypes encounterType;
        public bool isCleared;

        public abstract void StartEncounter();
    }
}