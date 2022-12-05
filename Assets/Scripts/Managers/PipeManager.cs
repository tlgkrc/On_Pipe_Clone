using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PipeManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables

        [SerializeField] private PoolTypes grainType;
        [SerializeField] private ushort amountOfPeck;
        [SerializeField] private ushort sizeOfAPeck;
        

        #endregion

        #region Private Variables

        private const float _safeFactor = .75f;
        private float _pipeStartPos;
        private float _pipeFinishPos;
        private GrainGOData _grainGoData;

        #endregion

        #endregion

        private void Awake()
        {
            _grainGoData = GetGrainData();
            Init();
        }

        #region Event Supscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onSetPlayerPos += OnSetPlayerPos;
        }

        private void UnSubscribeEvents()
        {
            PlayerSignals.Instance.onSetPlayerPos -= OnSetPlayerPos;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        private void Start()
        {
            InitializePecks();
        }

        private void Init()
        {
            var transform1 = transform;
            var position = transform1.position;
            var localScale = transform1.localScale;
            _pipeStartPos = position.z - localScale.z;
            _pipeFinishPos = position.z + localScale.z;
        }

        private GrainGOData GetGrainData()
        {
            return Resources.Load<CD_Grain>("Data/CD_Grain").GrainData.GrainDatas[grainType];
        }

        private void OnSetPlayerPos(float playerPos)
        {
            if (playerPos >= _pipeStartPos && playerPos < _pipeFinishPos )
            {
                PlayerSignals.Instance.onGetNewPlayerScale?.Invoke(transform.localScale.y);
            }
        }

        private void InitializePecks()
        {
            if (_grainGoData.offSet*sizeOfAPeck * amountOfPeck < transform.localScale.z*2* _safeFactor)
            {
                for (ushort i = 0; i < amountOfPeck; i++)
                {
                    InitializeAPack(i);
                }
            }
            else
            {
                Debug.Log("You have to decrease peck count or size of a peck");
            }
        }

        private void InitializeAPack(ushort order)
        {
            for (int j = 0; j < sizeOfAPeck; j++)
            {
                var gO = PoolSignals.Instance.onGetPoolObject?.Invoke(grainType.ToString(), transform);
                var localScale = transform.localScale;
                gO.transform.localScale = localScale.x * Vector3.one;
                gO.transform.position = new Vector3(0, 0,
                    _pipeStartPos + (localScale.z / amountOfPeck) * ((order + 1) * 2 - 1) - 
                    ((sizeOfAPeck*_grainGoData.offSet)/2)+ j*_grainGoData.offSet*localScale.x);
            }
        }
    }
}