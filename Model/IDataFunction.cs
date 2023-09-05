using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF16KR.Model
{
    /// <summary>
    /// Проекция данных функции
    /// </summary>
    public interface IDataFunction
    {
        double A {  get; }
        double B { get; }
        double C { get; }

        double X { get;}
        double Y { get; }

        double FuncXY { get; }
    }
}
