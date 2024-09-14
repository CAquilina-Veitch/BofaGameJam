using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Scripts.Extensions
{
    public static class UniRXExtensions 
    {
        public static IDisposable AssignTo(this IDisposable disposable, SerialDisposable serialDisposable)
        {
            serialDisposable.Disposable = disposable;
            return disposable;
        }
        public static IDisposable Subscribe(this IObservable<long> observable, Action method) => observable.Subscribe(_ => method());

    }
}
