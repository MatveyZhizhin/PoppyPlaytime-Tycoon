using System;

namespace Assets.Scripts.UI
{
    public interface ITextUser
    {
        public event Action<int> Changed;
    }
}
