using Assets.Scripts.CottonGarden;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Triggers
{
    public class HarvestTrigger : Trigger<Harvest>
    {
        [SerializeField] private Health _gardenHealth;

        protected override void OnEnter(Harvest triggered)
        {                    
            triggered.StartCoroutine(triggered.HarvestCotton(_gardenHealth));                     
        }

        protected override void OnStay(Harvest triggered)
        {
            if(_gardenHealth.IsHarvested)
            {
                triggered.StopAllCoroutines();
            }
        }

        protected override void OnExit(Harvest triggered)
        {
            triggered.StopAllCoroutines();
        }
    }
}
