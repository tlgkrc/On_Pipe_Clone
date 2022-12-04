using System;
using Enums;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers.Grain
{
    public class GrainPhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables

        [SerializeField] private GrainManager manager;
        
        #endregion

        #region Private Variables



        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                manager.ActivateMeshDisjunction();
                ScoreSignals.Instance.onUpdatePlayerScore?.Invoke();
                Invoke(nameof(SendPool), 1f);
            }
        }
        
        private void SendPool()
        {
            PoolSignals.Instance.onReleasePoolObject?.Invoke(PoolTypes.Corn.ToString(), manager.gameObject);
        }
    }
}