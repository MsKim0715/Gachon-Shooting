using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerStat playerStat;
        [SerializeField] private Color color;
        [SerializeField] private Button button;
        public GameObject panel;
        private GameManager _gm;

        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }


        private void OnClick()
        {
            _gm = GameManager.Instance;
            _gm.SetPlayerData(playerStat, color);
            panel.SetActive(false);
        }
    }
}