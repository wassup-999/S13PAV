using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float DetectSize = 0.1f;
    public float Distance = 0.1f;
    private bool isGrounded;
    

    public Transform FeetReference;

    void Start()
    {
        
    }

   
    void Update()
    {
        isGrounded = CheckIfGrounded();
    }

    public bool CheckIfGrounded()
    {
        Vector2 size = new Vector2(DetectSize, DetectSize);
        RaycastHit2D[] hitInfos=  Physics2D.BoxCastAll(FeetReference.transform.position, size,0,Vector2.down, Distance);

        foreach (var coll in hitInfos)
        {
            GameObject go = coll.collider.gameObject;
            if (go.tag == "Ground")
            {
                print(go.name);
                return true;
            }
        }
        
        return false;

    }       
    public bool IsGrounded => isGrounded;  
    
}
