using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (BoxCollider2D))]
public class ControllerPlayer2D : MonoBehaviour
{
    public LayerMask collisionMask;
    const float skinwidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    BoxCollider2D collider;
    RaycastOrigins raycastorigins;


    // Start is called before the first frame update
    void Start()
    {
        
        collider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    // Update is called once per frame
    

    public void Move(Vector3 velocity)
    {
        UpdateRayCastOrigins();

        VerticalCollisions(ref velocity);

        transform.Translate(velocity);
     

        
    }

    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinwidth;
        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastorigins.bottomLeft : raycastorigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
            Debug.DrawRay(raycastorigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2, Color.red);

            if (hit)
            {
                velocity.y = ( hit.distance - skinwidth) * directionY;
                rayLength = hit.distance;
            }
        }
    }
    void UpdateRayCastOrigins ()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinwidth * -2);

        raycastorigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastorigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastorigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastorigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinwidth * -2);

        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }
    struct RaycastOrigins 
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
   
}
