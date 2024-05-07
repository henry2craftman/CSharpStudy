using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 책 내용을 미리 등록한 후, 책의 정보를 이용하여 책을 검색하는 도서검색 서비스
/// 1. 5권 정도의 도서를 등록
/// 2. Library라는 이름의 딕셔너리에 책을 넣는다.
/// </summary>
public class DctionaryStudy : MonoBehaviour
{
    [Header("검색 페이지")]
    public GameObject searchPanel;
    public GameObject registerPanel;
    public TMP_Dropdown dropdown;
    public InputField inputSearch;
    public Button searchBtn;
    public TMP_Text logSearch;

    [Space(20)]
    [Header("등록 페이지")]

    public InputField inputBookName;
    public InputField inputLocation;
    public Button registerBtn;
    public TMP_Text logRegister;


    Dictionary<string, string> library = new Dictionary<string, string>();

    void Start()
    {
        library.Add("Book1", "1,1");
        library.Add("Book2", "2,3");
        library.Add("Book3", "1,3");
        library.Add("Book4", "1,2");
        library.Add("Book5", "1,4");

        logSearch.text = $"Please enter the name of the book.";
        logRegister.text = $"Please enter the name and the location of the book.";
    }

    // <실습1>
    // 1. 도서등록: 책 제목 또는 위치를 입력하여 도서 등록
    public void OnRegisterBtnClkEvent()
    {
        string bookName = inputBookName.text;
        string location = inputLocation.text;

        if(bookName == "" || location == "")
        {
            logRegister.text = $"Please enter the name and the location of the book.";
            return;
        }

        library.Add(bookName, location);

        logRegister.text = $"{bookName} is registered on {location}.";
    }

    // 2. 도서검색: 책 제목 또는 위치를 입력받아 결과를 출력
    public void OnSearchBtnClkEvent()
    {
        logSearch.text = "";
        string bookName = "";
        string location = "";

        switch (dropdown.value)
        {
            case 0:
                bookName = inputSearch.text;

                if(bookName == "")
                {
                    logSearch.text = $"Please enter the name of the book.";
                    return;
                }

                if(library.ContainsKey(bookName))
                {
                    location = library[bookName];
                    logSearch.text = $"{bookName} is located on {location}.";
                }
                else
                    logSearch.text = $"No books on the list";

                break;
            case 1:
                location = inputSearch.text;

                if (location == "")
                {
                    logSearch.text = $"Please enter the location of the book.";
                    return;
                }

                if (library.ContainsValue(location))
                {
                    string key = library.FirstOrDefault(x => x.Value == location).Key;

                    logSearch.text += $"{key} is located on {location}.";
                }
                else
                    logSearch.text += $"No books on the list";
                break;
        }
    }

    public void OnMoveNextPageBtnClkEvent(bool isSearchPage)
    {
        searchPanel.SetActive(!isSearchPage);
        registerPanel.SetActive(isSearchPage);
    }

    public void OnShowListBtnClkEvent()
    {
        logSearch.text = "";
        logRegister.text = "";

        if(searchPanel.activeSelf)
        {
            foreach(KeyValuePair<string, string> bookInfo in library)
            {
                logSearch.text += $"{bookInfo.Key} is on {bookInfo.Value}\n";
            }
        }
        else
        {
            foreach (KeyValuePair<string, string> bookInfo in library)
            {
                logRegister.text += $"{bookInfo.Key} is on {bookInfo.Value}\n";
            }
        }
    }
}
