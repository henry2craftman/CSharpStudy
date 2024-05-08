using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ClassStudy;



// C#에서는 단일 상속만 가능
public class ClassStudy : MonoBehaviour // MonoBehaviour(부모 클래스)를 상속받은 ClassStudy(하위 클래스)
{
    // 1. 데이터를 저장하기 위한 컨테이너
    // 2. 기능을 정의하기 위해 사용(캡슐화, 상속, 추상화, 다형성)
    // 3. 상속의 장점: 코드의 재사용, 유지보수가 편하다, 다형성 구현할 수 있다.

    [SerializeField] TMP_InputField vehicleNumberInput;
    [SerializeField] Button registerBtn;
    [SerializeField] Button outBtn;

    public class Car
    {
        public string carNumber;
        public DateTime date;

        public Car(string carNumber, DateTime date)
        {
            this.carNumber = carNumber;
            this.date = date;
        }
    }

    public class ParkingLot
    {
        List<Car> cars = new List<Car>();

        public void InCar(string carNumber)
        {
            if(carNumber == "")
            {
                Debug.Log("자동차 번호를 입력해 주세요.");
                return;
            }

            Car car = new Car(carNumber, DateTime.Now);
            cars.Add(car);
        }

        public void OutCar(string carNumber)
        {
            if (carNumber == "")
            {
                Debug.Log("자동차 번호를 입력해 주세요.");
                return;
            }

            Car carFound = cars.Find(x => x.carNumber == carNumber);

            if (carFound == null)
                return;

            cars.Remove(carFound);
        }

        public void ShowCarList()
        {
            string carInfo = "";

            foreach (Car car in cars)
            {
                carInfo += car.carNumber + ", " + car.date + "\n";
            }

            Debug.Log(carInfo);
        }
    }

    ParkingLot parkingLot;

    void Start()
    {
        /* 클래스 예시
         * // 클래스의 인스턴싱, 객체화
        Person p1 = new Person("신태욱", 23);
        //p1.name = "신태욱"; // 필드에 값을 대입
        //p1.age = 23; ;
        print(p1.Speak("Hello"));

        Car car = new Car();*/

        // 실습2. 주차장 관리시스템
        // 1. Car클래스 정의 -> 차량번호, 입차시간을 필드로 가지는 클래스
        // 2. ParkingLot클래스 정의 -> Car클래스를 넣을 수 있는 컬랙션(List, Queue, Stack) 필드
        //                         -> 차량 입차(메서드), 출차 기능(메서드), 현재 주차된 차량 목록 출력 기능(메서드)

        // 순서1. 플레이버튼 눌렀을 때 Start함수에서 ParkingLot클래스 할당(new)
        parkingLot = new ParkingLot();
        parkingLot.InCar("5555");
        parkingLot.ShowCarList();

        // 순서2. 등록 버튼 클릭시 클릭 이벤트 메서드 실행 -> ParkingLot 클래스의 차량 입차 메서드 실행 -> input의 내용 기반 차량 등록
        // 순서3. 등록 버튼 클릭시 현재 주차된 차량 목록 출력(업데이트)
        // 순서4. 출차 버튼 클릭시 현재 주차된 차량 목록에서 해당 내용 제거

        // 차량 입차 메서드: 5138 입력 후 등록버튼 클릭시 실행, 차량번호, 입차시간을 가지고 있는 Car클래스 new 키워드로 만든다.
    }

    public void OnRegisterBtnClkEvent()
    {
        if(parkingLot == null)
        {
            print("parkingLot을 만들어 주세요.");
            return;
        }

        parkingLot.InCar(vehicleNumberInput.text);
        parkingLot.ShowCarList();
    }

    public void OnUnregisterBtnClkEvent()
    {
        if (parkingLot == null)
        {
            print("parkingLot을 만들어 주세요.");
            return;
        }

        parkingLot.OutCar(vehicleNumberInput.text);
        parkingLot.ShowCarList();
    }
}
