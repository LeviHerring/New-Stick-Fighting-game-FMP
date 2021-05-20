using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSelector : MonoBehaviour
{
    [SerializeField]
    public int numberPosPlayerOne = 3;

    [SerializeField]
    public int[] boundsPlayerOne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!(numberPosPlayerOne <= boundsPlayerOne[0]))
            {

                numberPosPlayerOne--;
                transform.position += new Vector3(-200, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!(numberPosPlayerOne >= boundsPlayerOne[1]))
            {
                numberPosPlayerOne++;
                transform.position += new Vector3(200, 0, 0);
            }
        }
    }
}
