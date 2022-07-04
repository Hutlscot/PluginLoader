namespace CadUtils.Commands;

using System;
using System.Windows;

/// <summary>
/// Базовый класс для команд с типизованным параметром.
/// </summary>
/// <typeparam name="T"> Тип вью-модели. </typeparam>
public abstract class TypedBaseCommand<T> : BaseCommand
{
    /// <summary>
    /// Название окна ошибки.
    /// </summary>
    private const string ERROR_WINDOW_TITLE = "Ошибка";

    /// <summary>
    /// Указывает, доступна ли возможность вызова команды.
    /// </summary>
    /// <param name="parameter"> Параметр для команды. </param>
    /// <returns> True - доступна. </returns>
    public sealed override bool CanExecute(object parameter)
    {
        if (parameter is T typedParameter)
            return CanExecute(typedParameter);

        return true;
    }

    /// <summary>
    /// Выполнение команды.
    /// </summary>
    /// <param name="parameter"> Параметр для команды. </param>
    public sealed override void Execute(object parameter)
    {
        try
        {
            if (parameter is T typedParameter)
                Execute(typedParameter);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, ERROR_WINDOW_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    /// <summary>
    /// Указывает, доступна ли возможность вызова команды с типизированным параметром.
    /// </summary>
    /// <param name="parameter"> Параметр для команды. </param>
    /// <returns> True - доступна. </returns>
    protected virtual bool CanExecute(T parameter)
    {
        return true;
    }

    /// <summary>
    /// Выполнение команды с типизированным параметром.
    /// </summary>
    /// <param name="parameter"> Параметр для команды. </param>
    protected abstract void Execute(T parameter);
}