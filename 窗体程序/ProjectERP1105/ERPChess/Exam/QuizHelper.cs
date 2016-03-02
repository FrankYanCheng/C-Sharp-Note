using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool
{
    class QuizHelper
    {
        public static int totalSeconds = 240; // 答题总时间20分钟
        public static int remainSeconds;       // 剩余的时间

        public static int[] allQuestionIds;    // 所有问题的Id数组
        public static bool[] selectedStates;   // 记录对应索引的问题是否已经被随机抽中

        public static int questionNum = 20;                        // 题目数量
        public static int[] selectedQuestionIds = new int[20];     // 选出的问题Id数组        
        public static string[] correctAnswers = new string[20];    // 标准答案数组
        public static string[] studentAnswers = new string[20];    // 学员的答案   
        
    }
}
