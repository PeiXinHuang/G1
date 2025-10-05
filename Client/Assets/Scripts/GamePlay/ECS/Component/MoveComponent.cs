public class MoveComponent : BaseComponent
{
    public float moveSpeed = 0.0f;
    public float moveValue = 10.0f;

    public bool isMoving = false;
    public bool isJumping = false;

    public int jumpMaxCount = 2; // 最大跳跃次数
    public int hasJumpCount = 0; // 已跳跃次数
    public float upSpeed = 0.0f;
    public float jumpValue = 7.0f;

    public void SetJump(bool isJump)
    {
        if (isJump && hasJumpCount < jumpMaxCount)
        {
            upSpeed = jumpValue;
            hasJumpCount++;
            isJumping = true;
        }
        else if (!isJump)
        {
            isJumping = false;
            hasJumpCount = 0;
        }
    }
}