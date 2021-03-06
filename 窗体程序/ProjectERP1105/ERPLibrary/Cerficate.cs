﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ERPLibrary
{
    public class Cerficate
    {
        public Cerficate(CerficateType ct)
        {
            this.moneyProgress = new Queue<int>();//
            switch (ct)
            {
                case CerficateType.Security:
                    this.buildTime = 4;
                    for (int i = 0; i < this.buildTime; i++)
                    {
                        this.moneyProgress.Enqueue(1);
                    }
                    break;
                case CerficateType.ISO18000:
                    this.buildTime = 4;
                    for (int i = 0; i < this.buildTime; i++)
                    {
                        this.moneyProgress.Enqueue(1);
                    }
                    break;
                case CerficateType.ISO14000:
                    this.buildTime = 4;
                    for (int i = 0; i < this.buildTime; i++)
                    {
                        this.moneyProgress.Enqueue(1);
                    }
                    break;
                case CerficateType.ISO9000:
                    this.buildTime = 2;
                    for (int i = 0; i < this.buildTime; i++)
                    {
                        this.moneyProgress.Enqueue(1);
                    }
                    break;
            }
        }
        private bool canuse;

        public bool Canuse
        {
            get { return canuse; }
            set { canuse = value; }
        }
        public void IsAvailable()
        {
            if (this.moneyProgress.Count == 0)
            {
                this.canuse = true;
            }
            else
            {
                this.canuse = false;
            }
        }
        private int buildTime;
        public int BuildTime
        {

            get
            {
                return buildTime;
            }
        }
        private Queue<int> moneyProgress;
        public Queue<int> MoneyProgress
        {
            get
            {
                return this.moneyProgress;
            }
        }

        public void Invesment(ref double cash)
        {
            if (this.canuse == false)
            {
                if (this.moneyProgress.Count > 0)
                {
                    cash -= this.moneyProgress.Peek();
                    this.moneyProgress.Dequeue();
                }
            }
        }
    }
    public enum CerficateType
    {
        Security,
        ISO18000,
        ISO14000,
        ISO9000,
    }

}
