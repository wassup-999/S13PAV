using UnityEngine;


[RequireComponent (typeof(PlayerInputs))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public PlayerInputs InputManager;
    public PlayerMovement playerMovement;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        InputManager = GetComponent<PlayerInputs>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Start()
    {
       // InputManager = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
