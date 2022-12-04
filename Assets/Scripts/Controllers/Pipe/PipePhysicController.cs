using System;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers.Pipe
{
    public class PipePhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables

        [SerializeField] private PipeManager manager;

        #endregion

        #region Private Variables


        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
          
        }
    }
}