namespace MasujimaRyohei
{
    public enum PlayerMovementType
    {
        TouchPad,
        Both,
        Pointer
    }
    public class PLAYER
    {
        public const string SPEED = "PLAYER_SPEED_KEY"; // float 
        public const string MOVEMENT_TYPE = "PLAYER_MOVEMENT_TYPE_KEY"; // 0 = Touch, 1 = Both, 2 = Pointer
    }
}