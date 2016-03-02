﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPChess
{
    public enum MessageType
    {
        #region//指令的类型
        /// <summary>
        /// 玩家退出
        /// </summary>
        playerChange,
        /// <summary>
        /// 连接成功
        /// </summary>
        Connection,
        /// <summary>
        /// 决策者信息
        /// </summary>
        PlayerInfo,
        /// <summary>
        /// 来自竞价窗口的指令
        /// </summary>
        ComEleFrm,
        /// <summary>
        /// 来自创建游戏时的指令
        /// </summary>
        frmOrgan,
        /// <summary>
        /// 准备就绪的指令
        /// </summary>
        ReadyCom,
        /// <summary>
        /// 提交订单的指令
        /// </summary>
        CommitResult,
        /// <summary>
        /// 开始游戏的指令
        /// </summary>
        btnStartGame,
        /// <summary>
        /// 关闭闪屏
        /// </summary>
        CloseSplash,
        /// <summary>
        /// 订单结果
        /// </summary>
        BidReslult,
        /// <summary>
        /// 下一步骤，根据竞价类型打开不同的窗体
        /// </summary>
        Next,
        /// <summary>
        /// 打开竞价窗体
        /// </summary>
        frmQuantity,
        /// <summary>
        /// 关闭上一个竞拍窗口
        /// </summary>
        ClosePreQuantity,
        /// <summary>
        /// 所有人均放弃该订单
        /// </summary>
        Nobody,
        /// <summary>
        /// 有人获得该订单
        /// </summary>
        Someone,
        /// <summary>
        /// 打开电量订单登记表窗口
        /// </summary>
        frmEleRsult,
        /// <summary>
        /// 打开燃煤订单登记表
        /// </summary>
        frmBuyResult,
        /// <summary>
        /// 判断上一次订单已经关闭
        /// </summary>
        isClose,
        /// <summary>
        /// 名字相同，有改动
        /// </summary>
        changeName,
        /// <summary>
        /// 总分
        /// </summary>
        totalPoint,
        /// <summary>
        /// 本年经营结果
        /// </summary>
        ThisYearPoint,
        /// <summary>
        /// 电脑数
        /// </summary>
        computerCount,
        /// <summary>
        /// 根据决策者数初始化完毕
        /// </summary>
        initialComOver
        #endregion
    }
}
