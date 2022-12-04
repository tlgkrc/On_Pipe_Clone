using RayFire;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ObstacleManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables

        [SerializeField] private RayfireBomb bomb;

        #endregion

        #region Private Variables


        #endregion

        #endregion

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onActivateImpactBomb += OnActivateBomb;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onActivateImpactBomb -= OnActivateBomb;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnActivateBomb()
        {
            bomb.StartExplosion();
        }
    }
}