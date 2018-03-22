
using System;
using System.IO;
using System.Collections.Generic;
using System.StubHelpers;
using System.Runtime.InteropServices;
using System.Threading;

//试题数据结构
public struct Test_Questions
{
    public int Title_Number;   //题库题号
    public string Subject;    //题目
    public string Option_A;   //选项A
    public string Option_B;   //选项B
    public string Option_C;   //选项C
    public string Option_D;   //选项D
    public string Answer;     //答案
};

public static class common // static 不是必须
{
    public static Test_Questions gTest_Questions;
}