using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Spawn Data", menuName = "Scriptable Object/Spawn Data")]
    public class StageData : ScriptableObject
    {
        [SerializeField] private float spawnInterval;

        [SerializeField] private string stage1;

        [SerializeField] private string stage2;

        [SerializeField] private string stage3;

        [SerializeField] private string stage4;

        [SerializeField] private string stage5;

        [SerializeField] private string stage6;

        [SerializeField] private string stage7;

        [SerializeField] private string stage8;

        [SerializeField] private string stage9;

        [SerializeField] private string stage10;

        public float SpawnInterval
        {
            get => spawnInterval;
            set => spawnInterval = value;
        }

        public string Stage1
        {
            get => stage1;
            set => stage1 = value;
        }

        public string Stage2
        {
            get => stage2;
            set => stage2 = value;
        }

        public string Stage3
        {
            get => stage3;
            set => stage3 = value;
        }

        public string Stage4
        {
            get => stage4;
            set => stage4 = value;
        }

        public string Stage5
        {
            get => stage5;
            set => stage5 = value;
        }

        public string Stage6
        {
            get => stage6;
            set => stage6 = value;
        }

        public string Stage7
        {
            get => stage7;
            set => stage7 = value;
        }

        public string Stage8
        {
            get => stage8;
            set => stage8 = value;
        }

        public string Stage9
        {
            get => stage9;
            set => stage9 = value;
        }

        public string Stage10
        {
            get => stage10;
            set => stage10 = value;
        }

        public object Clone()
        {
            return Instantiate(this);
        }
    }
}