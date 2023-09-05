using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF16KR.Model;

/// <summary>
/// Данные функций многочлена
/// </summary>
public sealed class DataFunction : INotifyPropertyChanged, IDataFunction
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public double X
    {
        get => x;
        set
        {
            x = value;
            OnPropertyChanged(nameof(X));
        }
    }

    public double Y
    {
        get => y;
        set
        {
            y = value;
            OnPropertyChanged(nameof(Y));
        }
    }

    public double FuncXY
    {
        get => funcXY;
        set
        {
            funcXY = value;
            OnPropertyChanged(nameof(FuncXY));
        }
    }


    private double x;
    private double y;
    private double funcXY;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
