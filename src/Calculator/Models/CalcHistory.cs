using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models;

using SQLite;



public class CalcHistory
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Calc { get; set; }
   
}
