using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {

    public GameObject item;

    public Image imageView;
    public AudioSource audiosource;

    void Awake()
    {
        for (int i = 0; i < 5; ++i)
        {
            GameObject itemObj = Instantiate(item) as GameObject;

            itemObj.transform.parent = this.gameObject.transform;
            itemObj.transform.localScale = Vector3.one;

            Text txt=itemObj.GetComponentInChildren<Text>();
            txt.text = "关卡" + (i + 1);

            Item it=itemObj.GetComponent<Item>();
            it.num = i;
            it.path = "texture/LevelBg/map_1_" + (i + 1);

            EventTriggerListener.Get(itemObj).onClick += HandleItem;
        }
    }

	// Use this for initialization
	void Start () {
        audiosource = this.GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {

	}


    void HandleItem(GameObject obj)
    {
        Item it = obj.GetComponent<Item>();

        Sprite img = Resources.Load<Sprite>(it.path);
        imageView.overrideSprite = img;
        
        imageView.color = new Color(255, 255, 255, 255);

        audiosource.Play();
    }




}
