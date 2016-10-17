namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    public enum PlayerMovementType
    {
        TouchPad,
        Both,
        Pointer
    }
    public class GameData : MonoBehaviour
    {
        private PlayerMovementType _playerMovementType;
        private float _playerSpeed;

        public void SetPlayerMovementType(PlayerMovementType type)
        {
            _playerMovementType = type;
            SaveData.SetInt(PLAYER.MOVEMENT_TYPE, (int)type);
        }
        public PlayerMovementType GetPlayerMovementType()
        {
            return _playerMovementType;
        }
        public void SetPlayerSpeed(float speed)
        {
            _playerSpeed = speed;
        }
        public float GetPlayerSpeed()
        {
            return _playerSpeed;
        }
    }
}