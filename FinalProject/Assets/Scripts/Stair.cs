using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Stair : MonoBehaviour
{
    float horizontal, vertical;
    [SerializeField] float _upSpeed;
    [SerializeField] GameObject _player;
    [SerializeField] ThirdPersonController _controller;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�����O�_���U�e���V��
        vertical = Input.GetAxisRaw("Vertical");
        //�����O�_���U���k��V��
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"  && (vertical != 0 || horizontal != 0))
        {
            //�H���a���_�l�I�V�e�g�X�g�u�ç�I���쪺�����x�s�bhit
            Physics.Raycast(_player.transform.position, _player.transform.forward, out hit);

            //�p�G�I���쪺����=�ӱ�A�N�����a���ۼӱ�A�Ϫ��a�V�W��
            if(hit.collider.gameObject == gameObject)
                _controller._verticalVelocity = _upSpeed;
        }
    }
}