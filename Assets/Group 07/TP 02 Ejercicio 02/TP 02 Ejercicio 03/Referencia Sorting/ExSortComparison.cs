using System;

public class ExSortComparison<T>
{

    public void Sort(Comparison<T> comparison)
    {
        //Chequear que la lista no este vacia
        InternalSort((x, y) => comparison(x, y));
    }

    //Func<T,T,int>
    //int FuncName (T var1, T var2)

    //Func<T, int>
    //int FuncName(T var)

    //Func<int>
    //int FuncName()
    void InternalSort(Func<T, T, int> compareFunc)
    {

    }
}
