using System;
using UnityEngine;

namespace Assets.Scripts.CottonGarden
{
    public class Growth : MonoBehaviour
    {
        [SerializeField] private GameObject _cotton;

        public event Action Grew;
        public event Action Harvested;

        public void GrowCotton()
        {
            _cotton.SetActive(true);
            Grew?.Invoke();
        }

        public void HarvestCotton()
        {
            _cotton.SetActive(false);
            Harvested?.Invoke();
        }
    }
}
