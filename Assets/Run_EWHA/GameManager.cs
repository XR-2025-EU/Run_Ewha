using UnityEngine;


public class GameManager : MonoBehaviour
{
    public int currentState = 0; // 0부터 4까지

    public void AdvanceState()
    {
        currentState++;
        Debug.Log("Now moving to state: " + currentState);
    }
}
