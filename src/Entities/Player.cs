namespace theCaspianSeaMonster.Entities;

public enum Facing
{
    Left,
    Right,
    Strate,
}

public enum State
{
    Idle,
}

public class Player
{
    public Facing Facing { get; set; } = Facing.Right;
    public State State { get; set; }
    //public bool IsAttacking => State == State.Kicking || State == State.Punching;
    //public bool CanJump => State == State.Idle || State == State.Walking;
}
