using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MAtchStart : MonoBehaviour
{
    public GameObject weaponPanel; // ���� ���� �г�
    public Button pistolButton; // ���� ���� ��ư
    public Button ARButton; // ����� ���� ��ư
    public Button shotgunButton; // ��ź�� ���� ��ư
    public Button sniperButton; // ������ ���� ��ư

    void Start()
    {
        // ���� ���� �� ���� ���� �г��� Ȱ��ȭ
        weaponPanel.SetActive(true);

        // �� ���� ��ư�� �̺�Ʈ ������ �߰�
        pistolButton.onClick.AddListener(() => SelectWeapon("Pistol"));
        ARButton.onClick.AddListener(() => SelectWeapon("AR"));
        shotgunButton.onClick.AddListener(() => SelectWeapon("Shotgun"));
        sniperButton.onClick.AddListener(() => SelectWeapon("Sniper"));
    }

    public void SelectWeapon(string weaponName)
    {
        // ���� ���� ����
        Debug.Log(weaponName + " ���õ�");
        // ���� ���� �� �г� ��Ȱ��ȭ
        weaponPanel.SetActive(false);
        // ���� �÷��� ���� �߰�
        StartGameWithWeapon(weaponName);
    }

    private void StartGameWithWeapon(string weaponName)
    {
        // ���⿡ ���⿡ ���� ���� ���� ������ �߰��ϼ���.
        // ��: �÷��̾��� ���⸦ ��ü�ϰų�, ���⿡ ���� Ư���� �ɷ��� Ȱ��ȭ
        Debug.Log(weaponName + "���� ���� ����!");
    }
}
