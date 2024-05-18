using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    string scene;

    PipeRotate rot;
    MagicCube cube;



    void Start()
    {
        scene=SceneManager.GetActiveScene().name;

        if (scene =="Steam_Lab") rot=FindObjectOfType<PipeRotate>();
        else cube = FindObjectOfType<MagicCube>();
    }

    
    void Update()
    {
       if (this.gameObject.GetNamedChild("[For_key] Dynamic Attach") != null)
        {
            if (scene == "Steam_Lab") rot.Win(rot.keyscore);
            else cube.Win(cube.keyscore);

            Destroy(this.gameObject);
        } 
    }
}
