using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public interface IState
    {
        IState RunState(SiteInfoContext context);
    }
}
