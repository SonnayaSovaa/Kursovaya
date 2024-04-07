using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Chest_Open : MonoBehaviour
{

    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Chest TRIG");
        if (other.tag=="Left" && controller_L.selectAction.action.ReadValue<float>() > 0 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() > 0)
        {
            Debug.Log("Chestttttt");
            if (this.gameObject.transform.rotation.z==0)
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
            else
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }



}
