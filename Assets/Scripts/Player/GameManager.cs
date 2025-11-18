using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public float TimeToDestroy;
    public float currenTime;
    
    public PlayerInputs playerInputs;
    void Start()
    {
        
    }

    
    void Update()
    {
        currenTime += Time.deltaTime;     
        TestRestHealh();
    }

    public void TestRestHealh() 
    {  
        if(currenTime >=TimeToDestroy) 
        {
            playerInputs.PlayerHealth--;
            currenTime = 0;
        }
        
    }
    
}
