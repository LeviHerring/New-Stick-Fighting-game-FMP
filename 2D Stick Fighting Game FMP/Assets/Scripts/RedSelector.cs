using UnityEngine;

public class RedSelector : MonoBehaviour
{

    [SerializeField]
    public int numberPosPlayerTwo = 0;

    [SerializeField]
    public int[] boundsPlayerTwo; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
          
            if (!(numberPosPlayerTwo <= boundsPlayerTwo[0]))
            {

                numberPosPlayerTwo--;
                transform.position += new Vector3(-220, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!(numberPosPlayerTwo >= boundsPlayerTwo[1]))
            {
                numberPosPlayerTwo++;
                transform.position += new Vector3(220, 0, 0);
            }
            
            
            
        }
    }
}
