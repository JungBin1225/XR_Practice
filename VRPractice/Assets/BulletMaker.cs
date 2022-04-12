using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMaker : MonoBehaviour
{
    private float spawn_time = 0.0f;
    public GameObject prefab_bullet;
    public int max_bullets_count = 5;
    public int bullets_count = 0;

    public GameObject bulletexplosionPrefab;
    private GameObject obj_bulletexplosion = null;

    public GameObject effectPrefab;

    private Text text;
    void Start()
    {
        prefab_bullet.SetActive(false);
        text = GameObject.FindObjectOfType<Text>();

    #if UNITY_ANDROID        
        Screen.sleepTimeout=SleepTimeout.NeverSleep;
    #elif UNITY_IOS        
        iPhoneSettings.screenCanDarken = false;
    #endif
    }

    // Update is called once per frame
    void Update()
    {
        spawn_time += Time.deltaTime;
        if (spawn_time > 1.0f && max_bullets_count >= bullets_count)
        {
            spawn_time = 0.0f;
            GameObject obj_bullet = GameObject.Instantiate(prefab_bullet, this.transform) as GameObject;
            obj_bullet.SetActive(true);
            obj_bullet.transform.localPosition = new Vector3(Random.Range(-2.0f, 2.0f),Random.Range(0.5f, 3.0f), 30.0f);
            bullets_count++;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child_bullet = transform.GetChild(i);
            child_bullet.Translate(new Vector3(0, 0, 15 * Time.deltaTime));
            if (child_bullet.localPosition.z < -5.0f)
            {
                child_bullet.transform.localPosition = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(0.5f, 3.0f), 30.0f);
            }
        }

        text.text = "총알 개수: " + bullets_count;
    }

    public void BulletDestroy(GameObject go)
    {
        bullets_count--;
        

        if (obj_bulletexplosion != null) Destroy(obj_bulletexplosion);
        obj_bulletexplosion = Instantiate(bulletexplosionPrefab);
        GameObject effect = Instantiate(effectPrefab);
        effect.transform.position = new Vector3(0, 1, -3);

        Destroy(go);
    }

}
