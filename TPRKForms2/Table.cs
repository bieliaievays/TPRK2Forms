﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace TPRKForms2
{
    public class Table
    {
        public static readonly int RowsCount = 100;
        public static readonly int MinValue = 0;
        public static readonly int MaxValue = 1000;

        public Table(int inputx)
        {
            int tempSum = 0;
            Rows = new List<Row>();
            Row.x = inputx;
            for (int i = 0; i < RowsCount; i++)
            {
                Row row = new Row();
                Rows.Add(row);
                tempSum = tempSum + row.Win;
            }
            Average = tempSum / RowsCount;
        }

        public List<Row> Rows { get; set; }
        public int Average { get; set; }

        public class Row
        {
            public static int x { get; set; }
            public int Win { get; set; }
            public int Y { get; set; }

            public Row()
            {
                Random random = new Random();
                Thread.Sleep(25);
                Y = random.Next(MinValue, MaxValue + 1);
                if (Y >= x)
                {
                    Win = Y;
                }
                else
                {
                    bool won = random.NextDouble() < 0.5;
                    if (won)
                    {
                        Win = MaxValue;
                    }
                    else
                    {
                        Win = MinValue;
                    }
                }
            }
        }
    }
}