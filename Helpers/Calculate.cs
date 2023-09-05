using System;
using WPF16KR.Enum;
using WPF16KR.Model;

namespace WPF16KR
{
    /// <summary>
    /// Класс вычислений
    /// </summary>
    public static class Calculate
    {
        /// <summary>
        /// Функция многочлена n-ой степени
        /// </summary>
        /// <param name="functionType">Тип функции</param>
        /// <param name="a">Коэффициент a</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="c">Коэффициент c</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double FuncN(FuncType functionType,
                                     double a, double b, double c,
                                     double x, double y)
        {
            int extent = ParseEnum(functionType);
            return a * Math.Pow(x, extent) + b * Math.Pow(y, extent - 1) + c;
        }

        /// <summary>
        /// Функция многочлена n-ой степени
        /// </summary>
        /// <param name="functionType">Тип функции</param>
        /// <param name="data">Данные коэффициентов</param>
        /// <returns></returns>
        public static double FuncN(FuncType functionType, IDataFunction data)
        {
            int extent = ParseEnum(functionType);
            return data.A * Math.Pow(data.X, extent) + data.B * Math.Pow(data.Y, extent - 1) + data.C;
        }

        /// <summary>
        /// Проверка преобразования типа функции
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int ParseEnum(FuncType func)
        {
            try
            {
                return (int)func;
            }
            catch
            {
                throw new ArgumentException("Преобразование типа перечисления прошло неудачно");
            }
        }
    }
}
