using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// 자료형과 형변환에 대한 스터디 클래스 입니다.
/// </summary>
public class DataTypeStudy : MonoBehaviour
{
 // 값(Value)형 변수
 // 자료형   변수명      값
    bool   isEnable = false;    // 1Byte, true/false의 값 
    int    number   = 100;      // 4Byte(32bit), 부호가 있는 정수형 자료형, 최대 0~4,294,967,295 or -2,147,483,648~2,147,483,647
    // uint numberUInt = 4294967295; // 4Byte(32bit), 부호가 없는 정수형 자료형, 최대 0~4,294,967,295
    float  number2  = 35.5f;    // 4Byte, 실수형 자료형
    double number3  = 35.5;     // 8Btye(64bit), 실수형 자료형
    char   data     = 'c';      // 1Byte, 1개의 문자를 저장하는 자료형
    string name     = "Henry";  // 문자열, 문자의 크기에 따라 크기가 변하는 자료형

    int number4; // 값을 할당하지 않는 경우 자동으로 0으로 값을 초기화

    const int age = 20; // 상수: 일기전용, runtime시 값을 변경하지 못함

    // Start is called before the first frame update
    void Start()
    {
        print(isEnable);
        print(typeof(bool));
        print(number4);

        // age = 60; // 상수로 runtime시 값을 변경하지 못함

// 형변환 = Type Casting
        int myInt = 10;
        double myDouble = 55.4;

// 방식1. 암시적, 명시적 형변환
        myDouble = myInt;       // 암시적 형변환
        // myInt = myDouble;    // 암시적 형변환 불가: myDouble의 크기가 더 크기 때문에
        myInt = (int)myDouble;  // 명시적 형변환: 크기가 큰 변수를 크기가 작은 변수로 변환 -> 55

// 방식2. 형변환 내장 메소드
        myInt.ToString();       // int형 변수 -> string형 변수로 변환
        string age = "36";
        age.ToIntArray();       // string -> int형 배열로 변환
        int.Parse(age);         // string -> int형으로 변환\
        print(int.MaxValue);    // int의 최대값
        float.Parse(age);       // string -> float형으로 변환
        double.Parse(age);      // string -> double형으로 변환
        bool.Parse(age);        // string -> bool형으로 변환
    }
}
