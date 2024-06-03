using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] public TMP_Text description;
    [SerializeField] public TMP_Text rank;
    [SerializeField] public TMP_Text uron;

    public int real_uron=0;

    public GameObject[] weapons;

    public CurrentWeapon curr;

    Transform TheWeapon;

    [SerializeField] GameObject igrok;

    //Transform[] allWeap;   

    public bool weap;

    [SerializeField] Player player;

    MusicVolume forWeapMass;


    [SerializeField] PlayerImput L_trig;
    [SerializeField] PlayerImput R_trig;

    private void Start()
    {
        forWeapMass = FindObjectOfType<MusicVolume>();


        //GameObject[] we = forWeapMass.real_weapons;


        GameObject[] we = forWeapMass.real_weapons;


        if (SceneManager.GetActiveScene().name != "Start") weapons = new GameObject[35];
        else
            if (PlayerPrefs.GetInt("PipeRotat") + PlayerPrefs.GetInt("MagicCube") > 0) weapons = new GameObject[4];
        else weapons = new GameObject[3];

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = we[i];
        }
        if (SceneManager.GetActiveScene().name != "Start" && GetComponent<CurrentWeapon>() != null) weapons[weapons.Length - 1] = FindObjectOfType<CurrentWeapon>().gameObject;
        /*
        int j = 0;
        for (int i = allWeap.Length - 1; i >= 0; i--)
        {
            if (allWeap[i]!=null && allWeap[i].gameObject.name.Contains("W_"))
            {
                weapons[j] = allWeap[i].gameObject;
                j++;
            }
        }
        */

    }

    public void InHand()
    {
        //if ((0 < L_trig.tagg && L_trig.tagg < 37) || (0 < R_trig.tagg && R_trig.tagg < 37))
        //{

            //if (TagDetecter.hoverTag < 37)
            //{
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] != null && (weapons[i].GetNamedChild("[Right Controller] Dynamic Attach") || weapons[i].GetNamedChild("[Left Controller] Dynamic Attach")))
                {
                    Debug.Log("INHAND");
                    weap = true;
                    int currUr = What(int.Parse(weapons[i].tag));
                    if (weapons[i].GetComponent<CurrentWeapon>() == null) curr = weapons[i].AddComponent<CurrentWeapon>();
                    curr.currentUron = currUr;
                    //weapons[i].transform.parent = igrok.transform;

                }
                else
                   if (weapons[i] != null) (weapons[i].GetComponent("TheWeapon") as MonoBehaviour).enabled = false;
            }
            //}
        //}
    }

    int What(int cur_tag)
    {

        switch (cur_tag)
        {
            case 0:
                description.text = "Довольно обычная крепкая булава.";
                rank.text = "2";
                real_uron = 16;
                break;
            case 1:
                description.text = "Простое аккуратное копьё. Ничего необычного.";
                rank.text = "2";
                real_uron = 13;
                break;
            case 2:
                description.text = "Копьё, пропитанное слабой тёмной магией.";
                rank.text = "3";
                real_uron = 21;
                break;
            case 3:
                description.text = "Магическо ядовитое копьё. Строго воспрещено использовать в пищу.";
                rank.text = "4";
                real_uron = 36;
                break;
            case 4:
                description.text = "Зачарованный меч рака. Нет, это не намёк.";
                rank.text = "4";
                real_uron = 39;
                break;
            case 5:
                description.text = "Неотёсанный меч космического мага. Он слишком много витал в облаках, что в конце концов покинул атмосферу...";
                rank.text = "3";
                real_uron = 26;
                break;
            case 6:
                description.text = "Загадочное копьё глубин. Бывало на дне.";
                rank.text = "4";
                real_uron = 33;
                break;
            case 7:
                description.text = "Неотёсанный меч светлого монаха. Со временем потемнеет.";
                rank.text = "3";
                real_uron = 27;
                break;
            case 8:
                description.text = "Костяная дубина лича. У него и отобрали.";
                rank.text = "6";
                real_uron = 59;
                break;
            case 9:
                description.text = "Меч гоблина-некроманта. Он не смог спасти некроманта от смерти. Какая ирония.";
                rank.text = "5";
                real_uron = 43;
                break;
            case 10:
                description.text = "Меч гоблина Огненных Долин. Возможно, что-то подгорит.";
                rank.text = "5";
                real_uron = 42;
                break;
            case 11:
                description.text = "Рубило 'Монолит'. Нет, желания не исполняет.";
                rank.text = "6";
                real_uron = 56;
                break;
            case 12:
                description.text = "Поднятый с глубин меч Атлантиды.";
                rank.text = "3";
                real_uron = 20;
                break;
            case 13:
                description.text = "Разочарованный меч тьмы. мы не знаем, чем он разочарован.";
                rank.text = "6";
                real_uron = 53;
                break;
            case 14:
                description.text = "Меч драконьего дыхания. Слегка пахнет гнильню и сажей.";
                rank.text = "6";
                real_uron = 58;
                break;
            case 15:
                description.text = "Паровая колотушка. Порхает, как бабочка, бьёт, как шершень.";
                rank.text = "6";
                real_uron = 60;
                break;
            case 16:
                description.text = "Меч ледяного краба. Замёрз, бедняга.";
                rank.text = "4";
                real_uron = 37;
                break;
            case 17:
                description.text = "Резак спрутов-киборгов. И этим всё сказано.";
                rank.text = "3";
                real_uron = 26;
                break;
            case 18:
                description.text = "Лунный факел Олимпа. Освещает путь (нет).";
                rank.text = "3";
                real_uron = 22;
                break;
            case 19:
                description.text = "Прямой резак тёмного утра.";
                rank.text = "2";
                real_uron = 14;
                break;
            case 20:
                description.text = "Прямой резак сетлого вечера.";
                rank.text = "3";
                real_uron = 28;
                break;
            case 21:
                description.text = "Древний меч Замёрзшего океана.";
                rank.text = "5";
                real_uron = 42;
                break;
            case 22:
                description.text = "Неожиданно простой боевой топор. Хотя бы острый.";
                rank.text = "2";
                real_uron = 16;
                break;
            case 23:
                description.text = "Топор Прожигающего Света (прожигает время).";
                rank.text = "4";
                real_uron = 39;
                break;
            case 24:
                description.text = "Качественный топор. Добротно, надёжно, хорошо.";
                rank.text = "3";
                real_uron = 21;
                break;
            case 25:
                description.text = "Секира простака. Теперь ваша.";
                rank.text = "3";
                real_uron = 25;
                break;
            case 26:
                description.text = "Секира пламенных чар. Смотрите, чтобы не подгорела.";
                rank.text = "5";
                real_uron = 46;
                break;
            case 27:
                description.text = "Секира редкого металла. А может, и не очень.";
                rank.text = "4";
                real_uron = 33;
                break;
            case 28:
                description.text = "Посох заклинателя ядов (или просто токсика).";
                rank.text = "6";
                real_uron = 51;
                break;
            case 29:
                description.text = "Потухшая волшебная палочка. Теперь просто колотушка.";
                rank.text = "2";
                real_uron = 17;
                break;
            case 30:
                description.text = "Палочка 'Глаз дракона'. Наличие частей дракона не гарантируется.";
                rank.text = "3";
                real_uron = 24;
                break;
            case 31:
                description.text = "Тюремный молот Печи. Мы не знаем, за что его посадили.";
                rank.text = "4";
                real_uron = 38;
                break;
            case 32:
                description.text = "Увесистый молот Печи. Иногда худеет к лету.";
                rank.text = "5";
                real_uron = 43;
                break;
            case 33:
                description.text = "Каменно-энергетический молот Печи. Кофеин, таурин и вольфрам.";
                rank.text = "6";
                real_uron = 55;
                break;
            case 34:
                description.text = "Кирка Начала Турнира. Пусть победит сильнейший!";
                rank.text = "1";
                real_uron = 7;
                break;
            case 35:
                description.text = "Вилы Начала Турнира. Да прибудет с вами удача!";
                rank.text = "1";
                real_uron = 7;
                break;
            case 36:
                description.text = "Лопата Начала Турнира. Вперёд и с песней!";
                rank.text = "1";
                real_uron = 7;
                break;
        }
        uron.text = "" + real_uron;
        //PlayerPrefs.SetInt("Uron", real_uron);
        return real_uron;
    }
           
        
    

    public void OutHand()
    {
        TheWeapon = FindObjectOfType<Weap_Detecter>().gameObject.transform;

        description.text = "Что ж, всего лишь ваши руки.";
        rank.text = "0";
        uron.text = "0";
        real_uron = 0;

        weap = false;


        //allWeap = TheWeapon.GetComponentsInChildren<Transform>();

        /*
         int j = 0;
         for (int i = allWeap.Length - 1; i >= 0; i--)
         {
             if (allWeap[i].gameObject.name.Contains("W_"))
             {
                 weapons[j] = allWeap[i].gameObject;
                 j++;
             }
         }
        */


        //Debug.Log("Count   " + count);
        //TheWeapon = FindObjectOfType<Weap_Detecter>().gameObject.transform;

        //allWeap = TheWeapon.GetComponentsInChildren<Transform>();
        forWeapMass = FindObjectOfType<MusicVolume>();

        GameObject[] we = forWeapMass.real_weapons;


        if (SceneManager.GetActiveScene().name != "Start") weapons = new GameObject[35];
        else
            if (PlayerPrefs.GetInt("PipeRotat")+ PlayerPrefs.GetInt("MagicCube")>0) weapons = new GameObject[4];
            else weapons = new GameObject[3];

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = we[i];
        }
        if (SceneManager.GetActiveScene().name != "Start" && GetComponent<CurrentWeapon>() != null && weapons[weapons.Length - 1] == null) weapons[weapons.Length - 1] = FindObjectOfType<CurrentWeapon>().gameObject;
        /*

        if (FindObjectOfType<CurrentWeapon>() != null)
        {
            int pos = 0;
            foreach (var t in weapons)
            {
                pos++;
                if (t == null)
                {
                    weapons[pos] = FindObjectOfType<CurrentWeapon>().gameObject;
                    break;
                }
            }

            curr.currentUron = 0;
        }
        
        else if (SceneManager.GetActiveScene().name == "Start" && FindObjectOfType<CurrentWeapon>().gameObject != null)
        {
            int pos = 0;
            foreach (var t in weapons)
            {
                pos++;
                if (t==null)
                {
                    weapons[pos]= FindObjectOfType<CurrentWeapon>().gameObject;
                    break;
                }
            }


            curr.currentUron = 0;
        }*/

        foreach (var k in weapons)
        {
            if (k != null)
            {
                (k.GetComponent("TheWeapon") as MonoBehaviour).enabled = true;
                if (k.GetComponent<CurrentWeapon>() != null)
                {
                    k.transform.parent = TheWeapon;
                    Destroy(k.GetComponent<CurrentWeapon>());
                }
            }
        }

        



    } 



}
