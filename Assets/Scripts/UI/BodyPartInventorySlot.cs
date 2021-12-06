using TMPro;
using UnityEngine;

public class BodyPartInventorySlot : MonoBehaviour
{
    public BodyPartType bodyPartType;

    public ZombieType zombieType;

    public float displayTime = 2f;

    public int offSet = 80;

    public bool onlyNewParts = false;

    private float _currentDisplayTime;

    private GameObject _popUp;

    private Inventory _inventory;

    private TMP_Text _textMesh;

    private void Awake()
    {
        _inventory = Inventory.instance;
        _textMesh = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        if (onlyNewParts)
            _textMesh.text = _inventory.GetAmountOfNewBodyPart(bodyPartType, zombieType).ToString();
        else
            _textMesh.text = _inventory.GetTotalAmountOfBodyPart(bodyPartType, zombieType).ToString();
    }

    void Update()
    {
        if(_currentDisplayTime > 0f)
        {
            _currentDisplayTime -= Time.deltaTime;
        }
        else if (_popUp != null)
        {   
            Destroy(_popUp);
        }
    }

    public void UpdateUI()
    {
        if(onlyNewParts)
        {
            _textMesh.text = _inventory.GetAmountOfNewBodyPart(bodyPartType, zombieType).ToString();
        }
        else
        {
            _textMesh.text = _inventory.GetTotalAmountOfBodyPart(bodyPartType, zombieType).ToString();
            ShowBodyPartCollectedPopUp();
        }
    }

    public void ShowBodyPartCollectedPopUp()
    {
        _currentDisplayTime = displayTime;
        if (_popUp != null)
            return;
        _popUp = Instantiate(gameObject, transform);
        Destroy(_popUp.GetComponent<BodyPartInventorySlot>());
        _popUp.transform.position = new Vector3(transform.position.x, transform.position.y - offSet, 0);
        _popUp.GetComponentInChildren<TMP_Text>().text = "+";
    }
}
