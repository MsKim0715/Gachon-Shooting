using System.Collections;
using Data;
using Pooling;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private StageData stageData;
        [SerializeField] private StageData Stage_Data;
        private string[] _allStages;
        private GameManager _gm;
        private Coroutine _spawnCoroutine;
        private int _stageNum;

        private void Start()
        {
            Stage_Data = stageData.Clone() as StageData;
            _gm = GameManager.Instance;
            if (Stage_Data != null)
                _allStages = new[]
                {
                    Stage_Data.Stage1, Stage_Data.Stage2, Stage_Data.Stage3, Stage_Data.Stage4, Stage_Data.Stage5,
                    Stage_Data.Stage6, Stage_Data.Stage7, Stage_Data.Stage8, Stage_Data.Stage9, Stage_Data.Stage10
                };
            _stageNum = 0;
            StartCoroutine(CheckPlayerState());
        }

        private IEnumerator CheckPlayerState()
        {
            while (true)
            {
                if (_gm && _gm.IsPlayerLive())
                {
                    if (_spawnCoroutine == null) _spawnCoroutine = StartCoroutine(Spawn());
                }
                else
                {
                    if (_spawnCoroutine != null)
                    {
                        StopCoroutine(_spawnCoroutine);
                        _spawnCoroutine = null;
                    }
                }

                yield return new WaitForSeconds(1);
            }
        }


        private IEnumerator Spawn()
        {
            for (var i = 0; i < 4; i++)
            for (var j = 0; j < _allStages.Length; j++)
            {
                GameManager.Instance.stageNum = _stageNum++;
                Debug.Log("Stage : " + _stageNum);
                var obj = Pooler.Instance.GetObj(_allStages[j]);
                obj.transform.position = transform.position;
                if (GameManager.Instance.stageNum>= 40)
                {
                    Debug.Log("Clear");
                    StopAllCoroutines();
                }

                yield return new WaitForSeconds(Stage_Data.SpawnInterval);
            }
        }
    }
}