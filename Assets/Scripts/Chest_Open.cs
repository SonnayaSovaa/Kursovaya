using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Chest_Open : MonoBehaviour
{

    public ActionBasedController controller_L;
    public ActionBasedController controller_R;
    static int rotated = 0;
    public int Os_x = 0;
    public int Os_y = 0;
    public int Os_z = 0;

    [SerializeField] AudioSource audio;


    public void OnTriggerStay(Collider other)
    {

        if ((other.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() == 1 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() == 1))
        {
            if ((rotated == 0) && this.gameObject.transform.rotation.z == 0)
            {
                audio.Play();
                this.gameObject.transform.localEulerAngles = new Vector3(Os_x*270, Os_y * 270, Os_z*270);
                rotated = 1;
                Debug.Log("Rot" + rotated);

                GameObject THEchest = this.transform.parent.gameObject;
                Transform[] comps = THEchest.GetComponentsInChildren<Transform>();
                Debug.Log("___"+comps[0]+ "___"+comps[1] + "__" + comps[2] + "__" + comps[3]);

                foreach (Transform comp in comps)
                {
                    if (comp.name == "reinforced_wooden_chest_base" || comp.name=="Korpus")
                    {
                        Transform[] items = comp.GetComponentsInChildren<Transform>();
                        Debug.Log("IT  "+items.Length);
                        foreach (Transform i in items)
                        {
                            string Tag = i.tag;
                            Debug.Log("TAGGGAGGA  " + i.name);

                            if (Tag.Contains("1") || i.tag.Contains("2") || i.tag.Contains("3") || i.tag.Contains("4") || i.tag.Contains("5") || i.tag.Contains("6") || i.tag.Contains("7") || i.tag.Contains("8") || i.tag.Contains("9") || i.tag.Contains("0"))
                            {
                                i.gameObject.transform.localScale = new Vector3(i.gameObject.transform.localScale.x * 100f, i.gameObject.transform.localScale.y*100f, i.gameObject.transform.localScale.z * 100f);
                                i.parent = null;

                                Rigidbody ri = i.GetComponent<Rigidbody>();
                                ri.AddForce(Vector3.up*70);
                            }
                        }
                        break;
                    }
                    
                }

            }

            else
            {

                if ((rotated == 0) && (this.gameObject.transform.localEulerAngles.z == 270|| this.gameObject.transform.localEulerAngles.y == 270|| this.gameObject.transform.localEulerAngles.x == 270))
                {
                    audio.Play();
                    this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                    rotated = 1;
                    Debug.Log("Rot" + rotated);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        rotated = 0;
        Debug.Log("Rot" + rotated);
    }

}

