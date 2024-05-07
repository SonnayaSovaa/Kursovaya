using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Interaction.Toolkit.AR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocalPipeRotate : MonoBehaviour
{
    
    public ActionBasedController controller_L;
    public ActionBasedController controller_R;
    static int rotated = 0;

    [SerializeField] AudioSource rot;
    public void OnTriggerStay(Collider other)
    {
        
        if ((other.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() ==1 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() ==1))
        {
           // Debug.Log("PIPE");
            if (rotated == 0)
            {

                this.gameObject.transform.localEulerAngles += new Vector3(0, 0, 90);
                rotated = 1;
                rot.Play();
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (controller_L.selectAction.action.ReadValue<float>() == 0 && controller_R.selectAction.action.ReadValue<float>() == 0)
            rotated = 0;        
    }


}