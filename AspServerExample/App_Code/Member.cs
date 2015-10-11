using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Member의 요약 설명입니다.
/// </summary>
public class Member
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Member()
    {
        Name = "";
        Score = 0;
    }

    public Member(string name, int score)
    {
        Name = name;
        Score = score;
    }
}