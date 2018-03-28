
using System;
using System.IO;
using System.Collections.Generic;
using System.StubHelpers;
using System.Runtime.InteropServices;
using System.Threading;

//当前状态
public enum e_Current_cmd
{
    CHECK_INPUT,        //检测输入
    START_CONVERSION,   //开始转换
    CONVERSION_FINISH,   //转换完成
    CONVERSION_FAILURE, //转换失败
};

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

//当前状态
public enum e_Conversion_cmd
{
    SUBJECT,    //题目
    OPTION_A,   //选项A
    OPTION_B,   //选项B
    OPTION_C,   //选项C
    OPTION_D,   //选项D
    ANSWER,     //答案
    NULL,       //空行
};

//输入信息结构
public struct Input_Info
{
    public string input_path;
    public string mysql_ip;
    public string mysql_port;
    public string mysql_ID;
    public string mysql_password;
    public string mysql_databases;
    public string mysql_table;
    public string table_struct;
}

public static class common // static 不是必须
{
    public static Test_Questions gTest_Questions;
    public static e_Current_cmd gCurrent_cmd;
    public static Input_Info gInput_Info;
    public static e_Conversion_cmd gConversion_cmd;

}