using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    public GameObject[] zdrowie;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (staty.hp < 1)
        {
            Invoke(nameof(ResetPoziomu),3);
        }
        Debug.Log("zdrowie" + staty.hp);
    }


    void ResetPoziomu()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetInt("obecna"));
    }
}