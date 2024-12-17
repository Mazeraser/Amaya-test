using System;

namespace Codebase.Tweens
{
    public interface ITween
    {
        void Do(float value, float duration, Action onComplete);
    }
}
    
