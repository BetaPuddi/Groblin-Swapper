using System.Collections.Generic;
using UnityEngine;

namespace Encounters
{
    public class EncounterChain : Encounter
    {
        public List<Encounter> encounterList;
        public int encountersCleared;

        public override void StartEncounter()
        {
            encounterList = new List<Encounter>();
            SelectEncounter();
        }

        private void SelectEncounter()
        {
            for (int i = 0; i < encounterList.Count; i++)
            {
                encounterList[i].StartEncounter();
            }
        }
    }
}