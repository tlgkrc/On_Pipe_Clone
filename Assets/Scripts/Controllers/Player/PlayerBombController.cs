using Managers;
using RayFire;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerBombController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private RayfireBomb bomb;
        
        #endregion

        #endregion
        
        public void ActivateBomb()
        {
            bomb.StartExplosion();
        }
    }
}