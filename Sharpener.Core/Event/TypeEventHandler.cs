using System;

namespace Sharpener.Core.Event
{
    [Serializable]
    public delegate void GenericEventHandler<in TSender, in TEventArgs>(TSender sender, TEventArgs e) where TEventArgs : EventArgs;
}