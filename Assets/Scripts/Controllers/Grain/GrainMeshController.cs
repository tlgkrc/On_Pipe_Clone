using RayFire;
using Signals;
using UnityEngine;

namespace Controllers.Grain
{
    public class GrainMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables


        #endregion

        #region Private Variables
        

        #endregion

        #endregion

        public void ActivateDisjunction()
        {
            var rayFireRigid = gameObject.AddComponent<RayfireRigid>();
            rayFireRigid.simulationType = SimType.Dynamic;
            rayFireRigid.demolitionType = DemolitionType.Runtime;
            rayFireRigid.objectType = ObjectType.MeshRoot;
            rayFireRigid.physics.useGravity = true;
            rayFireRigid.Initialize();
            PlayerSignals.Instance.onActivatePlayerBomb?.Invoke();
        }
    }
}