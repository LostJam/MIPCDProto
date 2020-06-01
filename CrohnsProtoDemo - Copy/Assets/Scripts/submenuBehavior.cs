using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class submenuBehavior : MonoBehaviour
{

    public static Dictionary<string, GameObject> Organs = new Dictionary<string, GameObject>();

    public static void RegisterOrgan(string name, GameObject gameObject)
    {
        if (submenuBehavior.Organs.ContainsKey(name) == false)
        {
            Organs.Add(name, gameObject);
            Debug.Log("added " + name);

        }
    }

    private static Dictionary<string, GameObject> submenus = new Dictionary<string, GameObject>();
    public static void RegisterSubmenu(string name, GameObject gameObject)
    {
        if (submenuBehavior.submenus.ContainsKey(name) == false)
        {
            submenus.Add(name, gameObject);
            Debug.Log("added " + name);
        }
    }

    private static Dictionary<string, GameObject> mainmenus = new Dictionary<string, GameObject>();
    public static void RegisterMainMenu(string name, GameObject gameObject)
    {
        if (submenuBehavior.mainmenus.ContainsKey(name) == false)
        {
            mainmenus.Add(name, gameObject);
            Debug.Log("added to main " + name);
        }
    }

   // public glowyBehavoir glowyClass;
    GameObject submenu;
    public GameObject changer;
    public GameObject movie;
    public GameObject scissors;
    public GameObject cami;
    public GameObject loadVol;
    public GameObject plane;

    public GameObject oculus;

    public CustomLaserPointer laser;
    public Transform hand;
    GameObject ob;
    GameObject plus;
    Vector3 oldPos;
    Vector3 originalBody;
    Quaternion originalBodyRot;
    // Update is called once per frame
    public void Awake()
    {
        oldPos = scissors.transform.position;
         originalBody = loadVol.transform.position;
        originalBodyRot = loadVol.transform.rotation;
    }

    void Update()
    {
        if (laser.isDown)// && laser.itemHit.layer == 8)
        {
            if (laser.itemHit)
            {
                rightClick(laser.itemHit);

            }
        }
        if (laser.leftClick && laser.shootingLaser)
        {
            if (laser.itemHit)
            {
                leftClick(laser.itemHit);
            }
        }
    }

    public void leftClick(GameObject subOb)
    {
        //check that it has a first child
        if (subOb.transform.childCount > 0) 
        {
           //if its in the dictionary
            var subName = subOb.transform.GetChild(0).gameObject.name;
            if (submenus.ContainsKey(subName))
            {
                var menu = submenus[subName];
                if (menu.activeSelf)
                {
                    menu.SetActive(false);
                }
                else
                {
                    menu.SetActive(true);
                }
            }
        }

    }
    //takes in hit data from laser pointer ob is item hit
    public void rightClick(GameObject ob)
    {
        //TODO REMOVE THIS LAYER?????????
        //if its layer is Button then it will have canvas behavoir
        if (ob.layer == 8)
        {
            // var name = ob.transform.GetChild(0).gameObject.name;
            if (mainmenus.ContainsKey(ob.name))
            {
                if (ob.name == "MOVIE" && movie.activeSelf)
                {
                    movie.SetActive(false);
                }
                else if (ob.name == "MOVIE")
                {
                    movie.SetActive(true);
                    //GameObject myMov = Instantiate(movie) as GameObject;
                    //myMov.transform.SetParent(ob.transform);
                }
                if (ob.name == "REMOVE")
                {
                    Debug.Log("REMOVED");
                    loadVol.gameObject.SetActive(false);
                }
                if (ob.name == "RESET")
                {
                    Debug.Log("RESET");
                    loadVol.transform.position = originalBody;
                    loadVol.transform.rotation = originalBodyRot;
                  
                }
                else if (ob.name == "CUTTING")
                {
                  //  Vector3 oldPos;
                    if (scissors.transform.parent != hand)
                    {
                        scissors.SetActive(true);
                        scissors.transform.position = hand.position;
                        scissors.transform.SetParent(hand);
                    }
                    else
                    {
                        scissors.SetActive(false);
                        scissors.transform.position = oldPos;
                        scissors.transform.SetParent(null);
                    }
                    //or get the action script on that item
                }
                else if (ob.name == "CAMERA")
                {
                    //  Vector3 oldPos;
                    if (cami.transform.parent != hand)
                    {
                        oldPos = cami.transform.localPosition;
                        cami.transform.SetParent(hand);
                        cami.transform.position = cami.transform.parent.transform.GetChild(0).position;
                        cami.transform.rotation = cami.transform.parent.transform.GetChild(0).rotation;
                      
                    }
                    else
                    {
                        cami.transform.position = oldPos;
                        cami.transform.SetParent(null);
                  
                    }
                }

                //DICOM STUFF
                if (ob.name == "larry1")
                {
                    loadVol.gameObject.SetActive(true);
                    if (plane != null)
                    plane.SetActive(true);
                    // make a function ugh

                    foreach (var item in NotificationManager.activeFeaturesObjs)
                    {
                        item.SetActive(true);
                    }

                    Instantiate(changer);
                    changer.GetComponent<MenuFollowsVolume>().oculus = oculus.transform;
                    ob.transform.root.gameObject.SetActive(false);
                }
                else if (ob.transform.root.name == "DicomAdd" && ob.name == "Panel")
                {
                    //if the submenu is not open
                    if (ob.transform.GetChild(0).transform.gameObject.activeSelf == false)
                    {
                        ob.transform.GetChild(1).transform.gameObject.SetActive(false);
                        ob.transform.GetChild(0).transform.gameObject.SetActive(true);
                    }
                }
                else if (ob.name == "larry2")
                {
                    loadVol.gameObject.SetActive(true);
                    //close the changeing submenu
                    var submenu = mainmenus["DicomLoader2"];
                    submenu.SetActive(false);             
                }
                else if (ob.transform.root.name == "DicomChanger(Clone)" && ob.name == "Panel2")
                {
                    submenu = ob.transform.GetChild(0).gameObject;
                    if (submenu.activeSelf == false)
                    {
                        submenu.SetActive(true);
                    }
                }

            }
            if (ob.name == "Toggle")
            {
                findObjectToToggle(ob.transform.parent.parent.GetChild(0).GetComponent<TextMeshProUGUI>().text, ob.transform.GetChild(0).gameObject);
            }
        }
    }

    public void findObjectToToggle(string organName, GameObject eye)
    {
        bool eyeOpen = eye.activeSelf;

        if (Organs.ContainsKey(organName))
        {
            var organ = Organs[organName];
            if (eyeOpen)
            {
                organ.SetActive(false);
                eye.SetActive(false);
            }
            else
            {
                organ.SetActive(true);
                eye.SetActive(true);
            }
        }
    }

}
