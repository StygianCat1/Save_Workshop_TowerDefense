using UnityEngine;

public class DodgeBullet_Behavior : MonoBehaviour
{
    [SerializeField] public int dodgeTBD;
    
    private int _isDodging;
    

    // Update is called once per frame
    void Update()
    {
        _isDodging = Random.Range(0, dodgeTBD);
        DodgeBullet();
    }

    
    void DodgeBullet()
    {
        if (_isDodging == 0)
        {
            print("dodge");
        }
        else
        {
            print("hit");
        }
        
    }
}
