using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IfStudy : MonoBehaviour
{
    public TMP_Text mainTxt;
    public TMP_Text subTxt;
    List<string> operOrder = new List<string>();
    bool isOperClicked = false;
    bool isCalculated = false;

    private void Start()
    {
        mainTxt.text = "0";
        subTxt.text = string.Empty;
    }

    /* If 연습
     * enum Options
        {
            BookName,
            Author,
            Location
        }
        Options option = Options.Location;
        int number = 5;

        void Start()
        {
            if (option == Options.BookName) 
            {

            }

            // 위 조건 이후에 실행되는 기능

            if(option == Options.Location)
            {

            }
            else
            {

            }


            if(number > 10)
            {

            }
            else if(number < 10)
            {
                // 기능
            }
            else if(number >= 5 && number <= 8)
            {

            }


            switch(number)
            {
                case 0:
                    break;
                case 10:
                    break;
            }
        }*/

    double Add(double inputA, double inputB)
    {
        return inputA + inputB;
    }
    double Subtract(double inputA, double inputB)
    {
        return inputA - inputB;
    }

    public void OnNumBtnClkEvent(string num)
    {
        if(mainTxt.text ==  "0")
            mainTxt.text = string.Empty;

        if (isCalculated)
        {
            mainTxt.text = string.Empty;
            subTxt.text = string.Empty;
            isCalculated = false;
        }

        if (isOperClicked)
        {
            mainTxt.text = string.Empty;
            isOperClicked = false;
        }

        mainTxt.text += num;
    }

    public void OnOperClkEvent(string oper)
    {
        isOperClicked = true;

        if(isCalculated)
        {
            operOrder.Add(oper);
            subTxt.text += $"{oper}";
            isCalculated = false;
            return;
        }
        else
        {
            operOrder.Add(oper); // 12 + 3 -> +(0)
            subTxt.text += $"{mainTxt.text}{oper}";
        }
    }

    public void OnCalBtnClkEvent()
    {
        isCalculated = true;

        subTxt.text += mainTxt.text;

        char[] opers = { '+', '-', 'x', '÷' }; 
        string[] strings = subTxt.text.Split(opers); // 12 + 3 + 1 -> A{12, 3, 1}   B{+, +}
        double[] numbers = new double[strings.Length];
        // if(B[i] == "+")
        //  result = A[i] + A[i+1]
        // else if(B[i] == "-")
        //  result = A[i] - A[i+1]

        for (int i = 0; i < strings.Length; i++)
        {
            numbers[i] = double.Parse(strings[i]);
        }

        double result = numbers[0];
        for (int i = 0;i < operOrder.Count; i++)
        {
            if (numbers.Length == (i + 1))
                break;

            switch (operOrder[i])
            {
                case "+":
                    result += numbers[i + 1];
                    break;
                case "-":
                    result -= numbers[i + 1];
                    break;
                case "x":
                    result *= numbers[i + 1];
                    break;
                case "÷":
                    result /= numbers[i + 1];
                    break;
                default:
                    Console.WriteLine("Unknown operator: " + opers[i]);
                    break;
            }
        }

        mainTxt.text = result.ToString();
    }

    public void OnClearBtnClkEvent()
    {
        mainTxt.text = "0";
        subTxt.text = string.Empty;
        operOrder.Clear();
    }

    public void OnDelBtnClkEvent()
    {
        if (mainTxt.text.Length < 1)
            return;

        int lastIndex = mainTxt.text.Length - 1;
        mainTxt.text = mainTxt.text.Substring(0, lastIndex);
    }
}
