using System;
using System.Collections.Generic;
using System.Text;

namespace ProdeDBFirst.Negocio.Base
{
    public interface IBaseBusinessBis<TRepo>: IDisposable where TRepo: class
    {
        TRepo Repository { get; set; }
    }
}
