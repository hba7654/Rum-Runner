using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public void Move(InputAction.CallbackContext context)
    public void Move(InputActionMap.actionTriggered context)
    {
        Debug.Log("Move!" + context);
    }
    /* public void Move()
     {
         //Debug.Log("Move!" + context);
         var kb = Keyboard.current;
         if()
     }*/
}