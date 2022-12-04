using RayFire;
using Signals;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        #region Self Variables

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
            rayFireRigid.physics.useGravity = false;
            rayFireRigid.Initialize();
            PlayerSignals.Instance.onActivateImpactBomb?.Invoke();
            Invoke(nameof(InvokeFail), 1f);
        }

        private void InvokeFail()
        {
            CoreGameSignals.Instance.onLevelFailed?.Invoke();
        }
    }
}