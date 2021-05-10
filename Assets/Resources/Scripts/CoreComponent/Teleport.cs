using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public LayerMask TeleportableGround;
    Vector2 charDimension;
    float TPDownCheckDistance = 4;
    float BoxCheckSideDistance;
    Animator anim;

    void Start()
    {
        charDimension = GetComponent<CircleCollider2D>().bounds.size;
        anim = GetComponent<Animator>();
        BoxCheckSideDistance = charDimension.x * 0.25f;
    }

    bool CheckIfAlreadyPlaying()//RISCRIVERE GENERALE PER TUTTI
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.IsName("vanishanddeathanimation") || info.IsName("appearAnimation");
    }

    public void PerformTeleport(out Vector2 position2Spawn)
    {
        position2Spawn = Vector2.zero;

        if (CheckCollisionWithObstacles(MousePositionConverter(), out position2Spawn))
        {
            if (!CheckIfAlreadyPlaying())
                anim.SetTrigger("Teleport");
        }
    }
    /// <summary>
    /// Teleport Check Collision
    /// </summary>
    /// <param name="position"></param>
    /// <param name="SpawnPoint"></param>
    /// <returns></returns>
    public bool CheckCollisionWithObstacles(Vector2 position, out Vector2 SpawnPoint)
    {
        RaycastHit2D hitPoint = FindPlatformToTeleport(position);
        Debug.LogWarning("FUNZIONA QUASI PERFETTAMENTE");

        //FIRST DRAW A RAY CHECKING FIRST OBSTACLES ("GROUND")
        SpawnPoint = Vector2.zero;
        if (hitPoint)
        {

            //I FOUND A PLATFORM, NOW I NEED TO CHECK IF THERE IS ENOUGH SPACE TO SPAWN THE PLAYER
            Vector2 BoxCheckPosition = new Vector2(hitPoint.point.x, hitPoint.point.y + .05f + charDimension.y * 0.5f);

            //FIRST BOX CHECK(HALF CHAR DIM ON X)
            RaycastHit2D rightBox = Physics2D.BoxCast(BoxCheckPosition + new Vector2(charDimension.x * .25f, 0), charDimension /** .5f*/, 0, Vector2.right, BoxCheckSideDistance, TeleportableGround);
            RaycastHit2D leftBox = Physics2D.BoxCast(BoxCheckPosition - new Vector2(charDimension.x * .25f, 0), charDimension /** .5f*/, 0, Vector2.left, BoxCheckSideDistance, TeleportableGround);

            if (rightBox && leftBox)
            {

                float topRightColliderPosition = (rightBox.collider.bounds.size.y * 0.5f) + rightBox.transform.position.y;
                float topLeftColliderPosition = (leftBox.collider.bounds.size.y * 0.5f) + leftBox.transform.position.y;

                float highestColliderPosition = (topRightColliderPosition > topLeftColliderPosition) ? topRightColliderPosition : topLeftColliderPosition;
                float lowestColliderPosition = (topRightColliderPosition < topLeftColliderPosition) ? topRightColliderPosition : topLeftColliderPosition;
                float yToUse = highestColliderPosition < position.y ? highestColliderPosition : (lowestColliderPosition < position.y ? lowestColliderPosition : 0);

                if (yToUse == 0)
                    return false;


                //NEXT ATTEMPT A BIT HIGHER
                RaycastHit2D secondRightBoxCheck = Physics2D.BoxCast(new Vector2(BoxCheckPosition.x, yToUse + 0.01f) + new Vector2(charDimension.x * .5f, charDimension.y * .5f), charDimension, 0, Vector2.right, BoxCheckSideDistance, TeleportableGround);
                RaycastHit2D secondLeftBoxCheck = Physics2D.BoxCast(new Vector2(BoxCheckPosition.x, yToUse + 0.01f) + new Vector2(-charDimension.x * .5f, charDimension.y * .5f), charDimension, 0, Vector2.left, BoxCheckSideDistance, TeleportableGround);

                if (secondRightBoxCheck && secondLeftBoxCheck)
                    return false;

                if (!secondRightBoxCheck)
                {
                    SpawnPoint = new Vector2(BoxCheckPosition.x, yToUse) + new Vector2(charDimension.x * .5f, 0) - new Vector2(0, .05f);
                    return true;
                }
                else
                {
                    SpawnPoint = new Vector2(BoxCheckPosition.x, yToUse) + new Vector2(charDimension.x * .5f, 0) - new Vector2(0, .05f);
                    return true;
                }
            }
            else
            {
                SpawnPoint = hitPoint.point - new Vector2(0, .05f);
                return true;
            }

        }
        return false;
    }
    /// <summary>
    /// Find the first platform available below the cursor to teleport
    /// </summary>
    /// <param name="position"></param>
    private RaycastHit2D FindPlatformToTeleport(Vector2 position)
    {
        return Physics2D.Raycast(position, Vector2.down, TPDownCheckDistance, TeleportableGround);
    }

    public Vector2 MousePositionConverter()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
