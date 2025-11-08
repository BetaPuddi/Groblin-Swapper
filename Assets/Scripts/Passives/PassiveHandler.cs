using System.Collections.Generic;
using System.Linq;
using Character;
using Enums;
using Equipment;
using Managers;
using UnityEngine;

namespace Passives
{
    public class PassiveHandler : MonoBehaviour
    {
        public List<PassiveBase> listOfCharacterPassives;

        public void TriggerPassives(int executionInt)
        {
            var executionOrder = executionInt switch
            {
                0 => EExecutionOrder.PlayerBeforeTurn,
                1 => EExecutionOrder.PlayerBeforeAction,
                2 => EExecutionOrder.PlayerAfterAction,
                3 => EExecutionOrder.EnemyBeforeTurn,
                4 => EExecutionOrder.EnemyBeforeAction,
                5 => EExecutionOrder.EnemyAfterAction,
                _ => EExecutionOrder.PlayerBeforeTurn
            };

            foreach (var passive in listOfCharacterPassives.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
            {
                passive.TriggerEffect();
            }

            CharacterInventory inv = null;

            if (GetComponent<CharacterBase>().characterInventory != null)
            {
                inv = GetComponent<CharacterBase>().characterInventory;
            }

            if (inv != null)
            {
                if (inv.headSlot != null)
                {
                    foreach (var passive in inv.headSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect();
                    }
                }

                if (inv.chestSlot != null)
                {
                    foreach (var passive in inv.chestSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect();
                    }
                }

                if (inv.legSlot != null)
                {
                    foreach (var passive in inv.legSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect();
                    }
                }

                if (inv.armSlot != null)
                {
                    foreach (var passive in inv.armSlot.passiveEffects.Where(passive => passive.isTriggeredEffect && passive.executionOrder == executionOrder))
                    {
                        passive.TriggerEffect();
                    }
                }
            }
        }
    }
}