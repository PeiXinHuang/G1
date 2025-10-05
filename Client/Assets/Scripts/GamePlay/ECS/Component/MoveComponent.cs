public class MoveComponent : BaseComponent
{
    public float moveSpeed = 0.0f;
    public float moveValue = 10.0f;

    public bool isMoving = false;
    public bool isJumping = false;

    public int jumpMaxCount = 2; // �����Ծ����
    public int hasJumpCount = 0; // ����Ծ����
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