using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatsLVL : MonoBehaviour
{
    public int HpLVL { get; set; }
    public int MDefLVL { get; set; }
    public int PDefLVL { get; set; }
    public int MAtackLVL { get; set; }
    public int PAtackLVL { get; set; }


    private void Awake()
    {
        LoadStatsLVL();
    }
    void Start()
    {
       
    }

    public void LoadStatsLVL()
    {
        _ = PlayerPrefs.HasKey("HpLVL") ? (HpLVL = PlayerPrefs.GetInt("HpLVL")) : (HpLVL = 1);
        _ = PlayerPrefs.HasKey("MDefLVL") ? (MDefLVL = PlayerPrefs.GetInt("MDefLVL")) : (MDefLVL = 1);
        _ = PlayerPrefs.HasKey("PDefLVL") ? (PDefLVL = PlayerPrefs.GetInt("PDefLVL")) : (PDefLVL = 1);
        _ = PlayerPrefs.HasKey("MAtackLVL") ? (MAtackLVL = PlayerPrefs.GetInt("MAtackLVL")) : (MAtackLVL = 1);
        _ = PlayerPrefs.HasKey("PAtackLVL") ? (PAtackLVL = PlayerPrefs.GetInt("PAtackLVL")) : (PAtackLVL = 1);

        //Debug.Log("HpLVL = " + HpLVL);
        //Debug.Log("MDefLVL = " + MDefLVL);
        //Debug.Log("PDefLVL = " + PDefLVL);
        //Debug.Log("MAtackLVL = " + MAtackLVL);
        //Debug.Log("PAtackLVL = " + PAtackLVL);
    }



    void Update()
    {
        //ТЕст
        if (Input.GetKeyDown(KeyCode.D))
            PlayerPrefs.DeleteAll();	// очистка всей информации для этого приложения
    }
}
