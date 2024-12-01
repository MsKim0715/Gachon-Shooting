using CollisionEvent;
using Data;
using InputData;
using Move;
using UnityEngine;
using UseShooter = Shooter.Shooter; // Shooter 네임스페이스 안에 있는 Shooter 추상화 클래스

namespace Player
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        [SerializeField] private Movement movement;
        [SerializeField] private BaseInput input;
        [SerializeField] private UseShooter shooter;
        [SerializeField] private PlayerStat playerStat;
        public PlayerStat Player_Stat;
        private GameManager _gm;
        private Vector2 _inputData;
        private SpriteRenderer _playerColor;
        private IDie _playerDie;
        private Color _setColor;


        private void Start()
        {
            movement = GetComponent<Movement>();
            input = GetComponent<BaseInput>();
            shooter = GetComponent<UseShooter>();
            _playerDie = GetComponent<IDie>();
            _playerColor = GetComponent<SpriteRenderer>();
            Player_Stat = playerStat.Clone() as PlayerStat;
            _playerColor.color = _setColor;
        }

        private void Update()
        {
            _inputData = input.GetMoveInput();
            shooter.Shoot(Player_Stat.ShootDelay, Player_Stat.IsShoot);
            movement.Move(_inputData, Player_Stat.PlayerSpeed);
            _playerDie.Die(Player_Stat.HP);
        }

        private void OnEnable()
        {
            _gm = GameManager.Instance;
            _gm.onDataReceived.AddListener(SetData);
            _gm.SetPlayerLive(true);
        }

        private void OnDisable()
        {
            _gm.onDataReceived.RemoveListener(SetData);
            _gm.SetPlayerLive(false);
        }

        public void Damage(float damage)
        {
            Player_Stat.HP -= damage;
        }

        private void SetData(PlayerStat playerStat, Color color)
        {
            this.playerStat = playerStat;
            _setColor = color;
        }
    }
}