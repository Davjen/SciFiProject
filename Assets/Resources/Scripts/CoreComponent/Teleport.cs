using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public LayerMask TeleportableGround;
    Vector2 charDimension;
    float TPDownCheckDistance;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        charDimension = GetComponent<CircleCollider2D>().bounds.size;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public bool PerformTeleport(out Vector2 position2Spawn)
    {
        position2Spawn = Vector2.zero;
        
        if (CheckCollisionWithObstacles(MousePositionConverter(), out position2Spawn))
        {
            anim.SetTrigger("Teleport");//TO DO FARE UN CONTROLLER RIGUARDO L'ANIMAZIONE per non farla + volte
       
            return true;
        }
        return false;
    }
    public bool CheckCollisionWithObstacles(Vector2 position, out Vector2 SpawnPoint)
    {
        RaycastHit2D hitPoint = FindPlatformToTeleport(position);

        //FIRST DRAW A RAY CHECKING FIRST OBSTACLES ("GROUND")
        SpawnPoint = Vector2.zero;
        if (hitPoint)
        {
            //I FOUND A PLATFORM, NOW I NEED TO CHECK IF THERE IS ENOUGH SPACE TO SPAWN THE PLAYER
            Vector2 BoxCheckPosition = new Vector2(hitPoint.point.x, hitPoint.point.y - .05f - charDimension.y * 0.5f);
            //FIRST BOX CHECK(HALF CHAR DIM ON X)
            RaycastHit2D rightBox = Physics2D.BoxCast(BoxCheckPosition + new Vector2(charDimension.x * .25f, 0), charDimension * .5f, 0, Vector2.right);
            RaycastHit2D leftBox = Physics2D.BoxCast(BoxCheckPosition - new Vector2(charDimension.x * .25f, 0), charDimension * .5f, 0, Vector2.left);
            if (rightBox && leftBox)
            {
                float topRightColliderPosition = (rightBox.collider.bounds.size.y * 0.5f) + rightBox.transform.position.y;
                float topLeftColliderPosition = (leftBox.collider.bounds.size.y * 0.5f) + rightBox.transform.position.y;

                float highestColliderPosition = (topRightColliderPosition > topLeftColliderPosition) ? topRightColliderPosition : topLeftColliderPosition;
                float lowestColliderPosition = (topRightColliderPosition < topLeftColliderPosition) ? topRightColliderPosition : topLeftColliderPosition;
                float yToUse = highestColliderPosition < position.y ? highestColliderPosition : (lowestColliderPosition < position.y ? lowestColliderPosition : 0);
                if (yToUse == 0)
                    return false;

                RaycastHit2D secondRightBoxCheck = Physics2D.BoxCast(new Vector2(BoxCheckPosition.x, yToUse) + new Vector2(charDimension.x * .5f, 0), charDimension, 0, Vector2.right);
                RaycastHit2D secondLeftBoxCheck = Physics2D.BoxCast(new Vector2(BoxCheckPosition.x, yToUse) + new Vector2(charDimension.x * .5f, 0), charDimension, 0, Vector2.left);
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
