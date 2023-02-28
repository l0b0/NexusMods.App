﻿using Microsoft.Extensions.DependencyInjection;
using NexusMods.App.UI.ViewModels;

namespace NexusMods.UI.Tests;

public class AUiTest
{
    private readonly IServiceProvider _provider;

    public AUiTest(IServiceProvider provider)
    {
        _provider = provider;
        
        // Do this to trigger the AvaloniaApp constructor/initialization
        provider.GetRequiredService<AvaloniaApp>();
    }

    protected VMWrapper<T> GetActivatedViewModel<T>()
    where T : AViewModel
    {
        var vm = _provider.GetRequiredService<T>();
        return new VMWrapper<T>(vm);
    }

    public class VMWrapper<T> : IDisposable where T : AViewModel
    {
        private readonly IDisposable _disposable;
        public T VM { get; }
        public VMWrapper(T vm)
        {
            VM = vm;
            _disposable = vm.Activator.Activate();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
        
        public void Deconstruct(out T vm)
        {
            vm = VM;
        }
    }
}