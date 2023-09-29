using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF16KR.Enum;
using WPF16KR.Model;

namespace WPF16KR.ViewModel;

/// <summary>
/// ViewModel основного окна программы
/// </summary>
public sealed class ApplicationViewModel : INotifyPropertyChanged, IDisposable
{

    #region Properties

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Событие изменения выбора функции
    /// </summary>
    private event Action<FuncType> OnFunctionsChanged;
    /// <summary>
    /// События изменения введенных данных
    /// </summary>
    private event Action OnDataChanged;

    /// <summary>
    /// Список функций
    /// </summary>
    public Dictionary<string, FuncType> Functions { get; set; }

    /// <summary>
    /// Выбранная функция
    /// </summary>
    public string SelectedFunc
    {
        get => selectedFuncString;
        set
        {
            selectedFuncString = value;
            selectedFunc = Functions[value];

            OnFunctionsChanged?.Invoke(selectedFunc);
            OnDataChanged?.Invoke();
            OnPropertyChanged(nameof(SelectedFunc));
        }
    }
    private string selectedFuncString;
    private FuncType selectedFunc;

    public string Function => $"f(x, y) = ax^{Calculate.ParseEnum(selectedFunc)} + by^{Calculate.ParseEnum(selectedFunc) - 1} + c";

    /// <summary>
    /// Ввод данных для параметра А
    /// </summary>
    public string A
    {
        get => a.ToString();
        set
        {
            if (int.TryParse(value.Trim(), out int result))
            {
                DataMap.ForEach(data => data.A = result);
                a = result;
            }
            else
            {
                DataMap.ForEach(data => data.A = 0);
                a = 0;
            }

            OnDataChanged?.Invoke();
            OnPropertyChanged(nameof(A));
        }
    }
    private int a;

    /// <summary>
    /// Ввод данных для параметра В
    /// </summary>
    public string B
    {
        get => b.ToString();
        set
        {
            if (int.TryParse(value.Trim(), out int result))
            {
                DataMap.ForEach(data => data.B = result);
                b = result;
            }
            else
            {
                DataMap.ForEach(data => data.B = 0);
                b = 0;
            }

            OnDataChanged?.Invoke();
            OnPropertyChanged(nameof(B));
        }
    }
    private int b;

    /// <summary>
    /// Выпадающий список для параметра С
    /// </summary>
    public List<int> ExtentCList
    {
        get => extentCList;
        set
        {
            extentCList = value;
            OnPropertyChanged(nameof(ExtentCList));
        }
    }
    private List<int> extentCList;

    /// <summary>
    /// Выбранные данные для параметра C
    /// </summary>
    public int C
    {
        get => selectedC;
        set
        {
            DataMap.ForEach(data => data.C = value);

            selectedC = value;
            OnDataChanged?.Invoke();
            OnPropertyChanged(nameof(C));
        }
    }
    private int selectedC;

    /// <summary>
    /// Данные функций многочлена
    /// </summary>
    public List<DataFunction> DataMap { get; set; }

    #endregion


    #region ClassLifeCicle

    public ApplicationViewModel()
    {
        DataMap = new();

        Functions = new Dictionary<string, FuncType>()
        {
            { "линейная", FuncType.Linear },
            { "квадратичная", FuncType.Quadratic },
            { "кубическая", FuncType.Tres },
            { "4-ой степени", FuncType.Quattor },
            { "5-ой степени", FuncType.Quinque }
        };

        ExtentCList = new List<int>(Functions.Count) { 1, 2, 3, 4, 5 };
        selectedFunc = FuncType.Linear;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        OnFunctionsChanged += FunctionsChanged;
        OnDataChanged += DataChanged;
    }

    private void Unsubscribe()
    {
        OnFunctionsChanged -= FunctionsChanged;
        OnDataChanged -= DataChanged;
    }

    #endregion


    #region Methods

    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    /// <summary>
    /// Обработчик события изменения основной функции
    /// </summary>
    /// <param name="func"></param>
    private void FunctionsChanged(FuncType func)
    {
        int selectIndex = ExtentCList.IndexOf(C);
        if (selectIndex < 0)
        {
            selectIndex = 0;
        }

        var list = new List<int>(Functions.Count);
        for (int i = 0; i < Functions.Count; i++)
        {
            list.Add((int)((i + 1) * Math.Pow(10, Calculate.ParseEnum(func) - 1)));
        }
        ExtentCList = list;

        C = ExtentCList[selectIndex];

        OnPropertyChanged(nameof(Function));
    }

    /// <summary>
    /// Обработчик события изменения данных
    /// </summary>
    private void DataChanged()
    {
        foreach (var data in DataMap)
        {
            data.FuncXY = Calculate.FuncN(selectedFunc, data);
        }
    }

    #endregion

}
