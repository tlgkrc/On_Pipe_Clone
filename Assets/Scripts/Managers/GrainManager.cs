using Controllers.Grain;
using UnityEngine;

namespace Managers
{
    public class GrainManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables

        [SerializeField] private GrainMeshController meshController;
        [SerializeField] private GrainPhysicController physicController;

        #endregion

        #region Private Variables
        
        

        #endregion

        #endregion

        public void ActivateMeshDisjunction()
        {
            meshController.ActivateDisjunction();
        }
    }
}