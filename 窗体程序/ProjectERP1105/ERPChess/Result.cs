﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPChess
{
    public class Result
    {
        #region//pal：profit and loss 损益部分

        double pal_security;
        /// <summary>
        /// 安全费
        /// </summary>
        public double Pal_Security
        {
            get { return pal_security; }
            set { pal_security = value; }
        }

        double pal_sale;
        /// <summary>
        /// 售电
        /// </summary>
        public double Pal_sale
        {
            get { return pal_sale; }
            set { pal_sale = value; }
        }




        double pal_cost;
        /// <summary>
        /// 主营业务成本
        /// </summary>
        public double Pal_cost
        {
            get { return pal_cost; }
            set { pal_cost = value; }
        }
        double pal_attach;
        /// <summary>
        /// 产品销售税金及附加
        /// </summary>
        public double Pal_attach
        {
            get { return pal_attach; }
            set { pal_attach = value; }
        }
        double pal_TBusProfit;
        /// <summary>
        /// 主营业务利润
        /// </summary>
        public double Pal_TBusProfit
        {
            get { return pal_TBusProfit; }
            set { pal_TBusProfit = value; }
        }
        double pal_manage;
        /// <summary>
        /// 管理费用
        /// </summary>
        public double Pal_manage
        {
            get { return pal_manage; }
            set { pal_manage = value; }
        }
        double pal_financial;
        /// <summary>
        /// 财务费用
        /// </summary>
        public double Pal_financial
        {
            get { return pal_financial; }
            set { pal_financial = value; }
        }
        double pal_busProfit;
        /// <summary>
        /// 营业利润
        /// </summary>
        public double Pal_busProfit
        {
            get { return pal_busProfit; }
            set { pal_busProfit = value; }
        }
        double pal_profit;
        /// <summary>
        /// 利润总额
        /// </summary>
        public double Pal_profit
        {
            get { return pal_profit; }
            set { pal_profit = value; }
        }
        double pal_tax;
        /// <summary>
        /// 所得税
        /// </summary>
        public double Pal_tax
        {
            get { return pal_tax; }
            set { pal_tax = value; }
        }
        double pal_netProfit;
        /// <summary>
        /// 净利润
        /// </summary>
        public double Pal_netProfit
        {
            get { return pal_netProfit; }
            set { pal_netProfit = value; }
        }
        #endregion
        #region//anl:Assets and liabilities 资产负债部分
        double anl_proCash;
        /// <summary>
        /// 现金
        /// </summary>
        public double Anl_proCash
        {
            get { return anl_proCash; }
            set { anl_proCash = value; }
        }
        double anl_proRaccount;
        /// <summary>
        /// 应收账款
        /// </summary>
        public double Anl_proRaccount
        {
            get { return anl_proRaccount; }
            set { anl_proRaccount = value; }
        }
        double anl_proSave;
        /// <summary>
        /// 存货
        /// </summary>
        public double Anl_proSave
        {
            get { return anl_proSave; }
            set { anl_proSave = value; }
        }
        double anl_proTLiquid;
        /// <summary>
        /// 流动资产合计
        /// </summary>
        public double Anl_proTLiquid
        {
            get { return anl_proTLiquid; }
            set { anl_proTLiquid = value; }
        }
        double anl_proDepreciationtotal;
        /// <summary>
        /// 设备折旧累计(新增加）
        /// </summary>
        public double Anl_proDepreciationtotal
        {
            get { return anl_proDepreciationtotal; }
            set { anl_proDepreciationtotal = value; }
        }
        double anl_proTdevicealueyuan;
        ///<summary>
        ///设备原值（新增加）
        ///</summary>
        public double Anl_proTdevicevalueyuan
        {
            get { return anl_proTdevicealueyuan; }
            set { anl_proTdevicealueyuan = value; }

        }
        double anl_proTdevicevalue;
        /// <summary>
        /// 设备净值
        /// </summary>
        public double Anl_proTdevicevalue
        {
            get { return anl_proTdevicevalue; }
            set { anl_proTdevicevalue = value; }
        }
        double anl_proBuilding;
        /// <summary>
        /// 在建工程
        /// </summary>
        public double Anl_proBuilding
        {
            get { return anl_proBuilding; }
            set { anl_proBuilding = value; }
        }
        double anl_proTSolid;
        /// <summary>
        /// 固定资产合计
        /// </summary>
        public double Anl_proTSolid
        {
            get { return anl_proTSolid; }
            set { anl_proTSolid = value; }
        }
        double anl_proTotal;
        /// <summary>
        /// 资产总计
        /// </summary>
        public double Anl_proTotal
        {
            get { return anl_proTotal; }
            set { anl_proTotal = value; }
        }
        double anl_debtSloan;
        /// <summary>
        /// 短期贷款
        /// </summary>
        public double Anl_debtSloan
        {
            get { return anl_debtSloan; }
            set { anl_debtSloan = value; }
        }
        double anl_debtTax;
        /// <summary>
        /// 应交税
        /// </summary>
        public double Anl_debtTax
        {
            get { return anl_debtTax; }
            set { anl_debtTax = value; }
        }
        double anl_debtLloan;
        /// <summary>
        /// 长期贷款
        /// </summary>
        public double Anl_debtLloan
        {
            get { return anl_debtLloan; }
            set { anl_debtLloan = value; }
        }
        double anl_debtPaccount;
        /// <summary>
        /// 应付账款
        /// </summary>
        public double Anl_debtPaccount
        {
            get { return anl_debtPaccount; }
            set { anl_debtPaccount = value; }
        }
        double anl_debtT;
        /// <summary>
        /// 总负债
        /// </summary>
        public double Anl_debtT
        {
            get { return anl_debtT; }
            set { anl_debtT = value; }
        }
        double anl_rstock;
        /// <summary>
        /// 股东资本
        /// </summary>
        public double Anl_rstock
        {
            get { return anl_rstock; }
            set { anl_rstock = value; }
        }
        double anl_rprofitSave;
        /// <summary>
        /// 利润留存
        /// </summary>
        public double Anl_rprofitSave
        {
            get { return anl_rprofitSave; }
            set { anl_rprofitSave = value; }
        }
        double anl_rNetprofit;
        /// <summary>
        /// 本年净利
        /// </summary>
        public double Anl_rNetprofit
        {
            get { return anl_rNetprofit; }
            set { anl_rNetprofit = value; }
        }
        double anl_rightsT;
        /// <summary>
        /// 所有者权益
        /// </summary>
        public double Anl_rightsT
        {
            get { return anl_rightsT; }
            set { anl_rightsT = value; }
        }
        double anl_rightsDebt;
        /// <summary>
        /// 负债加权益
        /// </summary>
        public double Anl_rightsDebt
        {
            get { return anl_rightsDebt; }
            set { anl_rightsDebt = value; }
        }
        #endregion
        #region//cc:Comprehensive cost 综合费用
        double cc_sales;
        /// <summary>
        /// 订单销售额
        /// </summary>
        public double Cc_sales
        {
            get { return cc_sales; }
            set { cc_sales = value; }
        }

        double ddzl;
        ///<summary>
        ///存储售电销售量（新增加）
        ///</summary>
        public double DdZl
        {
            get { return ddzl; }
            set { ddzl = value; }
        }

        double ddze;
        ///<summary>
        ///存储售电销售额（新增加）
        /// </summary>
        public double DdZe
        {
            get { return ddze; }
            set { ddze = value; }
        }




        #region//mbc:Main business cost 主营业务成本

        double cc_mbc_Ele;
        /// <summary>
        /// 购电费
        /// </summary>
        public double Cc_mbc_Ele
        {
            get { return cc_mbc_Ele; }
            set { cc_mbc_Ele = value; }
        }
        /// <summary>
        /// 安全费
        /// </summary>
        double cc_mbc_Security;
        public double Cc_mbc_Security
        {
            get { return cc_mbc_Security; }
            set { cc_mbc_Security = value; }
        }

        double cc_mbc_oil;
        /// <summary>
        /// 燃油
        /// </summary>
        public double Cc_mbc_oil
        {
            get { return cc_mbc_oil; }
            set { cc_mbc_oil = value; }
        }



        double cc_mbc_coal;
        /// <summary>
        /// 燃煤
        /// </summary>
        public double Cc_mbc_coal
        {
            get { return cc_mbc_coal; }
            set { cc_mbc_coal = value; }
        }
        double cc_mbc_water;
        /// <summary>
        /// 水费
        /// </summary>
        public double Cc_mbc_water
        {
            get { return cc_mbc_water; }
            set { cc_mbc_water = value; }
        }
        double cc_mbc_material;
        /// <summary>
        /// 材料费
        /// </summary>
        public double Cc_mbc_material
        {
            get { return cc_mbc_material; }
            set { cc_mbc_material = value; }
        }
        double cc_mbc_welfare;
        /// <summary>
        /// 工福费
        /// </summary>
        public double Cc_mbc_welfare
        {
            get { return cc_mbc_welfare; }
            set { cc_mbc_welfare = value; }
        }
        double cc_mbc_dep;
        /// <summary>
        /// 本年折旧
        /// </summary>
        public double Cc_mbc_dep
        {
            get { return cc_mbc_dep; }
            set { cc_mbc_dep = value; }
        }
        double cc_mbc_repair;
        /// <summary>
        /// 修理费
        /// </summary>
        public double Cc_mbc_repair
        {
            get { return cc_mbc_repair; }
            set { cc_mbc_repair = value; }
        }
        double cc_mbc_blowdown;
        /// <summary>
        /// 排污费
        /// </summary>
        public double Cc_mbc_blowdown
        {
            get { return cc_mbc_blowdown; }
            set { cc_mbc_blowdown = value; }
        }
        double cc_mbc_entrust;
        /// <summary>
        /// 管理费
        /// </summary>
        public double Cc_mbc_entrust
        {
            get { return cc_mbc_entrust; }
            set { cc_mbc_entrust = value; }
        }
        double cc_mbc_littleOilfire;
        /// <summary>
        /// 微油点火消耗
        /// </summary>
        public double Cc_mbc_littleOilfire
        {
            get { return cc_mbc_littleOilfire; }
            set { cc_mbc_littleOilfire = value; }
        }  
        double cc_mbc_others;
        /// <summary>
        /// 其他
        /// </summary>
        public double Cc_mbc_others
        {
            get { return cc_mbc_others; }
            set { cc_mbc_others = value; }
        }
        double cc_mbc_total;
        /// <summary>
        /// 合计
        /// </summary>
        public double Cc_mbc_total
        {
            get { return cc_mbc_total; }
            set { cc_mbc_total = value; }
        }
        #endregion
        #region//fmt:Financial management tax:财务/管理/税
        double cc_fmt_Linterest;
        /// <summary>
        /// 长贷利息费
        /// </summary>
        public double Cc_fmt_Linterest
        {
            get { return cc_fmt_Linterest; }
            set { cc_fmt_Linterest = value; }
        }
        double cc_fmt_Sinterest;
        /// <summary>
        /// 短贷利息费
        /// </summary>
        public double Cc_fmt_Sinterest
        {
            get { return cc_fmt_Sinterest; }
            set { cc_fmt_Sinterest = value; }
        }
        double cc_fmt_discount;
        /// <summary>
        /// 贴现
        /// </summary>
        public double Cc_fmt_discount
        {
            get { return cc_fmt_discount; }
            set { cc_fmt_discount = value; }
        }
        double cc_fmt_manage;
        /// <summary>
        /// 管理费
        /// </summary>
        public double Cc_fmt_manage
        {
            get { return cc_fmt_manage; }
            set { cc_fmt_manage = value; }
        }
        double cc_fmt_attach;
        /// <summary>
        /// 产品税金及附加
        /// </summary>
        public double Cc_fmt_attach
        {
            get { return cc_fmt_attach; }
            set { cc_fmt_attach = value; }
        }
        double cc_fmt_tax;
        /// <summary>
        /// 所得税
        /// </summary>
        public double Cc_fmt_tax
        {
            get { return cc_fmt_tax; }
            set { cc_fmt_tax = value; }
        }
        double cc_fmt_insurance;
        /// <summary>
        /// 财保费
        /// </summary>
        public double Cc_fmt_insurance
        {
            get { return cc_fmt_insurance; }
            set { cc_fmt_insurance = value; }
        }
        double cc_fmt_nitric;
        /// <summary>
        /// 认证费
        /// </summary>
        public double Cc_fmt_nitric
        {
            get { return cc_fmt_nitric; }
            set { cc_fmt_nitric = value; }
        }
        double cc_fmt_powerRate;
        /// <summary>
        /// 线损费
        /// </summary>
        public double Cc_fmt_powerRate
        {
            get { return cc_fmt_powerRate; }
            set { cc_fmt_powerRate = value; }
        }
        #endregion
        #region//o:operations 运营状况
        double cc_o_Tdevicevalue;
        /// <summary>
        /// 设备价值
        /// </summary>
        public double Cc_o_Tdevicevalue
        {
            get { return cc_o_Tdevicevalue; }
            set { cc_o_Tdevicevalue = value; }
        }
        double cc_o_building;
        /// <summary>
        /// 在建工程
        /// </summary>
        public double Cc_o_building
        {
            get { return cc_o_building; }
            set { cc_o_building = value; }
        }
        double cc_o_cash;
        /// <summary>
        /// 现金
        /// </summary>
        public double Cc_o_cash
        {
            get { return cc_o_cash; }
            set { cc_o_cash = value; }
        }
        double cc_o_Raccount;
        /// <summary>
        /// 应收账款
        /// </summary>
        public double Cc_o_Raccount
        {
            get { return cc_o_Raccount; }
            set { cc_o_Raccount = value; }
        }
        double cc_o_saveCoal;
        /// <summary>
        /// 存货
        /// </summary>
        public double Cc_o_saveCoal
        {
            get { return cc_o_saveCoal; }
            set { cc_o_saveCoal = value; }
        }
        double cc_o_Lloan;
        /// <summary>
        /// 长期贷款
        /// </summary>
        public double Cc_o_Lloan
        {
            get { return cc_o_Lloan; }
            set { cc_o_Lloan = value; }
        }
        double cc_o_Sloan;
        /// <summary>
        /// 短期贷款
        /// </summary>
        public double Cc_o_Sloan
        {
            get { return cc_o_Sloan; }
            set { cc_o_Sloan = value; }
        }
        double cc_o_Paccount;
        /// <summary>
        /// 应付账款
        /// </summary>
        public double Cc_o_Paccount
        {
            get { return cc_o_Paccount; }
            set { cc_o_Paccount = value; }
        }
        #endregion
        #endregion
    }
}
