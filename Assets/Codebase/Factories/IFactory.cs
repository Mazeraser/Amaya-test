using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
    public interface IFactory<T,Y>
    {
        T Create(Y property);
    }
}
    
