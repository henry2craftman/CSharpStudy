using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 컬렉션 스터디를 위한 클래스
/// </summary>
public class CollectionStudy : MonoBehaviour
{
    public InputField input;
    public Text output;

    // 컬렉션의 특징 및 장점
    // 1. 데이터 관리를 효율적으로 할 수 있다. -> 가변형 데이터 구조
    // 2. 데이터 검색 및 정렬을 위한 메서드(기능)들이 존재
    // 3. 다양한 데이터 유형을 저장할 수 있다.

    List<string> names = new List<string>();                         // List: 배열과 같이 객체화 해줘야 한다.
    Dictionary<string, int> library = new Dictionary<string, int>(); // Dictionary: Key, Value가 한 쌍, Key는 중복이 안됨
    Stack<string> exeStack = new Stack<string>();                    // Stack: 순서대로 쌓은 후, 마지막 아이템부터 꺼낸다.
    Queue<string> exeQueue = new Queue<string>();                    // Queue: 순서대로 넣은 후, 넣은 순서대로 꺼낸다.
    HashSet<string> hashNames = new HashSet<string>();                  // HashSet: List와 같은 역할, 내용은 중복 불가

    void Start()
    {
        names.Clear();
        library.Clear();
        exeStack.Clear();
        exeQueue.Clear();
        hashNames.Clear();

        // List
         /* 
         names.Add("신태욱");            // 해당 값을 추가
         names.Remove("신태욱");         // 해당 값으로 찾아 해당 값을 제거
         int length = names.Capacity;   // 리스트의 크기
         names.RemoveAt(0);             // 해당 인덱스(번호)로 찾고 해당 인덱스의 값을 제거
         names.Contains("신태욱");      // 해당 값이 있는지 확인
         names.AddRange(names2);        // 특정 자료형의 컬렉션을 추가
         names.Sort();                  // 오름차순 정렬
         names.Reverse();               // 역순으로 배치
         names.Insert(0, "김한수");      // 특정 위치에 값 추가
         names.InsertRange(0, names2);  // 특정 위치에 특정 자료형의 컬렉션을 추가
        */

/*        names.Add("신태욱");
        names.Insert(0, "김한수");
        print(names[0]);
        print(names[1]);

        // Dictionary
        library.Add("책1", 1);                      // 컬렉션 추가
        bool isExist = library.TryAdd("책1", 2);    // Key가 있는지 확인하고, 없다면 추가
        library.ContainsKey("책1");                 // Key가 있는지 확인
        library.ContainsValue(1);                   // Value가 있는지 확인

        // Stack
        exeStack.Push("책1");                        // 컬렉션 추가
        string st = exeStack.Pop();                 // 마지막 넣은 값 꺼내기
        // print(exeStack.Peek());                     // 마지막으로 넣은 값 확인
        // string name = exeStack.Peek();
        // exeStack.TryPeek(out name);                 // 마지막으로 넣은 값 반환
        // exeStack.TryPop(out name);                  // 마지막으로 넣은 값 반환 및 제거

        // Queue
        exeQueue.Enqueue("신태욱");                  // 컬렉션 추가
        string name2 = exeQueue.Dequeue();          // 처음 넣은 값 꺼내기
        exeQueue.TryPeek(out name2);                // 마지막 값 반환
        exeQueue.TryDequeue(out name2);             // 처음 값 반환 및 제거

        // HashSet: 내용 중복 X { "신태욱", "김태우", "임영림", "김흥수" }
        hashNames.Add("신태욱");
        HashSet<string> newNames = new HashSet<string>{ "김태우", "임영림", "김흥수" };
        hashNames.IntersectWith(newNames); // 교집합: { "김태우", "임영림", "김흥수" }
        hashNames.IsSupersetOf(newNames);
        newNames.IsProperSupersetOf(hashNames);  // 진상위집합인지 확인
        newNames.IsSubsetOf(hashNames);          // 부분집합인지 확인
        newNames.IsProperSubsetOf(hashNames);    // 진부분집합 인지 확인*/
    }

    private void Update()
    {
        실습1();

        // 실습1. 학급 명단 관리 시스템
        void 실습1()
        {
            // 1. 새 학생의 이름을 추가          (add: a + space)
            // 2. 특정 학생을 명단에서 삭제      (delete: d + space)
            //  2-1. 없으면 정보없음을 출력
            // 3. 전체 학생 명단을 출력          (show: s + space)
            // 4. 특정 학생이 명단의 위치 확인   (check: c + space)

            RegisterName(KeyCode.Space, KeyCode.A);

            ShowNameList(KeyCode.Space, KeyCode.S);

            DeleteName(KeyCode.Space, KeyCode.D);

            CheckName(KeyCode.Space, KeyCode.C);

            void RegisterName(KeyCode downKey, KeyCode key)
            {
                if (Input.GetKeyDown(downKey) && Input.GetKey(key))
                {
                    string value = input.text;

                    output.text = value + "이 추가되었습니다.\n";

                    names.Add(value);
                }
            }

            void ShowNameList(KeyCode downKey, KeyCode key)
            {
                if (Input.GetKeyDown(downKey) && Input.GetKey(key))
                {
                    if(names.Count == 0)
                    {
                        output.text = "명단이 없습니다. 명단을 입력해 주세요.\n";
                        return;
                    }

                    output.text = "명단은 아래와 같습니다.\n";

                    int i = 0;
                    foreach (string name in names)
                        output.text += i++ + ": " + name + "\n";
                }
            }

            void DeleteName(KeyCode downKey, KeyCode key)
            {
                if (Input.GetKeyDown(downKey) && Input.GetKey(key))
                {
                    string value = input.text;

                    if (names.Contains(value))
                    {
                        names.Remove(value);
                        output.text = value + "를 명단에서 삭제했습니다.\n";
                    }
                    else
                        output.text = "명단에 해당 내용이 존재하지 않습니다.\n";
                }
            }

            void CheckName(KeyCode downKey, KeyCode key)
            {
                if (Input.GetKeyDown(downKey) && Input.GetKey(key))
                {
                    string value = input.text;

                    if (names.Contains(value))
                        output.text = value + "는 " + names.IndexOf(value) + "번째 위치에 있습니다.\n";
                    else
                        output.text = "명단에 해당 내용이 존재하지 않습니다.\n";
                }
            }

        }
    }
}
